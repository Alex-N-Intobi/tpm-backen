using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class InstalledEnvironmentService : ServiceBase<InstalledEnvironment, int>, IInstalledEnvironmentService
{
    public InstalledEnvironmentService(IInstalledEnvironmentRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
