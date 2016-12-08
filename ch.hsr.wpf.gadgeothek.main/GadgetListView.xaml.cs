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

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for GadgetListView.xaml
    /// </summary>
    public partial class GadgetListView : UserControl
    {
        //public static String ServerUrl { get; set; } = ConfigurationManager.AppSettings["server"].ToString();

        public static ObservableCollection<Gadget> AllGadgets  {get; set;}

        private Gadget _currentGadget;
        //private readonly LibraryAdminService _service = new LibraryAdminService(ServerUrl);


        public GadgetListView()
        {
            InitializeComponent();
            PullGadgetList();

            DataContext = this;
        }

        
        public static void PullGadgetList()
        {
            AllGadgets = new ObservableCollection<Gadget>();

            foreach (var gadget in MainWindow._service.GetAllGadgets())
            {
                AllGadgets.Add(gadget);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("start with a new Gadget");
            _currentGadget = null;
            showSingleGadget();
        }

        private void dataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentGadget = (Gadget)((DataGrid)sender).SelectedItem;
        }

        private void editGadget(object sender, MouseButtonEventArgs e)
        {
            _currentGadget = (Gadget)((DataGrid)sender).SelectedItem;
            showSingleGadget();
        }

        private void showSingleGadget()
        {
            Console.WriteLine("show gadget: " + _currentGadget?.Name);
            SingleGadgetWindow SingleGadgetWindow = new SingleGadgetWindow(_currentGadget);
            if (SingleGadgetWindow.ShowDialog() == true)
            {
                // TODO: Save the Gadget
            }
            else
            {
                // edit was canceled
            }
        }
    }
}
