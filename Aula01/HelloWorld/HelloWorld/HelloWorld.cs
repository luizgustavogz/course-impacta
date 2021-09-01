using System;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            bool isAdulto = true;
            decimal valor = 10.55m;
            double valor2 = 10.55;
            char sexo = 'M';

            var nome = "Luiz Gustavo";
            var idade = 19;

            Console.WriteLine($"{nome}, sexo: {sexo}, {idade} anos");
        }
    }
}
