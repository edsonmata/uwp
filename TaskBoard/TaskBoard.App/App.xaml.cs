using Microsoft.EntityFrameworkCore;
using Prism.Unity.Windows;
using System.IO;
using System.Threading.Tasks;
using TaskBoard.App.Repositories;
using TaskBoard.App.Repositories.Sql;
using TaskBoard.App.Services;
using TaskBoard.App.Util;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;

namespace TaskBoard.App
{
    sealed partial class App : PrismUnityApplication
    {
        public static ITaskBoardRepository Repository { get; private set; }

        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            UseSqlite();

            NavigationService.Navigate(PageTokens.MainPage, null);
            return Task.FromResult<object>(null);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(ICardService), typeof(CardService), true);
            RegisterTypeIfMissing(typeof(ICardGroupService), typeof(CardGroupService), true);
            RegisterTypeIfMissing(typeof(IBoardService), typeof(BoardService), true);            
        }

        /// <summary>
        /// Configures the app to use the Sqlite data source. If no existing Sqlite database exists, 
        /// loads a demo database filled with fake data so the app has content.
        /// </summary>
        public static void UseSqlite()
        {
            string demoDatabasePath = Package.Current.InstalledLocation.Path + @"\Assets\TaskBoard.db";
            string databasePath = ApplicationData.Current.LocalFolder.Path + @"\TaskBoard.db";
            if (!File.Exists(databasePath))
            {
                File.Copy(demoDatabasePath, databasePath);
            }
            var dbOptions = new DbContextOptionsBuilder<TaskBoardContext>().UseSqlite(
                "Data Source=" + databasePath);
            Repository = new SqlTaskBoardRepository(dbOptions);
        }

    }
}
