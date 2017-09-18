using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevOps.Abstractions.Core.Services
{
    public class DirectoryParseService<TFile> : IDirectoryParseService<TFile>
    {
        private readonly IFileParseService<TFile> _file;

        public DirectoryParseService(IFileParseService<TFile> file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public List<TFile> Parse(string path) => ParseFiles(path).ToList();

        private IEnumerable<TFile> ParseFiles(string path)
        {
            foreach (var filePath in Directory.EnumerateFiles(path, "*.json"))
                yield return _file.Parse(filePath);
        }
    }
}
