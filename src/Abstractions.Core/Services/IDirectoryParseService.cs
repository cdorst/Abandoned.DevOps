using System.Collections.Generic;

namespace DevOps.Abstractions.Core.Services
{
    public interface IDirectoryParseService<TFile>
    {
        List<TFile> Parse(string path);
    }
}
