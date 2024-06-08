using System.Runtime.CompilerServices;

namespace Eco.Infrastructure.ZaloPay.Models.Common
{
    /// <summary>
    /// BaseCallback
    /// </summary>
    public class BaseCallback
    {
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// Mac
        /// </summary>
        public string Mac { get; set; } = string.Empty;

        /// <summary>
        /// Type
        /// </summary>
        public int Type { get; set; }   
    }
}
