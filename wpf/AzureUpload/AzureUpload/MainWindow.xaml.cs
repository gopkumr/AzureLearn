using Azure.Storage.Blobs.Specialized;
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
    public partial class MainWindow : Window
    {
        string filePath;
        OpenFileDialog fileDialog;
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=learnstorageaccount001;AccountKey=ZDGsLRLolPI1xZm9sFHQ/jGCPlWRjhwIh27X43rRHeeoskwtAYxpqmPFuuc+bIlKorqcvO6WEswd6bDyJDI/4w==;EndpointSuffix=core.windows.net";
        string containerName = "learnstoragecontainer";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileDialog = new OpenFileDialog();
            fileDialog.FileOk += FileDialog_FileOk;
            fileDialog.ShowDialog();
            
        }

        private void FileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lblFilename.Content = fileDialog.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var blobServiceClient = new Azure.Storage.Blobs.BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
         
            var fileStream = File.OpenRead(fileDialog.FileName);
            containerClient.UploadBlob(fileDialog.SafeFileName, fileStream);
            MessageBox.Show("Uploaded");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var blobServiceClient = new Azure.Storage.Blobs.BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobs = containerClient.GetBlobs();
            lstData.Items.Clear();
            foreach (var blob in blobs)
            {
                lstData.Items.Add(blob.Name);
            }
        }

        BlobLeaseClient leaseClient;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var blobServiceClient = new Azure.Storage.Blobs.BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            leaseClient=containerClient.GetBlobLeaseClient();
            var leaseResponse = leaseClient.Acquire(TimeSpan.FromMinutes(5));
            MessageBox.Show("Lease acquired");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            leaseClient.Release();
            MessageBox.Show("Lease released");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var tableUI = new TableUI();
            tableUI.ShowDialog();
                
        }
    }
}
