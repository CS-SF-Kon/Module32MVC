using Module32MVC.Models.DB;

namespace Module32MVC.Repositories;

public interface IRequestRepository
{
    Task AddRequest(Request request);
    Task<Request[]> GetRequests();
}
