using AirTek.Models;
namespace AirTek.Ops
{
    public class FlightItinerariesOps
    {
        private const int MaxOrdersPerFlight = 20;
        /// <summary>
        /// Load FlightItineraries from orders data and flightSchedule
        /// </summary>
        /// <param name="ordersData"></param>
        /// <param name="flightSchedules"></param>
        /// <returns>List<FlightItineraries></returns>
        public static List<FlightItineraries> CreateFlightItineraries(Dictionary<string, Order> ordersData, List<FlightSchedule> flightSchedules)
        {
			
            List<FlightItineraries> flightItineraries = new();
            var groupOrders = ordersData.GroupBy(m => m.Value.Destination).ToList();
            foreach (var group in groupOrders)
            {
                var groupFlightSchedules = flightSchedules.Where(m => m.DestinationLocation.Equals(group.Key)).ToList();
                int processedOrdersCounter = 0;
                int flightScheduleCounter = 0;
                foreach (var order in group)
                {
                    if (processedOrdersCounter == MaxOrdersPerFlight)
                    {
                        processedOrdersCounter = 0;
                    }

                    if (groupFlightSchedules.Count > 0 && flightScheduleCounter < groupFlightSchedules.Count)
                    {
                        flightItineraries.Add(new FlightItineraries()
                        {
                            OrderNo = order.Key,
                            FlightSchedule = groupFlightSchedules[flightScheduleCounter]
                        });

                        processedOrdersCounter++;
                        if (processedOrdersCounter == MaxOrdersPerFlight)
                        {
                            flightScheduleCounter++;
                        }
                    }
                    else
                    {
                        flightItineraries.Add(new FlightItineraries()
                        {
                            OrderNo = order.Key,
                            FlightSchedule = null
                        });
                    }
                }
            }

            return flightItineraries;
        }
    }
}