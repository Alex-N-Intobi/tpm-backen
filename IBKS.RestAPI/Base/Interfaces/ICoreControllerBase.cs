using Microsoft.AspNetCore.Mvc;
using IBKS.Contracts.Base;
using IBKS.Repositories.Base.Options;
using IBKS.Repositories.Base.Paging;

namespace IBKS.RestAPI.Base.Interfaces;

public interface IControllerBase<TContract, TKey> where TContract : ContractBase<TKey>
{
    Task<ActionResult<IPageable<TContract>>> GetMany(RequestManyOptions searchOptions = null, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> GetOne(TKey id, RequestOneOptions searchOptions = null, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> CreateOne(TContract contract, CancellationToken cancellationToken = default);

    Task<ActionResult<TContract>> UpdateOne(TKey id, TContract contract, CancellationToken cancellationToken = default);

    Task<IActionResult> DeleteOne(TKey id, CancellationToken cancellationToken = default);
}
