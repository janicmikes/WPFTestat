using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ch.hsr.wpf.gadgeothek.main.ViewModel;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for ServerConnectDialog.xaml
    /// </summary>
    public partial class ServerConnectDialog : Window
    {
        public ServerConnectDialog(String serverUrl)
        {
            InitializeComponent();
            TextBoxServerUrl.Text = serverUrl;
        }

        public string Answer
        {
            get { return TextBoxServerUrl.Text; }
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
