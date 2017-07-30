using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var inputTrafficLights = Console.ReadLine().Split().Select(x => (TrafficLight)Enum.Parse(typeof(TrafficLight), x));
        var trafficLights = new List<TrafficLight>(inputTrafficLights);

        int numberOfUpdates = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfUpdates; i++)
        {
            for (int trafficLightIndex = 0; trafficLightIndex < trafficLights.Count; trafficLightIndex++)
            {
                var currentLight = trafficLights[trafficLightIndex];

                if (currentLight == TrafficLight.Red)
                {
                    trafficLights[trafficLightIndex] = TrafficLight.Green;
                }
                else if (currentLight == TrafficLight.Green)
                {
                    trafficLights[trafficLightIndex] = TrafficLight.Yellow;
                }
                else
                {
                    trafficLights[trafficLightIndex] = TrafficLight.Red;
                }
            }

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}