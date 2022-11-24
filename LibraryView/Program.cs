using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace LibraryView
{
    public static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBookStorage, BookStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBookLogic, BookLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGenreStorage, GenreStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGenreLogic, GenreLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}