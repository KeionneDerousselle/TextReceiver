using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextReceiver.ViewModels
{
  public class ContactsViewModel : IViewModel
  {
    private void On_Contact_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
      Console.WriteLine("was caught here");
      //this.RaiseEvent(new RoutedEventArgs(ContactSelectedEvent, this));
    }
  }
}
