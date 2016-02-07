using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMessage: IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public int ThemeId { get; set; }
    }
}
