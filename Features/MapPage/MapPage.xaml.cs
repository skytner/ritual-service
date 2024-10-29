using System.Windows.Controls;

namespace RitualService.Features.MapPage
{
    public partial class MapPage : Page
    {
        public MapPage()
        {
            InitializeComponent();
            DataContext = new MapPageViewModel();
        }
    }
}
