using System.Text;

public class Program
{
    TransportVehicle transportVehicle;
    List<Stop> stops;
    int actualPassengers; 
  /// <summary>
    /// Точка входу в програму. Ініціалізує кодування консолі та запускає створення структури.
    /// </summary>
    public static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        Program program = new Program();
        program.CreateStructure();
    }

    /// <summary>
    /// Створює основні об'єкти системи: зупинки, лічильник пасажирів, валідатор, GPS-монітор, транспортний засіб та маршрут.
    /// </summary>
    public void CreateStructure()
    {
        // Create Stop objects
        Stop stop1 = new Stop("Central Station", "Downtown");
        Stop stop2 = new Stop("North Square", "North District");
        List<Stop> stops = new List<Stop> { stop1, stop2 };

        // Create PassengerCounter
        PassengerCounter passengerCounter = new PassengerCounter("PC001", 25);

        // Create PaymentValidator
        PaymentValidator paymentValidator = new PaymentValidator("PV001", true);

        // Create GPSMonitor
        GPSMonitor gpsMonitor = new GPSMonitor("GPS001", true);

        // Create TransportVehicle (will be updated in Road creation)
        TransportVehicle tempVehicle = null;

        // Create Road
        Road road = new Road("Route 1", stops, tempVehicle);

        // Create TransportVehicle with all dependencies
        TransportVehicle transportVehicle = new TransportVehicle(
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

    /// <summary>
    /// Запускає основний цикл роботи транспорту: початок дня, обробка зупинок, контроль лінії та завершення дня.
    /// </summary>
    public void StartWork()
    {

        StartOfDay();

        for (int i = 0; i < stops.Count; i++)

        {

            Console.WriteLine("Автобус прибув на зупинку " + stops[i].Name);

            RideInRace();

            if (stops.Count != i + 1)
                Console.WriteLine("Транспорт виїхав на наступну зупинку");

        }

        LineControl();

        EndOfDay();

    }

    /// <summary>
    /// Виконує процедуру початку робочого дня: перевірка службової картки, активація GPS та валідатора.
    /// </summary>
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

    /// <summary>
    /// Виводить список зупинок маршруту.
    /// </summary>
    public void TakeStop()
    {

        for (int i = 0; i < stops.Count; i++)

        {

            Console.WriteLine(stops[i].Location + ") " + stops[i].Name);

        }

    }

    /// <summary>
    /// Обробляє посадку та висадку пасажирів на зупинці, а також оплату проїзду.
    /// </summary>
    public void RideInRace()
    {

        int choice = 0;

        ElectronicTicket ticket = new ElectronicTicket("12", "Passenger Ticket", 0, true);

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

    /// <summary>
    /// Обробляє оплату проїзду електронним квитком, включаючи перевірку валідності та пільгових поїздок.
    /// </summary>
    public void ProcessPayment()
    {

        Console.WriteLine("скільки грошей в білеті");

        float ballance = float.Parse(Console.ReadLine());

        Console.WriteLine("він валідний? (1 - Так, 0 - Ні)");

        bool valid = int.Parse(Console.ReadLine()) == 1;

        ElectronicTicket ticket = new ElectronicTicket("TCK001", "Passenger Ticket", ballance, valid); // додати валідність квитка як поле 

        bool isConcessionary = false;

        Console.WriteLine("Пасажир підносить квиток до валідатора.");

        Console.WriteLine("Введіть ID квитка:");

        string ticketId = Console.ReadLine();

        ticket.Id = ticketId;

        Console.WriteLine("Це пільговий квиток? (1 - Так, 0 - Ні)");

        isConcessionary = int.Parse(Console.ReadLine()) == 1;

        if (ticket.Valid == true)

        {

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

        }

        else

        {

            Console.WriteLine("Звернуться до кондуктора за відновлення валідності?");

            Console.WriteLine("він валідний? (1 - Так, 0 - Ні)");

            valid = int.Parse(Console.ReadLine()) == 1;

            if (valid == true)

            {

                Console.WriteLine("кондуктор відновлює валідність квитка");

                ticket.Valid = true;

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

    /// <summary>
    /// Виконує контроль лінії: перевірка службової картки, друк звіту та фіксація порушень.
    /// </summary>
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

    /// <summary>
    /// Завершує робочий день: перевірка службової картки, генерація підсумкового звіту та вимкнення пристроїв.
    /// </summary>
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

            Console.WriteLine($"Без оплати проїхало: {actualPassengers - transportVehicle.PassengerCounter.Count}" + "пасажирів сума витрат на цьому " + (actualPassengers - transportVehicle.PassengerCounter.Count) * 15 + "гривень");

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