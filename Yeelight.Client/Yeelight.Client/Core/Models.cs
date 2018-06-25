using Yeelight.Client.Utils;

namespace Yeelight.Client.Core
{
    public enum Models
    {
        /// <summary>
        /// Unknown model.
        /// </summary>
        Unknown,

        /// <summary>
        /// Mono device, supports brightness adjustment only.
        /// </summary>
        [ActualName("mono")]
        Mono,

        /// <summary>
        /// Color device, support both color and color temperature adjustment.
        /// </summary>
        [ActualName("color")]
        Color,

        /// <summary>
        /// Smart LED stripe.
        /// </summary>
        [ActualName("stripe")]
        Stripe,

        /// <summary>
        ///  Ceiling Light.
        /// </summary>
        [ActualName("ceiling")]
        Ceiling,

        /// <summary>
        /// Bedside lamp.
        /// </summary>
        [ActualName("bslamp")]
        BedsideLamp,

        /// <summary>
        /// Desk Lamp.
        /// </summary>
        [ActualName("desklamp")]
        DeskLamp
    }
}