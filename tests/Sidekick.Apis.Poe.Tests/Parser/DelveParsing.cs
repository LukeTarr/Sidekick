using Sidekick.Common.Game.Items;
using Xunit;

namespace Sidekick.Apis.Poe.Tests.Parser
{
    [Collection(Collections.Mediator)]
    public class DelveParsing
    {
        private readonly IItemParser parser;

        public DelveParsing(ParserFixture fixture)
        {
            parser = fixture.Parser;
        }

        [Fact]
        public void ParsePotentChaoticResonator()
        {
            var actual = parser.ParseItem(@"Item Class: Delve Stackable Socketable Currency
Rarity: Currency
Potent Chaotic Resonator
--------
Stack Size: 1/10
Requires 2 Socketed Fossils
--------
Sockets: D D 
--------
Reforges a rare item with new random modifiers
--------
All sockets must be filled with Fossils before this item can be used.
--------
Note: ~price 1 chaos
");

            Assert.Equal(Class.DelveStackableSocketableCurrency, actual.Metadata.Class);
            Assert.Equal(Category.Currency, actual.Metadata.Category);
            Assert.Equal(Rarity.Currency, actual.Metadata.Rarity);
            Assert.Equal("Potent Chaotic Resonator", actual.Metadata.Type);
        }

        [Fact]
        public void PowerfulChaoticResonator()
        {
            var actual = parser.ParseItem(@"Item Class: Delve Stackable Socketable Currency
Rarity: Currency
Powerful Chaotic Resonator
--------
Stack Size: 1/10
Requires 3 Socketed Fossils
--------
Sockets: D D D 
--------
Reforges a rare item with new random modifiers
--------
All sockets must be filled with Fossils before this item can be used.
--------
Note: ~price 4 chaos
");

            Assert.Equal(Class.DelveStackableSocketableCurrency, actual.Metadata.Class);
            Assert.Equal(Rarity.Currency, actual.Metadata.Rarity);
            Assert.Equal(Category.Currency, actual.Metadata.Category);
            Assert.Equal("Powerful Chaotic Resonator", actual.Metadata.Type);
        }

        [Fact]
        public void PerfectFossil()
        {
            var actual = parser.ParseItem(@"Item Class: Stackable Currency
Rarity: Currency
Perfect Fossil
--------
Stack Size: 1/20
Applies to: Weapons, Body Armour, Gloves, Boots, Helmets, Shields, Maps
--------
Improved Quality
--------
Place in a Resonator to influence item crafting.
--------
Note: ~price 4 chaos
");

            Assert.Equal(Class.StackableCurrency, actual.Metadata.Class);
            Assert.Equal(Rarity.Currency, actual.Metadata.Rarity);
            Assert.Equal(Category.Currency, actual.Metadata.Category);
            Assert.Equal("Perfect Fossil", actual.Metadata.Type);
        }
    }
}
