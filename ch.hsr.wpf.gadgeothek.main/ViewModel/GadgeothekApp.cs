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

        public GadgetListViewModel GadgetListViewModel { get; set;}

        // Todo: Add Loans View Model

        public GadgeothekApp()
        {
            ServerUrl = ConfigurationManager.AppSettings["server"].ToString();
            Service = new LibraryAdminService(ServerUrl);
        }

        public List<Gadget> GetAllGadgets() => Service.GetAllGadgets();
    
    }
}
