using System.Windows;
using System.Windows.Controls;

namespace RitualService.UI.Components
{
    public partial class HeaderComponent : UserControl
    {
        public event RoutedEventHandler NavigateRequested;

        public HeaderComponent()
        {
            InitializeComponent();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, new RoutedEventArgs { RoutedEvent = NavigationEvent.Main });
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, new RoutedEventArgs { RoutedEvent = NavigationEvent.Services });
        }

        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, new RoutedEventArgs { RoutedEvent = NavigationEvent.Contacts });
        }
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, new RoutedEventArgs { RoutedEvent = NavigationEvent.Contacts });
        }
    }

    public static class NavigationEvent
    {
        public static readonly RoutedEvent Main = EventManager.RegisterRoutedEvent(
            "Main", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HeaderComponent));

        public static readonly RoutedEvent Services = EventManager.RegisterRoutedEvent(
            "Services", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HeaderComponent));

        public static readonly RoutedEvent Contacts = EventManager.RegisterRoutedEvent(
            "Contacts", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HeaderComponent));

        public static readonly RoutedEvent Auth = EventManager.RegisterRoutedEvent(
            "Auth", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HeaderComponent));
    }
}
