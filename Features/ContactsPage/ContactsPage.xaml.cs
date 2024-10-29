using System.Windows.Controls;

namespace RitualService.Features.ContactsPage
{
    public partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            InitializeComponent();
            DataContext = new ContactsPageViewModel();
        }
    }
}
