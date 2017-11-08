using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
	public class OtherPluralProviderTests
    {
	    [Fact]
		public void ShouldAlwaysReturnOtherCategory()
	    {
		    var provider = new OtherPluralProvider();

		    for (decimal n = 0; n < 250; n += 0.1M)
		    {
			    provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
		    }
	    }
    }
}