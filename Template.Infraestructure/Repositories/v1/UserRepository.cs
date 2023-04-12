using Lorni.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.ModelAggregate.v1.UserAggregate;

namespace Template.Infraestructure.Repositories.v1
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _config;
        private DbSession _dbSession;
        public UserRepository(IConfiguration config, DbSession dbSession)
        {
            _config = config;
            _dbSession = dbSession;
        }

        public async Task<User> Get(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
