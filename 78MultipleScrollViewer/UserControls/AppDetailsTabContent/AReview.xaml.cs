using MiscUtil;
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

namespace _78MultipleScrollViewer.UserControls.AppDetailsTabContent
{
    /// <summary>
    /// Interaction logic for AReview.xaml
    /// </summary>
    public partial class AReview : UserControl
    {
        List<string> Names;
        public AReview()
        {
            InitializeComponent();

            Names = new List<string> { "Charles", "Mike", "Kumi", "Tony", "Oleksander", "Dustin", "Valentina", "Amanda", "Emma" };

            string reviewName = Names[StaticRandom.Next(Names.Count)];
            ReviewerNameLabel.Content = reviewName;
            AvatarLabel.Content = reviewName[0];
            NumOfStarsLabel.Content = GetRandomNumOfStars();
            ReviewTitle.Content = GetReviewTitleBasedOnStars(NumOfStarsLabel.Content.ToString());
        }

        private string GetRandomNumOfStars()
        {
            string content = "";

            for (int i = 0; i < StaticRandom.Next(1, 6); i++)
            {
                content += "★";
            }

            return content;
        }

        private string GetReviewTitleBasedOnStars(string inStars)
        {
            string reStr = string.Empty;

            if (inStars.Length >= 4)
            {
                reStr = "This app is really awesome";
            }
            else if (inStars.Length == 3)
            {
                reStr = "This app is all right";
            }
            else
            {
                reStr = "This app isn't good at all";
            }

            return reStr;
        }
    }
}
