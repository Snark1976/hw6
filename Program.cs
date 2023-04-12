internal class Program
{
    private static void Main(string[] args)
    {
        bool flag;
        Random rand = new();
        do
        {
            Console.Write("Введите номер задачи (41 или 43) для проверки или все, что угодно, для выхода: ");
            flag = Console.ReadLine() switch
            {
                "41" => Task41(),
                "43" => Task43(),
                _ => false
            };
        }
        while (flag);
    }

    static bool Task41()
    {
        Console.Write("Введите несколько чисел (разделитель пробел): ");
        int[] numbers = Console.ReadLine()!.Split(' ').Select(x => int.Parse(x)).ToArray();
        Console.WriteLine($"Введено чисел: {numbers.Length}, из них положительных: {numbers.Count(x => x > 0)}.");
        return true;
    }

    static bool Task43()
    {
        var equations = new double[2][];
        for (int i = 0; i < 2; i++)
        {
            Console.Write("Введите коэфициенты k и b {i + 1}-го уравнения (разделитель пробел): ");                         
            equations[i] = Console.ReadLine()!.Split(' ').Select(x => double.Parse(x)).ToArray();
        }
        if (equations[0][0] == equations[1][0])
        {
            string msg = equations[0][1] != equations[1][1] ? "Общих точек нет" 
                : $"Бесконечно много общих точек вида (x; {equations[0][0]} * x + {equations[0][1]})";
            Console.WriteLine(msg);           
        }
        else
        {
            double x = (equations[0][1] - equations[1][1]) / (equations[1][0] - equations[0][0]);
            double y = equations[0][0] * x + equations[0][1];
            Console.WriteLine($"Одна общая точка ({x}; {y})");
        }
        return true;
    }
}