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

        public LoansViewModel()
        {

        }

        public ObservableCollection<Loan> AllLoans { get; set; } = new ObservableCollection<Loan>();
       

        public void PullLoansList()
        {
            AllLoans.Clear();
            foreach (var loan in GadgeothekApp.GetAllLoans())
            {
                AllLoans.Add(loan);
            }
        }
    }
}
