﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _78MultipleScrollViewer.UserControls.HamburgerMenuVIews
{
    /// <summary>
    /// Interaction logic for AllOwned.xaml
    /// </summary>
    public partial class AllOwned : UserControl
    {

        public AllOwned()
        {
            InitializeComponent();
            HamHeader.FilterMenuItemClicked += HamHeader_FilterMenuItemClicked;
            HamHeader.SortByMenuItemClicked += HamHeader_SortByMenuItemClicked;
        }

        private void HamHeader_FilterMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).Header.ToString().ToLower() == "sort by name")
            {
                HamAppsList.SortByName();
            }
            else
            {
                HamAppsList.SortByDate();
            }
        }

        private void HamHeader_SortByMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).Header.ToString().ToLower() == "all types")
            {
                HamAppsList.AddAll();
            }
            else
            {
                //Here we can just filter by the header, because the header already contains 
                //The string we want to sort by
                HamAppsList.FilterByType((sender as MenuItem).Header.ToString());
            }
        }

    }
}
