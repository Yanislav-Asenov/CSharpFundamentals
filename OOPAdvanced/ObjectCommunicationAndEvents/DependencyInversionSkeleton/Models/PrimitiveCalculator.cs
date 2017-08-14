using System.Reflection;
using System.Linq;
using System;

public class PrimitiveCalculator : IPrimitiveCalculator
{
    private ICalculationStrategy calculationStrategy;

    public PrimitiveCalculator()
        : this(new AdditionStrategy())
    {

    }

    public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
    {
        this.calculationStrategy = calculationStrategy;
    }

    public void ChangeStrategy(char @operator)
    {
        var targetStrategyType =
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes(typeof(StrategyAttribute))
                            .Where(atr => atr.Equals(@operator))
                            .ToArray().Length > 0);

        if (targetStrategyType == null)
        {
            throw new ArgumentException("Invalid strategy mode!");
        }

        this.calculationStrategy = (ICalculationStrategy)Activator.CreateInstance(targetStrategyType, new object[0]);
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        int result = this.calculationStrategy.Calculate(firstOperand, secondOperand);
        return result;
    }
}