using System;
using TextReceiver.ViewModels;

namespace TextReceiver.Message
{
  public class MessageViewModel : IViewModel
  {
    public Models.Message Message { get; set; }
  }
}
