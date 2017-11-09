using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
	public class FrenchPluralProviderTests
    {
	    [Fact]
		public void ShouldReturnOne_WhenIntegerEqualsZeroOrOne()
	    {
		    var provider = new FrenchPluralProvider();

		    for (decimal n = -1.99M; n < 2; n += 0.01M)
		    {
			    provider.GetPluralCategory(n).ShouldBe(PluralCategory.One);
		    }
	    }

        [Fact]
        public void ShouldReturnOther_WhenIntegerNotEqualsZeroAndOne()
        {
            var provider = new FrenchPluralProvider();

            for (decimal n = -250; n < 250; n += 0.01M)
            {
                if (n <= -2 || n >= 2)
                {
                    provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
                }
            }
        }
    }
}