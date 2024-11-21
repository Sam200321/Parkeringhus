using System;  //ParkingHouse.cs
using System.Collections.Generic;

public class ParkingHouse
{
    public List<ParkingSpot> ParkingSpots { get; set; }

    public ParkingHouse(int totalSpots)
    {
        ParkingSpots = new List<ParkingSpot>();
        for (int i = 1; i <= totalSpots; i++)
        {
            ParkingSpots.Add(new ParkingSpot(i));
        }
    }

    public bool AssignSpot()
    {
        foreach (var spot in ParkingSpots)
        {
            if (!spot.IsOccupied)
            {
                spot.IsOccupied = true;
                spot.OccupiedTime = DateTime.Now;
                Console.WriteLine($"Parkeringsplats {spot.SpotNumber} är nu upptagen.");
                return true;
            }
        }
        Console.WriteLine("Inga lediga parkeringsplatser.");
        return false;
    }



    public void EndParking(int spotNumber)
    {
        var spot = ParkingSpots.Find(s => s.SpotNumber == spotNumber);
        if (spot != null && spot.IsOccupied)
        {
            spot.IsOccupied = false;
            if (spot.OccupiedTime.HasValue)
            {
                TimeSpan parkedDuration = DateTime.Now - spot.OccupiedTime.Value;
                Console.WriteLine($"Parkeringen är klar för plats {spot.SpotNumber}. Tidsparkering: {parkedDuration.TotalMinutes} minuter.");
                spot.OccupiedTime = null;
            }
        }
        else
        {
            Console.WriteLine("Parkeringsplatsen är inte upptagen.");
        }
    }
}
