﻿using ch.hsr.wpf.gadgeothek.main.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.main
{
    /// <summary>
    /// Interaction logic for LoansView.xaml
    /// </summary>
    public partial class LoansView : UserControl
    {
        public LoansViewModel LoansViewModel;
        public LoansView()
        {
            InitializeComponent();
            LoansViewModel = new LoansViewModel();
            DataContext = LoansViewModel;
        }
    }
}
