using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class TicketEventLogService : ServiceBase<TicketEventLog, long>, ITicketEventLogService
{
    public TicketEventLogService(ITicketEventLogRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
