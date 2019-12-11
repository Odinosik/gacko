namespace GACKO.Shared.Models
{
    /// <summary>
    /// Base View Model
    /// </summary>
    public abstract class GackoBaseViewModel
    {
        /// <summary>
        /// Error message
        /// </summary>
        public GackoError Error { get; set; }
    }
}
