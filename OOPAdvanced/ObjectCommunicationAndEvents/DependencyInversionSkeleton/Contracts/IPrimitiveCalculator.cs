﻿public interface IPrimitiveCalculator
{
    void ChangeStrategy(char @operator);

    int PerformCalculation(int firstOperand, int secondOperand);
}