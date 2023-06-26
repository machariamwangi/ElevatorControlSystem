using ElevatorControlSystem.Data;
using ElevatorControlSystem.Domain;
using ElevatorControlSystem.Interfaces;

namespace ElevatorControlSystem.Services
{
    public class ElevatorSimulatorService: IElevatorSimulatorService
    {
        private List<Elevator> elevators;
       // private int numFloors = ElevatorData.Floors;
        int numElevators = ElevatorData.Elevators;
        public ElevatorSimulatorService()
        {
            elevators = new List<Elevator>();
            for (int i = 0; i < numElevators; i++)
            {
                elevators.Add(new Elevator(ElevatorData.MaxPeople));
            }
        }

        public void CallElevator(int floor, int passengerCount, int passengerWeight)
        {
            Elevator nearestElevator = GetNearestElevator(floor);
            nearestElevator.LoadPassenger(passengerCount, passengerWeight);
            nearestElevator.MoveToFloor(floor);
            nearestElevator.UnloadPassenger(passengerCount, passengerWeight);
        }

        private Elevator GetNearestElevator(int floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (Elevator elevator in elevators)
            {
                int distance = Math.Abs(elevator.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElevator = elevator;
                }
            }

            return nearestElevator;
        }

        public void ShowElevatorStatus()
        {
            for (int i = 0; i < elevators.Count; i++)
            {
                Elevator elevator = elevators[i];
                Console.WriteLine($"Elevator {i + 1}:");
                Console.WriteLine($"Current floor: {elevator.CurrentFloor}");
                Console.WriteLine($"Direction: {elevator.Direction}");
                Console.WriteLine($"Moving: {elevator.IsMoving}");
                Console.WriteLine($"Passenger count: {elevator.PassengerCount}");
                Console.WriteLine();
            }
        }
    }
}
