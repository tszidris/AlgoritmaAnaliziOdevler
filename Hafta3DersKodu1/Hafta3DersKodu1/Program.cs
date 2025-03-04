namespace BubbleSortAnaliziII
{
    internal class Program
    {
        static void Main()
        {
            // Büyük O = en kötü senaryo
            // Büyük Delta = en iyi senaryo
            // Büyük Teta = ortalama senaryo

            int[] siraliDizi = [3, 4, 5, 6, 10, 12, 15, 20, 23, 100];
            int[] sirasizDizi = [12, 3, 6, 4, 10, 5, 11, 7, 9, 8];
            int n = siraliDizi.Length;
            Console.WriteLine("Boyut n: " + n + "\n");

            Console.Write("Optimizasyon yapılmamış Bubble Sort O değeri: ");
            int sonucBir = BubbleSortOptimizasyonsuz(sirasizDizi);
            Console.WriteLine(sonucBir);

            Console.Write("Optimizasyon yapılmış Bubble Sort O değeri: ");
            int sonucIki = BubbleSortOptimizeli(sirasizDizi);
            Console.WriteLine(sonucIki);

            Console.WriteLine();

            Console.Write("Optimizasyon yapılmamış Bubble Sort Delta değeri: ");
            int sonucUc = BubbleSortOptimizasyonsuz(siraliDizi);
            Console.WriteLine(sonucUc);

            Console.Write("Optimizasyon yapılmış Bubble Sort Delta değeri: ");
            int sonucDort = BubbleSortOptimizeli(siraliDizi);
            Console.WriteLine(sonucDort);

            Console.WriteLine();

            Random rastgele = new();
            int denemeSayisi = 100;
            int toplamOptimizasyonsuz = 0, toplamOptimizeli = 0;

            for (int t = 0; t < denemeSayisi; t++)
            {
                int[] rastgeleDizi = new int[n];
                for (int i = 0; i < n; i++)
                {
                    rastgeleDizi[i] = rastgele.Next(1, 101); // 1 ile 100 arasında rastgele sayılarla doldur
                }

                toplamOptimizasyonsuz += BubbleSortOptimizasyonsuz(rastgeleDizi);
                toplamOptimizeli += BubbleSortOptimizeli(rastgeleDizi);
            }

            Console.WriteLine("Ortalama karşılaştırma sayısı (Optimizasyonsuz Bubble Sort): " + (toplamOptimizasyonsuz / denemeSayisi));
            Console.WriteLine("Ortalama karşılaştırma sayısı (Optimizeli Bubble Sort): " + (toplamOptimizeli / denemeSayisi));

            // Optimizasyon yapılmamış Bubble Sort için en iyi durum, en kötü durumla aynıdır, yani n^2.
            // Optimizasyon yapılmış Bubble Sort için en iyi durum n, en kötü durum n^2'dir.
        }

        static int BubbleSortOptimizasyonsuz(int[] orijinalDizi)
        {
            int n = orijinalDizi.Length;

            int[] dizi = new int[n];
            Array.Copy(orijinalDizi, dizi, n);

            int karsilastirmaSayisi = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (dizi[j] > dizi[j + 1])
                    {
                        (dizi[j + 1], dizi[j]) = (dizi[j], dizi[j + 1]);
                    }
                    karsilastirmaSayisi++;
                }
            }
            return karsilastirmaSayisi;
        }

        static int BubbleSortOptimizeli(int[] orijinalDizi)
        {
            int n = orijinalDizi.Length;

            int[] dizi = new int[n];
            Array.Copy(orijinalDizi, dizi, n);

            int karsilastirmaSayisi = 0;
            for (int i = 0; i < n - 1; i++)
            {
                bool degisimYok = true;
                for (int j = 0; j < n - 1; j++)
                {
                    if (dizi[j] > dizi[j + 1])
                    {
                        (dizi[j + 1], dizi[j]) = (dizi[j], dizi[j + 1]);
                        degisimYok = false;
                    }
                    karsilastirmaSayisi++;
                }
                if (degisimYok)
                {
                    break;
                }
            }
            return karsilastirmaSayisi;
        }
    }
}
