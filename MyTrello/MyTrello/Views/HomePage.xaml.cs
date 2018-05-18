using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using MyTrello.ViewModels;
using MyTrello.Models;

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

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            // Our list only accepts text
            e.AcceptedOperation = (e.DataView.Contains(StandardDataFormats.Text)) ? DataPackageOperation.Move : DataPackageOperation.None;
        }

        private async void ListView_Drop(object sender, DragEventArgs e)
        {
            // This test is in theory not needed as we returned DataPackageOperation.None if
            // the DataPackage did not contained text. However, it is always better if each
            // method is robust by itself
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                // We need to take a Deferral as we won't be able to confirm the end
                // of the operation synchronously
                var def = e.GetDeferral();
                var s = await e.DataView.GetTextAsync();
                var items = s.Split('\n');


                var listViewSource = e.OriginalSource as ListView;
                var cardsListSource = listViewSource.DataContext as CardsList;





                foreach (var item in items)
                {
                    
                }
                e.AcceptedOperation = DataPackageOperation.Copy;
                def.Complete();
            }
        }

        private void ListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            // The ListView is declared with selection mode set to Single.
            // But we want the code to be robust
            if (e.Items.Count == 1)
            {
                var element = e.Items[0] as Card;
                e.Data.SetText(element.ID.ToString());
                // Reorder or move to trash are always a move
                e.Data.RequestedOperation = DataPackageOperation.Move;
                //_deletedItem = null;
            }
        }

        private void TargetListView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            // args.DropResult is always Move and therefore we have to rely on _deletedItem to distinguish
            // between reorder and move to trash
            // Another solution would be to listen for events in the ObservableCollection
            //if (_deletedItem != null)
            //{
            //    _selection.Remove(_deletedItem);
            //    _deletedItem = null;
            //}
        }
    }
}
