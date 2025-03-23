namespace QuickSort2
{
    internal class Program
    {
        static void Main()
        {
            for (int i = 0; i < 20; i++)
            {
                int[] dizi = RastgeleDiziOlustur(6);
                QuickSort(dizi, 0, dizi.Length - 1);
                DiziYazdir(dizi);
            }
        }
        // Lomuto'nun Bölme Metodu
        static int LomutoBolme(int[] dizi, int dusuk, int yuksek)
        {
            int pivot = dizi[yuksek];
            int i = (dusuk - 1);

            for (int j = dusuk; j <= yuksek - 1; j++)
            {
                if (dizi[j] <= pivot)
                {
                    i++;
                    Degistir(dizi, i, j);
                }
            }
            Degistir(dizi, i + 1, yuksek);
            return (i + 1);
        }
        // Hoare'un Bölme Metodu
        static int HoareBolme(int[] dizi, int dusuk, int yuksek)
        {
            int pivot = dizi[dusuk];
            int i = dusuk - 1, j = yuksek + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (dizi[i] < pivot);

                do
                {
                    j--;
                } while (dizi[j] > pivot);

                if (i >= j)
                    return j;

                Degistir(dizi, i, j);
            }
        }

        static void Degistir(int[] dizi, int i, int j)
        {
            (dizi[j], dizi[i]) = (dizi[i], dizi[j]);
        }

        static void QuickSort(int[] dizi, int dusuk, int yuksek)
        {
            if (dusuk < yuksek)
            {
                int j = HoareBolme(dizi, dusuk, yuksek);
                QuickSort(dizi, dusuk, j - 1);
                QuickSort(dizi, j + 1, yuksek);
            }
        }

        static int[] RastgeleDiziOlustur(int uzunluk)
        {
            Random rastgele = new();
            int[] dizi = new int[uzunluk];
            for (int i = 0; i < uzunluk; i++)
            {
                dizi[i] = rastgele.Next(100);
            }
            return dizi;
        }

        static void DiziYazdir(int[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
