using System;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ignite.Services.Configs
{

    /// <summary>
    /// Service for loading and managing application configurations from a YAML file.
    /// </summary>
    public class ConfigService
    {
        private const string _cfgName = "cfg.yaml";


        /// <summary>
        /// Main app configuration object.
        /// </summary>
        public IgniteConfig Configs { get; private set; }


        public async Task LoadConfigs()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, _cfgName);
            Configs = await IgniteConfig.LoadYaml(fileName);
            Console.Title = Configs.TargetInstance;
        }





       

    }
}
