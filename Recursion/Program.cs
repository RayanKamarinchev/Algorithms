int[] arr = { 1, 2, 3, 4, 5 };
//Console.WriteLine(Sum(arr, 0)); 
//Draw(3);
//Gen(new int[5], 0);


static int Sum(int[] arr, int index)
{
    if (arr.Length - 1==index)
    {
        return arr[index];
    }
    return arr[index] + Sum(arr, index + 1);
}

static void Draw(int n)
{
    for (int i = n; i >= -n; i--)
    {
        if (i==0)
            continue;
        Console.WriteLine(new string((i>0?'*':'#'), Math.Abs(i)));
    }
}

static void Gen(int[] arr, int n)
{
    if (arr.Length==n)
    {
        foreach (var num in arr)
        {
            Console.Write(num);
        }

        Console.WriteLine();
        return;
    }
    for (int i = 0; i <= 1; i++)
    {
        arr[n] = i;
        Gen(arr, n + 1);
    }
}
