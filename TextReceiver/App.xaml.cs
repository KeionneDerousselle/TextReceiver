using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TextReceiver.Common;
using TextReceiver.ViewModels;

namespace TextReceiver
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private static readonly ViewModelLocator ViewModelLocator = new ViewModelLocator();
    protected override void OnStartup(StartupEventArgs e)
    {
      ResourceDictionary rd = new ResourceDictionary {{"VMLocator", ViewModelLocator}};
      Current.Resources.MergedDictionaries.Add(rd);
      base.OnStartup(e);
    }
  }
}
