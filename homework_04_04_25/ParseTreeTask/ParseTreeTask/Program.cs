using ParseTreeTask;

Calc exp = new("(* (+ 1 1) 2)");
Console.WriteLine(exp.CalculateExpression());
