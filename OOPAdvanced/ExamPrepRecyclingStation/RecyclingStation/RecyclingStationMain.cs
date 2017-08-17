namespace RecyclingStation
{
    using RecyclingStation.BusinessLogic.Core;
    using RecyclingStation.BusinessLogic.Factories;
    using RecyclingStation.BusinessLogic.Interfaces.Core;
    using RecyclingStation.BusinessLogic.Interfaces.Factories;
    using RecyclingStation.BusinessLogic.Interfaces.IO;
    using RecyclingStation.BusinessLogic.IO;
    using RecyclingStation.Interfaces.Core;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            IReader consoleReader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            IInputOutputManager inputOutputManager = new InputOutputManager(consoleReader, consoleWriter);

            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IGarbageFactory garbageFactory = new GarbageFactory();
            IRecyclingManager recyclingManager = new RecyclingManager(garbageProcessor, garbageFactory);

            IRunnable engine = new Engine(inputOutputManager, recyclingManager);
            engine.Run();
        }
    }
}
