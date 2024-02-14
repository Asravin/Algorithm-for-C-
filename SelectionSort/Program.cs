﻿void SortSekection(int[] collection)
{
    int size = collection.Length;
    for (int i = 0; i < size - 1; i++)
    {
      int pos = i;
      for (int j = i + 1; j < size; j++)
      {
        if (collection[j] < collection[pos]) pos = j;
      }
      int temp = collection[i];
      collection[i] = collection[pos];
      collection[pos] = temp;
    }
}


int[] array = {7, 6, 3, 4, 5, 1, 2, 3};
Console.WriteLine($"[{String.Join(',', array)}]");
SortSekection(array);
Console.WriteLine($"[{String.Join(',', array)}]");