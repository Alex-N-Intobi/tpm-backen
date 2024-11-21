using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IBKS.Repositories.Base.Options;
using IBKS.Repositories.Base.Paging;
using IBKS.RestAPI.Base.Interfaces;
using IBKS.RestAPI.Mapping.Extensions;
using IBKS.Services.Base.Interfaces;
using IBKS.Contracts.Base;

namespace IBKS.RestAPI.Base;

public abstract class ApiControllerBase<TContract, TDomain, TIService, TKey> : ApiControllerBase<TIService>, IControllerBase<TContract, TKey>
    where TContract : ContractBase<TKey>
    where TDomain : Domains.Base.DomainBase<TKey>
    where TIService : IServiceBase<TDomain, TKey>, IServiceBase
{
    public ApiControllerBase(TIService service, IMapper mapper, ILogger<ApiControllerBase> logger) : base(service, mapper, logger) { }

    [HttpGet]
    public async Task<ActionResult<IPageable<TContract>>> GetMany([FromQuery] RequestManyOptions searchOptions = null, CancellationToken cancellationToken = default)
    {
        IPageable<TDomain> domains = await Service.GetManyAsync(searchOptions, cancellationToken);

        return Ok(Mapper.MapPageableTo<TContract>(domains));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<TContract>> GetOne(TKey id, [FromQuery] RequestOneOptions searchOptions = null, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation($"Getting {typeof(TDomain)} with Id: {id}.");
        TDomain domain = await Service.GetOneAsync(id, searchOptions, cancellationToken);

        if (domain == null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<TContract>(domain));
    }

    [HttpPost]
    public async Task<ActionResult<TContract>> CreateOne([FromBody] TContract contract, CancellationToken cancellationToken = default)
    {
        TDomain domain = Mapper.Map<TDomain>(contract);
        TDomain created = await Service.CreateOneAsync(domain, cancellationToken);

        return Ok(Mapper.Map<TContract>(created));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<TContract>> UpdateOne(TKey id, [FromBody]TContract contract, CancellationToken cancellationToken = default)
    {
        TDomain domain = Mapper.Map<TDomain>(contract);
        TDomain updated = await Service.UpdateOneAsync(id, domain, cancellationToken);

        return Ok(Mapper.Map<TContract>(updated));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteOne(TKey id, CancellationToken cancellationToken = default)
    {
        await Service.DeleteOneAsync(id, cancellationToken);

        return NoContent();
    }
}
