using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private List<Models.Contact> _contacts = new List<Models.Contact>()
    {
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"}
    };
    public ObservableCollection<Models.Contact> Contacts { get; set; } 
    public Models.Contact SelectedContact { get; set; } 
    public ContactsViewModel()
    {
      Contacts = new ObservableCollection<Models.Contact>(_contacts);
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
