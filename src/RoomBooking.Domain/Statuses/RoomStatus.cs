namespace RoomBooking.Domain.Statuses;

public class RoomStatus 
{
    public int Id { get; set; }
    public HousekeepingStatus HousekeepingStatus { get; set; }
    public RoomOperationalStatus OperationalStatus { get; set; }
}

public enum HousekeepingStatus
{
    Dirty,
    Clean
}

public enum RoomOperationalStatus
{
    InService,
    OutOfService
}