using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.main.ViewModel
{
    public class GadgeothekApp
    {
        // Move into GadgeothekApp()
        public  String ServerUrl { get; set; }

        // Move into GadgeothekApp()
        public LibraryAdminService Service { get; set; }

        public GadgetListViewModel GadgetListViewModel { get; internal set; }
        public LoansViewModel LoansViewModel { get; internal set; }
        public ReservationsViewModel ReservationsViewModel { get; internal set; }

        // Todo: Add Loans View Model

        public GadgeothekApp()
        {
            ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            Service = new LibraryAdminService(ServerUrl);

            // start refreshing
            UpdateTimer(UpdateTimerOnTick);
        }

        private void UpdateTimer(EventHandler updateTimerOnTick)
        {
            System.Windows.Threading.DispatcherTimer updateTimer = new System.Windows.Threading.DispatcherTimer();
            updateTimer.Tick += updateTimerOnTick;
            updateTimer.Interval = new TimeSpan(0, 0, 5);
            updateTimer.Start();
        }


        private void UpdateTimerOnTick(object sender, EventArgs e)
        {
            LoansViewModel?.PullLoansList();
            ReservationsViewModel?.PullReservationsList();
        }

        public List<Gadget> GetAllGadgets() => Service.GetAllGadgets();
        public List<Loan> GetAllLoans() => Service.GetAllLoans();
        public List<Reservation> GetAllReservations() => Service.GetAllReservations();
    }
}
