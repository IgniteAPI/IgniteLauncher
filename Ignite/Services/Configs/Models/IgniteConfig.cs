using System;
using System.ComponentModel;
using System.IO;
using YamlDotNet.Serialization;

namespace Ignite.Services.Configs
{
    public class IgniteConfig : IgniteConfigBase<IgniteConfig>
    {

        [YamlMember(Description = "Target Instance to Load")]
        public string TargetInstance { get; set; } = "MyNewIgniteInstance";

        [YamlMember(Description = "Changes the name of the CMD Window")]
        public string IgniteCMDName { get; set; } = "Ignite";

        [YamlMember(Description = "Relative Path to SteamCMD Folder")]
        public string SteamCMDFolder { get; set; } = "SteamCMD";

        [YamlMember(Description = "Relative Path to Installed Games Folder")]
        public string GamesFolder { get; set; } = "GamePackages";

        [YamlMember(Description = "Relative Path to Installed Games Folder")]
        public string InstanceFolder { get; set; } = @"Instances";

        [YamlMember(Description = "Enables the use of local development plugins")]
        public bool EnableDevelopmentPlugins { get; set; } = false;

        [YamlMember(Description = "IpAddress for Ignite to be hosted on. Leave 0.0.0.0 unless you know what youre doing")]
        public string IPAdress { get; set; } = "0.0.0.0";

        [YamlMember(Description = "Autoupdates Ignite Launcher on Restart")]
        public bool AutoUpdateIgnite { get; set; } = true;

        [YamlMember(Description = "Enables Services for Ignite WebAPI & WebUI")]
        public bool EnableWebApi { get; set; } = true;












    }
}
