using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_SerialPort_Messenger
{
    public class Usuario
    {
        private string nodo;
        private string username;
        private string path_LogRespectivo;
        private Queue<string>[] queueMsg;

        public string Nodo { get => nodo; set
            {
                if (nodo != null)
                {
                    nodo = value;
                }
            }
        }
        public string Username { get => username; 
            set {
                if(username != null)
                {
                    username = value;
                }       
            } 
        }
        public string Path_LogRespectivo { get => path_LogRespectivo; set => path_LogRespectivo = value; }
        public Queue<string>[] QueueMsg { get => queueMsg; private set => queueMsg = value; }

        public Usuario(string nodo, string username, string path_LogRespectivo)
        {
            Nodo = nodo;
            Username = username;
            Path_LogRespectivo = path_LogRespectivo;
            QueueMsg = queueMsg;
            QueueMsg = new Queue<string>[5];
        }

    }
}
