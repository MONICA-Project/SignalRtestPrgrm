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
using Microsoft.AspNetCore.SignalR.Client;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectButt.Content == "Disconnect")
            {
                connection.StopAsync();
                ConnectButt.Content = "Connect";
                return;
            }             
            connection = new HubConnectionBuilder()
         .WithUrl(SignalRUrl.Text)
         .Build();
            { //SoundheatmapUpdate
                connection.On<string>("peoplewithwearablesUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        peoplewithwearablesUpdate.Content = (int.Parse(peoplewithwearablesUpdate.Content.ToString())+1).ToString();
                        if((bool) LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);
                        
                    });
                });

                connection.On<string>("SoundsensorUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        SoundsensorUpdate.Content = (int.Parse(SoundsensorUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("ZoneUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        ZoneUpdate.Content = (int.Parse(ZoneUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("Incidents", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        Incidents.Content = (int.Parse(Incidents.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("SoundIncidents", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        SoundIncidents.Content = (int.Parse(SoundIncidents.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("TemperatureUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        TemperatureUpdate.Content = (int.Parse(TemperatureUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("HumidityUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        HumidityUpdate.Content = (int.Parse(HumidityUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("WindUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        WindUpdate.Content = (int.Parse(WindUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });

                connection.On<string>("AggregateUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        AggregateUpdate.Content = (int.Parse(AggregateUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });
                connection.On<string>("PeopleGateCounting", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        PeopleGateCounting.Content = (int.Parse(PeopleGateCounting.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });
                connection.On<string>("SoundheatmapUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        SoundheatmapUpdate.Content = (int.Parse(SoundheatmapUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });
                connection.On<string>("PeopleheatmapUpdate", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var newMessage = $"{message}";
                        PeopleheatmapUpdate.Content = (int.Parse(PeopleheatmapUpdate.Content.ToString()) + 1).ToString();
                        if ((bool)LogToFile.IsChecked)
                            LogHandler.WriteLogFile(newMessage);

                    });
                });
                try
                {
                    await connection.StartAsync();
                    
                    connection.Closed += async (berr) =>
                    {
                        await Task.Delay(new Random().Next(0, 5) * 1000);
                        await connection.StartAsync();
                    };
                    ConnectButt.Content = "Disconnect";
                   
         
                }

                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "Connection Failed");
                   
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
