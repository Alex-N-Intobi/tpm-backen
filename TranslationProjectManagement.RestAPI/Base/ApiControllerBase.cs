using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationProjectManagement.Contracts.Base;
using TranslationProjectManagement.Repositories.Base.Options;
using TranslationProjectManagement.Repositories.Base.Paging;
using TranslationProjectManagement.RestAPI.Base.Interfaces;
using TranslationProjectManagement.RestAPI.Mapping.Extensions;
using TranslationProjectManagement.Services.Base.Interfaces;

namespace TranslationProjectManagement.RestAPI.Base;

public abstract class ApiControllerBase<TContract, TDomain, TIService> : ApiControllerBase<TIService>, IControllerBase<TContract>
    where TContract : ContractBase
    where TDomain : Domains.Base.DomainBase
    where TIService : IServiceBase<TDomain>, IServiceBase
{
    public ApiControllerBase(TIService service, IMapper mapper, ILogger<ApiControllerBase> logger) : base(service, mapper, logger) { }

    [HttpGet]
    public virtual async Task<ActionResult<IPageable<TContract>>> GetMany([FromQuery] RequestManyOptions searchOptions = null, CancellationToken cancellationToken = default)
    {
        IPageable<TDomain> domains = await Service.GetManyAsync(searchOptions, cancellationToken);

        return Ok(Mapper.MapPageableTo<TContract>(domains));
    }

    [HttpGet]
    [Route("{id:int}")]
    public virtual async Task<ActionResult<TContract>> GetOne(int id, [FromQuery] RequestOneOptions searchOptions = null, CancellationToken cancellationToken = default)
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
    public virtual async Task<ActionResult<TContract>> CreateOne([FromBody] TContract contract, CancellationToken cancellationToken = default)
    {
        TDomain domain = Mapper.Map<TDomain>(contract);
        TDomain created = await Service.CreateOneAsync(domain, cancellationToken);

        return Ok(Mapper.Map<TContract>(created));
    }

    [HttpPut]
    [Route("{id:int}")]
    public virtual async Task<ActionResult<TContract>> UpdateOne(int id, [FromBody]TContract contract, CancellationToken cancellationToken = default)
    {
        TDomain domain = Mapper.Map<TDomain>(contract);
        TDomain updated = await Service.UpdateOneAsync(id, domain, cancellationToken);

        return Ok(Mapper.Map<TContract>(updated));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public virtual async Task<IActionResult> DeleteOne(int id, CancellationToken cancellationToken = default)
    {
        await Service.DeleteOneAsync(id, cancellationToken);

        return NoContent();
    }
}
