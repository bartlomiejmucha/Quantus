﻿using Quantus.Providers;
using Shouldly;
using Xunit;

namespace Quantus.Tests.Providers
{
	public class EnglishPluralProviderTests
	{
		[Fact]
		public void ShouldReturnOneCategory_ForNumberOne()
		{
			var provider = new EnglishPluralProvider();

			provider.GetPluralCategory(1).ShouldBe(PluralCategory.One);
			provider.GetPluralCategory(-1).ShouldBe(PluralCategory.One);
		}

		[Fact]
		public void ShouldAlwaysReturnOtherCategory_ExceptForNumberOne()
		{
			var provider = new EnglishPluralProvider();

			for (decimal n = -250; n < 250; n += 0.1M)
			{
				if (n != 1 && n != -1)
				{
					provider.GetPluralCategory(n).ShouldBe(PluralCategory.Other);
				}
			}
		}
	}
}