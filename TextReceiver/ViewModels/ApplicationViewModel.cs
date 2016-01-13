using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Commands;
using TextReceiver.Contacts;
using TextReceiver.Conversation;
using TextReceiver.Models;
using TextReceiver.TextReceiverMessages;

namespace TextReceiver.ViewModels
{
  public class ApplicationViewModel : ObservableObject, IViewModel
  {
    private ICommand _changePageCommand;

    private IViewModel _currentViewModel;
    private List<IViewModel> _viewModels;

    public ICommand ChangePageCommand {
      get
      {
        if (_changePageCommand == null)
        {
          _changePageCommand = new RelayCommand(p => ChangeViewModel((IViewModel) p), p => p is IViewModel);
        }
        return _changePageCommand;
      }
    }

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
    public List<IViewModel> ViewModels
    {
      get
      {
        if (_viewModels == null)
        {
          _viewModels = new List<IViewModel>();
        }
        return _viewModels;
      }
    }

    public ApplicationViewModel()
    {
      var contactsViewModel = new ContactsViewModel();
      var conversationViewModel = new ConversationViewModel();

      Messenger.Default.Register<ContactSelected>(this, (contactSelectedMessage) =>
      {
        ChangeViewModel(conversationViewModel);
      });

      ViewModels.Add(contactsViewModel);
      ViewModels.Add(conversationViewModel);

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
