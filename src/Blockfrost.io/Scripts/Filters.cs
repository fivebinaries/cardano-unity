using System.Collections.Generic;
using System.Linq;

namespace Blockfrost {
    public class Listing {
        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// The page number for listing the results.
        /// </summary>
        public int? page { get; set; }

        public Dictionary<string, string> AsDict() {
            return this.GetType().GetProperties()
                .Where(property => property.GetValue(this) != null)
                .ToDictionary(property => property.Name, property => property.GetValue(this).ToString());
        }
    }

    public class OrderedListing : Listing {
        /// <summary>
        /// Ascending/Descending
        /// </summary>
        public enum Order { asc, desc }
        /// <summary>
        /// The ordering of items from the point of view of the blockchain,
        /// not the page listing itself. By default, we return oldest first,
        /// newest last.
        /// </summary>
        public Order? order { get; set; }
    }

    public class TargetableOrderedListing : OrderedListing {
        /// <summary>
        /// The block number and optionally also index from which (inclusive) to
        /// start search for results, concatenated using colon.
        /// Has to be lower than or equal to `to` parameter.
        /// </summary>
        /// <example>8929261</example>
        public string from { get; set; } = null;
        /// <summary>
        /// The block number and optionally also index where (inclusive) to end
        /// the search for results, concatenated using colon.
        /// Has to be higher than or equal to `from` parameter.
        /// </summary>
        /// <example>9999269:10</example>
        public string to { get; set; } = null;
    }
}