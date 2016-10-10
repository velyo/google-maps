namespace Velyo.Google.Maps
{
    /// <summary>
    /// By default, directions are calculated and displayed using the unit system of the origin's country or region. 
    /// (Note: origins expressed using latitude/longitude coordinates rather than addresses always default to metric units.) 
    /// For example, a route from "Chicago, IL" to "Toronto, ONT" will display results in miles, while the reverse route will display results in kilometers.
    /// </summary>
    public enum UnitSystem
    {
        /// <summary>
        /// Specifies usage of the metric system. Distances are shown using kilometers.
        /// </summary>
        METRIC = 0,

        /// <summary>
        /// Specifies usage of the Imperial (English) system. Distances are shown using miles.
        /// </summary>
        IMPERIAL = 1
    }
}
