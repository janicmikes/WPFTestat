using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Condition = ch.hsr.wpf.gadgeothek.domain.Condition;

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
            Gadget gadget = new Gadget
            {
                InventoryNumber = ID.Text,
                Name = Name.Text,
                Price = Double.Parse(Price.Text),
                // TODO: Kommentierter Code ergibt noch eine Exception
                //Condition = (Condition) Condition.SelectedItem,
                Manufacturer = Manufacturer.Text
            };
            GadgetListView.AllGadgets.Add(gadget);
            bool updateFaild = MainWindow._service.UpdateGadget(gadget);
            if (updateFaild)
            {
                throw new Exception("Gadget couldn't be updated");
            }
           
        }

        private void NumberDoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // TODO Regex should allow only one dot
            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
