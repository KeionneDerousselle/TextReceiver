using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TextReceiver.Commands;
using TextReceiver.ViewModels;

namespace TextReceiver.Contacts
{
  public class ContactsViewModel : IViewModel
  {
    private ICommand _contactSelected;
    public ContactSelectedDelegate ContactSelected { get; set; }

    public ICommand ContactSelectedCommand {
      get {
        if (_contactSelected == null)
        {
          _contactSelected = new RelayCommand(On_Contact_Selected);
        }
        return _contactSelected;
      }
      set { _contactSelected = value; }
    }

    public ContactsViewModel()
    {
    }
    private void On_Contact_Selected(object sender)
    {
      MessageBox.Show("contact was selected");
      ContactSelected?.Invoke(sender);
    }
  }
}
