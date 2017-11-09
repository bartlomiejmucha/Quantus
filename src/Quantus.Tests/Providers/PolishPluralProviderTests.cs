using Quantus.Providers;
using Shouldly;
using System;
using Xunit;

namespace Quantus.Tests.Providers
{
    public class PolishPluralProviderTests
	{
		[Fact]
		public void ShouldReturnOneCategory_ForNumberOne()
		{
			var provider = new PolishPluralProvider();

			provider.GetPluralCategory(1).ShouldBe(PluralCategory.One);
			provider.GetPluralCategory(-1).ShouldBe(PluralCategory.One);
		}

		[Fact]
		public void ShouldReturnFewCategory_WhenReminderIsBetweenTwoAndFourButNotBetweenTwelveAndFourteen()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = -250; n < 250; n += 1M)
			{
				var i10 = Math.Abs(n % 10);
				var i100 = Math.Abs(n % 100);

				if (i10 >= 2 && i10 <= 4 && i100 <= 12 && i100 >= 14)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Few);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategory_WhenNuberNotOneAndReminderIsZeroOrOne()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = -250; n < 250; n += 1M)
			{
				var i10 = Math.Abs(n % 10);

				if (n != 1 && n != -1 && (i10 == 0 || i10 == 1))
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategory_WhenReminderBetweenFiveAndNine()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = -250; n < 250; n += 1M)
			{
				var i10 = Math.Abs(n % 10);

				if (i10 >= 5 && i10 <= 9)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnManyCategory_WhenReminderBetweenTwelveAndFourteen()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = -250; n < 250; n += 1M)
			{
				var i100 = Math.Abs(n % 100);

				if (i100 >= 12 && i100 <= 14)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Many);
				}
			}
		}

		[Fact]
		public void ShouldReturnOtherCategory_WhenThereIsDecimalDigit()
		{
			var provider = new PolishPluralProvider();

			for (decimal n = -250; n < 250; n += 0.1M)
			{
				var i = (int) Math.Abs(n);
				if (i != n && i != -n)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
				}
			}
		}
    }
}