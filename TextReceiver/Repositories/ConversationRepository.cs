using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseSharp.Portable;
using Newtonsoft.Json;

namespace TextReceiver.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        public async Task<Models.Conversation> GetConversationById(Guid conversationId)
        {
            Firebase fb = new Firebase("https://text-receiver.firebaseio.com/");
            var path = "/conversations";
            string data = await fb.GetAsync(path);
            IEnumerable<Models.Conversation> conversations = JsonConvert.DeserializeObject<IEnumerable<Models.Conversation>>(data);
            return conversations.FirstOrDefault(c => c.ConversationId.Equals(conversationId));
        }

        public async Task<IEnumerable<Models.Conversation>> GetAllConversations()
        {
            Firebase fb = new Firebase("https://text-receiver.firebaseio.com/");
            var path = "/conversations";
            string data = await fb.GetAsync(path);
            IEnumerable<Models.Conversation> conversations = JsonConvert.DeserializeObject<IEnumerable<Models.Conversation>>(data);
            return conversations;
        }
    }
}
