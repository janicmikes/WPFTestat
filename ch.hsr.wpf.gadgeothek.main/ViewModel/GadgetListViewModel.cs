using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.main.ViewModel
{
    public class GadgetListViewModel : INotifyPropertyChanged
    {

        public GadgeothekApp GadgeothekApp;

        public GadgetListViewModel()
        {

        }

        private ObservableCollection<Gadget> _allGadgets = new ObservableCollection<Gadget>();

        public ObservableCollection<Gadget> AllGadgets
        {
            get { return _allGadgets; }
            set
            {
                _allGadgets = value;
                OnPropertyChanged(nameof(AllGadgets));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PullGadgetList()
        {
            AllGadgets.Clear();
            foreach (var gadget in GadgeothekApp.GetAllGadgets())
            {
                AllGadgets.Add(gadget);
            }
        }

        public void ShowSingleGadget(Gadget gadget)
        {
            // edit gadget
            if (gadget != null)
            {
                // copy the gadget
                Gadget editableGadget = new Gadget
                {
                    InventoryNumber = gadget.InventoryNumber,
                    Name = gadget.Name,
                    Price = gadget.Price,
                    Condition = gadget.Condition,
                    Manufacturer = gadget.Manufacturer
                };

                // copy back
                SingleGadgetWindow singleGadgetWindow = new SingleGadgetWindow(editableGadget);
                if (singleGadgetWindow.ShowDialog() == true)
                {
                    gadget.InventoryNumber = editableGadget.InventoryNumber;
                    gadget.Name = editableGadget.Name;
                    gadget.Price = editableGadget.Price;
                    gadget.Condition = editableGadget.Condition;
                    gadget.Manufacturer = editableGadget.Manufacturer;

                    if (GadgeothekApp.Service.UpdateGadget(gadget))
                    {
                        OnPropertyChanged(nameof(AllGadgets));
                        PullGadgetList();
                    }
                    else
                    {
                        if (!GadgeothekApp.Service.DeleteGadget(gadget))
                        {
                            throw new Exception("Update Gadget Failed!");

                        }
                    }
                }
                editableGadget = null;

            }

            // add new gadget
            else
            {
                gadget = new Gadget();
                SingleGadgetWindow singleGadgetWindow = new SingleGadgetWindow(gadget);
                if (singleGadgetWindow.ShowDialog() == true)
                {
                    if (GadgeothekApp.Service.AddGadget(gadget))
                    {
                        OnPropertyChanged(nameof(AllGadgets));
                        PullGadgetList();
                    }
                    else
                    {
                        throw new Exception("Add Gadget Failed!");
                    }
                }
            }
        }
    }
}
