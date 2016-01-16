using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using TextReceiver.ViewModels;

namespace TextReceiver
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : MetroWindow
  {
    public MainWindow()
    {
      this.DataContext = new ApplicationViewModel();
      InitializeComponent();
    }
  }
}
