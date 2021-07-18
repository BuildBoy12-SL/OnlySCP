// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace OnlySCP
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig" />
    public class Config : IConfig
    {
        /// <inheritdoc cref="IConfig.IsEnabled" />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the SCP to spawn if only one SCP spawns in any given round.
        /// </summary>
        [Description("The SCP to spawn if only one SCP spawns in any given round.")]
        public RoleType FirstScp { get; set; } = RoleType.Scp173;
    }
}