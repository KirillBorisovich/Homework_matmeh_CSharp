// <copyright file="СalculatorBusinessLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator;

/// <summary>
/// Сalculator business logic.
/// </summary>
public class СalculatorBusinessLogic
{
    private double previousValue = 0;
    private string operation = string.Empty;
    private bool isNewOperation = true;

    /// <summary>
    /// Gets current value.
    /// </summary>
    public double CurrentValue { get; private set; } = 0;

    /// <summary>
    /// Clear values.
    /// </summary>
    public void Clear()
    {
        this.previousValue = 0;
        this.CurrentValue = 0;
        this.operation = string.Empty;
        this.isNewOperation = true;
    }

    /// <summary>
    /// Enter number.
    /// </summary>
    /// <param name="value">Number to enter.</param>
    public void EnterNumber(string value)
    {
        if (this.isNewOperation)
        {
            this.CurrentValue = int.Parse(value);
            this.isNewOperation = false;
            return;
        }

        this.CurrentValue = (this.CurrentValue * 10) + int.Parse(value);
    }

    /// <summary>
    /// Enter operation.
    /// </summary>
    /// <param name="inputOperation">Operation to be entered.</param>
    public void EnterOperation(string inputOperation)
    {
        if (!string.IsNullOrEmpty(this.operation) && !this.isNewOperation)
        {
            this.Calculate();
        }
        else
        {
            this.previousValue = this.CurrentValue;
        }

        this.operation = inputOperation;
        this.isNewOperation = true;
    }

    /// <summary>
    /// Calculate the expression.
    /// </summary>
    /// <exception cref="DivideByZeroException">Division by Zero Exception.</exception>
    /// <exception cref="UnknownOperationException">Unknown operation exception.</exception>
    public void Calculate()
    {
        if (string.IsNullOrEmpty(this.operation) && this.isNewOperation)
        {
            return;
        }

        switch (this.operation)
        {
            case "/":
                if (this.CurrentValue == 0)
                {
                    throw new DivideByZeroException();
                }

                this.CurrentValue = this.previousValue / this.CurrentValue;
                break;
            case "*":
                this.CurrentValue = this.previousValue * this.CurrentValue;
                break;
            case "-":
                this.CurrentValue = this.previousValue - this.CurrentValue;
                break;
            case "+":
                this.CurrentValue = this.previousValue + this.CurrentValue;
                break;
            default:
                throw new UnknownOperationException();
        }

        this.isNewOperation = true;
    }
}
