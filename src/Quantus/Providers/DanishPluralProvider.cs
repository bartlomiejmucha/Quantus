using System.Configuration.Provider;

namespace Quantus.Providers
{
    public class DanishPluralProvider : ProviderBase, IPluralProvider
    {
        public PluralCategory GetPluralCategory(decimal n)
        {
            n = n < 0 ? -n : n;

            if (n == 1)
            {
                return PluralCategory.One;
            }

            var i = (int) n;
            if (i == 0 || i == 1)
            {
                var t = n - i;
                if (t > 0)
                {
                    return PluralCategory.One;
                }
            }

            return PluralCategory.Other;
        }
    }
}