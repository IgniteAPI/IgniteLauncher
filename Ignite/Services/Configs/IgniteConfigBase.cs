using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ignite.Services.Configs
{
    public abstract class IgniteConfigBase<T> where T : IgniteConfigBase<T>, new()
    {
        [YamlIgnore]
        public string filePath;

        public async Task Save()
        {
            var serializer = new SerializerBuilder()
                 .WithNamingConvention(CamelCaseNamingConvention.Instance)
                 .Build();

            var yaml = serializer.Serialize(this);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!); // Ensure directory exists
            await File.WriteAllTextAsync(filePath, yaml);
        }

        public static async Task<T> LoadYaml(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // Optionally create a default file
                var defaultInstance = new T();
                defaultInstance.filePath = filePath; // Set the file path for saving later
                await defaultInstance.Save();
                return defaultInstance;
            }

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();

            var yaml = await File.ReadAllTextAsync(filePath);
            return deserializer.Deserialize<T>(yaml);
        }
    }
}
