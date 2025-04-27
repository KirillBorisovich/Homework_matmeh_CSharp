// <copyright file="CalculatorUI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator;

/// <summary>
/// Calculator graphical interface.
/// </summary>
public partial class CalculatorUI : Form
{
    private ÑalculatorBusinessLogic calculator = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorUI"/> class.
    /// </summary>
    public CalculatorUI()
    {
        this.InitializeComponent();

        this.Output.DataBindings.Add(
            "Text",
            this.calculator,
            "CurrentValue",
            false,
            DataSourceUpdateMode.OnPropertyChanged);

        foreach (Control control in this.ControlButtons.Controls)
        {
            if (control is Button button)
            {
                if (button.Text == "C")
                {
                    button.Click += this.Clear_Click;
                }
                else if (button.Text == "=")
                {
                    button.Click += this.Equality_Click;
                }
                else if (char.IsDigit(button.Text[0]))
                {
                    button.Click += this.NumberButton_Click;
                }
                else
                {
                    button.Click += this.OperationButton_Click;
                }
            }
        }
    }

    private void NumberButton_Click(object? sender, EventArgs e)
    {
        var button = (Button?)sender;

        if (button == null)
        {
            return;
        }

        this.calculator.EnterNumber(button.Text);
    }

    private void OperationButton_Click(object? sender, EventArgs e)
    {
        var button = (Button?)sender;

        if (button == null)
        {
            return;
        }

        try
        {
            this.calculator.EnterOperation(button.Text);
        }
        catch (DivideByZeroException)
        {
            this.HandleError("Division by zero error!");
        }
        catch (UnknownOperationException)
        {
            this.HandleError("Unknown operation error!");
        }
    }

    private void Equality_Click(object? sender, EventArgs e)
    {
        try
        {
            this.calculator.Calculate();
        }
        catch (DivideByZeroException)
        {
            this.HandleError("Division by zero error!");
        }
        catch (UnknownOperationException)
        {
            this.HandleError("Unknown operation error!");
        }
    }

    private void Clear_Click(object? sender, EventArgs e)
    {
        this.calculator.Clear();
    }

    private void HandleError(string message)
    {
        this.calculator.Clear();
        this.Output.Text = message;
    }
}