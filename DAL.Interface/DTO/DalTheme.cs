using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalTheme: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public long CountViews { get; set; }
        public int CreatorId { get; set; }
        public int SectionId { get; set; }
    }
}
