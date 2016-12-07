using ch.hsr.wpf.gadgeothek.domain;
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

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for SingleGadgetWindow.xaml
    /// </summary>
    public partial class SingleGadgetWindow : Window
    {
        private Gadget CurrentGadget { get; set; }
        public SingleGadgetWindow(Gadget gadget)
        {
            InitializeComponent();
            CurrentGadget = gadget;
            DataContext = CurrentGadget;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
