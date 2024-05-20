using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for HamburgerMenuApp.xaml
    /// </summary>
    public partial class HamburgerMenuApp : UserControl
    {
        public List<string> appNames;
        public List<string> appTypes;
        public string appName;
        public DateTime purchased;
        public string type;
        public HamburgerMenuApp()
        {
            InitializeComponent();

            appTypes = new List<string>()
            {
                "Apps", "Games", "Movies", "Avatars"
            };

            List<string> filePaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\Images\MiniIcons", "*.png").ToList<string>();
            FileInfo myRandomFile = new FileInfo(filePaths[StaticRandom.Next(filePaths.Count)]);
            AppImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
            AppNameLabel.Content = (new CultureInfo("en-US", false).TextInfo).ToTitleCase
                (
                AppImage.Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.').First()
                );

            appName = AppNameLabel.Content.ToString();
            type = appTypes[StaticRandom.Next(appTypes.Count)];
            purchased = new DateTime(2024, 1, StaticRandom.Next(1, DateTime.Now.Day + 1));
            PurchasedLabel.Content = purchased.ToString("d");
        }
    }
}
