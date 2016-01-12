using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TextReceiver.Commands;
using TextReceiver.Models;

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
      ViewModels.Add(new ConversationViewModel());
      var contactsViewModel = new ContactsViewModel();
      ViewModels.Add(contactsViewModel);

      CurrentViewModel = ViewModels[1];
    }

    private void ChangeViewModel(IViewModel viewModel)
    {
      if (!ViewModels.Contains(viewModel))
      {
        ViewModels.Add(viewModel);
      }
      CurrentViewModel = viewModel;
    }

    private void ContactSelected(object sender, System.Windows.RoutedEventArgs e)
    {
      Console.WriteLine("a contact was selected");
    }
  }
}
