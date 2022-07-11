//input
int target = 18;
int[] values = new int[3]{5, 3, 2};

Console.WriteLine(Greedy(target, values));

static int Greedy(int target, int[] values)
{
    values = mergeSort(values);
    int sum = 0;
    int steps = 0;
    while (sum != target)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (sum + values[values.Length - 1 - i] <= target)
            {
                steps++;
                sum += values[values.Length - 1 - i];
                i = values.Length;
            }
        }
    }

    return steps;
}
    //sorting
static int[] mergeSort(int[] array)
{
    int[] left;
    int[] right;
    int[] result = new int[array.Length];
    if (array.Length <= 1)
        return array;
    int midPoint = array.Length / 2;
    left = new int[midPoint];
    right = array.Length % 2 == 0 ? new int[midPoint] : new int[midPoint + 1];
    for (int i = 0; i < midPoint; i++)
    {
        left[i] = array[i];
    }

    int x = 0;
    for (int i = midPoint; i < array.Length; i++)
    {
        right[x] = array[i];
        x++;
    }

    left = mergeSort(left);
    right = mergeSort(right);
    result = merge(left, right);
    return result;
}

static int[] merge(int[] left, int[] right)
{
    int resultLength = right.Length + left.Length;
    int[] result = new int[resultLength];
    int indexLeft = 0, indexRight = 0, indexResult = 0;
    while (indexLeft < left.Length || indexRight < right.Length)
    {
        if (indexLeft < left.Length && indexRight < right.Length)
        {
            if (left[indexLeft] <= right[indexRight])
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
            }
            else
            {
                result[indexResult] = right[indexRight];
                indexRight++;
            }

            indexResult++;
        }
        else if (indexLeft < left.Length)
        {
            result[indexResult] = left[indexLeft];
            indexLeft++;
            indexResult++;
        }
        else if (indexRight < right.Length)
        {
            result[indexResult] = right[indexRight];
            indexRight++;
            indexResult++;
        }
    }

    return result;
}