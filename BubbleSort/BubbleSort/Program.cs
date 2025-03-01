using System;
using System.Diagnostics;

namespace BubbleSortAnalizi
{
    internal class Program
    {
        static void Main()
        {
            int[] diziBoyutlari = [100, 500, 1000, 5000, 10000, 100000, 1000000]; // Test edilecek dizi boyutları

            foreach (int boyut in diziBoyutlari)
            {
                int[] dizi = RastgeleDiziOlustur(boyut);
                Stopwatch kronometre = Stopwatch.StartNew();

                OptimizeEdilmisBubbleSort(dizi);

                kronometre.Stop();
                Console.WriteLine($"{boyut} elemanlı dizi {kronometre.ElapsedMilliseconds} ms içinde sıralandı.");
            }
        }

        static int[] RastgeleDiziOlustur(int boyut)
        {
            Random rastgele = new();
            int[] dizi = new int[boyut];

            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = rastgele.Next(1, 1001); // 1 ile 1000 arasında rastgele sayı
            }

            return dizi;
        }

        static void OptimizeEdilmisBubbleSort(int[] dizi)
        {
            int n = dizi.Length;
            bool degisti;

            for (int i = 0; i < n - 1; i++)
            {
                degisti = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (dizi[j] > dizi[j + 1])
                    {
                        // Elemanları yer değiştir
                        (dizi[j], dizi[j + 1]) = (dizi[j + 1], dizi[j]);
                        degisti = true;
                    }
                }

                // Eğer hiç değişiklik yapılmadıysa, dizi zaten sıralıdır
                if (!degisti)
                    break;
            }
        }
    }
}
