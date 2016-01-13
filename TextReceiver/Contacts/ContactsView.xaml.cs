using System.Windows.Controls;

namespace TextReceiver.Contacts
{
  /// <summary>
  /// Interaction logic for ContactsView.xaml
  /// </summary>
  public partial class ContactsView : UserControl
  {
    public ContactsView()
    {
      DataContext = new ContactsViewModel();
      InitializeComponent();
    }
  }
}
