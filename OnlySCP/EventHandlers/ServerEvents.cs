// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace OnlySCP.EventHandlers
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;

    /// <summary>
    /// Handles all events subscribed from the <see cref="Exiled.Events.Handlers.Server"/> class.
    /// </summary>
    public class ServerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public ServerEvents(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            List<Player> scps = ListPool<Player>.Shared.Rent(Player.Get(Team.SCP));
            if (scps.Count == 1)
                scps[0].Role = plugin.Config.FirstScp;

            ListPool<Player>.Shared.Return(scps);
        }
    }
}