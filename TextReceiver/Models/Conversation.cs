using System;
using System.Collections.Generic;

namespace TextReceiver.Models
{
  public class Conversation
  {
    public Guid ConversationId { get; set; }
    public IEnumerable<Contact> Participants { get; set; } 
    public IEnumerable<Message> Messages { get; set; } 
    public string Name { get; set; }

    public Conversation()
    {
      ConversationId = Guid.NewGuid();
    }
  }
}
