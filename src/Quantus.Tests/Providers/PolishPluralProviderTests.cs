using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
	public class PolishPluralProviderTests
	{
		[Fact]
		public void ShouldReturnOneCategoryForNumberOne()
		{
			var provider = new PolishPluralProvider();

			provider.GetPluralCategory(1).ShouldBe(PluralCategory.One);
		}

		[Fact]
		public void ShouldReturnFewCategoryWhenReminderIsBetweenTwoAndFourButNotBetweenTwelveAndFourteen()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = 0; n < 250; n += 1M)
			{
				var i10 = n % 10;
				var i100 = n % 100;

				if (i10 >= 2 && i10 <= 4 && i100 <= 12 && i100 >= 14)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Few);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategoryWhenNuberNotOneAndReminderIsZeroOrOne()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = 0; n < 250; n += 1M)
			{
				var i10 = n % 10;

				if (n != 1 && (i10 == 0 || i10 == 1))
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategoryWhenReminderBetweenFiveAndNine()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = 0; n < 250; n += 1M)
			{
				var i10 = n % 10;

				if (i10 >= 5 && i10 <= 9)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategoryWhenReminderBetweenTwelveAndFourteen()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = 0; n < 250; n += 1M)
			{
				var i100 = n % 100;

				if (i100 >= 12 && i100 <= 14)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnOtherCategoryWhenThereIsDecimalDigit()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = 0; n < 250; n += 0.1M)
			{
				var i = (int) n;
				if (i != n)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
				}
			}
		}
	}
}