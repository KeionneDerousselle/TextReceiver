using System;

namespace TextReceiver.Models
{
  public class Contact
  {
    public Guid ContactId { get; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] Avatar { get; set; }

    public Contact()
    {
        ContactId = Guid.NewGuid();
    }
  }
}
