using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using Entities;

namespace DAL.Realization
{
    public class MessageRepository: IMessageRepository
    {
        private readonly DbContext context;

        public MessageRepository(DbContext _context)
        {
            this.context = _context;            
        }
        public IEnumerable<DalMessage> GetAll()
        {
            return context.Set<Message>().Select(message => new DalMessage()
                {
                    Id = message.Id,
                    Content = message.Content,
                    DatePublication = message.DatePublication,
                    SenderId = message.SenderId,
                    ThemeId = message.ThemeId
                });
        }

        public DalMessage GetById(int entityId)
        {
            var message = context.Set<Message>().Where(m => m.Id == entityId).FirstOrDefault();
            return new DalMessage()
            {
                Id = message.Id,
                Content = message.Content,
                DatePublication = message.DatePublication,
                SenderId = message.SenderId,
                ThemeId = message.ThemeId
            };
        }

        public IEnumerable<DalMessage> GetByThemeId(int themeId)
        {
            return context.Set<Message>().Where(message => message.ThemeId == themeId).Select(message => new DalMessage()
            {
                Id = message.Id,
                Content = message.Content,
                DatePublication = message.DatePublication,
                SenderId = message.SenderId,
                ThemeId = message.ThemeId
            });
        }

       

        public void Create(DalMessage entity)
        {
            var message = new Message()
            {
                Id = entity.Id,
                Content = entity.Content,
                DatePublication = entity.DatePublication,
                SenderId = entity.SenderId,
                ThemeId = entity.ThemeId
            };
            context.Set<Message>().Add(message);
        }

        public void Delete(DalMessage entity)
        {
            var message = context.Set<Message>().Where(m => m.Id == entity.Id).FirstOrDefault();
            if (message != null)
            {
                context.Set<Message>().Remove(message);
            }
        }

        public void Update(DalMessage entity)
        {
            var message = context.Set<Message>().Where(m => m.Id == entity.Id).FirstOrDefault();
            if (message != null)
            {
                message.Content = entity.Content;
                message.DatePublication = entity.DatePublication;
                message.SenderId = entity.SenderId;
                message.ThemeId = entity.ThemeId;
            }
        }
    }
}
