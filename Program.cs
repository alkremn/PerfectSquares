using System;
using System.Collections.Generic;

namespace PerfectSquares
{
    class Program
    {
        const int kArraySize = 3;
        const int kSumConstant = 15;


        static void Main(string[] args)
        {
            int startPosition = 0;

            var targetValues = new List<List<int>>{
                new List<int>{4, 8, 2},
                new List<int>{4, 5, 7},
                new List<int>{6, 1, 6},
            };

            var values = new List<int>();

            for (int i = 1; i <= 9; i++)
            {
                values.Add(i);
            }

            var targetMatrix = new Matrix(targetValues);

            List<Matrix> perfectMatrices = new List<Matrix>();

            GeneratePermutations(values, startPosition, values.Count, perfectMatrices);

            var result = GetMinimumCostMatrix(perfectMatrices, targetMatrix);

            Console.WriteLine($"Current matrix is:");
            targetMatrix.Print();

            Console.WriteLine($"Perfect matrix is:");
            result.Value.Print();
            
            Console.WriteLine($"The minimum possible cost is {result.Key}");
        }

        static KeyValuePair<int, Matrix> GetMinimumCostMatrix(List<Matrix> perfectMatrices, Matrix targetMatrix)
        {

            int smallestCost = Int32.MaxValue;
            Matrix closestMatrix = null;

            foreach (var matrix in perfectMatrices)
            {
                int result = matrix.GetConvertingCost(targetMatrix);
                if (result < smallestCost)
                {
                    smallestCost = result;
                    closestMatrix = matrix;
                }
            }

            return new KeyValuePair<int, Matrix>(smallestCost, closestMatrix);
        }

        static void PerfectSquares(List<int> values, List<Matrix> perfectMatrices)
        {
            var matrix = GetMatrix(values);
            if (matrix.IsPerfect(kSumConstant))
            {
                perfectMatrices.Add(matrix);
            }
        }

        static Matrix GetMatrix(List<int> values)
        {
            var result = new List<List<int>>();
            List<int> row = new List<int>();

            for (int i = 0; i < values.Count; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    result.Add(row);
                    row = new List<int>();
                }
                row.Add(values[i]);
            }
            result.Add(row);

            return new Matrix(result);
        }

        static void GeneratePermutations(List<int> values, int startIndex, int size, List<Matrix> perfectMatrices)
        {
            if (startIndex == size)
            {
                PerfectSquares(values, perfectMatrices);
                return;
            }

            for (int i = startIndex; i < size; i++)
            {
                SwapValues(values, startIndex, i);
                GeneratePermutations(values, startIndex + 1, size, perfectMatrices);
                SwapValues(values, startIndex, i);
            }
        }

        static void SwapValues(List<int> values, int firstIndex, int secondIndex)
        {
            int temp = values[firstIndex];
            values[firstIndex] = values[secondIndex];
            values[secondIndex] = temp;
        }

    }
}
