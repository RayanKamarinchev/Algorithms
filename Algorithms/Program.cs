List<int> numbers = new List<int>();
int max = 10;
for (int i = 1; i <= max; i++)
{
    numbers.Add(i);
}

Console.WriteLine(LinearSearch(numbers, 7));
Console.WriteLine(BinarySearch(numbers, 0));

static double LinearSearch(List<int> nums, int value)
{
    for (int i = 0; i < nums.Count; i++)
    {
        if (nums[i] == value)
        {
            return i;
        }
    }

    return -1;
}

static double BinarySearch(List<int> nums, int value)
{
    int left = 0;
    int right = nums.Count - 1;
    while (left <= right)
    {
        int index = (left + right) / 2;
        if (nums[index] > value)
        {
            right = index - 1;
        }
        else if (nums[index] < value)
        {
            left = index + 1;
        }
        else
        {
            return index;
        }
    }

    return -1;
}