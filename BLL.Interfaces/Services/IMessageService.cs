using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IMessageService
    {
        MessageEntity GetMessageEntityById(int id);
        IEnumerable<MessageEntity> GetAllMessageEntities();
        IEnumerable<MessageEntity> GetMessagesByThemeId(int themeId);
        void CreateMessage(MessageEntity message);
        void DeleteMessage(MessageEntity message);
        void UpdateMessage(MessageEntity message);
    }
}
