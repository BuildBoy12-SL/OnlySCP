// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace OnlySCP
{
    using Exiled.API.Features;
    using OnlySCP.EventHandlers;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets an instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <summary>
        /// Gets an instance of the <see cref="OnlySCP.EventHandlers.ServerEvents"/> class.
        /// </summary>
        public static ServerEvents ServerEvents { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            ServerEvents = new ServerEvents(Config);
            ServerHandlers.RoundStarted += ServerEvents.OnRoundStarted;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted -= ServerEvents.OnRoundStarted;
            ServerEvents = null;
            base.OnDisabled();
        }
    }
}