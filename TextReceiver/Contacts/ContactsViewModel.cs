using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Contacts
{
  public class ContactsViewModel : IViewModel
  {
    public ContactsViewModel()
    {
      Messenger.Default.Register<ContactClicked>(this, (contactClickedMessage) => {
        OnContactSelected(contactClickedMessage.ContactId);
      });
    }
    private void OnContactSelected(Guid contactId)
    {
      MessageBox.Show("contact was selected " + contactId);
      Messenger.Default.Send(new ContactSelected()
      {
        ContactId = contactId
      });
    }
  }
}
