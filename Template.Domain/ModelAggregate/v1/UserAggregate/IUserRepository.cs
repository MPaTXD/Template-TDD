using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.ModelAggregate.v1.UserAggregate
{
    public interface IUserRepository
    {
        Task<User> Get(int userId);
    }
}
