namespace LinqProblems.Problems3
{
    public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string Type { get; set; } // "Single", "Double", "Suite"
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public bool HasSeaView { get; set; }
    public bool HasBalcony { get; set; }
}

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public DateTime MemberSince { get; set; }
}

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string Status { get; set; } // "Confirmed", "Cancelled", "Completed"
    public decimal TotalPrice { get; set; }
}

public class Payment
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } // "Credit Card", "Cash", "Online"
    public bool IsPaid { get; set; }
}



        public class HotelMangaer
    {
        
            public static void Ececute()
                {
                     var rooms = new List<Room>
        {
            new Room { Id = 1, RoomNumber = "101", Type = "Single", PricePerNight = 100, Capacity = 1, HasSeaView = false, HasBalcony = false },
            new Room { Id = 2, RoomNumber = "102", Type = "Double", PricePerNight = 150, Capacity = 2, HasSeaView = false, HasBalcony = true },
            new Room { Id = 3, RoomNumber = "103", Type = "Double", PricePerNight = 180, Capacity = 2, HasSeaView = true, HasBalcony = true },
            new Room { Id = 4, RoomNumber = "201", Type = "Suite", PricePerNight = 300, Capacity = 4, HasSeaView = true, HasBalcony = true },
            new Room { Id = 5, RoomNumber = "202", Type = "Single", PricePerNight = 120, Capacity = 1, HasSeaView = true, HasBalcony = false }
        };

        var guests = new List<Guest>
        {
            new Guest { Id = 1, Name = "Ali Rezaei", Email = "ali@email.com", Phone = "09123456789", 
                       Country = "Iran", MemberSince = DateTime.Now.AddYears(-2) },
            new Guest { Id = 2, Name = "Sara Mohammadi", Email = "sara@email.com", Phone = "09129876543", 
                       Country = "Iran", MemberSince = DateTime.Now.AddMonths(-6) },
            new Guest { Id = 3, Name = "John Smith", Email = "john@email.com", Phone = "+441234567890", 
                       Country = "UK", MemberSince = DateTime.Now.AddYears(-1) },
            new Guest { Id = 4, Name = "Maria Garcia", Email = "maria@email.com", Phone = "+34123456789", 
                       Country = "Spain", MemberSince = DateTime.Now.AddMonths(-3) },
            new Guest { Id = 5, Name = "Alex Chen", Email = "alex@email.com", Phone = "+861234567890", 
                       Country = "China", MemberSince = DateTime.Now.AddYears(-3) }
        };

        var reservations = new List<Reservation>
        {
            new Reservation { Id = 1, RoomId = 1, GuestId = 1, CheckInDate = DateTime.Now.AddDays(-10), 
                            CheckOutDate = DateTime.Now.AddDays(-7), NumberOfGuests = 1, Status = "Completed", TotalPrice = 300 },
            new Reservation { Id = 2, RoomId = 3, GuestId = 2, CheckInDate = DateTime.Now.AddDays(-5), 
                            CheckOutDate = DateTime.Now.AddDays(-2), NumberOfGuests = 2, Status = "Completed", TotalPrice = 540 },
            new Reservation { Id = 3, RoomId = 4, GuestId = 3, CheckInDate = DateTime.Now.AddDays(-3), 
                            CheckOutDate = DateTime.Now.AddDays(2), NumberOfGuests = 3, Status = "Confirmed", TotalPrice = 1500 },
            new Reservation { Id = 4, RoomId = 2, GuestId = 1, CheckInDate = DateTime.Now.AddDays(-1), 
                            CheckOutDate = DateTime.Now.AddDays(3), NumberOfGuests = 2, Status = "Confirmed", TotalPrice = 600 },
            new Reservation { Id = 5, RoomId = 5, GuestId = 4, CheckInDate = DateTime.Now.AddDays(1), 
                            CheckOutDate = DateTime.Now.AddDays(4), NumberOfGuests = 1, Status = "Confirmed", TotalPrice = 360 },
            new Reservation { Id = 6, RoomId = 3, GuestId = 5, CheckInDate = DateTime.Now.AddDays(5), 
                            CheckOutDate = DateTime.Now.AddDays(10), NumberOfGuests = 2, Status = "Confirmed", TotalPrice = 900 },
            new Reservation { Id = 7, RoomId = 1, GuestId = 2, CheckInDate = DateTime.Now.AddDays(-15), 
                            CheckOutDate = DateTime.Now.AddDays(-12), NumberOfGuests = 1, Status = "Cancelled", TotalPrice = 300 }
        };

        var payments = new List<Payment>
        {
            new Payment { Id = 1, ReservationId = 1, Amount = 300, PaymentDate = DateTime.Now.AddDays(-11), 
                         PaymentMethod = "Credit Card", IsPaid = true },
            new Payment { Id = 2, ReservationId = 2, Amount = 540, PaymentDate = DateTime.Now.AddDays(-6), 
                         PaymentMethod = "Online", IsPaid = true },
            new Payment { Id = 3, ReservationId = 3, Amount = 500, PaymentDate = DateTime.Now.AddDays(-4), 
                         PaymentMethod = "Credit Card", IsPaid = true },
            new Payment { Id = 4, ReservationId = 4, Amount = 600, PaymentDate = DateTime.Now.AddDays(-2), 
                         PaymentMethod = "Cash", IsPaid = true },
            new Payment { Id = 5, ReservationId = 5, Amount = 360, PaymentDate = DateTime.Now.AddDays(0), 
                         PaymentMethod = "Online", IsPaid = false }
        };

         DateTime checkDate = DateTime.Now.AddDays(2);
        var bookedRooms = reservations
            .Where(r => r.Status != "Cancelled" &&
                       r.CheckInDate <= checkDate &&
                       r.CheckOutDate > checkDate)
            .Select(r => r.RoomId)
            .Distinct()
            .ToList();

        var availableRooms = rooms
            .Where(r => !bookedRooms.Contains(r.Id))
            .Select(r => new
            {
                r.RoomNumber,
                r.Type,
                r.PricePerNight,
                Features = $"{(r.HasSeaView ? "Sea View " : "")}{(r.HasBalcony ? "Balcony" : "")}".Trim()
            })
            .OrderBy(r => r.PricePerNight)
            .ToList();

        Console.WriteLine($"=== Available Rooms on {checkDate:yyyy-MM-dd} ===");
        if (availableRooms.Any())
        {
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} ({room.Type}): ${room.PricePerNight}/night");
                Console.WriteLine($"  Features: {room.Features}");
            }
        }
        else
        {
            Console.WriteLine("No rooms available on this date.");
        }

         var stayAnalysis = reservations
            .Where(r => r.Status == "Completed")
            .Select(r => new
            {
                StayDuration = (r.CheckOutDate - r.CheckInDate).Days,
                r.NumberOfGuests,
                r.TotalPrice
            })
            .GroupBy(r => 1) // همه در یک گروه
            .Select(g => new
            {
                AverageStay = Math.Round(g.Average(r => r.StayDuration), 1),
                AverageGuests = Math.Round(g.Average(r => r.NumberOfGuests), 1),
                AveragePrice = Math.Round(g.Average(r => r.TotalPrice), 2),
                TotalReservations = g.Count()
            })
            .FirstOrDefault();

        Console.WriteLine("\n=== Stay Analysis ===");
        if (stayAnalysis != null)
        {
            Console.WriteLine($"Average Stay Duration: {stayAnalysis.AverageStay} days");
            Console.WriteLine($"Average Number of Guests: {stayAnalysis.AverageGuests}");
            Console.WriteLine($"Average Reservation Price: ${stayAnalysis.AveragePrice}");
            Console.WriteLine($"Total Completed Reservations: {stayAnalysis.TotalReservations}");
        }
        var loyalGuests = reservations
            .Where(r => r.Status != "Cancelled")
            .GroupBy(r => r.GuestId)
            .Select(g => new
            {
                GuestId = g.Key,
                ReservationCount = g.Count(),
                TotalNights = g.Sum(r => (r.CheckOutDate - r.CheckInDate).Days),
                TotalSpent = g.Sum(r => r.TotalPrice),
                FirstStay = g.Min(r => r.CheckInDate),
                LastStay = g.Max(r => r.CheckInDate)
            })
            .Where(g => g.ReservationCount > 1)
            .Join(guests,
                  stats => stats.GuestId,
                  guest => guest.Id,
                  (stats, guest) => new
                  {
                      guest.Name,
                      guest.Country,
                      guest.MemberSince,
                      stats.ReservationCount,
                      stats.TotalNights,
                      stats.TotalSpent,
                      stats.FirstStay,
                      stats.LastStay,
                      LoyaltyLevel = stats.ReservationCount switch
                      {
                          >= 5 => "Platinum",
                          >= 3 => "Gold",
                          _ => "Silver"
                      }
                  })
            .OrderByDescending(g => g.ReservationCount)
            .ToList();

        Console.WriteLine("\n=== Loyal Guests ===");
        foreach (var guest in loyalGuests)
        {
            Console.WriteLine($"{guest.Name} ({guest.Country}): {guest.LoyaltyLevel} Member");
            Console.WriteLine($"  Reservations: {guest.ReservationCount}, Total Nights: {guest.TotalNights}");
            Console.WriteLine($"  Total Spent: ${guest.TotalSpent}");
            Console.WriteLine($"  First Stay: {guest.FirstStay:yyyy-MM-dd}, Last Stay: {guest.LastStay:yyyy-MM-dd}");
        }

                }
    }
}