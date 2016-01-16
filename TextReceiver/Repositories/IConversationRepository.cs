using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReceiver.Repositories
{
  public interface IConversationRepository
  {
    Task<Models.Conversation> GetConversationById(Guid conversationId);
    Task<IEnumerable<Models.Conversation>>  GetAllConversations();
  }
}
