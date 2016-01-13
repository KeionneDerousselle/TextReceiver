using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Commands;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Contact
{
  public class ContactViewModel : IViewModel
  {
    private ICommand _contactClicked;
    public ICommand ContactClickedCommand
    {
      get
      {
        if (_contactClicked == null)
        {
          _contactClicked = new RelayCommand(On_Contact_Clicked);
        }
        return _contactClicked;
      }
      set { _contactClicked = value; }
    }

    private void On_Contact_Clicked(object sender)
    {
      MessageBox.Show("contact was clicked");
      Messenger.Default.Send<ContactClicked>(new ContactClicked()
      {
        ContactId = Guid.NewGuid()
      });
    }
  }
}
