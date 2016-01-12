using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReceiver.Models
{
  public class Message
  {
    public Contact Sender { get; set; }
    public Contact Receiver { get; set; }
    public string Content { get; set; }
    public DateTime TimeStamp { get; set; }
  }
}
