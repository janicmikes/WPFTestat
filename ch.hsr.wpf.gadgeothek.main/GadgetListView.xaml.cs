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
using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for GadgetListView.xaml
    /// </summary>
    public partial class GadgetListView : UserControl
    {
        public static String ServerUrl { get; set; } = "http://localhost:8080";

        public ObservableCollection<Gadget> AllGadgets  {get; set;}

        private readonly LibraryAdminService _service = new LibraryAdminService(ServerUrl);


        public GadgetListView()
        {
            InitializeComponent();
            PullGadgetList();

            DataContext = this;
        }

        private void PullGadgetList()
        {
            AllGadgets = new ObservableCollection<Gadget>();

            foreach (var gadget in _service.GetAllGadgets())
            {
                AllGadgets.Add(gadget);
            }
        }


    }
}
