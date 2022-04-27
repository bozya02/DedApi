using DedApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DedApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntriesListPage : ContentPage
    {
        public List<EntryModel> Entries { get; set; }
        
        public EntriesListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Entries = await App.RequestManager.GetEntrieModels();
            lvEntries.ItemsSource = Entries;
        }

        private void sbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = sbSearch.Text.ToLower();


            lvEntries.ItemsSource = Entries.Where(en => en.API.ToLower().Contains(searchText) || en.Description.ToLower().Contains(searchText));
        }

        private async void lvEntries_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var entry = lvEntries.SelectedItem as EntryModel;

            await Navigation.PushAsync(new EntryPage(entry));
        }
    }
}