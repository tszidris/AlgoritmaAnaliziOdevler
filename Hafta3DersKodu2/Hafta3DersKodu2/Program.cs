namespace LargestSubsum
{
    internal class Program
    {
        static int adimSayaci = 0;  // Adım sayısını takip eden statik sayaç

        static void Main()
        {
            // Test durumu: Pozitif ve negatif sayılar içeren dizi
            int[] testDizisi = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
            int enBuyukToplam = FindLargestSubsum(testDizisi);
            Console.WriteLine("En büyük alt dizi toplamı: " + enBuyukToplam);
            Console.WriteLine("Adım sayısı: " + adimSayaci);

            // Sayaç sıfırla ve ikinci test durumu
            adimSayaci = 0;  // Sayaç sıfırlanıyor
            int[] testDizisi2 = [2, 3, 5, 1, 6];
            int enBuyukToplam2 = FindLargestSubsum(testDizisi2);
            Console.WriteLine("En büyük alt dizi toplamı: " + enBuyukToplam2);
            Console.WriteLine("Adım sayısı: " + adimSayaci);

            // Sayaç sıfırla ve üçüncü test durumu
            adimSayaci = 0;  // Sayaç sıfırlanıyor
            int[] testDizisi3 = [-1, -2, -3, -4];
            int enBuyukToplam3 = FindLargestSubsum(testDizisi3);
            Console.WriteLine("En büyük alt dizi toplamı: " + enBuyukToplam3);
            Console.WriteLine("Adım sayısı: " + adimSayaci);

            // Sayaç sıfırla ve dördüncü test durumu
            adimSayaci = 0;  // Sayaç sıfırlanıyor
            int[] testDizisi4 = [5];
            int enBuyukToplam4 = FindLargestSubsum(testDizisi4);
            Console.WriteLine("En büyük alt dizi toplamı: " + enBuyukToplam4);
            Console.WriteLine("Adım sayısı: " + adimSayaci);
        }

        public static int FindLargestSubsum(int[] dizi)
        {
            int n = dizi.Length;
            int maxToplam = int.MinValue;  // maxToplam değişkenini çok küçük bir değere başlatıyoruz

            // Kaba kuvvet yöntemi ile O(n^3) karmaşıklık
            for (int baslangic = 0; baslangic < n; baslangic++)  // Başlangıç indeksini seçen ilk döngü
            {
                adimSayaci++;  // Dış döngü her çalıştığında sayaç artırılıyor

                for (int son = baslangic; son < n; son++)  // Bitiş indeksini seçen ikinci döngü
                {
                    adimSayaci++;  // İkinci döngü her çalıştığında sayaç artırılıyor

                    int toplam = 0;
                    for (int k = baslangic; k <= son; k++)  // Alt dizinin toplamını hesaplayan üçüncü döngü
                    {
                        toplam += dizi[k];
                        adimSayaci++;  // İç döngüde her toplama işlemi için sayaç artırılıyor
                    }
                    maxToplam = Math.Max(maxToplam, toplam);  // Daha büyük bir toplam bulunursa güncelle
                }
            }

            return maxToplam;  // En büyük alt dizi toplamını döndür
        }
    }
}
