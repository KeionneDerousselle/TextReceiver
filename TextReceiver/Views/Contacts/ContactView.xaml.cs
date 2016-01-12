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

namespace TextReceiver.Views
{
  /// <summary>
  /// Interaction logic for ContactView.xaml
  /// </summary>
  public partial class ContactView : UserControl
  {
    public static readonly RoutedEvent ContactClickedEvent = EventManager.RegisterRoutedEvent("ContactClicked",
      RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ContactView)); 
    public event RoutedEventHandler ContactClicked
    {
      add { AddHandler(ContactClickedEvent, value);}
      remove { RemoveHandler(ContactClickedEvent, value);}
    }

    public ContactView()
    {
      InitializeComponent();
    }

    private void On_Contact_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      this.RaiseEvent(new RoutedEventArgs(ContactClickedEvent, this));
    }
  }
}
