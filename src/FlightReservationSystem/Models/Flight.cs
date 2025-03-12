using System;
using System.Collections.Generic;

namespace FlightReservationSystem.Models
{

  public class Flight
  {
    public string FlightNumber { get; }
    public string Destination { get; }
    public int TotalSeats { get; }
    private List<Passenger> _passengers;
    private Queue<Passenger> _waitlist;

    public Flight(string flightNumber, string destination, int totalSeats)
    {
      FlightNumber = flightNumber;
      Destination = destination;
      TotalSeats = totalSeats;
      _passengers = new List<Passenger>();
      _waitlist = new Queue<Passenger>();
    }

    public bool BookSeat(Passenger passenger)
    {
      if (TotalSeats > _passengers.Count())
      {
        _passengers.Add(passenger);
        return true;
      }
      AddToWaitlist(passenger);
      return false;
    }

    public void AddToWaitlist(Passenger passenger)
    {
      _waitlist.Enqueue(passenger);

    }

    public List<Passenger> Passengers => _passengers;

    public Queue<Passenger> Waitlist => _waitlist;
  }
}