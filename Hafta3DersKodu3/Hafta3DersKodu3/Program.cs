namespace MinMaxVeİkiliArama
{
    internal class Program
    {
        static void Main()
        {
            int[] sıralıDizi = [1, 2, 3, 4, 5, 6, 7, 8];
            int[] sırasızDizi = [8, 5, 3, 2, 7, 6, 4, 1];
            int arananDeğer = 7;

            Console.WriteLine("N değeri: " + sıralıDizi.Length);
            Console.WriteLine();

            Console.WriteLine("Min Fonksiyonu Test Ediliyor:");
            Console.WriteLine("En İyi Durum (İlk Eleman Minimum): " + Min(sıralıDizi));
            Console.WriteLine("En Kötü Durum (Son Eleman Minimum): " + Min(sırasızDizi));

            Console.WriteLine("\nMax Fonksiyonu Test Ediliyor:");
            Console.WriteLine("En İyi Durum (İlk Eleman Maksimum): " + Max(sıralıDizi.Reverse().ToArray()));
            Console.WriteLine("En Kötü Durum (Son Eleman Maksimum): " + Max(sırasızDizi.Reverse().ToArray()));

            Console.WriteLine("\nDoğrusal Arama Test Ediliyor:");
            Console.WriteLine("En İyi Durum (İlk Eleman Eşleşmesi): " + DogrusalArama(sıralıDizi, sıralıDizi[0]));
            Console.WriteLine("En Kötü Durum (Son Eleman Eşleşmesi): " + DogrusalArama(sıralıDizi, sıralıDizi[^1]));
            Console.WriteLine("Ortalama Durum (Orta Eleman Eşleşmesi): " + DogrusalArama(sıralıDizi, sıralıDizi[(sıralıDizi.Length - 1) / 2]));

            Console.WriteLine("\nİkili Arama Test Ediliyor:");
            Console.WriteLine("En İyi Durum (Orta Eleman Eşleşmesi): " + IkiliArama(sıralıDizi, sıralıDizi[(sıralıDizi.Length - 1) / 2]));
            Console.WriteLine("En Kötü Durum (Bulunamama Durumu): " + IkiliArama(sıralıDizi, 100));
            Console.WriteLine("Ortalama Durum (Rastgele Eleman Eşleşmesi): " + IkiliArama(sıralıDizi, arananDeğer));
        }

        static int Min(int[] dizi)
        {
            int kontrol = 1;
            int min = dizi[0];
            for (int i = 1; i < dizi.Length; i++)
            {
                kontrol++;
                if (dizi[i] < min)
                {
                    min = dizi[i];
                }
            }
            return kontrol;
        }

        static int Max(int[] dizi)
        {
            int kontrol = 1;
            int max = dizi[0];
            for (int i = 1; i < dizi.Length; i++)
            {
                kontrol++;
                if (dizi[i] > max)
                {
                    max = dizi[i];
                }
            }
            return kontrol;
        }

        static int DogrusalArama(int[] dizi, int değer)
        {
            int kontrol = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                kontrol++;
                if (dizi[i] == değer)
                {
                    break;
                }
            }
            return kontrol;
        }

        static int IkiliArama(int[] dizi, int değer)
        {
            int n = dizi.Length;
            int[] diziKopya = new int[n];
            Array.Copy(dizi, diziKopya, n);
            Array.Sort(diziKopya);

            int kontrol = 0;
            int sol = 0;
            int sağ = n - 1;

            while (sol <= sağ)
            {
                kontrol++;
                int orta = (sol + sağ) / 2;
                if (değer > diziKopya[orta])
                    sol = orta + 1;
                else if (değer < diziKopya[orta])
                    sağ = orta - 1;
                else
                    break;
            }

            return kontrol;
        }
    }
}

