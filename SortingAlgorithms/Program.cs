int[] arr = { 78, 55, 45, 98, 13 };

arr = quickSort(arr, 0, arr.Length-1);
foreach (var i in arr)
{
    Console.WriteLine(i);
}

static int[] BubbleSort(int[] arr)
{
    for (int i = 0; i <= arr.Length - 2; i++)
    {
        for (int j = 0; j <= arr.Length - 2; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }

    return arr;
}

static int[] SelectionSort(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        int minIndx = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[j] < arr[minIndx])
            {
                minIndx = j;
            }
        }

        (arr[i], arr[minIndx]) = (arr[minIndx], arr[i]);
    }

    return arr;
}

static int Partition(int[] arr, int left, int right)
{
    int pivot;
    pivot = arr[left];
    while (true)
    {
        while (arr[left] < pivot)
        {
            left++;
        }
        while (arr[right] > pivot)
        {
            right--;
        }
        if (left < right)
        {
            int temp = arr[right];
            arr[right] = arr[left];
            arr[left] = temp;
        }
        else
        {
            return right;
        }
    }
}
static int[] quickSort(int[] arr, int left, int right)
{
    int pivot;
    if (left < right)
    {
        pivot = Partition(arr, left, right);
        if (pivot > 1)
        {
            quickSort(arr, left, pivot - 1);
        }
        if (pivot + 1 < right)
        {
            quickSort(arr, pivot + 1, right);
        }
    }

    return arr;
}

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