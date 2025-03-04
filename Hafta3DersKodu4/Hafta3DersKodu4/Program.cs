namespace PowFunction
{
    internal class Program
    {
        static int callCount = 0;  // Fonksiyon çağrılarının sayısını tutan statik sayaç
        static void Main()
        {
            // PowFunctionLinear testini yapıyoruz
            Console.WriteLine("PowFunctionLinear Testi:");
            callCount = 0;
            int resultLinear = PowFunctionLinear(2, 16);
            Console.WriteLine($"PowFunctionLinear Sonucu: {resultLinear}");
            Console.WriteLine($"PowFunctionLinear fonksiyon çağrıları: {callCount}");

            Console.WriteLine();  // Testler arasında açıklayıcı bir boşluk

            // PowFunctionRecursive testini yapıyoruz
            Console.WriteLine("PowFunctionRecursive Testi:");
            callCount = 0;  // Her test öncesinde sayaç sıfırlanır
            int resultRecursive = PowFunctionRecursive(2, 16);
            Console.WriteLine($"PowFunctionRecursive Sonucu: {resultRecursive}");
            Console.WriteLine($"PowFunctionRecursive fonksiyon çağrıları: {callCount}");
        }

        static int PowFunctionLinear(int x, int y)
        {
            int result = 1;

            for (int i = 0; i < y; i++)
            {
                callCount++;
                result *= x;
            }

            return result;
        }

        static int PowFunctionRecursive(int x, int y)
        {
            callCount++;  // Fonksiyon her çağrıldığında sayaç artar
            int m;
            if (y == 0)
                return 1;

            if (y % 2 == 1)
                return x * PowFunctionRecursive(x, y - 1);

            m = PowFunctionRecursive(x, y / 2);
            return m * m;
        }
    }
}
