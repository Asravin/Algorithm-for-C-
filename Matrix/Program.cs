int number = Convert.ToInt32(Console.ReadLine());
int[, ] matrix = new int[number, number];
for(int i = 1; i < number / 2; i++)
{
    for(int j = i; j < number; j++)
    {
        matrix[i, j] = i * j;
        matrix[j, i] = j * i;
    }
    Console.WriteLine();
}


for(int i = 1; i < number / 2; i++)
{
    for(int j = 1; j < number / 2; j++)
    {
        Console.Write(matrix[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}