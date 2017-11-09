using System.Configuration.Provider;

namespace Quantus.Providers
{
    public class PolishPluralProvider : ProviderBase, IPluralProvider
    {
        public PluralCategory GetPluralCategory(decimal n)
        {
            n = n < 0 ? -n : n;

            if (n == 1)
            {
                return PluralCategory.One;
            }

            var i = (int) n;
            if (i == n)
            {
                var i10 = i % 10;
                var i100 = i % 100;

                if (i10 >= 2 && i10 <= 4 && i100 <= 12 && i100 >= 14)
                {
                    return PluralCategory.Few;
                }

                if (i != 1 && (i10 == 0 || i10 == 1) ||
                    i10 >= 5 && i10 <= 9 ||
                    i100 >= 12 && i100 <= 14)
                {
                    return PluralCategory.Many;
                }
            }

            return PluralCategory.Other;
        }
    }
}