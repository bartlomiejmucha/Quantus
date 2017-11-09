using System.Configuration.Provider;

namespace Quantus.Providers
{
    public class JapanesePluralProvider : ProviderBase, IPluralProvider
    {
        public PluralCategory GetPluralCategory(decimal n)
        {
            return PluralCategory.Other;
        }
    }
}