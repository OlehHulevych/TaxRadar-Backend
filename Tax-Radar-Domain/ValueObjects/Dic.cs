namespace Tax_Radar_Domain.ValueObjects;

public sealed record Dic
{
    public string Value { get; }

    public Dic(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("DIC is required.", nameof(value));

        var normalized = value.Trim().ToUpperInvariant();
        if (!IsValidFormat(normalized))
            throw new ArgumentException($"'{value}' is not a valid DIC (must be 'CZ' followed by 8-10 digits).", nameof(value));

        Value = normalized;
    }

    public override string ToString() => Value;

    private static bool IsValidFormat(string value)
    {
        if (!value.StartsWith("CZ", StringComparison.Ordinal))
            return false;

        var digits = value[2..];
        return digits.Length is >= 8 and <= 10 && digits.All(char.IsDigit);
    }
}
