using FlightReservationSystem.Models;

namespace FlightReservationSystem.Services
{
  public class FlightReservationService
  {

    private readonly List<Flight> _flightList = new List<Flight>(){new Flight("B106","United Kingdom",30)};

    public IEnumerable<Flight> GetAllFlights()
    {
      return _flightList;
    }

    public Flight GetFlight(String flightNumber)
    {
      return _flightList.Where(f => f.FlightNumber == flightNumber).FirstOrDefault();
    }

    public void AddFlight(Flight flight)
    {
      _flightList.Add(flight);

    }

    public BookingStatus BookFlight(string flightNumber, Passenger passenger)
    {
      if (_flightList.Any(f => f.FlightNumber == flightNumber))
      {
        Flight f = _flightList.Where(f => f.FlightNumber == flightNumber).Select(f=> f).FirstOrDefault();
        bool status = f.BookSeat(passenger);
        if (status)
          return BookingStatus.BookedOnFlight;
        else return BookingStatus.AddedToWaitlist;



      }
      else return BookingStatus.NotBooked;

    }
  }
}