using ch.hsr.wpf.gadgeothek.main.ViewModel;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Controller
        public GadgeothekApp GadgeothekApp = new GadgeothekApp();

        public MainWindow()
        {  
            InitializeComponent();
            this.DataContext = GadgeothekApp;

            GadgeothekApp.GadgetListViewModel = GadgetListView.GadgetListViewModel;
            GadgetListView.GadgetListViewModel.GadgeothekApp = GadgeothekApp;
            GadgetListView.GadgetListViewModel.PullGadgetList();

            

            ReservationsView.ReservationsViewModel.GadgeothekApp = GadgeothekApp;
            ReservationsView.ReservationsViewModel.PullReservationsList();
        }

        private void AboutUsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Gadgeothek Admin Tool\n See: https://github.com/janicmikes/WPFTestat for more Info", "About",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void ConnectToServerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ServerConnectDialog serverConnectDialog = new ServerConnectDialog();
            if (serverConnectDialog.ShowDialog() == true)
            {
                if (GadgeothekApp.ServerUrl != serverConnectDialog.Answer)
                {
                    GadgeothekApp.ServerUrl = serverConnectDialog.Answer;
                    GadgeothekApp.Service = new LibraryAdminService(GadgeothekApp.ServerUrl);
                }
            }
        }

    }

}
