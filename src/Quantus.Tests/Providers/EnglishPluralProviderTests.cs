using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
	public class EnglishPluralProviderTests
	{
		[Fact]
		public void ShouldReturnOneCategoryForNumberOne()
		{
			var provider = new EnglishPluralProvider();

			provider.GetPluralCategory(1).ShouldBe(PluralCategory.One);
		}

		[Fact]
		public void ShouldAlwaysReturnOtherCategoryExceptForNumberOne()
		{
			var provider = new EnglishPluralProvider();

			for (decimal n = 0; n < 250; n += 0.1M)
			{
				if (n != 1)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
				}
			}
		}
	}
}