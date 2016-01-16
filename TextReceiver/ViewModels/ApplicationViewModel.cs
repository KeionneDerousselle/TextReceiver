using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Commands;
using TextReceiver.Conversations;
using TextReceiver.Models;
using TextReceiver.SelectedConversation;
using TextReceiver.TextReceiverMessages;

namespace TextReceiver.ViewModels
{
  public class ApplicationViewModel : ObservableObject, IViewModel
  {
    private ICommand _userMenuClickedCommand;
    private bool _userMenuIsOpen;

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

    public ICommand UserMenuClickedCommand
    {
      get
      {
        if (_userMenuClickedCommand == null)
        { _userMenuClickedCommand = new RelayCommand(ToggleUserMenu); }
        return _userMenuClickedCommand;
      }
      set { _userMenuClickedCommand = value; }
    }

    public bool UserMenuIsOpen
    {
      get { return _userMenuIsOpen; }
      set
      {
        _userMenuIsOpen = value;
        OnPropertyChanged("UserMenuIsOpen");
      }
    }

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

    private void ToggleUserMenu(object obj)
    {
      //bool currentlyOpen = userMenuButton.ContextMenu.IsOpen;
      //userMenuButton.ContextMenu.IsEnabled = !currentlyOpen;
      //if (!currentlyOpen)
      //{
      //  userMenuButton.ContextMenu.PlacementTarget = userMenuButton;
      //  userMenuButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
      //}
      //userMenuButton.ContextMenu.IsOpen = !currentlyOpen;
      UserMenuIsOpen = !UserMenuIsOpen;
    }

  }
}
