using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class StatusService : ServiceBase<Status, int>, IStatusService
{
    public StatusService(IStatusRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
