using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReceiver.Models
{
  public class Conversation
  {
    public IEnumerable<Contact> Contacts { get; set; } 
    public IEnumerable<Message> Messages { get; set; } 
    public string Name { get; set; }
  }
}
