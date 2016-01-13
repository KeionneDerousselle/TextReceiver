using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Contacts;
using TextReceiver.Conversation;
using TextReceiver.Models;
using TextReceiver.TextReceiverMessages;

namespace TextReceiver.ViewModels
{
  public class ApplicationViewModel : ObservableObject, IViewModel
  {

    private IViewModel _currentViewModel;
    private IViewModel _contactsViewModel;
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
      Messenger.Default.Register<ContactSelected>(this, (contactSelectedMessage) =>
      {
        MessageBox.Show("switch the page");
        ChangeViewModel(_conversationViewModel);
      });

      _contactsViewModel = SimpleIoc.Default.GetInstance<ContactsViewModel>();
      _conversationViewModel = SimpleIoc.Default.GetInstance<ConversationViewModel>();

      ViewModels.Add(_contactsViewModel);
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

      MessageBox.Show("new view model selected");
    }

  }
}
