using AirTek.Models;
using AirTek.Ops;

//USER STORY #1

Console.WriteLine("Flight schedule:");
//Load flight schedules with static source and destinations
List<FlightSchedule> flightSchedules = FlightScheduleOps.CreateFlightSchedule(2);
foreach (FlightSchedule schedule in flightSchedules)
{
    Console.WriteLine($"Flight:{schedule.FlightNo}, departure: {schedule.SourceLocation}, arrival: {schedule.DestinationLocation}, day:{schedule.Day}");
}

Console.WriteLine("========================================================================================================");

//USER STORY #2

//Read json file and load orders
var orders = OrderOps.LoadOrders();
List<FlightItineraries> flightItineraries = FlightItinerariesOps.CreateFlightItineraries(orders, flightSchedules);

Console.WriteLine("Flight itineraries:");

foreach (FlightItineraries flightItinerary in flightItineraries)
{
    if (flightItinerary.FlightSchedule != null)
    {
        Console.WriteLine($"order: {flightItinerary.OrderNo}, flightNumber: {flightItinerary.FlightSchedule.FlightNo}, departure: {flightItinerary.FlightSchedule.SourceLocation}, arrival: {flightItinerary.FlightSchedule.DestinationLocation}, day:{flightItinerary.FlightSchedule.Day}");
    }
    else {
        Console.WriteLine($"order: {flightItinerary.OrderNo}, flightNumber: not scheduled");
    }    
}


Console.ReadLine();