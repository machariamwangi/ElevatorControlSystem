using ElevatorControlSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Interfaces
{
    public interface IElevatorSimulatorService
    {
        public void CallElevator(int floor, int passengerCount, int passengerWeight);
        public void ShowElevatorStatus();
    }
}
