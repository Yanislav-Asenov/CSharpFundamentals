﻿using System;

[Strategy('/')]
public class DivisionStrategy : ICalculationStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand / secondOperand;
    }
}