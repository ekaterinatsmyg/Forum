using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using BLL.Mappers;

namespace BLL.Services
{
    public class MessageService: IMessageService
    {
        private readonly IUnitOfWork uow;
        private readonly IMessageRepository messageRepository;

        public MessageService(IUnitOfWork uow, IMessageRepository repository)
        {
            this.uow = uow;
            this.messageRepository = repository;
        }
        public MessageEntity GetMessageEntityById(int id)
        {
            return messageRepository.GetById(id).ToBllMessage();
        }

        public IEnumerable<MessageEntity> GetAllMessageEntities()
        {
            return messageRepository.GetAll().Select(message => message.ToBllMessage());
        }
        public IEnumerable<MessageEntity> GetMessagesByThemeId(int themeId)
        {
            return messageRepository.GetByThemeId(themeId).Select(message => message.ToBllMessage());
        }
        public void CreateMessage(MessageEntity message)
        {
            messageRepository.Create(message.ToDalMessage());
            uow.Commit();
        }

        public void DeleteMessage(MessageEntity message)
        {
            messageRepository.Delete(message.ToDalMessage());
            uow.Commit();
        }

        public void UpdateMessage(MessageEntity message)
        {
            messageRepository.Update(message.ToDalMessage());
            uow.Commit();
        }
    }
}
