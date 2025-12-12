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
}