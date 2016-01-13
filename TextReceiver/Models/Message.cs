using System;
using System.Collections.Generic;

namespace TextReceiver.Models
{
  public class Message
  {
    public Contact Sender { get; set; }
    public IEnumerable<Contact> Receivers { get; set; }
    public string Content { get; set; }
    public DateTime TimeStamp { get; set; }
  }
}
