using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Message;
using TextReceiver.Models;
using TextReceiver.Repositories;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.SelectedConversation
{
    public class SelectedConversationViewModel : ObservableObject, IViewModel
    {
        private Models.Conversation _conversation;
        private List<Models.Message> _messages;

        public Models.Conversation Conversation
        {
            get { return _conversation; }
            set
            {
                _conversation = value;
                Messages.Clear();
                foreach (var message in _conversation.Messages)
                {
                    Messages.Add(new MessageViewModel()
                    {
                        Message = message
                    });
                }
                OnPropertyChanged("Conversation");
            }
        }
        public ObservableCollection<MessageViewModel> Messages { get; set; }

        public SelectedConversationViewModel()
        {
            Messages = new ObservableCollection<MessageViewModel>();
            Messenger.Default.Register<ConversationSelected>(this, ChangeSelectedConversation);
        }

        private async void ChangeSelectedConversation(ConversationSelected conversationSelectedMessage)
        {
            ConversationRepository convoRepo = new ConversationRepository();
            Conversation = await convoRepo.GetConversationById(conversationSelectedMessage.ConversationId);      
        }
    }
}
