namespace InsertionSort
{
    internal class Program
    {
        static void Main()
        {
            int[] siraliDizi = [1, 2, 3, 4, 5]; // En iyi durum O(n)
            int[] tersSiraliDizi = [5, 4, 3, 2, 1]; // En kötü durum O(n^2)

            int iterasyonSayisi = InsertionSort(siraliDizi);
            Console.WriteLine($"En iyi durum: {iterasyonSayisi} iterasyon");

            iterasyonSayisi = InsertionSort(tersSiraliDizi);
            Console.WriteLine($"En kötü durum: {iterasyonSayisi} iterasyon");
        }

        static int InsertionSort(int[] dizi)
        {
            int sayac = 0;
            for (int i = 1; i < dizi.Length; i++)
            {
                sayac++;
                int anahtar = dizi[i];
                int j = i - 1;

                while (j >= 0 && dizi[j] > anahtar)
                {
                    sayac++;
                    dizi[j + 1] = dizi[j];
                    j--;
                }

                dizi[j + 1] = anahtar;
            }
            return sayac;
        }
    }
}
