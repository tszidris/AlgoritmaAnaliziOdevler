namespace KthSelectionAnalysis
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        static void Main()
        {
            int[] dizi = RastgeleDiziOlustur(10000000); // 10 milyon elemanlı rastgele bir dizi oluştur
            int k = 10; // 10. en küçük elemanı bul

            // Yöntem 1: Tüm diziyi sıralayarak bulma
            Stopwatch zamanlayici1 = Stopwatch.StartNew();
            int kacinciKucuk1 = FindKthSmallestBySorting(dizi, k);
            zamanlayici1.Stop();
            Console.WriteLine($"(Tam Sıralama) {k}. en küçük eleman: {kacinciKucuk1}, Süre: {zamanlayici1.ElapsedMilliseconds} ms");

            // Yöntem 2: Sadece k elemanı sıralayarak ve geri kalanını işlemeye devam ederek bulma
            Stopwatch zamanlayici2 = Stopwatch.StartNew();
            int kacinciKucuk2 = FindKthSmallestInsertionSort(dizi, k);
            zamanlayici2.Stop();
            Console.WriteLine($"(Kısmi Sıralama) {k}. en küçük eleman: {kacinciKucuk2}, Süre: {zamanlayici2.ElapsedMilliseconds} ms");
        }

        // Rastgele Dizi Oluşturma Metodu
        static int[] RastgeleDiziOlustur(int boyut)
        {
            Random rastgele = new();
            int[] dizi = new int[boyut];
            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = rastgele.Next(1, 10001); // 1 ile 10.000 arasında rastgele sayılar
            }
            return dizi;
        }

        // Tüm diziyi sıralayarak k. en küçük elemanı bulan metod
        static int FindKthSmallestBySorting(int[] dizi, int k)
        {
            int[] diziKopya = (int[])dizi.Clone(); // Orijinal diziyi değiştirmemek için kopya oluştur
            Array.Sort(diziKopya); // Diziyi sırala
            return diziKopya[k - 1]; // k. en küçük elemanı döndür
        }

        // Kısmi sıralama kullanarak k. en küçük elemanı bulan metod
        static int FindKthSmallestInsertionSort(int[] dizi, int k)
        {
            // İlk k elemanı saklayacak yeni bir dizi oluştur
            int[] kDizi = new int[k];

            // İlk k elemanı kopyala
            Array.Copy(dizi, kDizi, k);

            // İlk k elemanı Ekleme (Insertion) Sıralaması ile sırala
            for (int i = 1; i < k; i++)
            {
                int anahtar = kDizi[i];
                int j = i - 1;

                while (j >= 0 && kDizi[j] > anahtar)
                {
                    kDizi[j + 1] = kDizi[j];
                    j--;
                }
                kDizi[j + 1] = anahtar;
            }

            // Dizide kalan elemanları işle
            for (int i = k; i < dizi.Length; i++)
            {
                if (dizi[i] < kDizi[k - 1]) // Eğer yeni eleman, kDizi içindeki en büyük elemandan küçükse
                {
                    kDizi[k - 1] = dizi[i]; // En büyük elemanı değiştir

                    // Tekrar Insertion Sort ile sıralama yap
                    int anahtar = kDizi[k - 1];
                    int j = k - 2;
                    while (j >= 0 && kDizi[j] > anahtar)
                    {
                        kDizi[j + 1] = kDizi[j];
                        j--;
                    }
                    kDizi[j + 1] = anahtar;
                }
            }

            return kDizi[k - 1]; // En küçük k eleman arasında en büyük olanı döndür
        }
    }
}
