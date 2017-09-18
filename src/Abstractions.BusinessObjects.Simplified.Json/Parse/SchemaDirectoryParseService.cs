using DevOps.Abstractions.Core.Services;
using Microsoft.Extensions.Logging;

namespace DevOps.Abstractions.BusinessObjects.Simplified.Json.Parse
{
    public class SchemaDirectoryParseService : DirectoryParseMapToParentService<Schema, Concept>
    {
        public SchemaDirectoryParseService(IDirectoryParseService<Schema> directoryParseService, ILogger<DirectoryParseMapToParentService<Schema, Concept>> logger, IParentMappingService<Schema, Concept> parentMappingService) : base(directoryParseService, logger, parentMappingService)
        {
        }
    }
}
