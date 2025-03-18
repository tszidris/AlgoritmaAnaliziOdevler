using System;

class MaxSubarrayDivideConquer
{
    public static int FindMaxSubarray(int[] nums)
    {
        return MaxSubArrayHelper(nums, 0, nums.Length - 1);
    }

    private static int MaxSubArrayHelper(int[] nums, int left, int right)
    {
        if (left == right)
        {
            return nums[left];
        }

        int mid = left + (right - left) / 2;

        int leftSum = MaxSubArrayHelper(nums, left, mid);
        int rightSum = MaxSubArrayHelper(nums, mid + 1, right);
        int crossingSum = MaxCrossingSum(nums, left, mid, right);

        return Math.Max(leftSum, Math.Max(rightSum, crossingSum));
    }

    private static int MaxCrossingSum(int[] nums, int left, int mid, int right)
    {
        int leftSum = int.MinValue;
        int sum = 0;

        for (int i = mid; i >= left; i--)
        {
            sum += nums[i];
            leftSum = Math.Max(leftSum, sum);
        }

        int rightSum = int.MinValue;
        sum = 0;

        for (int i = mid + 1; i <= right; i++)
        {
            sum += nums[i];
            rightSum = Math.Max(rightSum, sum);
        }

        return leftSum + rightSum;
    }

    public static void Main()
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine("Maksimum Alt Dizi Toplamı: " + FindMaxSubarray(nums));
    }
}
