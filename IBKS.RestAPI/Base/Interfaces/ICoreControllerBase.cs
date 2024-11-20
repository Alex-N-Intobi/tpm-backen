using Microsoft.AspNetCore.Mvc;
using IBKS.Contracts.Base;
using IBKS.Repositories.Base.Options;
using IBKS.Repositories.Base.Paging;

namespace IBKS.RestAPI.Base.Interfaces;

public interface IControllerBase<TContract> where TContract : ContractBase
{
    Task<ActionResult<IPageable<TContract>>> GetMany(RequestManyOptions searchOptions = null, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> GetOne(int id, RequestOneOptions searchOptions = null, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> CreateOne(TContract contract, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> UpdateOne(int id, TContract contract, CancellationToken cancellationToken = default);

    Task<IActionResult> DeleteOne(int id, CancellationToken cancellationToken = default);
}
