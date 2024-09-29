using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;

namespace App_SerialPort_Messenger.bin.Debug.Logs
{

    public class Message_Receiver_manager
    {
        // El puerto serial
        private SerialPort serialPort;

        // Encapsulación
        public SerialPort SerialPortAssigned { get { return serialPort; } private set { serialPort = value; } }

        //Donde estarán los mensajes que recibe
        string receivedData;
        
        // Recibimos puerto serial, para compartir ya una misma instancia
        public Message_Receiver_manager(SerialPort serialPort)
        {
            SerialPortAssigned = serialPort;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            MessageBox.Show(Path.GetDirectoryName(Application.ExecutablePath));
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    receivedData = serialPort.ReadLine();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error al leer datos: " + ex.Message);
                }

                string user = GetUser(receivedData);
                WriteInTxt(receivedData, user);
            }
        }

        private string GetUser(string message) {
            int startIndex = message.IndexOf("[") + 1;
            int endIndex = message.IndexOf(':');

            return message.Substring(startIndex , endIndex - startIndex);
        }

        private void WriteInTxt(string message, string user)
        {
            string route = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Logs", $"Log_{user}.txt");
            using (StreamWriter sw = new StreamWriter(route, true))
            {
                sw.WriteLine(message);
            }
        }
    }


    
}
