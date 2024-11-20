using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class LogTypeService : ServiceBase<LogType, int>, ILogTypeService
{
    public LogTypeService(ILogTypeRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
