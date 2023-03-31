namespace RoundaBoutz.Shared.Models;

public class Estimate
{
    public Guid Id { get; set; }
    public DateOnly DateCreated { get; set; }
    public DateOnly DateUpdated { get; set; }
    public Customer Customer { get; set; } = new();
    public bool IsRush { get; set; }
}