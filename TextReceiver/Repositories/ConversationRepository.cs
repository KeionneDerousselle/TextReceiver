using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FirebaseSharp.Portable;
using Newtonsoft.Json;

namespace TextReceiver.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly Firebase _fb;
        private readonly string _path = ConfigurationManager.AppSettings["FirebaseConversationsPath"];
        public ConversationRepository(Firebase fb)
        {
            _fb = fb;
        }

        public async Task<Models.Conversation> GetConversationById(Guid conversationId)
        {
            string data = await _fb.GetAsync(_path);
            IEnumerable<Models.Conversation> conversations = JsonConvert.DeserializeObject<IEnumerable<Models.Conversation>>(data);
            return conversations.FirstOrDefault(c => c.ConversationId.Equals(conversationId));
        }

        public async Task<IEnumerable<Models.Conversation>> GetAllConversations()
        {
            string data = await _fb.GetAsync(_path);
            IEnumerable<Models.Conversation> conversations = JsonConvert.DeserializeObject<IEnumerable<Models.Conversation>>(data);
            return conversations;
        }
    }
}
