// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace OnlySCP
{
    using System;
    using Exiled.API.Features;
    using OnlySCP.EventHandlers;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private ServerEvents serverEvents;

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            serverEvents = new ServerEvents(this);
            ServerHandlers.RoundStarted += serverEvents.OnRoundStarted;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted -= serverEvents.OnRoundStarted;
            serverEvents = null;
            base.OnDisabled();
        }
    }
}