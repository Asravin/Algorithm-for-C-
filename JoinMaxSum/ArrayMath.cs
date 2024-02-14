public static class ArrayMath{
    public static int GetSum(this int[] array, int math = 3){
        int max = 0;
        int size = array.Length;

        for(int i = 0; i <= size - math; i++){
            int temp = 0;

            for(int j = 0; j < math; j++){
                temp += array[j];
            }

            if(temp > max) max = temp;
        }

        return max;
    }
}