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
      new Models.Contact() { Name="Darrius Wright", PhoneNumber="4239335970"},
      new Models.Contact() { Name="Kassi Chevalier", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Emma Derousselle", PhoneNumber="3377399915"},
      new Models.Contact() { Name="Kathryn Davis", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Tailar Chevalier", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Keri Derousselle", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Erin Collopy", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Lynus", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Bobby Joe", PhoneNumber="3377395608"},
      new Models.Contact() { Name="Billy Bob", PhoneNumber="3377395608"}
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
