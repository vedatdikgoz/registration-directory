using Core.DataAccess.EntityFrameworkCore;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;


namespace DataAccess.Concrete
{
    public class UserRepository : EntityRepositoryBase<User, DataContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DataContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

    }
}
