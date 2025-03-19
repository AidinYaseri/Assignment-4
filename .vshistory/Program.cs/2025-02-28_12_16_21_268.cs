namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Validate(3,3));
            Console.WriteLine(Validate(4.33,4.65));
            Console.WriteLine(Validate("Hello", "Hello"));
            Console.WriteLine(Validate(2.4f, 2.44));
            Console.WriteLine(Validate(3,4));
        }
        static bool Validate (int input, int number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(double input, double number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(string input, string number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(float input, int number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(byte input, byte number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(ushort input, int number, double anotherNumber)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(double input, double number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(string input, string number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(float input, int number)
        {
            if (input == number)
                return true;
            else
                return false;
        }
        static bool Validate(byte input, byte number)
        {
            if (input == number)
                return true;
            else
                return false;
        }

    }
}
