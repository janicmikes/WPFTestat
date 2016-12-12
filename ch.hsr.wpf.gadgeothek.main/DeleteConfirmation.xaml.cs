using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using ch.hsr.wpf.gadgeothek.domain;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for DeleteConfirmation.xaml
    /// </summary>
    public partial class DeleteConfirmation : Window
    {
        public DeleteConfirmation(Gadget gadget)
        {
            InitializeComponent();
            DataContext = gadget;
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
