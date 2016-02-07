using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRoleUserRepository: IRepository<DalRoleUser>
    {
        IEnumerable<DalRoleUser> GetByUserId(int userId);        
    }
}
