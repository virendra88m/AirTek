using AirTek.Models;
namespace AirTek.Ops
{
    public class FlightScheduleOps
    {
        /// <summary>
        /// Load flight schdules with static source and destinations
        /// </summary>
        /// <param name="noOfDays"></param>
        /// <returns>List<FlightSchedule></returns>
        public static List<FlightSchedule> CreateFlightSchedule(int noOfDays)
        {
            List<FlightSchedule> flightSchedules = new();

            List<Airport> SourceAirports = new()
            {
                new Airport() { Code = "YUL", Name = "Montreal" }
            };

            List<Airport> DestinationAirports = new()
            {
                new Airport() { Code = "YYZ", Name = "Toronto" },
                new Airport() { Code = "YYC", Name = "Calgary" },
                new Airport() { Code = "YVR", Name = "Vancouver" }
            };

            int flightCounter = 1;

            for (int day = 1; day <= noOfDays; day++)
            {
                foreach (Airport sourceAirport in SourceAirports)
                {
                    foreach (Airport destAirport in DestinationAirports)
                    {
                        FlightSchedule flightSchedule = new()
                        {
                            FlightNo = flightCounter,
                            Day = day,
                            SourceLocation = sourceAirport.Code,
                            DestinationLocation = destAirport.Code,
                        };

                        flightSchedules.Add(flightSchedule);
                        flightCounter++;
                    }
                }
            }

            return flightSchedules;
        }
    }
}