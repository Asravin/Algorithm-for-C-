const int N = 1000;
const int THREADS_NUMBER = 10;

int[,] SerialMulRes = new int[N, N];
int[,] ThreadMulRes = new int[N, N];

int[,] FirstMatrix = MatrixGenerator(N, N);
int[,] SecondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(FirstMatrix, SecondMatrix);
PrepareParallelMatrixMul(FirstMatrix, SecondMatrix);
Console.WriteLine(EqualityMatrix(SerialMulRes, ThreadMulRes));

int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];

    for(int i = 0; i < res.GetLength(0); i++)
    {
        for(int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Ошибка: невозможно умножить данные матрицы");

    for(int i = 0; i < a.GetLength(0); i++)
    {
        for(int j = 0; j < b.GetLength(1); j++)
        {
            for(int k = 0; k < b.GetLength(0); k++)
            {
                SerialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Ошибка: невозможно умножить данные матрицы");
    int EachThreadCals = N / THREADS_NUMBER;
    
    var ThreadsList = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int StartPos = i * EachThreadCals;
        int EndPos = (i + 1) * EachThreadCals;

        if(i == THREADS_NUMBER - 1) EndPos = N;
        ThreadsList.Add(new Thread(() => ParallelMatrixMul(a, b, StartPos, EndPos)));
        ThreadsList[i].Start();
    }

    for(int i = 0; i < THREADS_NUMBER; i++)
    {
        ThreadsList[i].Join();
    }
}

void ParallelMatrixMul(int[,] a, int[,] b, int StartPos, int EndPos)
{
    for(int i = StartPos; i < EndPos; i++)
    {
        for(int j = 0; j < b.GetLength(1); j++)
        {
            for(int k = 0; k < b.GetLength(0); k++)
            {
                ThreadMulRes[i, j] += a[i, j] * b[k, j];
            }
        }
    }
}

bool EqualityMatrix(int[,] fMatrix, int[,] sMatrix)
{
    bool res = true;
    

    for(int i = 0; i < fMatrix.GetLength(0); i++)
    {
        for(int j = 0; j < fMatrix.GetLength(1); j++)
        {
            res = res && (fMatrix[i, j] == sMatrix[i, j]);
        }
    }
    return res;
}