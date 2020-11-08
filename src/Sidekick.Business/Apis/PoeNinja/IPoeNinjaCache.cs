using System;
using System.Threading.Tasks;
using Sidekick.Business.Apis.PoeNinja.Models;
using Sidekick.Domain.Game.Items.Models;

namespace Sidekick.Business.Apis.PoeNinja
{
    /// <summary>
    /// poe.ninja cache. The basic idea is fetching current poe.ninja with specified interval (e.g. hourly) in the background.
    /// imo it'd be overkill to request their api every time. Also perfomance. 
    /// Alternatively give the user the option to refresh the cache via TrayIcon or Shortcut.
    /// </summary>
    public interface IPoeNinjaCache
    {
        DateTime? LastRefreshTimestamp { get; }

        PoeNinjaItem GetItem(Item item);
        PoeNinjaCurrency GetCurrency(Item item);
        double? GetItemPrice(Item item);

        Task RefreshData();
    }
}
