using Microsoft.Extensions.Logging;
using System;

namespace DevOps.Abstractions.Core.Services
{
    public class DirectoryParseMapToParentService<TFile, TParent> : IDirectoryParseMapToParentService<TFile, TParent>
        where TFile : class
        where TParent : class
    {
        private readonly IDirectoryParseService<TFile> _directoryParseService;
        private readonly ILogger<DirectoryParseMapToParentService<TFile, TParent>> _logger;
        private readonly IParentMappingService<TFile, TParent> _parentMappingService;

        public DirectoryParseMapToParentService(
            IDirectoryParseService<TFile> directoryParseService,
            ILogger<DirectoryParseMapToParentService<TFile, TParent>> logger,
            IParentMappingService<TFile, TParent> parentMappingService)
        {
            _directoryParseService = directoryParseService ?? throw new ArgumentNullException(nameof(directoryParseService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _parentMappingService = parentMappingService ?? throw new ArgumentNullException(nameof(parentMappingService));
        }

        public TParent Parse(string path)
        {
            _logger.LogInformation("Parsing files in path and mapping to parent object");
            return _parentMappingService.Map(_directoryParseService.Parse(path));
        }
    }
}
