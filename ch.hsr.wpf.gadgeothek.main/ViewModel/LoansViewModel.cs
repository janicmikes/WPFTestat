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
    public class LoansViewModel
    {

        public GadgeothekApp GadgeothekApp;
        public ObservableCollection<Loan> AllLoans { get; set; } = new ObservableCollection<Loan>();

        public LoansViewModel()
        {
            UpdateLoanTimer(UpdateLoanTimerOnTick);
        }

        private void UpdateLoanTimer(EventHandler updateLoanTimerOnTick)
        {
            System.Windows.Threading.DispatcherTimer updateLoanTimer = new System.Windows.Threading.DispatcherTimer();
            updateLoanTimer.Tick += updateLoanTimerOnTick;
            updateLoanTimer.Interval = new TimeSpan(0, 0, 5);
            updateLoanTimer.Start();
        }


        private void UpdateLoanTimerOnTick(object sender, EventArgs e)
        {
            PullLoansList();
        }

        private void PullLoansList()
        {
            AllLoans.Clear();
            foreach (var loan in GadgeothekApp.GetAllLoans())
            {
                AllLoans.Add(loan);
            }
        }
    }
}
