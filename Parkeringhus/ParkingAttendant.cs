public class ParkingAttendant
{
    private ParkingHouse _parkingHouse;

    public ParkingAttendant(ParkingHouse parkingHouse)
    {
        _parkingHouse = parkingHouse;
    }

    // Kontrollera alla parkeringsplatser för böter
    public void CheckAllSpotsForFines()
    {
        foreach (var spot in _parkingHouse.ParkingSpots)
        {
            CheckSpotForFine(spot.SpotNumber);  // Kontrollera böter på varje plats
        }
    }

    // Kontrollera böter för en specifik parkeringsplats
    public void CheckSpotForFine(int spotNumber)
    {
        var spot = _parkingHouse.ParkingSpots.FirstOrDefault(s => s.SpotNumber == spotNumber);
        if (spot != null && spot.IsOccupied && spot.OccupiedTime.HasValue)
        {
            TimeSpan parkedDuration = DateTime.Now - spot.OccupiedTime.Value;
            if (parkedDuration.TotalMinutes > 120)  // Böter om parkeringsduration är längre än 2 timmar
            {
                Console.WriteLine($"Böter utfärdas på parkeringsplats {spotNumber}: {spot.OccupyingVehicle.LicensePlate} har varit parkerad i {parkedDuration.TotalMinutes} minuter.");
            }
            else
            {
                Console.WriteLine($"Parkeringsplats {spotNumber} är inte bötesbelagd: {spot.OccupyingVehicle.LicensePlate} har parkerat i {parkedDuration.TotalMinutes} minuter.");
            }
        }
        else
        {
            Console.WriteLine($"Parkeringsplats {spotNumber} är ledig eller har inget fordon.");
        }
    }
}

