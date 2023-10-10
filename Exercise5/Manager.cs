using Exercise5.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class Manager
    {
        public void run()
        {
            GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>(10);
            UI userInterface = new UI(handler);
            userInterface.ShowMainMenu();
        }
    }
}
