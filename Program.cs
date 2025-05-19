using Project_v2;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
class Program
{
    TransportVehicle transportVehicle;
    List<Stop> stops;
    
    public static void Main ()
    {
        Program program = new Program();    
        program.CreateStructure(); 
    }
    public void CreateStructure ()
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
        PaymentValidator paymentValidator = new PaymentValidator("PV001", true, 0);

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
        road = new Road("Route 1", stops, transportVehicle);

        // Create ElectronicTicket
        ElectronicTicket ticket = new ElectronicTicket("TCK001", "Monthly Pass", 50.0);

        // Create ServiceCard
        ServiceCard serviceCard = new ServiceCard("SC001");
        StartWork();
    }

    public void StartWork()
    {

        StartOfDay();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("автобус прибув на зупинку " + stops[i].Name);
            RideInRace();
            Console.WriteLine("транспорт виїхав на наступну зупинку");
        }
       
       
        
    }
    public void RideInRace ()
    {
        int choice = 0;
        ElectronicTicket ticket = new ElectronicTicket("12", "passanger ticket", 0);
        transportVehicle.OpenTheDoor(); 
        Console.WriteLine("введіть кількість пасажирів які прийшли");
        int passangerIN = int.Parse(Console.ReadLine());
        Console.WriteLine("введіть кількість пасажирів які пішли");
        int passangerOUT = int.Parse(Console.ReadLine());
        for (int i = 0; i < passangerIN; i++)
        {
            transportVehicle.PassengerCounter.AddToCounter();
            Console.WriteLine("У цього пасажира грощі/квиток");
            do
            {
                choice = int.Parse(Console.ReadLine());

            } while (choice != 1 || choice != 2);

            if (choice == 1)
            {
                Console.WriteLine("введіть кількість грошей які є у пасажира (15 грн проезд)");
                ticket.Balance = int.Parse(Console.ReadLine() ); 
            }

            if (ticket.Balance > 15)
            {
                Console.WriteLine("дякую що обиражте нас");
                transportVehicle.PaymentValidator.AddPaiment();
            }
            else
            {
                Console.WriteLine("в проїзді відмовленно");
            }
        }
    }
    public void StartOfDay()
    {
        int check = 0;
        bool checking = false;
        do
        {
            Console.WriteLine("введіть код від службову картку (9113) ");
            check = int.Parse(Console.ReadLine());
            if (!transportVehicle.PaymentValidator.CheckValidateCart(check))
            {
                Console.WriteLine("картка не дійсна, система не активна");
            }
        } while (!transportVehicle.PaymentValidator.CheckValidateCart(check));
        Console.WriteLine("Активація GPS ");
        transportVehicle.GPSMonitor.Status = true;
        Console.WriteLine("обробка маршруту, очикування данних GPS");
        Thread.Sleep(1300);
        Console.WriteLine("обробка маршруту, завершено. Ось маршрут: ");
        TakeStop();
        Console.WriteLine("Активація: ");
        transportVehicle.GPSMonitor.Status = true;
    }
    public void TakeStop()
    {
        for (int i = 0; i < stops.Count; i++)
        {
            Console.WriteLine(stops[i].Location + ") " + stops[i].Name);
        }

    }
}