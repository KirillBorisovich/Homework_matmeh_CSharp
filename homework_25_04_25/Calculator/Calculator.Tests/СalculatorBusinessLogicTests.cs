// <copyright file="СalculatorBusinessLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calculator.Tests;

public class СalculatorBusinessLogicTests
{
    private СalculatorBusinessLogic calculator;

    [SetUp]
    public void Setup()
    {
        this.calculator = new();
    }

    [Test]
    public void EnterNumberAndEnterOperationAndCalculateTest()
    {
        this.calculator.EnterNumber("2");
        this.calculator.EnterNumber("1");
        this.calculator.EnterOperation("+");
        this.calculator.EnterNumber("1");
        this.calculator.EnterNumber("0");
        this.calculator.Calculate();
        if (this.calculator.CurrentValue != 31.0)
        {
            Assert.Fail();
        }

        this.calculator.EnterOperation("-");
        this.calculator.EnterNumber("1");
        this.calculator.Calculate();
        if (this.calculator.CurrentValue != 30.0)
        {
            Assert.Fail();
        }

        this.calculator.EnterOperation("/");
        this.calculator.EnterNumber("-2");
        this.calculator.Calculate();
        if (this.calculator.CurrentValue != -15.0)
        {
            Assert.Fail();
        }

        this.calculator.EnterOperation("*");
        this.calculator.EnterNumber("-3");
        this.calculator.Calculate();
        if (this.calculator.CurrentValue != 45.0)
        {
            Assert.Fail();
        }

        this.calculator.Clear();
        Assert.That(this.calculator.CurrentValue, Is.EqualTo(0));
    }

    [Test]
    public void DivideByZeroExceptionTest()
    {
        this.calculator.EnterNumber("2");
        this.calculator.EnterOperation("/");
        this.calculator.EnterNumber("0");

        Assert.Throws<DivideByZeroException>(
            () => this.calculator.Calculate());
    }

    [Test]
    public void UnknownOperationExceptionTest()
    {
        this.calculator.EnterNumber("2");
        this.calculator.EnterOperation("#");
        this.calculator.EnterNumber("0");
        Assert.Throws<UnknownOperationException>(
            () => this.calculator.Calculate());
    }
}
