using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class Networksevice
    {
        public string SendPing()
        {

            return "Sucess : Ping Sent!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}
