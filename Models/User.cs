namespace Ch6Lab.Models;

public enum UserField
{
    Name,
    Phone,
    EMail,
    Address
}

public class User 
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }

    public string? Street { get; set; }
    public string? City { get; set; }
    public string? RegionCode { get; set; }
    public string? PostalCode { get; set; }
}