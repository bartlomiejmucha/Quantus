using Quantus.Providers;
using Shouldly;
using System;
using Xunit;

namespace Quantus.Tests.Providers
{
    public class DanishPluralProviderTests
	{
		[Fact]
		public void ShouldReturnOneCategory_ForNumberOne()
		{
			var provider = new DanishPluralProvider();

			provider.GetPluralCategory(1).ShouldBe(PluralCategory.One);
			provider.GetPluralCategory(-1).ShouldBe(PluralCategory.One);
		}

		[Fact]
		public void ShouldReturnOneCategory_WhenNumberIsZeroOrOne_And_DigitPartIsNotZero()
		{
			var provider = new DanishPluralProvider();

			for (decimal n = -1.99M; n < 2; n += 0.01M)
			{
			    var i = (int) Math.Abs(n);
			    if (i == 0 || i == 1)
			    {
			        var t = Math.Abs(n) - i;
			        if (t > 0)
			        {
			            provider.GetPluralCategory(n).ShouldBe(PluralCategory.One);
			        }
			    }
            }
		}

	    [Fact]
	    public void ShouldReturnOtherCategory_InAllOtherCases()
	    {
	        var provider = new DanishPluralProvider();

	        for (decimal n = -250M; n < 250; n += 0.01M)
	        {
	            if (n == 1 || n == -1)
	            {
	                continue;
	            }

	            var i = (int)Math.Abs(n);
	            if (i == 0 || i == 1)
	            {
	                var t = Math.Abs(n) - i;
	                if (t > 0)
	                {
	                    continue;
	                }
	            }

	            provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
            }
	    }
    }
}