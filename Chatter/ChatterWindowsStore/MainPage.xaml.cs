using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChatterWindowsStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HubConnection hubConnection;
        IHubProxy chatHubProxy;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            Connect(ServerUrl.Text);
        }

        private async void Connect(string url)
        {
            hubConnection = new HubConnection(ServerUrl.Text);

            chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            chatHubProxy.On<string, string>("broadcastMessage", (name, message) =>
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () => { IncomingMessage.Text = string.Format("{0}: {1}",name, message); })
             );

            await hubConnection.Start();
            chatHubProxy.Invoke("RegisterUser", "Windows Store Client");
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            chatHubProxy.Invoke("Send", ChatMessage.Text);
        }
    }
}
