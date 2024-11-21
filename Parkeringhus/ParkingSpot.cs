using Parkeringhus;

public class ParkingSpot
{
    public int SpotNumber { get; set; }
    public bool IsOccupied { get; set; }
    public DateTime? OccupiedTime { get; set; }
    public Vehicle OccupyingVehicle { get; set; } // För att hålla reda på vilket fordon som är parkerat på denna plats

    public ParkingSpot(int spotNumber)
    {
        SpotNumber = spotNumber;
        IsOccupied = false;
        OccupiedTime = null;
        OccupyingVehicle = null;
    }

    // Metod för att parkera ett fordon på denna plats
    public void ParkVehicle(Vehicle vehicle)
    {
        IsOccupied = true;
        OccupyingVehicle = vehicle;
        OccupiedTime = DateTime.Now;
    }

    // Metod för att frigöra parkeringsplatsen
    public void VacateSpot()
    {
        IsOccupied = false;
        OccupyingVehicle = null;
        OccupiedTime = null;
    }
}

