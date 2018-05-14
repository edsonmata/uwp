using MyTrello.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyTrello.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        public HomePageViewModel ViewModel
        {
            get => (HomePageViewModel)this.DataContext;
        }

        private void ListView_DragLeave(object sender, Windows.UI.Xaml.DragEventArgs e)
        {

        }

        private void ListView_DragEnter(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            //VisualStateManager.GoToState(this, "Inside", true);

        }

        private void ListView_Drop(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
        }

        private void SourceGrid_DragStarting(Windows.UI.Xaml.UIElement sender, Windows.UI.Xaml.DragStartingEventArgs args)
        {
        }
    }
}
