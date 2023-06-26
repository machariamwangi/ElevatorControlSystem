using ElevatorControlSystem.Data;
using ElevatorControlSystem.Data.Enums;

namespace ElevatorControlSystem.Domain
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsMoving { get; private set; }
        public int PassengerCount { get; private set; }
        public int MaxCapacity { get; private set; }
        public int CurrentWeight { get; private set; }

        public Elevator(int maxCapacity)
        {
            CurrentFloor = 1;
            Direction = Direction.None;
            IsMoving = false;
            PassengerCount = 0;
            MaxCapacity = maxCapacity;
            CurrentWeight = 0;
        }

        public void MoveToFloor(int floor)
        {
            Direction = floor > CurrentFloor ? Direction.Up : Direction.Down;
            IsMoving = true;
            Console.WriteLine($"Elevator is moving {Direction} to floor {floor}.");
            while (CurrentFloor != floor)
            {
                if (Direction == Direction.Up)
                    CurrentFloor++;
                else
                    CurrentFloor--;

                Console.WriteLine($"Elevator is passing floor {CurrentFloor}.");
            }

            IsMoving = false;
            Console.WriteLine($"Elevator has arrived at floor {CurrentFloor}.");
        }

        public void LoadPassenger(int count, int weight)
        {
            if (PassengerCount + count > MaxCapacity)
            {
                Console.WriteLine($"Elevator is at maximum capacity. Cannot load {count} passengers.");
                return;
            }


            if (CurrentWeight + weight > ElevatorData.WeightLimit)
            {
                Console.WriteLine($"Elevator has reached its weight limit. Cannot load passengers.");
                return;
            }

            PassengerCount += count;
            CurrentWeight += weight;
            Console.WriteLine($"{count} passengers loaded. Current passenger count: {PassengerCount}. Current weight: {CurrentWeight} kg.");
        }

        public void UnloadPassenger(int count, int weight)
        {
            if (PassengerCount - count < 0)
            {
                Console.WriteLine($"There are not enough passengers in the elevator. Cannot unload {count} passengers.");
                return;
            }

            PassengerCount -= count;
            CurrentWeight -= weight;
            Console.WriteLine($"{count} passengers unloaded. Current passenger count: {PassengerCount}. Current weight: {CurrentWeight} kg.");
        }
    }
}
