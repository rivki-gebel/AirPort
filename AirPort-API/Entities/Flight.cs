namespace AirPort_API.Entities
{
    public class Flight
    {
        public List<int> PassengersId { get; set; }
        public int FlightId { get; set; }
        public string Destination { get; set;}
        public string SourceLand { get; set;}
        public int AirplaneId { get; set; }
        public double Cost { get; set; }
        public DateTime TakeingOffTime { get; set; }
        

        public Flight()
        {
            PassengersId = new List<int>();
        }

    }
}
