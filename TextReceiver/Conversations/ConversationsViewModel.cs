using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Conversation;
using TextReceiver.Repositories;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Conversations
{
    public class ConversationsViewModel : IViewModel
    {
        private IEnumerable<Models.Conversation> _conversations;
        private IConversationRepository _convoRepo;
        public ObservableCollection<ConversationViewModel> Conversations { get; set; }

        public ConversationsViewModel(IConversationRepository convoRepo)
        {
            _convoRepo = convoRepo;
            Conversations = new ObservableCollection<ConversationViewModel>();

            Messenger.Default.Register<ConversationClicked>(this, (conversationClickedMessage) =>
            {
                OnConversationSelected(conversationClickedMessage.ConversationId);
            });

            GetAllConversations();
        }

        private async void GetAllConversations()
        {
            _conversations = await _convoRepo.GetAllConversations();
            if (_conversations.Any())
            {
                OnConversationSelected(_conversations.First().ConversationId);
            }
            foreach (var conversation in _conversations)
            {
                Conversations.Add(new ConversationViewModel {Conversation = conversation});
            }
        }
        private void OnConversationSelected(Guid conversationId)
        {
            Messenger.Default.Send(new ConversationSelected() { ConversationId = conversationId });
        }
    }
}
