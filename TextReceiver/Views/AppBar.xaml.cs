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
  /// Interaction logic for AppBar.xaml
  /// </summary>
  public partial class AppBar : UserControl
  {
    public AppBar()
    {
      InitializeComponent();
    }

    private void Expand_User_Menu(object sender, RoutedEventArgs e)
    {
      Button userMenuButton = (sender as Button);

      ToggleUserMenu(userMenuButton);
    }

    private void ToggleUserMenu(Button userMenuButton)
    {
      bool currentlyOpen = userMenuButton.ContextMenu.IsOpen;
      userMenuButton.ContextMenu.IsEnabled = !currentlyOpen;
      if (!currentlyOpen)
      {
        userMenuButton.ContextMenu.PlacementTarget = userMenuButton;
        userMenuButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
      }
      userMenuButton.ContextMenu.IsOpen = !currentlyOpen;
    }
  }
}
