// <copyright file="СalculatorBusinessLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Calculator;

/// <summary>
/// Сalculator business logic.
/// </summary>
public class СalculatorBusinessLogic : INotifyPropertyChanged
{
    private double previousValue = 0;
    private string operation = string.Empty;
    private bool isNewOperation = true;
    private double currentValue = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    public double CurrentValue
    {
        get => this.currentValue;
        private set
        {
            this.currentValue = value;
            this.OnPropertyChanged(nameof(this.CurrentValue));
        }
    }

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

        this.CurrentValue = (this.currentValue * 10) + double.Parse(value);
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
            this.previousValue = this.currentValue;
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
                if (this.currentValue == 0)
                {
                    throw new DivideByZeroException();
                }

                this.CurrentValue = this.previousValue / this.currentValue;
                break;
            case "*":
                this.CurrentValue = this.previousValue * this.currentValue;
                break;
            case "-":
                this.CurrentValue = this.previousValue - this.currentValue;
                break;
            case "+":
                this.CurrentValue = this.previousValue + this.currentValue;
                break;
            default:
                throw new UnknownOperationException();
        }

        this.isNewOperation = true;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
