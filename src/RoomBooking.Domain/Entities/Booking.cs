namespace RoomBooking.Domain.Entities;

using RoomBooking.Domain.Statuses;

public class Booking
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime DateCheckIn { get; set; }
    public DateTime DateCheckOut { get; set; }

    public int Adults { get; set; }
    public int Children { get; set; }


    public int GuestId { get; set; } //FK
    public BookingStatusEnum Status { get; set; } = BookingStatusEnum.Draft;

    // Supply the complete payment history for this booking.
    // Refunded means fully refunded; only Paid transactions contribute to the balance.
    // A negative balance represents an overpayment.
    public decimal GetBalanceDue(IEnumerable<Payment> payments)
    {
        ArgumentNullException.ThrowIfNull(payments);

        var netPaid = payments
            .Where(payment => payment.BookingId == Id && payment.Status == PayStatusEnum.Paid)
            .Sum(payment => payment.Amount);

        return TotalPrice - netPaid;
    }

    public BookingSettlementStatus GetSettlementStatus(IEnumerable<Payment> payments)
    {
        var balanceDue = GetBalanceDue(payments);

        if (balanceDue <= 0)
            return BookingSettlementStatus.FullyPaid;

        return balanceDue >= TotalPrice
            ? BookingSettlementStatus.Unpaid
            : BookingSettlementStatus.PartiallyPaid;
    }
}
