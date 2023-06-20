using Newtonsoft.Json;

namespace Playwright_CSharp_Dotnet
{
    public class ReadJson
    {
        public ReadJson()
        {

        }
        public string ReadData(String value)
        {
            string filePath = System.IO.Directory.GetParent(@"../../../") + "/config.json";
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return jsonFile[value];
        }
    }
}