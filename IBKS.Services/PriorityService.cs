using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class PriorityService : ServiceBase<Priority, int>, IPriorityService
{
    public PriorityService(IPriorityRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
