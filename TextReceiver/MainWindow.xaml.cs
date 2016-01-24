using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using TextReceiver.Common;
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
      DataContext = UnityIocContainer.Container.Resolve<ApplicationViewModel>();
      InitializeComponent();
    }
  }
}
