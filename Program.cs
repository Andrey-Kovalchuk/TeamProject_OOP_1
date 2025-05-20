public class Program
{
    TransportVehicle transportVehicle;
    List<Stop> stops;
    int actualPassengers; 
    public static void Main()
    {
        Program program = new Program();
        program.CreateStructure();

    }

    public void CreateStructure()
    {
        // Create Stop objects
        Stop stop1 = new Stop("Central Station", "1");
        Stop stop2 = new Stop("North Square", "2");
        Stop stop3 = new Stop("Akinava", "3");
        Stop stop4 = new Stop("Olimpiyska", "4");
        Stop stop5 = new Stop("ParodaysWay", "5");
        stops = new List<Stop> { stop1, stop2, stop3, stop4, stop5 };

        // Create PassengerCounter
        PassengerCounter passengerCounter = new PassengerCounter("PC001", 0);

        // Create PaymentValidator
        PaymentValidator paymentValidator = new PaymentValidator("PV001", true, 0, 0, 0);

        // Create GPSMonitor
        GPSMonitor gpsMonitor = new GPSMonitor("GPS001", false, "1");

        // Create TransportVehicle (will be updated in Road creation)
        TransportVehicle tempVehicle = null;

        // Create Road
        Road road = new Road("Route 1", stops, tempVehicle);

        // Create TransportVehicle with all dependencies
        transportVehicle = new TransportVehicle(
            1001,
            "Bus",
            "0101",
            passengerCounter,
            paymentValidator,
            gpsMonitor,
            road
        );

        // Update Road with the actual TransportVehicle
        road.TransportVehicle = transportVehicle;

        StartWork();
    }

    public void StartWork()
    {
        StartOfDay();
        for (int i = 0; i < stops.Count; i++)
        {
            Console.WriteLine("Автобус прибув на зупинку " + stops[i].Name);
            RideInRace();
            if (stops.Count != i+1)
            Console.WriteLine("Транспорт виїхав на наступну зупинку");
        }
        LineControl();
        EndOfDay();
    }

    public void StartOfDay()
    {
        int check = 0;
        do
        {
            Console.WriteLine("Введіть код службового картки (9113): ");
            check = int.Parse(Console.ReadLine());
            if (!transportVehicle.PaymentValidator.CheckValidateCart(check))
            {
                Console.WriteLine("Картка недійсна, система не активна.");
            }
        } while (!transportVehicle.PaymentValidator.CheckValidateCart(check));

        Console.WriteLine("Активація GPS...");
        transportVehicle.GPSMonitor.Status = true;
        Console.WriteLine("Обробка маршруту, очікування даних GPS...");
        Thread.Sleep(1300);
        Console.WriteLine("Обробка маршруту завершена. Ось маршрут:");
        TakeStop();
        Console.WriteLine("Система активована.");
        transportVehicle.PaymentValidator.Status = true;
    }

    public void TakeStop()
    {
        for (int i = 0; i < stops.Count; i++)
        {
            Console.WriteLine(stops[i].Location + ") " + stops[i].Name);
        }
    }

    public void RideInRace()
    {
        int choice = 0;
        ElectronicTicket ticket = new ElectronicTicket("12", "Passenger Ticket", 0);
        transportVehicle.OpenTheDoor();
        Console.WriteLine("Введіть кількість пасажирів, які зайшли:");
        int passengersIn = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть кількість пасажирів, які вийшли:");
        int passengersOut = int.Parse(Console.ReadLine());

        for (int i = 0; i < passengersIn; i++)
        {
            transportVehicle.PassengerCounter.AddToCounter();
            Console.WriteLine("У цього пасажира є гроші/квиток? (1 - Гроші, 2 - Квиток)");
            do
            {
                choice = int.Parse(Console.ReadLine());
            } while (choice != 1 && choice != 2);
            switch (choice) 
            {
                case 1:
                    Console.WriteLine("Введіть кількість грошей у пасажира (15 грн за проїзд):");
                    ticket.Balance = double.Parse(Console.ReadLine());
                    if (ticket.Balance >= 15.0)
                    {
                        Console.WriteLine("Дякуємо, що обираєте нас!");
                        transportVehicle.PaymentValidator.AddPayment();
                        ticket.Balance -= 15.0;
                    }
                    else
                    {
                        Console.WriteLine("В проїзді відмовлено.");
                    }
                    break;
                case 2:
                    ProcessPayment(); // метод для перевірки білету
                    break; 
                    
            }          
        }

        for (int i = 0; i < passengersOut; i++)
        {
            transportVehicle.PassengerCounter.RemoveFromCounter();
        }

        transportVehicle.CloseTheDoor();
    }

    public void ProcessPayment()
    {
        Console.WriteLine("скільки грошей в білеті");
        float ballance= float.Parse(Console.ReadLine());
        ElectronicTicket ticket = new ElectronicTicket("TCK001", "Passenger Ticket", ballance); // додати валідність квитка як поле 
        bool isConcessionary = false;
        Console.WriteLine("Пасажир підносить квиток до валідатора.");
        Console.WriteLine("Введіть ID квитка:");
        string ticketId = Console.ReadLine();
        ticket.Id = ticketId;
        Console.WriteLine("Це пільговий квиток? (1 - Так, 0 - Ні)");
        isConcessionary = int.Parse(Console.ReadLine()) == 1;

        if (isConcessionary)
        {
            Console.WriteLine("Пільговий квиток розпізнано. Реєструємо пільговий проїзд.");
            transportVehicle.PaymentValidator.RegisterConcessionaryRide();
        }
        else
        {

            if (transportVehicle.PaymentValidator.ValidateTicket(ticket))
            {
                if (ticket.Balance >= 15.0)
                {
                    Console.WriteLine("Оплата успішна. Дякуємо, що обираєте нас!");
                    transportVehicle.PaymentValidator.AddPayment();
                    ticket.Balance -= 15.0;
                }
                else
                {
                    Console.WriteLine("Недостатньо коштів на квитку.");
                }
            }
            else
            {
                Console.WriteLine("Квиток недійсний або прострочений.");
            }
        }

        Console.WriteLine("Чи є технічна помилка валідатора? (1 - Так, 0 - Ні)");
        int validatorError = int.Parse(Console.ReadLine());
        if (validatorError == 1)
        {
            Console.WriteLine("Кондуктор вручну реєструє оплату.");
            transportVehicle.PaymentValidator.AddPayment();
        }
    }

    public void LineControl()
    {
        ServiceCard serviceCard = new ServiceCard("SC001");
        Console.WriteLine("Контролер підносить службову картку до валідатора.");
        Console.WriteLine("Введіть код службового картки (9113):");
        int cardCode = int.Parse(Console.ReadLine());
        if (transportVehicle.PaymentValidator.CheckValidateCart(cardCode))
        {
            Console.WriteLine("Друк звіту? (1 - Так, 0 - Ні)");
            int printReport = int.Parse(Console.ReadLine());
           if (printReport == 1)
           {
            Console.WriteLine("Звіт надруковано.");
            Console.WriteLine("Звіт контролера:");
            Console.WriteLine($"Кількість пасажирів: {transportVehicle.PassengerCounter.Count}");
            Console.WriteLine($"Оплачені поїздки: {transportVehicle.PaymentValidator.TotalPayments}");
            Console.WriteLine($"Пільгові поїздки: {transportVehicle.PaymentValidator.ConcessionaryRides}");
            Console.WriteLine($"Виручка: {transportVehicle.PaymentValidator.TotalRevenue} грн");

            Console.WriteLine("Введіть фактичну кількість пасажирів у транспорті:");
             actualPassengers = int.Parse(Console.ReadLine());
             if (actualPassengers > transportVehicle.PassengerCounter.Count)
             {
                Console.WriteLine($"Виявлено {actualPassengers - transportVehicle.PassengerCounter.Count} пасажирів без оплати.");
                Console.WriteLine("Фіксуємо порушення для подальшого розгляду.");
             }

           }

        }
        else
        {
            Console.WriteLine("Службова картка недійсна.");
        }
    }

    public void EndOfDay()
    {
        ServiceCard serviceCard = new ServiceCard("SC001");
        Console.WriteLine("Кондуктор завершує зміну. Введіть код службового картки (9113):");
        int cardCode = int.Parse(Console.ReadLine());

        if (transportVehicle.PaymentValidator.CheckValidateCart(cardCode))
        {
            Console.WriteLine("Генерація підсумкового звіту:");
            Console.WriteLine($"Загальна кількість пасажирів: {transportVehicle.PassengerCounter.Count}");
            Console.WriteLine($"Оплачені поїздки: {transportVehicle.PaymentValidator.TotalPayments}");
            Console.WriteLine($"Пільгові поїздки: {transportVehicle.PaymentValidator.ConcessionaryRides}");
            Console.WriteLine($"Загальна виручка: {transportVehicle.PaymentValidator.TotalRevenue} грн");
            Console.WriteLine($"Без оплати проїхало: {actualPassengers - transportVehicle.PassengerCounter.Count}" + "пасажирів сума витрат на цьому " + (actualPassengers - transportVehicle.PassengerCounter.Count)*15 + "гривень");
            Console.WriteLine("Передача даних до центральної бази даних...");
            Thread.Sleep(1000);
            Console.WriteLine("Дані успішно передані.");

            transportVehicle.GPSMonitor.Status = false;
            transportVehicle.PaymentValidator.Status = false;
            Console.WriteLine("Валідатор і датчики вимкнено до наступної активації.");
        }
        else
        {
            Console.WriteLine("Службова картка недійсна. Зміну не завершено.");
        }
    }
}