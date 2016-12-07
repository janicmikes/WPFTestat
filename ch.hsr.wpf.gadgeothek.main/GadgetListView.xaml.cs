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

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for GadgetListView.xaml
    /// </summary>
    public partial class GadgetListView : UserControl
    {
        public ObservableCollection<Gadget> AllGadgets  {get; set;}
        public GadgetListView()
        {
            InitializeComponent();
            InitItems();

            DataContext = this;
        }

        private void InitItems()
        {
            AllGadgets = new ObservableCollection<Gadget>();
            // TODO:  gadgets in liste abfuellen
        }

    }
}
