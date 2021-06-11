using CallDoc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public interface IAuthRepository
    {
        public string CreateToken(Member user);
    }
}
