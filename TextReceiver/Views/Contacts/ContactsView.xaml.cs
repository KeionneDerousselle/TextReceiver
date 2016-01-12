using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextReceiver.ViewModels;

namespace TextReceiver.Views
{
  /// <summary>
  /// Interaction logic for ContactsView.xaml
  /// </summary>
  public partial class ContactsView : UserControl
  {
    public static readonly RoutedEvent ContactSelectedEvent = EventManager.RegisterRoutedEvent("ContactSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContactView));

    public event RoutedEventHandler ContactClicked
    {
      add { AddHandler(ContactSelectedEvent, value); }
      remove { RemoveHandler(ContactSelectedEvent, value); }
    }
    public ContactsView()
    {
      DataContext = new ContactsViewModel();
      InitializeComponent();
    }

    //private void On_Contact_Selected(object sender, System.Windows.RoutedEventArgs e)
    //{
    //  this.RaiseEvent(new RoutedEventArgs(ContactSelectedEvent, this));
    //}
  }
}
