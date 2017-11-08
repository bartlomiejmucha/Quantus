namespace Quantus.Providers
{
    public interface IPluralProvider
    {
        PluralCategory GetPluralCategory(decimal n);
    }
}