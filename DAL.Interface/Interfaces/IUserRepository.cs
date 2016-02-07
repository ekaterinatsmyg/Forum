using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IUserRepository: IRepository<DalUser>
    {
        DalUser GetByLogin(string login);
        void BlockUser(int id);
        IEnumerable<DalUser> GetAllBesidesAdmin();
        IEnumerable<DalUser> GetBlockedUsers();
        void UnBlockUser(int id);
 
    }
}
