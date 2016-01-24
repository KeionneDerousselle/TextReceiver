using Microsoft.Practices.Unity;
using TextReceiver.Repositories;

namespace TextReceiver.Common
{
    public class UnityIocContainer
    {
        private static IUnityContainer _container;

        static UnityIocContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IConversationRepository, ConversationRepository>(
                new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container { get { return _container; } }
    }
}
