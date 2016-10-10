namespace Velyo.Google.Maps.Directions
{
    /// <summary>
    /// Specifies a preferred mode of transit.
    /// </summary>
    public enum TransitMode
    {
        /// <summary>
        /// Indicates that the calculated route should prefer travel by bus.
        /// </summary>
        BUS,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train, tram, light rail, and subway.
        /// </summary>
        RAIL,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by subway.
        /// </summary>
        SUBWAY,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train.
        /// </summary>
        TRAIN,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by tram and light rail.
        /// </summary>
        TRAM
    }
}
