namespace TruckTour
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numberOfPetrolPumps = int.Parse(Console.ReadLine());

            var petrolPumps = new Queue<PetrolPump>();
            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                string[] lineArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long admounOfPetrol = long.Parse(lineArgs[0]);
                long distanceToNextPump = long.Parse(lineArgs[1]);

                petrolPumps.Enqueue(new PetrolPump()
                {
                    AmountOfPetrol = admounOfPetrol,
                    DistanceToNextPetrolPump = distanceToNextPump,
                    Index = i
                });
            }

            while (true)
            {
                var startPetrolPump = petrolPumps.Dequeue();
                petrolPumps.Enqueue(startPetrolPump);

                if (startPetrolPump.AmountOfPetrol < startPetrolPump.DistanceToNextPetrolPump)
                {
                    continue;
                }

                var currentTank = new PetrolTank();

                currentTank.AmountOfPetrol = startPetrolPump.AmountOfPetrol - startPetrolPump.DistanceToNextPetrolPump;

                bool isCircleComplete = false;
                while (true)
                {
                    var currentPetrolPump = petrolPumps.Dequeue();
                    petrolPumps.Enqueue(currentPetrolPump);

                    if (currentPetrolPump.Index == startPetrolPump.Index)
                    {
                        isCircleComplete = true;
                        break;
                    }

                    currentTank.AmountOfPetrol += currentPetrolPump.AmountOfPetrol;

                    if (currentTank.AmountOfPetrol < currentPetrolPump.DistanceToNextPetrolPump)
                    {
                        break;
                    }

                    currentTank.AmountOfPetrol -= currentPetrolPump.DistanceToNextPetrolPump;
                }

                if (isCircleComplete)
                {
                    Console.WriteLine(startPetrolPump.Index);
                    break;
                }
            }
        }
    }

    public class PetrolPump
    {
        public long AmountOfPetrol { get; set; }
        public long DistanceToNextPetrolPump { get; set; }
        public long Index { get; set; }
    }

    public class PetrolTank
    {
        public long AmountOfPetrol { get; set; }
    }
}
