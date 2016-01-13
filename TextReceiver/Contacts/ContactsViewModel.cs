using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TextReceiver.Contact;
using TextReceiver.TextReceiverMessages;
using TextReceiver.ViewModels;

namespace TextReceiver.Contacts
{
  public class ContactsViewModel : IViewModel
  {
    private List<Models.Contact> _contacts = new List<Models.Contact>()
    {
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derolle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionusselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="ne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Kee Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Kene Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Kene Dusselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Deroule", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Deselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keionne Dsselle", PhoneNumber="3377395608"}
    };
    public ObservableCollection<ContactViewModel> Contacts { get; set; } 
    public Models.Contact SelectedContact { get; set; } 
    public ContactsViewModel()
    {
        var contactViewModels = _contacts.Select(c => new ContactViewModel
        {
            Contact = c
        });
      Contacts = new ObservableCollection<ContactViewModel>(contactViewModels);
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
