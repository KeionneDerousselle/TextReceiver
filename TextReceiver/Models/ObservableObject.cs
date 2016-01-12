using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextReceiver.Annotations;

namespace TextReceiver.Models
{
  public abstract class ObservableObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      VerifyPropertyName(propertyName);

      if (PropertyChanged != null)
      {
        var e = new PropertyChangedEventArgs(propertyName);
        PropertyChanged(this, e);
      }
    }

    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    public virtual void VerifyPropertyName(string propertyName)
    {
      // Verify that the property name matches a real,
      // public, instance property on this object.
      if (TypeDescriptor.GetProperties(this)[propertyName] == null)
      {
        string msg = "Invalid property name: " + propertyName;

        if (this.ThrowOnInvalidPropertyName)
          throw new Exception(msg);
        else
          Debug.Fail(msg);
      }
    }

    protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
  }
}
