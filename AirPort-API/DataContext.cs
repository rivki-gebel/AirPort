using AirPort_API.Entities;

namespace AirPort_API
{
    public class DataContext
    {
        public List<AirPlane> airplaneList { get; set; }
        public List<Flight> flightsList { get; set; }
        public List<FlightTicket> TicketsList { get; set; }
        public List<Passanger> passangersList { get; set; }

        public DataContext()
        {
            airplaneList= new List<AirPlane> { new AirPlane {AirplaneId=1,Company="elal",IsProper=true,NumSeats=100 } ,
                                                  new AirPlane{AirplaneId=2,Company="ssf",IsProper=true,NumSeats=120} };

            flightsList = new List<Flight> { new Flight {FlightId=1,Destination="london",
            SourceLand="israel",AirplaneId=8,Cost=2000,TakeingOffTime=new DateTime(2023,4,2,12,30,0) } };

            TicketsList = new List<FlightTicket> {
                new FlightTicket {TicketId=122,FlightId=1,PassengerId=1 } };

            passangersList = new List<Passanger> { new Passanger {IdNum=32221,Name="jon a",Adress="new york" },
                                                                     new Passanger {IdNum=56879,Name="lea ss",Adress="israel bb" }};
        }
    }
}
