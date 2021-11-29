using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Todo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridPage : Page
    {
        public GridPage()
        {
            this.InitializeComponent();
        }

        private async void btLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await PopulateDataGrid();
            }
            catch (Exception ex)
            {
                ContentDialog noWifiDialog = new ContentDialog()
                {
                    Title = "Errore",
                    Content = ex.Message,
                    CloseButtonText = "Ok"
                };

                await noWifiDialog.ShowAsync();
            }
        }

        private async Task PopulateDataGrid()
        {
            string uri = "http://localhost:5000/api/Rest";
            HttpClient httpClient = new();

            using var httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); 
            string json = await httpResponse.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<TodoActivity>>(json);

            var model = new TodoActivityViewModel
            {
                Activities = data
            };
            this.DataContext = model;
        }
    }
}
