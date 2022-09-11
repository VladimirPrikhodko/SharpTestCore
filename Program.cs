using System.Diagnostics;
using Xunit;
using static System.Console;

namespace Test
{
    [Flags]
    public enum FlagNumbers : byte
    {
        zero = 0b_0000_0000,
        one = 0b_0000_0001,
        two = 0b_0000_0010,
        four = 0b_0000_0100,
        eifht = 0b_0000_1000,
        sixteen = 0b_0001_0000,
        thirtyTwo = 0b_0010_0000,
        sixtyFour = 0b_0100_0000,
    }

    public class Price
    {
        public static int Age = default;
        //public Price() { Age = default; } 

        [Fact]                                  // [Theory]                  several lines to method(string, int)
        public static void TestAdding()         // [InlineData("A", 0)]
        {                                       // [InlineData("B", 1)]
            // размещение
            int a = 2;
            int b = 2;
            int expected = 4;

            // действие
            int actual = a + b;

            // утверждение
            Assert.Equal(expected, actual);
        }
                                                                                    // default value
        public static (string, int IntFromStr) MethodWithTupple(string str, string defaultValue = "5")
            => (str, int.Parse(defaultValue));

        ///<summary>
        ///Send number to calculate its factorial.</summary>
        /// <param name="number">
        /// Number is cardinal value. </param>
        /// <returns>
        /// Factorial of number. </returns>
        public static int Factorial(int number)
        {
            if (number < 1)
                return 0;
            if (number == 1)
                return 1;
            return number * Factorial(number - 1);
        }

        public static int Fibbonachi(int num) =>
            num switch
            {
                1 => 0,
                2 => 1,
                _ => Fibbonachi(num - 1) + Fibbonachi(num - 2)
            };
    }

    public class SampleCollection<T>   // Generic Class with Indexer
    {
        private T[] arr = new T[10];
        public T this[int idx]
        {
            get => arr[idx];
            set => arr[idx] = value;
        }
    }

    public class SharpTestCore
    {
        static void Main(string[] args)
        {
            SampleCollection<string> collection = new SampleCollection<string>();
            collection[0] = "first";

            var tupple = Price.MethodWithTupple("13");
            WriteLine($"Tupple: {tupple.Item1} / {tupple.IntFromStr}");    // item or name
            (string strTup, int intTup) = tupple;         // Деконструция кортежа на две переменные

            var flagNumbers = FlagNumbers.one | FlagNumbers.four | FlagNumbers.two;           // Enum with flags
            WriteLine(flagNumbers);

            Price.TestAdding();

            // запись в текстовой файл, расположенный в файле проэкта
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));

            // модуль записи текста буферизируется, поэтому вызываем Flush для вмех прослушивателей полсле записи
            Trace.AutoFlush = true;

            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");

            WriteLine(Price.Factorial(5));

            for (int i = 1; i < 10; i++)
            {
                WriteLine("Fibbonachi " + i + " -> " + Price.Fibbonachi(i));
            }

            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: "green",
                ignoreCase: true);

            int number = 1234567890;
            Console.WriteLine(number.ToString("000-000-00-00"));  // format number

            if (OperatingSystem.IsWindows())
            {
                WriteLine("It's a Windows!");
            }

            var num = new Random().Next(10);
            if (num is int j)                  // j - local var, true if i - int
            {
                WriteLine(j);
            }

            string message = num switch
            {
                > 0 and < 10 => " Correct number",   // { Items: > 10, Cost: > 1000.00m } => 0.10m     ( > 10,  > 1000.00m) => 0.10m
                _ => " Wrong number"
            };
            WriteLine(num + message);

            WriteLine($"Date: {DateTime.Now: dd MMMM yyyy}");
        }
    }
}