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
using System.Windows.Shapes;
using System.IO.Ports;

namespace Lichtkrant_afwerking
{
    public partial class ComPortDialog : Window
    {
        public string SelectedComPort { get; private set; }

        public ComPortDialog()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Vul de ComboBox met beschikbare COM-poorten
            comPortComboBox.ItemsSource = SerialPort.GetPortNames();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Stel de geselecteerde COM-poort in
            SelectedComPort = comPortComboBox.SelectedItem as string;
            this.DialogResult = true;
            this.Close();
        }
    }
}
