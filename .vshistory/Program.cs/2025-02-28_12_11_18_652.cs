namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Validate(3,3));
            Console.WriteLine(Validate(4.33,4.65));
            Console.WriteLine(Validate("Hello", "Hello"));
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
      
    }
}
