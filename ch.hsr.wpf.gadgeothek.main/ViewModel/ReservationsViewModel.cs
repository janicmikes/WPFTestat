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
    public class ReservationsViewModel
    {

        public GadgeothekApp GadgeothekApp;
        public ObservableCollection<Reservation> AllReservations { get; set; } = new ObservableCollection<Reservation>();

        public ReservationsViewModel()
        {
        }

        public void PullReservationsList()
        {
            AllReservations.Clear();
            foreach (var Reservation in GadgeothekApp.GetAllReservations())
            {
                AllReservations.Add(Reservation);
            }
        }
    }
}
