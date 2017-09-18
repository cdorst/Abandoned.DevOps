using Newtonsoft.Json;
using System.IO;

namespace DevOps.Abstractions.Core.Services
{
    public class FileParseService<TFile> : IFileParseService<TFile>
    {
        public TFile Parse(string path)
            => JsonConvert.DeserializeObject<TFile>(File.ReadAllText(path));
    }
}
