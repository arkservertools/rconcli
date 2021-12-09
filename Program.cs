using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using CoreRCON;
using CoreRCON.Parsers.Standard;

namespace rcon
{

    class CommandLineArgs
    {
        public static CommandLineArgs I
        {
            get
            {
                return m_instance;
            }
        }

        public string argAsString(string argName)
        {
            if (m_args.ContainsKey(argName))
            {
                return m_args[argName];
            }
            else return "";
        }

        public long argAsLong(string argName)
        {
            if (m_args.ContainsKey(argName))
            {
                return Convert.ToInt64(m_args[argName]);
            }
            else return 0;
        }

        public double argAsDouble(string argName)
        {
            if (m_args.ContainsKey(argName))
            {
                return Convert.ToDouble(m_args[argName]);
            }
            else return 0;
        }

        public void parseArgs(string[] args, string defaultArgs)
        {
            m_args = new Dictionary<string, string>();
            parseDefaults(defaultArgs);
            foreach (string arg in args)
            {
                string[] words = arg.Split('=');
                m_args[words[0]] = words[1];
            }
        }

        private void parseDefaults(string defaultArgs)
        {
            if (defaultArgs == "") return;
            string[] args = defaultArgs.Split(';');
            foreach (string arg in args)
            {
                string[] words = arg.Split('=');
                m_args[words[0]] = words[1];
            }
        }

        private Dictionary<string, string> m_args = null;
        static readonly CommandLineArgs m_instance = new CommandLineArgs();
    }

    public class log
    {
        public static void trz(string cad)
        {
            Console.WriteLine(cad);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                // Parse Arguments
                string ip = "";
                ushort port = 0;
                string pwd = "";
                string cmd = "";
                string result = "";
                string file = "";
                CommandLineArgs.I.parseArgs(args, "ip=127.0.0.1;port=0;pwd=password");               
                ip = CommandLineArgs.I.argAsString("ip");
                port=(ushort)CommandLineArgs.I.argAsLong("port");
                pwd = CommandLineArgs.I.argAsString("pwd");
                cmd = CommandLineArgs.I.argAsString("cmd");
                file = CommandLineArgs.I.argAsString("file");

                if (ip!="" && port!=0 && pwd!="")
                {
                    
                    if (file!="")
                    {
                        RconTools.sendfilecomand(ip, port, pwd, file);                        
                    }
                    else
                    if (cmd != "")
                    {
                        RconTools.sendcomand(ip, port, pwd, cmd, out result);                        
                    }                    
                }
                else 
                {
                    log.trz("Invalid Arguments ip=xxx port=xxx pwd=xxx cmd=\"command to send\"");
                    log.trz("or ip=xxx port=xxx pwd=xxx file=textfilename.txt");
                }                                
            }
            catch (Exception e)
            {
                log.trz(string.Format("Exception {0} {1}",e.Message, e.StackTrace));                
            }
        }
           
    }
}
