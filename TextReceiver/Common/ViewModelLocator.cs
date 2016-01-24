using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TextReceiver.Contacts;
using TextReceiver.Conversations;
using TextReceiver.SelectedConversation;
using TextReceiver.ViewModels;

namespace TextReceiver.Common
{
  public class ViewModelLocator
  {
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      SimpleIoc.Default.Register<ConversationsViewModel>();
      SimpleIoc.Default.Register<SelectedConversationViewModel>();
    }

    public ApplicationViewModel ApplicationViewModel => ServiceLocator.Current.GetInstance<ApplicationViewModel>();
    public ConversationsViewModel ConversationsViewModel => ServiceLocator.Current.GetInstance<ConversationsViewModel>();
    public SelectedConversationViewModel ConversationViewModel => ServiceLocator.Current.GetInstance<SelectedConversationViewModel>();
  }
}
