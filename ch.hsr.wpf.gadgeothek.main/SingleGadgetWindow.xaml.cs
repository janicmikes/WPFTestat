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
            // copy the gadget
            CurrentGadget = new Gadget
            {
                InventoryNumber = gadget.InventoryNumber,
                Name = gadget.Name,
                Price = gadget.Price,
                Condition = gadget.Condition,
                Manufacturer = gadget.Manufacturer
            };
            DataContext = CurrentGadget;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double parsedPrice = Double.Parse(Price.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid Price");
                return;
            }

            Gadget gadget = new Gadget
            {
                InventoryNumber = ID.Text,
                Name = Name.Text,
                Price = Double.Parse(Price.Text),
                Condition = (Condition) Condition.SelectedItem,
                Manufacturer = Manufacturer.Text
            };
            
            bool updateSuccess = MainWindow._service.UpdateGadget(gadget);
            if (!updateSuccess)
            {
                throw new Exception("Gadget couldn't be updated");
            }
            GadgetListView.PullGadgetList();
            this.Close();
        }

        private void NumberDoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\d|\.");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\d");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
