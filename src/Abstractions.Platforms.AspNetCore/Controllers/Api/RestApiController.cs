using DevOps.Abstractions.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DevOps.Abstractions.Platforms.AspNetCore.Controllers.Api
{
    public class RestApiController<TDbContext, TRecord> : Controller
        where TDbContext : DbContext
        where TRecord : class
    {
        private readonly ILogger<RestApiController<TDbContext, TRecord>> _logger;
        private readonly IRepository<TDbContext, TRecord> _repository;
        private readonly IUpsertService<TDbContext, TRecord> _upsertService;

        public RestApiController(
            ILogger<RestApiController<TDbContext, TRecord>> logger,
            IRepository<TDbContext, TRecord> repository,
            IUpsertService<TDbContext, TRecord> upsertService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _upsertService = upsertService ?? throw new ArgumentNullException(nameof(upsertService));
        }

        protected async Task<IActionResult> DeleteRecordById(object[] keyValues)
        {
            _logger.LogInformation($"Deleting record with ID: {keyValues}");
            await _repository.RemoveAsync(keyValues);
            return Ok();
        }

        protected async Task<IActionResult> GetRecordById(object[] keyValues)
        {
            _logger.LogInformation($"Getting record with ID: {keyValues}");
            var record = await _repository.FindAsync(keyValues);
            return OkOrNoContent(record);
        }

        protected async Task<IActionResult> PostRecord(TRecord record)
        {
            _logger.LogInformation("Adding record");
            var result = await _repository.AddAsync(record);
            return OkOrNoContent(record);
        }

        protected async Task<IActionResult> PutRecord(TRecord record)
        {
            _logger.LogInformation("Upserting (if exists update, else insert) record");
            var result = await _upsertService.UpsertAsync(record);
            return OkOrNoContent(record);
        }

        private IActionResult OkOrNoContent<T>(T result)
        {
            if (result == null)
            {
                _logger.LogInformation("Returning 204 No Content response");
                return NoContent();
            }
            _logger.LogInformation("Returning 200 Ok response");
            return Ok(result);
        }
    }
}
