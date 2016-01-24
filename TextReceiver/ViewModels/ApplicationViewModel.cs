using System.Windows.Input;
using Microsoft.Practices.Unity;
using TextReceiver.Commands;
using TextReceiver.Common;
using TextReceiver.Conversations;
using TextReceiver.Models;
using TextReceiver.SelectedConversation;

namespace TextReceiver.ViewModels
{
    public class ApplicationViewModel : ObservableObject, IViewModel
    {
        private ICommand _userMenuClickedCommand;
        private bool _userMenuIsOpen;

        private IViewModel _currentNavModel;
        private IViewModel _currentContentModel;

        public IViewModel CurrentNavModel
        {
            get { return _currentNavModel; }
            set
            {
                if (_currentNavModel != value)
                {
                    _currentNavModel = value;
                    OnPropertyChanged("CurrentNavModel");
                }
            }
        }
        public IViewModel CurrentContentModel
        {
            get { return _currentContentModel; }
            set
            {
                if (_currentContentModel != value)
                {
                    _currentContentModel = value;
                    OnPropertyChanged("CurrentContentModel");
                }
            }
        }

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
            _currentNavModel = UnityIocContainer.Container.Resolve<ConversationsViewModel>();
            _currentContentModel = UnityIocContainer.Container.Resolve<SelectedConversationViewModel>();
        }

        private void ToggleUserMenu(object obj)
        {
            UserMenuIsOpen = !UserMenuIsOpen;
        }
    }
}
