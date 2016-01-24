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
      DataContext = new ApplicationViewModel();
      InitializeComponent();
    }
  }
}
