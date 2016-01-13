using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Conversation;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Conversations
{
  public class ConversationsViewModel : IViewModel
  {
    private Models.Contact keionne = new Models.Contact()
    {
      Name = "Keionne Derousselle",
      PhoneNumber = "3377395608"
    };

    private Models.Contact darrius = new Models.Contact()
    {
      Name = "Darrius Wright",
      PhoneNumber = "4239335970"
    };

    private List<Models.Conversation> _conversations;
    public ObservableCollection<ConversationViewModel> Conversations { get; set; }

    public ConversationsViewModel()
    {
      _conversations = new List<Models.Conversation>()
    {
      new Models.Conversation()
      {
        Name = "convo 1",
        Participants = new List<Models.Contact>()
        {
          keionne,
          darrius
        }
      },
      new Models.Conversation()
      {
        Name="convo 2"
      },
      new Models.Conversation()
      {
        Name = "convo 3"
      },
    };
      var conversationViewModels = _conversations.Select(c => new ConversationViewModel()
      {
        Conversation = c
      });

      Conversations = new ObservableCollection<ConversationViewModel>(conversationViewModels);
      Messenger.Default.Register<ConversationClicked>(this, (conversationClickedMessage) =>
      {
        OnConversationSelected(conversationClickedMessage.ConversationId);
      });
    }
    private void OnConversationSelected(Guid conversationId)
    {
      MessageBox.Show("conversation selected: " + conversationId);
      Messenger.Default.Send(new ConversationSelected() { ConversationId = conversationId });
    }
  }
}
