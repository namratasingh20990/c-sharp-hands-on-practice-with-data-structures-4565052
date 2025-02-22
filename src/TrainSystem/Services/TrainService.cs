using System.Collections.Generic;
using System.Linq;
using TrainSystem.Models;

namespace TrainSystem.Services
{
  public class TrainService
  {


    private readonly List<Track> trackList = new List<Track> { new Track(1), new Track(2) };


    private readonly Queue<Train> trainQueue = new Queue<Train>();

    public IEnumerable<Track> GetAllTracks()
    {
      return trackList;
    }

    public IEnumerable<Train> GetAllTrains()
    {

      return trainQueue;
    }

    public Train GetNextTrain()
    {
      if (trainQueue.Count > 0)
        return trainQueue.Peek();
      else return null;
    }

    public void ArriveTrain(Train train)
    {
      trainQueue.Enqueue(train);
    }

    public void AssignNextTrainToTrack()
    {
      // var availableTracks = trackList.Where(t => t.currentTrain == null);
      if (trackList.Any(t => t.currentTrain == null))
      {
        var availableTrack = trackList.Where(t => t.currentTrain == null).FirstOrDefault();
        if (availableTrack is not null)
        {
          Train nextTrain = GetNextTrain();
          // Track track = availableTracks.ElementAt(0);
          availableTrack.currentTrain = nextTrain;
          if (trainQueue.Count > 0)
            trainQueue.Dequeue();

        }


      }


    }

    public void DepartTrain(Track track)
    {
      track.currentTrain = null;



    }


    // private IEnumerable<Track> CreateTrackList()
    // {
    //   Track track1 = new Track(1);
    //   Track track2 = new Track(2);
    //   trackList.Add(track1);
    //   trackList.Add(track2);
    //   return trackList;
    // }
  }
}