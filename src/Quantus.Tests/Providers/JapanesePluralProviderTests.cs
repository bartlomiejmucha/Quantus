using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
    public class JapanesePluralProviderTests
    {
	    [Fact]
		public void ShouldReturnOtherCategory_Always()
	    {
		    var provider = new JapanesePluralProvider();

		    for (decimal n = -250; n < 250; n += 0.1M)
		    {
			    provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
		    }
	    }
    }
}