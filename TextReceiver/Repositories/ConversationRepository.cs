using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseSharp.Portable;

namespace TextReceiver.Repositories
{
  public class ConversationRepository : IConversationRepository
  {
    public async Task<Models.Conversation> GetConversationById(Guid conversationId)
    {
      Firebase fb = new Firebase("https://text-receiver.firebaseio.com/");
      var path = "/conversations";
      string data = await fb.GetAsync(path);
      Console.WriteLine(data);
      return new Models.Conversation();
    }

    public Task<IEnumerable<Models.Conversation>> GetAllConversations()
    {
      throw new NotImplementedException();
    }
  }
}
