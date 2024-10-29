using System.Windows.Controls;

namespace RitualService.Features.ServicesPage
{
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            DataContext = new ServicesPageViewModel();
        }
    }
}
