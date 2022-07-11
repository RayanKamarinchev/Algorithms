int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
List<char> path = new List<char>();
List<int[]> marks = new List<int[]>();
char[,] matrix = new char[n, m];
for (int i = 0; i < n; i++)
{
    string row = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = row[j];
    }
}
Find(0, 0, 'S');

void Find(int row, int col, char direction)
{
    if (!IsInBounds(row, col))
        return;
    path.Add(direction);

    if (IsExit(row, col))
    {
        PrintPath();
    }
    else if (!IsVisited(row, col) && IsFree(row, col))
    {
        Mark(row, col);
        Find(row, col + 1, 'R');
        Find(row, col - 1, 'L');
        Find(row - 1, col, 'U');
        Find(row + 1, col, 'D');
        Unmark(row, col);
    }
    path.RemoveAt(path.Count - 1);
}

bool IsInBounds(int row, int col)
{
    return !(row >= n || row < 0) && !(col >= m || col < 0);
}

bool IsExit(int row, int col)
{
    return matrix[row, col] == 'e';
}

void PrintPath()
{
    for (int i = 1; i < path.Count; i++)
    {
        Console.Write(path[i]);
    }
    Console.WriteLine();
}

void Mark(int row, int col)
{
    marks.Add(new int[]{row, col});
}

void Unmark(int row, int col)
{
    marks.RemoveAll(s => s[0] == row && s[1] == col);
}

bool IsVisited(int row, int col)
{
    return marks.Exists(x => x[0] == row && x[1] == col);
}

bool IsFree(int row, int col)
{
    return matrix[row, col] == '-';
}
