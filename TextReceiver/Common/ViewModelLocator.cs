using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TextReceiver.Contact;
using TextReceiver.Contacts;
using TextReceiver.Conversation;
using TextReceiver.ViewModels;

namespace TextReceiver.Common
{
  public class ViewModelLocator
  {
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      SimpleIoc.Default.Register<ApplicationViewModel>();
      SimpleIoc.Default.Register<ContactViewModel>();
      SimpleIoc.Default.Register<ContactsViewModel>();
      SimpleIoc.Default.Register<ConversationViewModel>();
    }

    public ApplicationViewModel ApplicationViewModel => ServiceLocator.Current.GetInstance<ApplicationViewModel>();
    public ContactViewModel ContactViewModel => ServiceLocator.Current.GetInstance<ContactViewModel>();
    public ContactsViewModel ContactsViewModel => ServiceLocator.Current.GetInstance<ContactsViewModel>();
    public ConversationViewModel ConversationViewModel => ServiceLocator.Current.GetInstance<ConversationViewModel>();
  }
}
