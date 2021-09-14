using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Azure;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace AzureUpload
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TableUI : Window
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=learnstorageaccount001;AccountKey=fiUXL1c4rppKOoEb3ZvI/axa2YwSuIWopLB/l6fS0OYdOJbvRZJilBzbtbyrc1o3HxETCRK6M76tXbPnja3cYg==;EndpointSuffix=core.windows.net";
        string tableName = "learntable";
        public TableUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudStorageAccount.CreateCloudTableClient();
            var table=tableClient.GetTableReference(tableName);
            var records = table.CreateQuery<Customer>().Where(q=>q.PartitionKey==partionkey.Text).ToList();
            lstRecord.Items.Clear();
            records.ForEach(q => { lstRecord.Items.Add(q.Name); });
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudStorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            var customer = new Customer() { PartitionKey = partionkey.Text, RowKey = rowKey.Text, Timestamp = DateTime.Now, Name=CustomerName.Text };

            var tableOperation = TableOperation.Insert(customer);
            var result = table.Execute(tableOperation);
            MessageBox.Show("Inserted");
        }
    }
}
