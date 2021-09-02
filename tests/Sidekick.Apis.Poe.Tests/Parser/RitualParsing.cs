using Sidekick.Common.Game.Items;
using Xunit;

namespace Sidekick.Apis.Poe.Tests.Parser
{
    [Collection(Collections.Mediator)]
    public class RitualParsing
    {
        private readonly IItemParser parser;

        public RitualParsing(ParserFixture fixture)
        {
            parser = fixture.Parser;
        }

        [Fact]
        public void RitualSplinter()
        {
            var actual = parser.ParseItem(@"Item Class: Stackable Currency
Rarity: Currency
Ritual Splinter
--------
Stack Size: 17/100
--------
Combine 100 Splinters to create a Ritual Vessel.
Shift click to unstack.
--------
Note: ~price 1 alch
");

            Assert.Equal(Class.StackableCurrency, actual.Metadata.Class);
            Assert.Equal(Rarity.Currency, actual.Metadata.Rarity);
            Assert.Equal(Category.Currency, actual.Metadata.Category);
            Assert.Equal("Ritual Splinter", actual.Metadata.Type);
        }

        [Fact]
        public void RitualVessel()
        {
            var actual = parser.ParseItem(@"Item Class: Stackable Currency
Rarity: Currency
Ritual Vessel
--------
Stack Size: 1/10
--------
Stores the monsters slain for the first time from a completed Ritual Altar for future use
--------
Right-click this item then left-click a Ritual Altar to store the monsters from the completed Ritual in this item. Cannot be used on a Ritual in a map opened with a Blood-Filled Vessel.
--------
Note: ~price 8 chaos
");

            Assert.Equal(Class.StackableCurrency, actual.Metadata.Class);
            Assert.Equal(Rarity.Currency, actual.Metadata.Rarity);
            Assert.Equal(Category.Currency, actual.Metadata.Category);
            Assert.Equal("Ritual Vessel", actual.Metadata.Type);
        }
    }
}
