using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Contacts;
using TextReceiver.Conversation;
using TextReceiver.Conversations;
using TextReceiver.Models;
using TextReceiver.SelectedConversation;
using TextReceiver.TextReceiverMessages;

namespace TextReceiver.ViewModels
{
  public class ApplicationViewModel : ObservableObject, IViewModel
  {

    private IViewModel _currentViewModel;
    private IViewModel _conversationsViewModel;
    private IViewModel _conversationViewModel;
    private List<IViewModel> _viewModels;

    public IViewModel CurrentViewModel
    {
      get { return _currentViewModel; }
      set
      {
        if (_currentViewModel != value)
        {
          _currentViewModel = value;
          OnPropertyChanged("CurrentViewModel");
        }
      }
    }
    public List<IViewModel> ViewModels => _viewModels ?? (_viewModels = new List<IViewModel>());

    public ApplicationViewModel()
    {
      Messenger.Default.Register<ConversationSelected>(this, (conversationSelectedMessage) =>
      {
        ChangeViewModel(_conversationViewModel);
      });

      _conversationsViewModel = SimpleIoc.Default.GetInstance<ConversationsViewModel>();
      _conversationViewModel = SimpleIoc.Default.GetInstance<SelectedConversationViewModel>();

      ViewModels.Add(_conversationsViewModel);
      ViewModels.Add(_conversationViewModel);

      CurrentViewModel = ViewModels[0];
    }

    private void ChangeViewModel(IViewModel viewModel)
    {
      if (!ViewModels.Contains(viewModel))
      {
        ViewModels.Add(viewModel);
      }
      CurrentViewModel = viewModel;
    }

  }
}
