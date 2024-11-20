using IBKS.Domains;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Interface;
using IBKS.Services.Base;
using IBKS.Services.Interface;

namespace IBKS.Services;

public class TicketService : ServiceBase<Ticket, long>, ITicketService
{
    public TicketService(ITicketRepository repository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
