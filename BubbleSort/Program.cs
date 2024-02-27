Console.WriteLine("Введите количество элементов массива: ");
int number = Convert.ToInt32(Console.ReadLine());
int[] array = new int[number];

for(int i = 0; i < number; i++)
{
    Console.Write("Введите элемент массива: ");
    array[i] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Начальный массив: [" + string.Join(",", array) + "]");
Console.WriteLine();

for(int i = 0; i < number; i++)
{
    for(int j = 0; j < number - 1; j++)
    {
        if(array[j] > array[j + 1])
        {
            int temp = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    }

    Console.WriteLine(i + "[" + string.Join(",", array) + "]");
}
