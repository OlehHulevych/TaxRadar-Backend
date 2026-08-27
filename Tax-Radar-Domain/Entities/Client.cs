using Tax_Radar_Domain.Common;
using Tax_Radar_Domain.ValueObjects;

namespace Tax_Radar_Domain.Entities;

public class Client : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public EmailAddress? Email { get; private set; }
    public Ico? Ico { get; private set; }
    public Dic? Dic { get; private set; }
    public Address? Address { get; private set; }

    protected Client()
    {
        Name = string.Empty;
    }

    public Client(
        Guid userId,
        string name,
        string? email = null,
        string? ico = null,
        string? dic = null,
        string? street = null,
        string? city = null,
        string? postalCode = null,
        string? country = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.", nameof(userId));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        UserId = userId;
        Name = name;
        Email = string.IsNullOrWhiteSpace(email) ? null : new EmailAddress(email);
        Ico = string.IsNullOrWhiteSpace(ico) ? null : new Ico(ico);
        Dic = string.IsNullOrWhiteSpace(dic) ? null : new Dic(dic);
        Address = BuildAddress(street, city, postalCode, country);
    }

    public void UpdateDetails(
        string name,
        string? email,
        string? ico,
        string? dic,
        string? street,
        string? city,
        string? postalCode,
        string? country)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name;
        Email = string.IsNullOrWhiteSpace(email) ? null : new EmailAddress(email);
        Ico = string.IsNullOrWhiteSpace(ico) ? null : new Ico(ico);
        Dic = string.IsNullOrWhiteSpace(dic) ? null : new Dic(dic);
        Address = BuildAddress(street, city, postalCode, country);
        MarkAsUpdated();
    }

    private static Address? BuildAddress(string? street, string? city, string? postalCode, string? country)
    {
        if (string.IsNullOrWhiteSpace(street) &&
            string.IsNullOrWhiteSpace(city) &&
            string.IsNullOrWhiteSpace(postalCode) &&
            string.IsNullOrWhiteSpace(country))
        {
            return null;
        }

        return new Address(street!, city!, postalCode!, country!);
    }
}
