using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreRCON;
using CoreRCON.Parsers.Standard;
using System.Net;

namespace rcon
{
    class RconTools
    {

        public static bool sendstatus(string _ip, ushort _port, string _pwd, string _cmd, out string result)
        {
            try
            {
                var rcon = new CoreRCON.RCON(IPAddress.Parse(_ip), _port, _pwd);
                rcon.ConnectAsync().Wait();
                // Send "status"
                Status status = rcon.SendCommandAsync<Status>("status").Result;         
                result = status.Hostname + " Players {$status.Humans} Version {$status.Version}";
                return true;
                //trz(string.Format("Command: {0} \n Result: {1}", _cmd, b));
            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
                //trz(string.Format("RCON Exception {0} {1}", e.Message, e.StackTrace));
            }
        }

        public static bool sendfilecomand(string _ip, ushort _port, string _pwd, string _file)
        {
            string result = "";
            bool b = true;
            try
            {
                if (System.IO.File.Exists(_file)) 
                {
                    string[] data = System.IO.File.ReadAllLines(_file);
                    
                    var rcon = new CoreRCON.RCON(IPAddress.Parse(_ip), _port, _pwd);
                    log.trz(string.Format("Conecting to {0} {1}", _ip, _port));
                    rcon.ConnectAsync().Wait();
                    log.trz(string.Format("RCON Conected"));
                    foreach (var cmd in data)
                    {                       
                        try
                        {
                            log.trz(string.Format("Sending Command : {0}", cmd));
                            result = rcon.SendCommandAsync(cmd).Result;
                            log.trz(string.Format("Command result \n{0}", result));
                        }
                        catch (Exception e)
                        {
                            log.trz(string.Format("RCON Exception {0} {1}", e.Message, e.StackTrace));
                            b = false;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                log.trz(string.Format("RCON Exception {0} {1}", e.Message, e.StackTrace));
                b =false;
            }
            return b;
        }



        public static bool sendcomand(string _ip, ushort _port, string _pwd, string _cmd,out string result)
        {
            try
            {
                var rcon = new CoreRCON.RCON(IPAddress.Parse(_ip), _port, _pwd);
                log.trz(string.Format("Conecting to {0} {1}", _ip,_port));
                rcon.ConnectAsync().Wait();
                log.trz(string.Format("RCON Conected"));
                log.trz(string.Format("Sending Command : {0}",_cmd));
                string b = rcon.SendCommandAsync(_cmd).Result;
                log.trz(string.Format("Command result \n{0}", _cmd));
                result = b;
                return true;               
            }
            catch (Exception e)
            {
                result = e.Message;
                log.trz(string.Format("RCON Exception {0} {1}", e.Message, e.StackTrace));
                return false;                                
            }
        }
    }
}
