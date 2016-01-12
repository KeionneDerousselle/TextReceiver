using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TextReceiver.Commands;

namespace TextReceiver.ViewModels
{
  public class ContactsViewModel : IViewModel
  {
    private ICommand _contactSelected;
    public ICommand ContactSelected {
      get {
        if (_contactSelected == null)
        {
          _contactSelected = new RelayCommand(On_Contact_Selected);
        }
        return _contactSelected;
      }
    }

    public ContactsViewModel()
    {
    }
    private void On_Contact_Selected(object sender)
    {
      Console.WriteLine("was caught here");
      //this.RaiseEvent(new RoutedEventArgs(ContactSelectedEvent, this));
    }
  }
}
