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

namespace _78MultipleScrollViewer.UserControls.HamburgerMenuVIews
{
    /// <summary>
    /// Interaction logic for HamburgerMenuAppList.xaml
    /// </summary>
    public partial class HamburgerMenuAppList : UserControl
    {
        public List<HamburgerMenuApp> allApps;
        public List<HamburgerMenuApp> appsOnFilter;
        public HamburgerMenuAppList()
        {
            InitializeComponent();

            allApps = new List<HamburgerMenuApp>();
            appsOnFilter = new List<HamburgerMenuApp>();

            for(int i = 0; i < 15; i++)
            {
                AddNewHamApp();
            }
        }

        public void AddNewHamApp() 
        {
            HamburgerMenuApp anApp = new HamburgerMenuApp();
            MainStackPanel.Children.Add(anApp);
            allApps.Add(anApp);
        }

        public void FilterByType(string inFilter)
        {
            appsOnFilter = allApps.Where(p => p.type == inFilter).ToList<HamburgerMenuApp>();
            MainStackPanel.Children.Clear();

            foreach(HamburgerMenuApp app in appsOnFilter)
            {
                MainStackPanel.Children.Add(app); 
            }
        }

        public void AddAll()
        {
            MainStackPanel.Children.Clear ();
            foreach(HamburgerMenuApp item in allApps)
            {
                MainStackPanel.Children.Add(item);
            }
        }

        public void SortByName()
        {
            List<HamburgerMenuApp> allAppsSorted = allApps.OrderBy(p => p.appName).ToList<HamburgerMenuApp>();
            MainStackPanel.Children.Clear();

            foreach(HamburgerMenuApp item in  allAppsSorted)
            {
                MainStackPanel.Children.Add(item);
            }
        }

        public void SortByDate()
        {
            List<HamburgerMenuApp> allAppsSorted = allApps.OrderByDescending(p => p.purchased).ToList<HamburgerMenuApp>();
            MainStackPanel.Children.Clear();

            foreach (HamburgerMenuApp item in allAppsSorted)
            {
                MainStackPanel.Children.Add(item);
            }
        }
    }
}
