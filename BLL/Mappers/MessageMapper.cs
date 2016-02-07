using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class MessageMapper
    {
        public static MessageEntity ToBllMessage(this DalMessage dalMessage)
        {
            if (dalMessage != null)
            {
                return new MessageEntity()
                {
                    Id = dalMessage.Id,
                    SenderId = dalMessage.SenderId,
                    ThemeId = dalMessage.ThemeId,
                    DatePublication = dalMessage.DatePublication,
                    Content = dalMessage.Content
                };
            }
            return null;
        }

        public static DalMessage ToDalMessage(this MessageEntity entityMessage)
        {
            if (entityMessage != null)
            {
                return new DalMessage()
                {
                    Id = entityMessage.Id,
                    SenderId = entityMessage.SenderId,
                    ThemeId = entityMessage.ThemeId,
                    DatePublication = entityMessage.DatePublication,
                    Content = entityMessage.Content
                };
            } 
            return null;
        }
    }
}
