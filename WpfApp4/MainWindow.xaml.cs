using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace Lichtkrant_afwerking
{

    public partial class MainWindow : Window
    {
        private ButtonTryCatch buttonTryCatchHandler;

        public MainWindow()
        {
            // Open het ComPortDialog-venster en vraag om een COM-poort
            ComPortDialog comPortDialog = new ComPortDialog();
            if (comPortDialog.ShowDialog() == true)
            {
                // Initialiseer ButtonTryCatch met de geselecteerde COM-poort
                string selectedComPort = comPortDialog.SelectedComPort;
                buttonTryCatchHandler = new ButtonTryCatch(selectedComPort);
            }
            else
            {
                // Als er geen COM-poort is geselecteerd, sluit de applicatie
                Close();
                return;
            }

            // Nu de COM-poort is ingesteld, initialiseer de rest van de UI-componenten
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // Event handler voor de button
        private void StartSerialCommunication(object sender, RoutedEventArgs e)
        {
            // Roep de StartSerialCommunication-methode aan en geef de TextBox door
            buttonTryCatchHandler.StartSerialCommunication(InputTextBox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}



