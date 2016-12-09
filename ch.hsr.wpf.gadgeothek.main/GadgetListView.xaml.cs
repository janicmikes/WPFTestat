using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;
using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek.main.ViewModel;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for GadgetListView.xaml
    /// </summary>
    public partial class GadgetListView : UserControl
    {
        //public static String ServerUrl { get; set; } = ConfigurationManager.AppSettings["server"].ToString();


        private Gadget _currentGadget;
        //private readonly LibraryAdminService _service = new LibraryAdminService(ServerUrl);

        public GadgetListViewModel GadgetListViewModel;

        public GadgetListView()
        {
            InitializeComponent();
            GadgetListViewModel = new GadgetListViewModel();
            DataContext = GadgetListViewModel;
        }


        private void ButtonAddNewGadget_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("start with a new Gadget");
            GadgetListViewModel.ShowSingleGadget(null);
        }
        private void ButtonDeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGadget == null)
            {
                MessageBox.Show("Please first select a gadget");
                return;
            }
            GadgetListViewModel.DeleteGadget(_currentGadget);

            _currentGadget = null;
        }

        private void MouseDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            GadgetListViewModel.ShowSingleGadget((Gadget)((DataGrid)sender).SelectedItem);
        }


        private void SaveCurrentGadgetHandler(object sender, RoutedEventArgs e)
        {
            _currentGadget = (Gadget) ((DataGrid) sender).SelectedItem;
        }
    }
}
