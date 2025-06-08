public class ContactFormDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateOnly? DateOfEvent { get; set; }
    public string? EventType { get; set; }
    public string? WeddingStyle { get; set; }
    public string? Venue { get; set; }
    public int? GuestCount { get; set; }
    public string? ReachSource { get; set; }
}