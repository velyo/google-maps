namespace Velyo.Google.Maps
{
    /// <summary>
    /// When you calculate directions, you need to specify which transportation mode to use.
    /// </summary>
    public enum TravelMode
    {
        /// <summary>
        /// (Default) indicates standard driving directions using the road network.
        /// </summary>
        DRIVING,

        /// <summary>
        /// requests bicycling directions via bicycle paths & preferred streets
        /// </summary>
        BICYCLING,

        /// <summary>
        /// requests directions via public transit routes
        /// </summary>
        TRANSIT,

        /// <summary>
        /// requests walking directions via pedestrian paths & sidewalks
        /// </summary>
        WALKING
    }
}
