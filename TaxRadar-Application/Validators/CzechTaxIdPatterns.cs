namespace TaxRadar_Application.Validators;

internal static class CzechTaxIdPatterns
{
    public const string Ico = @"^\d{8}$";
    public const string Dic = @"^CZ\d{8,10}$";
}
