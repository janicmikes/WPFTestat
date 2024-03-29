﻿using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;


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
            if (gadget != null)
            {
                EditGadget(gadget);
            }

            else
            {
                AddNewGadget();
            }
        }

        private void AddNewGadget()
        {
            Gadget gadget = new Gadget();
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

        private void EditGadget(Gadget gadget)
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
                    throw new Exception("Update Gadget Failed!");
                }
            }
            editableGadget = null;
        }

        public void DeleteGadget(Gadget gadget)
        {
            DeleteConfirmation deleteConfirmation = new DeleteConfirmation(gadget);
            if (deleteConfirmation.ShowDialog() == true)
            {
                try
                {
                    GadgeothekApp.Service.DeleteGadget(gadget);
                    OnPropertyChanged(nameof(AllGadgets));
                    PullGadgetList();
                }
                catch (Exception)
                {
                    throw new Exception("deleting gadget failded!");
                }
            }
        }
    }
}
