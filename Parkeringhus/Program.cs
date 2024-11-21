using System;

namespace Parkeringhus
{
    class Program
    {
        static void Main()
        {
            ParkingHouse parkingHouse = new ParkingHouse(25);
            ParkingManager manager = new ParkingManager(parkingHouse);
            ParkingAttendant attendant = new ParkingAttendant(parkingHouse);

            while (true)
            {
                Console.Clear();
                DisplayMenu();
                string? choice = Console.ReadLine(); // Gör string nullable

                switch (choice)
                {
                    case "1":
                        ParkVehicle(manager, "Bil");
                        break;
                    case "2":
                        ParkVehicle(manager, "MC");
                        break;
                    case "3":
                        ParkVehicle(manager, "Buss");
                        break;
                    case "4":
                        manager.ShowParkingHouseStatus();
                        break;
                    case "5":
                        Console.WriteLine("Ange parkeringsplatsnummer för att avsluta parkering:");
                        if (int.TryParse(Console.ReadLine(), out int spotNumber))
                        {
                            manager.EndParking(spotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt nummer. Försök igen.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Ange parkeringsplatsnummer för att kontrollera böter:");
                        if (int.TryParse(Console.ReadLine(), out int spotForFine))
                        {
                            attendant.CheckSpotForFine(spotForFine);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt nummer. Försök igen.");
                        }
                        break;
                    case "7":
                        attendant.CheckAllSpotsForFines();
                        break;
                    case "8":
                        Console.WriteLine("Avslutar programmet...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }

                Console.WriteLine("\nTryck på en tangent för att återgå till menyn...");
                Console.ReadKey();
            }
        }

        static void ParkVehicle(ParkingManager manager, string vehicleType)
        {
            Console.WriteLine($"Ange registreringsnummer för {vehicleType}:");
            string? licensePlate = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                Console.WriteLine("Registreringsnummer får inte vara tomt. Försök igen.");
                return;
            }

            string color = ChooseVehicleColor(); // Väljer färg

            Vehicle? vehicle = vehicleType switch
            {
                "Bil" => new Car(licensePlate, color),
                "MC" => new Motorcycle(licensePlate, color),
                "Buss" => new Bus(licensePlate, color),
                _ => null
            };

            if (vehicle != null)
            {
                vehicle.DisplayInfo();
                bool assigned = manager.AssignSpotToVehicle(vehicle);
                if (assigned)
                {
                    Console.WriteLine($"Fordonet {vehicle.LicensePlate} ({vehicle.Color}) har tilldelats parkeringsplats {vehicle.ParkingSpotNumber}.\n");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt fordonstyp.");
            }
        }

        public static string ChooseVehicleColor()
        {
            Console.WriteLine("Välj färg för fordonet:");
            Console.WriteLine("1. Röd");
            Console.WriteLine("2. Blå");
            Console.WriteLine("3. Grön");
            Console.WriteLine("4. Vit");
            Console.WriteLine("5. Svart");
            Console.Write("Skriv ditt val (1-5): ");

            string? choice = Console.ReadLine();
            return choice switch
            {
                "1" => "Röd",
                "2" => "Blå",
                "3" => "Grön",
                "4" => "Vit",
                "5" => "Svart",
                _ => "Vit" // Standardfärg
            };
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Meny färg
            Console.WriteLine("===============================================");
            Console.WriteLine("           VÄLJ ETT ALTERNATIV              ");
            Console.WriteLine("===============================================");
            Console.WriteLine("1. Parkera Bil");
            Console.WriteLine("2. Parkera MC");
            Console.WriteLine("3. Parkera Buss");
            Console.WriteLine("4. Visa parkeringshusstatus");
            Console.WriteLine("5. Avsluta parkering");
            Console.WriteLine("6. Kontrollera böter för en parkeringsplats");
            Console.WriteLine("7. Kontrollera alla parkeringsplatser för böter");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine("===============================================");
            Console.Write("Välj alternativ: ");
            Console.ResetColor();
        }
    }
}

