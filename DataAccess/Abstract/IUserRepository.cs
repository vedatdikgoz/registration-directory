using Core.DataAccess.EntityFrameworkCore;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
