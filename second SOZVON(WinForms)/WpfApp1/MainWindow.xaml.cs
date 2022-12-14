using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void asyncButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.Now;

            await RunDownloadAsync();

            TimeSpan elapsed = DateTime.Now - start;

            resultTextBlock.Text += $"Total execution time: {elapsed.TotalMilliseconds}";
        }

        private void syncButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.Now;

            RunDownload();

            TimeSpan elapsed = DateTime.Now - start;

            resultTextBlock.Text += $"Total execution time: {elapsed.TotalMilliseconds}";
        }

        private void RunDownload()
        {
            var data = PrepData();
            foreach (var site in data)
            {
                var result = DownloadWebsite(site);
                ReportWebsiteInfo(result);
            }
        }

        private async Task RunDownloadAsync()
        {
            var data = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var item in data)
            {
                tasks.Add(DownloadWebsiteAsync(item));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.codeproject.com",
            };

            resultTextBlock.Text = "";

            return output;
        }
        
        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.Url = websiteURL;
            output.Data = client.DownloadString(websiteURL);

            return output;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        {
            var client = new WebClient();

            var output = new WebsiteDataModel
            {
                Url = websiteURL,
                Data = await client.DownloadStringTaskAsync(websiteURL)
            };

            return output;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultTextBlock.Text += $"{data.Url} downloaded: {data.Data.Length} characters long.\n";
        }
    }
}
