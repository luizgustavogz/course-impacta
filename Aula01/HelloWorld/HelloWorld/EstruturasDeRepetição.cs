using System;

namespace HelloWorld
{
    class EstruturasDeRepetição
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                var argumento = args[i];
                Console.WriteLine($"Argumento lido no for: {argumento}");
            }

            Console.WriteLine();
            for (var i = args.Length; i > 0; i--)
            {
                var argumento = args[i - 1];
                Console.WriteLine($"for ao contrário: {argumento}");
            }

            Console.WriteLine();
            foreach(var argumento in args)
            {
                Console.WriteLine($"Argumento lido no foreach: {argumento}");
            }

            Console.WriteLine();
            var j = 0;
            while (j < args.Length)
            {
                var argumento = args[j];
                Console.WriteLine($"Argumento lido no while: {argumento}");
                j++;
            }

            Console.WriteLine();
            var n = 0;
            do
            {
                var argumento = args[n];
                Console.WriteLine($"Argumento lido no do while: {argumento}");
                n++;
            } while (n < args.Length);
        }
    }
}
