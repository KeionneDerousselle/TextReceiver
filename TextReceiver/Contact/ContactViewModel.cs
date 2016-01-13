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
    public Models.Contact Contact { get; set; }
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

    public ContactViewModel()
    {
    }

    private void On_Contact_Clicked(object sender)
    {
      MessageBox.Show("contact was clicked");
      Messenger.Default.Send(new ContactClicked()
      {
        ContactId = Contact.ContactId
      });
    }
  }
}
