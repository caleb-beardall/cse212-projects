using System.Globalization;
using System.IO.Pipelines;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];

        // Until enough items have been added to the array to meet the required length
        // set the value at the given index to index times the number being multiplied
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // (i + 1) accounts for 0 index
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Find the index where the "rotation" will occur
        int index = data.Count - amount;

        // Using the index variable, copy the elements that will be removed, remove them the end of the array,
        // and insert them at the front of the array
        List<int> subset = data.GetRange(index, amount);
        data.RemoveRange(index, amount);
        data.InsertRange(0, subset);
    }
}
