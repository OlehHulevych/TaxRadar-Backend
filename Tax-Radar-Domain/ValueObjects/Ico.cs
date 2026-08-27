namespace Tax_Radar_Domain.ValueObjects;

public sealed record Ico
{
    public string Value { get; }

    public Ico(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ICO is required.", nameof(value));

        var normalized = value.Trim();
        if (!IsValidFormat(normalized))
            throw new ArgumentException($"'{value}' is not a valid ICO (must be exactly 8 digits).", nameof(value));

        Value = normalized;
    }

    public override string ToString() => Value;

    private static bool IsValidFormat(string value) =>
        value.Length == 8 && value.All(char.IsDigit);
}
