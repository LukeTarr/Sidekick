using Sidekick.Common.Game.Items;
using Xunit;

namespace Sidekick.Apis.Poe.Tests.Parser
{
    [Collection(Collections.Mediator)]
    public class GemParsing
    {
        private readonly IItemParser parser;

        public GemParsing(ParserFixture fixture)
        {
            parser = fixture.Parser;
        }

        [Fact]
        public void ParseVaalGem()
        {
            var actual = parser.ParseItem(VaalGem);

            Assert.Equal(Category.Gem, actual.Metadata.Category);
            Assert.Equal(Rarity.Gem, actual.Metadata.Rarity);
            Assert.Equal("Vaal Double Strike", actual.Metadata.Type);
            Assert.Equal(1, actual.Properties.GemLevel);
            Assert.Equal(0, actual.Properties.Quality);
            Assert.False(actual.Properties.AlternateQuality);
            Assert.True(actual.Properties.Corrupted);
        }

        [Fact]
        public void ParseAnomalousGem()
        {
            var actual = parser.ParseItem(AnomalousGem);

            Assert.Equal(Category.Gem, actual.Metadata.Category);
            Assert.Equal(Rarity.Gem, actual.Metadata.Rarity);
            Assert.Equal("Static Strike", actual.Metadata.Type);
            Assert.Equal(1, actual.Properties.GemLevel);
            Assert.Equal(17, actual.Properties.Quality);
            Assert.True(actual.Properties.AlternateQuality);
            Assert.False(actual.Properties.Corrupted);
        }

        [Fact]
        public void ArcaneSurgeSupport()
        {
            var actual = parser.ParseItem(@"Item Class: Support Skill Gems
Rarity: Gem
Arcane Surge Support
--------
Arcane, Support, Spell, Duration
Level: 1
Cost & Reservation Multiplier: 130%
--------
Requirements:
Level: 1
--------
Each supported spell will track how much mana you spend on it, granting a buff when the total mana spent reaches a threshold. Cannot support skills used by totems, traps, mines or skills with a reservation.
--------
Gain Arcane Surge after Spending a total of 15 Mana with a Supported Skill
Arcane Surge grants 10% more Spell Damage
Arcane Surge grants 30% increased Mana Regeneration rate
Arcane Surge lasts 4 seconds
Supported Skills deal 10% more Spell Damage while you have Arcane Surge
--------
Experience: 1/70
--------
This is a Support Gem. It does not grant a bonus to your character, but to skills in sockets connected to it. Place into an item socket connected to a socket containing the Active Skill Gem you wish to augment. Right click to remove from a socket.
");

            Assert.Equal(Class.SupportSkillGems, actual.Metadata.Class);
            Assert.Equal(Rarity.Gem, actual.Metadata.Rarity);
            Assert.Equal(Category.Gem, actual.Metadata.Category);
            Assert.Equal("Arcane Surge Support", actual.Metadata.Type);
        }

        [Fact]
        public void VoidSphere()
        {
            var actual = parser.ParseItem(@"Item Class: Active Skill Gems
Rarity: Gem
Void Sphere
--------
Spell, AoE, Duration, Physical, Chaos, Orb
Level: 1
Cost: 30 Mana
Cooldown Time: 10.00 sec
Cast Time: 0.60 sec
Critical Strike Chance: 5.00%
Effectiveness of Added Damage: 55%
--------
Requirements:
Level: 34
Int: 79
--------
Creates a Void Sphere which Hinders enemies in an area around it, with the debuff being stronger on enemies closer to the sphere. It also regularly releases pulses of area damage. The Void Sphere will consume the corpses of any enemies which die in its area. Can only have one Void Sphere at a time.
--------
Deals 27 to 41 Physical Damage
Base duration is 5.00 seconds
Pulses every 0.40 seconds
40% of Physical Damage Converted to Chaos Damage
Enemies in range are Hindered, with up to 30% reduced Movement Speed, based on distance from the Void Sphere
--------
Experience: 1/252595
--------
Place into an item socket of the right colour to gain this skill. Right click to remove from a socket.
");

            Assert.Equal(Class.ActiveSkillGems, actual.Metadata.Class);
            Assert.Equal(Rarity.Gem, actual.Metadata.Rarity);
            Assert.Equal(Category.Gem, actual.Metadata.Category);
            Assert.Equal("Void Sphere", actual.Metadata.Type);
        }

        #region ItemText

        private const string VaalGem = @"Item Class: Unknown
Rarity: Gem
Double Strike
--------
Vaal, Attack, Melee, Strike, Duration, Physical
Level: 1
Mana Cost: 5
Attack Speed: 80% of base
Effectiveness of Added Damage: 91%
Experience: 1/70
--------
Requirements:
Level: 1
--------
Performs two fast strikes with a melee weapon.
--------
Deals 91.3% of Base Damage
25% chance to cause Bleeding
Adds 3 to 5 Physical Damage against Bleeding Enemies
--------
Vaal Double Strike
--------
Souls Per Use: 30
Can Store 2 Uses
Soul Gain Prevention: 8 sec
Effectiveness of Added Damage: 28%
--------
Performs two fast strikes with a melee weapon, each of which summons a double of you for a duration to continuously attack monsters in this fashion.
--------
Deals 28% of Base Damage
Base duration is 6.00 seconds
Modifiers to Skill Effect Duration also apply to this Skill's Soul Gain Prevention
Can't be Evaded
25% chance to cause Bleeding
Adds 3 to 5 Physical Damage against Bleeding Enemies
--------
Place into an item socket of the right colour to gain this skill.Right click to remove from a socket.
--------
Corrupted
--------
Note: ~price 2 chaos
";

        private const string AnomalousGem = @"Item Class: Unknown
Rarity: Gem
Anomalous Static Strike
--------
Attack, Melee, Strike, AoE, Duration, Lightning, Chaining
Level: 1
Mana Cost: 6
Effectiveness of Added Damage: 110%
Quality: +17% (augmented)
Alternate Quality
--------
Requirements:
Level: 12
Str: 21
Int: 14
--------
Attack with a melee weapon, gaining static energy for a duration if you hit an enemy. While you have static energy, you'll frequently hit a number of nearby enemies with beams, dealing attack damage.
--------
Beams Hit Enemies every 0.40 seconds
50% of Physical Damage Converted to Lightning Damage
Deals 110% of Base Damage
Base duration is 2.00 seconds
Chains +1 Times
17% increased Damage
Beams deal 40% less Damage
4 maximum Beam Targets
--------
Experience: 1/15249
--------
Place into an item socket of the right colour to gain this skill. Right click to remove from a socket.
";

        #endregion
    }
}
