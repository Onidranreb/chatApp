using Syncfusion.Maui.Chat;
using chatAppMessage.ViewModel;

namespace chatAppMessage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SfChat_AttachmentButtonClicked(object? sender, EventArgs e)
        {
            if (this.BindingContext is ViewModel.GettingStartedViewModel viewModel)
            {
                viewModel.Messages.Add(new Syncfusion.Maui.Chat.ImageMessage()
                {
                    Source = "dotnet_bot.png",
                    Author = viewModel.CurrentUser
                });
            }
        }
        
        private void OnClientSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // 1. Safely pull the selected client string item from the CollectionView selection
            if (e.CurrentSelection.FirstOrDefault() is string selectedClient)
            {
                // 2. Check if our page binding context is our SignalR ViewModel
                if (this.BindingContext is ViewModel.GettingStartedViewModel viewModel)
                {
                    // 3. Set the property name to reload the message logs
                    viewModel.SelectedClientName = selectedClient;

                    // PHONE OPTIMIZATION: Hide the client directory list and show the chat full screen!
                    SidebarPanel.IsVisible = false;
                    ChatPanel.IsVisible = true;
                }
            }
        }

        private void OnBackArrowTapped(object? sender, EventArgs e)
        {
            // PHONE OPTIMIZATION: Clear the chat view and return full screen to the messages list
            ChatPanel.IsVisible = false;
            SidebarPanel.IsVisible = true;

            // Clear the selection highlight in the CollectionView so the same client can be tapped again later
            if (sender is Image image && SidebarPanel.Children.OfType<CollectionView>().FirstOrDefault() is CollectionView collectionView)
            {
                collectionView.SelectedItem = null;
            }
        }
    }
}