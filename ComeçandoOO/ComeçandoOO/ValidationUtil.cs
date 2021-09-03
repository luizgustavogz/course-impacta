using System;

namespace ComeçandoOO
{
    class ValidationUtil<T>
    {
        public bool isValid (T data)
        {
            var result = false;

            if (data is String && data != null)
            {
                Console.WriteLine($"{data} = String válida!");
                result = true;
            }
            else if (data is int && data != null)
            {
                Console.WriteLine($"{data} = Int válida!");
                result = true;
            }
            else if (data is bool && data != null)
            {
                Console.WriteLine($"{data} = Bool válida!");
                result = true;
            }

            return result;
        }
    }
}
