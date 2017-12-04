using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PayBitForward.Messaging;
using PayBitForward.Models;

namespace Registry
{
  class Registry
  {
    
    private UdpCommunicator Communicator { get; set; }

    private JsonMessageConverter Converter { get; set; }

    private MessageRouter Router { get; set; }


    static void Main(string[] args)
    {
    }
  }
}
