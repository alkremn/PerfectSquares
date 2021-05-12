using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectSquares
{
    public class Matrix
    {
        private List<List<int>> matrix_;

        public Matrix(List<List<int>> matrix)
        {
            this.matrix_ = matrix;
        }

        public bool IsPerfect(int constant)
        {
            return RowCheck(constant) && ColumnCheck(constant) && DiagonalCheck(constant);
        }

        public int GetConvertingCost(Matrix other)
        {
            int totalCost = 0;

            for (int i = 0; i < matrix_.Count; i++)
            {
                for (int j = 0; j < matrix_.Count; j++)
                {
                    totalCost += Math.Abs(matrix_[i][j] - other.matrix_[i][j]);
                }
            }
            return totalCost;
        }

        public void Print()
        {
            foreach (var row in matrix_)
            {
                Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
            }
            Console.WriteLine();
        }

        private bool DiagonalCheck(int constant)
        {
            int sum = 0;

            for (int i = 0; i < matrix_.Count; i++)
            {
                sum += matrix_[i][i];
            }

            if (sum != constant) return false;

            sum = 0;

            for (int i = 0, j = matrix_.Count - 1; i < matrix_.Count; i++, j--)
            {
                sum += matrix_[i][j];
            }

            return sum == constant;
        }


        private bool ColumnCheck(int constant)
        {
            int sum = 0;
            for (int i = 0; i < matrix_.Count; i++)
            {
                sum = matrix_[0][i] + matrix_[1][i] + matrix_[2][i];
                if (sum != constant)
                {
                    return false;
                }
                sum = 0;
            }
            return true;
        }

        private bool RowCheck(int constant)
        {
            int sum = 0;
            for (int i = 0; i < matrix_.Count; i++)
            {
                sum = matrix_[i].Sum();
                if (sum != constant)
                {
                    return false;
                }
                sum = 0;
            }
            return true;
        }
    }
}