int n = int.Parse(Console.ReadLine());
List<int> queens = new List<int>();
int s = 0;
Solution();
Console.WriteLine(s);
void Solution()
{
    for (int i = 1; i <= n; i++)
    {
        queens.Add(i);
        if (!InDiagonal(queens))
        {
            if (queens.Count == n)
            {
                //foreach (var queen in queens)
                //{
                //    Console.WriteLine(queen);
                //}
                //Console.WriteLine();
                s++;
                queens.RemoveAt(queens.Count - 1);
                return;
            }
            Solution();
        }
        queens.RemoveAt(queens.Count-1);
    }
}

bool InDiagonal(List<int> queens)
{
    int x = queens[queens.Count - 1];
    for (int i = 0; i < queens.Count-1; i++)
    {
        int range = queens.Count - i - 1;
        if (x - range == queens[i]|| x + range == queens[i] || x == queens[i])
        {
            return true;
        }
    }
    return false;
}