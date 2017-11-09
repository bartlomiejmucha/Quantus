using System.Configuration.Provider;

namespace Quantus.Providers
{
    public class FrenchPluralProvider : ProviderBase, IPluralProvider
    {
        public PluralCategory GetPluralCategory(decimal n)
        {
            n = n < 0 ? -n : n;

            var i = (int) n;
            if (i == 0 || i == 1)
            {
                return PluralCategory.One;
            }

            return PluralCategory.Other;
        }
    }
}