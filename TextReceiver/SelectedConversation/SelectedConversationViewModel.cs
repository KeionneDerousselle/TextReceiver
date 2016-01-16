using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextReceiver.Message;
using TextReceiver.Models;
using TextReceiver.ViewModels;

namespace TextReceiver.SelectedConversation
{
  public class SelectedConversationViewModel : ObservableObject, IViewModel
  {
    private Models.Conversation _conversation;
    private List<Models.Message> _messages; 

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



    public Models.Conversation Conversation
    {
      get { return _conversation; }
      set { _conversation = value;
        OnPropertyChanged("Conversation");
      }
    }
    public ObservableCollection<MessageViewModel> Messages { get; set; }

    public SelectedConversationViewModel()
    {
      _messages = new List<Models.Message>()
      {
        new Models.Message()
        {
          Content = "Hi",
          Sender = keionne,
          Receivers = new List<Models.Contact>()
          {
            darrius
          }
        },
        new Models.Message()
        {
          Content = "hello",
          Sender = darrius,
          Receivers = new List<Models.Contact>()
          {
            keionne
          }
        },
        new Models.Message()
        {
          Content = "sup?",
          Sender = keionne,
          Receivers = new List<Models.Contact>()
          {
            darrius
          }
        },
        new Models.Message()
        {
          Content = "nm",
          Sender = darrius,
          Receivers = new List<Models.Contact>()
          {
            keionne
          }
        },
        new Models.Message()
        {
          Content = "cool",
          Sender = keionne,
          Receivers = new List<Models.Contact>()
          {
            darrius
          }
        },
        new Models.Message()
        {
          Content = "yup",
          Sender = darrius,
          Receivers = new List<Models.Contact>()
          {
            keionne
          }
        }
      };
      var messageViewModels = _messages.Select(m => new MessageViewModel()
      {
        Message = m
      });
      Messages = new ObservableCollection<MessageViewModel>(messageViewModels);
      _conversation = new Models.Conversation()
      {
        Participants = new List<Models.Contact>()
        {
          keionne,
          darrius
        },
        Messages = _messages
      };
  
      Conversation = _conversation;
    }

  }
}
