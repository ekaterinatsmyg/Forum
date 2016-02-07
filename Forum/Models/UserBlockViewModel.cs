using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace Forum.Models
{
    public class UserBlockViewModel
    {
        public int UserBlockId { get; set; }
        public IEnumerable<UserEntity> Users { get; set; }
    }
}