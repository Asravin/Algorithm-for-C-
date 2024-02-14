public static class ArrayCreator{
    public static int[] Create(this int number){
        return new int[number];
    }

    public static string ConvertToString(this int[] array){
        string str = $"[{String.Join(',', array)}]";
        System.Console.WriteLine(str);
        return str;
    }

    public static int[] Fill(this int[] array, int min = 0, int max = 10){
        return array = array.Select(item => Random.Shared.Next(min, max)).ToArray();
    }
}