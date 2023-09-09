namespace Sidekick.Apis.Poe.Trade.Models
{
    public interface ITradeFilter
    {
        /// <summary>
        /// Gets or sets a value indicating whether the filter is checked for filtering or not.
        /// </summary>
        bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the filter.
        /// </summary>
        double? Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the filter.
        /// </summary>
        double? Max { get; set; }
    }
}
