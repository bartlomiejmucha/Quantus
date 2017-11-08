using System.Configuration.Provider;

namespace Quantus.Providers
{
    public class EnglishPluralProvider : ProviderBase, IPluralProvider
    {
        public PluralCategory GetPluralCategory(decimal n)
        {
            return n == 1 ? PluralCategory.One : PluralCategory.Other;
        }
    }
}