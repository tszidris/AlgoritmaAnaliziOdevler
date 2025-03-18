using System;

public class MaxSubarrayKadane
{
    public int FindMaxSubarray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            throw new ArgumentException("Dizi boş olamaz.");
        }

        // Başlangıç Değerleri
        int currentSum = nums[0];  // Mevcut alt dizinin toplamı
        int maxSum = nums[0];      // Şu ana kadar bulunan en büyük alt dizi toplamı

        // Dizi üzerinde gezinme
        for (int i = 1; i < nums.Length; i++)
        {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        // En büyük toplamı döndür
        return maxSum;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        MaxSubarrayKadane kadane = new MaxSubarrayKadane();
        int result = kadane.FindMaxSubarray(nums);
        Console.WriteLine("En büyük toplamlı ardışık alt dizi toplamı: " + result);
    }
}
