using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Controls;

public class ButtonTryCatch
{
    private SerialPort port;

    public ButtonTryCatch(string portName)
    {
        port = new SerialPort(portName);
    }

    public void StartSerialCommunication(TextBox inputTextBox)
    {
        try
        {
            port.Open();

            // Lees tekst uit de TextBox
            string inputText = inputTextBox.Text;

            // Schrijf de volledige tekst naar de poort
            //port.Write(inputText);
            port.WriteLine("<IDO1><PA><FS> " + inputText + Convert.ToChar(13) + Convert.ToChar(10));

            port.Write("<IDO1><PA><FS>" + Convert.ToChar(13) + Convert.ToChar(10));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error opening/writing to the port: " + ex.Message);
        }
        finally
        {
            // Sluit de poort in het finally-blok om ervoor te zorgen dat deze wordt gesloten, zelfs als er een uitzondering optreedt
            if (port.IsOpen)
            {
                port.Close();
            }
        }
    }
}