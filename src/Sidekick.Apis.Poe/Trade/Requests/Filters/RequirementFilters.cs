using System.Text.Json.Serialization;

namespace Sidekick.Apis.Poe.Trade.Requests.Filters
{
    internal class RequirementFilters
    {
        [JsonPropertyName("lvl")]
        public StatFilterValue? Level { get; set; }

        [JsonPropertyName("dex")]
        public StatFilterValue? Dexterity { get; set; }

        [JsonPropertyName("str")]
        public StatFilterValue? Strength { get; set; }

        [JsonPropertyName("int")]
        public StatFilterValue? Intelligence { get; set; }
    }
}
