using _78MultipleScrollViewer.Pages;
using _78MultipleScrollViewer.UserControls;
using MahApps.Metro.Controls;
using System;
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

namespace _78MultipleScrollViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //MahApps.Metro - Framework
    public partial class MainWindow : MetroWindow
    {
        private Main MainWindowContentPage;
        private TopAppsWrapped MyTopAppsWrappedPage;
        private DownloadsAndUpdates MyDownloadsAndUpdates;

        public MainWindow()
        {
            InitializeComponent();
            MainWindowContentPage = new Main();
            MyTopAppsWrappedPage = new TopAppsWrapped();
            MyDownloadsAndUpdates = new DownloadsAndUpdates();

            MainWindowContentPage.DownloadsAndUpdatesClicked += MainWindowContentPage_DownloadsAndUpdatesClicked;

            MyTopAppsWrappedPage.AppClicked += MainWindowContentPage_AppClicked;
            MainWindowContentPage.TopAppButtonClicked += MainWindowContentPage_TopAppButtonClicked;
            MyTopAppsWrappedPage.BackButtonClicked += BackButtonClicked;
            MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
            MyDownloadsAndUpdates.BackButtonClicked += BackButtonClicked;
            
        }

        private void MainWindowContentPage_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MyTopAppsWrappedPage;
        }

        private void MainWindowContentPage_DownloadsAndUpdatesClicked()
        {
            MainWindowFrame.Content = MyDownloadsAndUpdates;
        }

        private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppDetails myAppDetails = new AppDetails(sender);
            myAppDetails.BackButtonClicked += BackButtonClicked;
            myAppDetails.AppClicked += MainWindowContentPage_AppClicked;
            MainWindowFrame.Content = myAppDetails;
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (MainWindowFrame.NavigationService.CanGoBack)
            {
                MainWindowFrame.NavigationService.GoBack();
            }
        }

        private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MainWindowContentPage;
        }
    }
}
