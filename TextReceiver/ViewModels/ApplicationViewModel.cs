﻿using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using TextReceiver.Commands;
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
            _currentNavModel = SimpleIoc.Default.GetInstance<ConversationsViewModel>();
            _currentContentModel = SimpleIoc.Default.GetInstance<SelectedConversationViewModel>();
        }

        private void ToggleUserMenu(object obj)
        {
            UserMenuIsOpen = !UserMenuIsOpen;
        }

    }
}
