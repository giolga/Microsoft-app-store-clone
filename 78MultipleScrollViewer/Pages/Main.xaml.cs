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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;
using _78MultipleScrollViewer.UserControls;//for DoubleAnimation

namespace _78MultipleScrollViewer.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public delegate void OnTopAppButtonClicked(object sender, RoutedEventArgs e);
        public event OnTopAppButtonClicked TopAppButtonClicked;

        public delegate void OnDownloadsAndUpdates();
        public event OnDownloadsAndUpdates DownloadsAndUpdatesClicked;

        public Main()
        {
            InitializeComponent();

            DealsAppsViewer.AppClicked += AnAppClicked;

            ProductivityTopApps.AppClicked += AnAppClicked;
            TopApps.AppClicked += AnAppClicked;

            ProductivityAppsL1.AppClicked += AnAppClicked;
            ProductivityAppsL2.AppClicked += AnAppClicked;
            ProductivityAppsL3.AppClicked += AnAppClicked;

            EntertainmentAppsViewer.AppClicked += AnAppClicked;
            GamingAppsViewer.AppClicked += AnAppClicked;

            TopApps.TopAppButtonClicked += TopApps_TopAppButtonClicked;

            FeaturesAppsViewer.AppClicked += AnAppClicked;
            MostPopularAppsViewer.AppClicked += AnAppClicked;
            TopFreeAppsViewer.AppClicked += AnAppClicked;
            TopFreeGamesAppsViewer.AppClicked += AnAppClicked;

            RightHeaderButtons.HeaderRightButtonsDownloadButtonClick += RightHeaderButtons_HeaderRightButtonsDownloadButtonClick;
        }

        private void AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }

        private void TopApps_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            TopAppButtonClicked(sender, e);
        }

        private void MainScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement element = (UIElement)sender;
            element.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 3))
            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void Page_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RightHeaderButtons.MouseDown_OutsideOfHeaderRightButtons();
        }

        private void RightHeaderButtons_HeaderRightButtonsDownloadButtonClick(object sender, RoutedEventArgs e)
        {
            DownloadsAndUpdatesClicked();
        }
    }
}
