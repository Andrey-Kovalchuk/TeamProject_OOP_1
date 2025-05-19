using System.Runtime.InteropServices;

class Program
{
    public static void Main ()
    {
        Program program = new Program();
        program.CreateStructure(); 
    }
    public void CreateStructure ()
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
        road = new Road("Route 1", stops, transportVehicle);

        // Create ElectronicTicket
        ElectronicTicket ticket = new ElectronicTicket("TCK001", "Monthly Pass", 50.0);

        // Create ServiceCard
        ServiceCard serviceCard = new ServiceCard("SC001");
    }
}