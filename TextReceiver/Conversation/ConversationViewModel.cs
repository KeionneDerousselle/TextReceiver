using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Commands;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Conversation
{
  public class ConversationViewModel : IViewModel
  {
    private ICommand _conversationClicked;

    public Models.Conversation Conversation { get; set; }
    public ICommand ConversationClickedCommand
    {
      get
      {
        if (_conversationClicked == null)
        {
          _conversationClicked = new RelayCommand(On_Conversation_Clicked);
        }
        return _conversationClicked;
      }
    }
    private void On_Conversation_Clicked(object sender)
    {
      MessageBox.Show("conversation was clicked");
      Messenger.Default.Send(new ConversationClicked()
      {
        ConversationId = Conversation.ConversationId
      });
    }
  }
}
