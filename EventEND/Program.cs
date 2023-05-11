using System;

namespace EventEND
{
    delegate void MyEventHandler(double x, double y);
    class MyEvent
    {
        MyEventHandler[] evnt = new MyEventHandler[4];
        public event MyEventHandler SomeEvent
        {
            // Добавить событие в список.
            add
            {
                int i;
                for (i = 0; i < 4; i++)
                    if (evnt[i] == null)
                    {
                        evnt[i] = value;
                        break;
                    }
                if (i == 4) Console.WriteLine("Список событий заполнен.");
            }
            remove
            {
                int i;
                for (i = 0; i < 4; i++)
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                if (i == 4) Console.WriteLine("Обработчик событий не найден.");
            }
        }
        public void OnSomeEvent(double x, double y)
        {
            for (int i = 0; i < 4; i++)
                if (evnt[i] != null) evnt[i](x, y);
        }
    }
    class Operation
    {
        public void Summa(double a, double b)
        {
            Console.WriteLine("Событие суммы:");
            Console.WriteLine(a + b);

        }

        public void Substract(double a, double b)
        {
            Console.WriteLine("Событие разности:");
            Console.WriteLine(a - b);
        }

        public void Divide(double a, double b)
        {
            Console.WriteLine("Событие деления:");
            if (b == 0)
            {
                Console.WriteLine("На ноль делить нельзя");
            }
            else { Console.WriteLine(a / b); }
        }

        public void Multi(double a, double b)
        {
            Console.WriteLine("Событие произведения:");
            Console.WriteLine(a * b);
        }
    }
    class Program
    {
        static void Main()
        {
            MyEvent evt = new MyEvent();
            Operation s = new Operation();
            evt.SomeEvent += s.Summa;
            evt.SomeEvent += s.Multi;
            evt.SomeEvent += s.Substract;
            evt.SomeEvent += s.Divide;
            Console.WriteLine("Введите числа");
            double a = Int32.Parse(Console.ReadLine());
            double b = Int32.Parse(Console.ReadLine());
            evt.OnSomeEvent(a, b);
            evt.SomeEvent += s.Divide;
            Console.ReadKey();


        }
    }
}