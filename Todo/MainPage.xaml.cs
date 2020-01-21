using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup;

namespace Todo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        MainPageViewModel<TodoObject> viewModel = new MainPageViewModel<TodoObject>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Read();
            ToolbarItem toolbarItem = this.FindByName("NameLabel") as ToolbarItem;
            toolbarItem.Text = "New";
        }

        void listview_ItemTapped(Object sender, ItemTappedEventArgs e)
        {
            TodoObject item = e.Item as TodoObject;
            viewModel.ToggleCompleted(item);
        }

        void listview_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            deselectCell(sender, e);
        }

        void deselectCell(object sender, SelectedItemChangedEventArgs e)
        {
            if (e?.SelectedItem != null)
            {
                if (sender is ListView lv)
                    lv.SelectedItem = null;
            }
        }

        void AddToolbarItem_Clicked(Object sender, EventArgs e)
        {
            PresentPopup();
        }

        async void PresentPopup()
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new MyPopupPage());
        }

        void OnDelete(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;//((MenuItem)sender);
            TodoObject item = mi.CommandParameter as TodoObject;
            viewModel.Delete(item);
            viewModel.Read();
        }

    }
}
