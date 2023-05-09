using System.Text.Json.Serialization;

namespace $safeprojectname$.Model
{
    public class Config
    {
        [JsonPropertyName("exampleData")]
        public string ExampleData { get; set; }
    }
}
