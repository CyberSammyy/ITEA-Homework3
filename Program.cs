using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ITEA_Homework3
{
    class Program
    {
        private static int Check(int size) //array size validation method
        {
            if (size > 16 || size < 1)
            {
                return -1;
            }
            else return 0;
        }
        public static void Show(int[,] array) //method that shows all elements in array with tabulation
        {
            int size = (int)Sqrt(array.Length);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static int[,] MatrixCreator(int size, int mode) //creates matrixes according to the tasks from the second part
        {
            if (Check(size) < 0)
            {
                Console.WriteLine("Error. Incorrect size.");
                int[,] error = new int[1, 1];
                error[0, 0] = -1;
                return error;
            }
            else
            {
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Array is created by matrix creator.");
            }
            int[,] array = new int[size, size];
            int temp = size;
            int temp_2 = 0;
            for (int i = 0; i < size; i++) //this fills a matrix with zeros
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = 0;
                }
            }
            if (mode == 1) //this part of code (task 1) fills only the top part of matrix. then it just copy top part to the bottom row by row
            {
                for(int i = 0; i < size; i++)
                {
                    int counter = 0;
                    for (int j = temp_2; j < temp; j++)
                    {
                        if(i == 0 || i == size - 1)
                        {
                            array[i, j] = counter + 1;
                        }
                        else
                        {
                            array[i, j] = counter + 1;
                        }
                        counter++;
                    }
                    temp_2++;
                    temp--;
                    if (temp == temp_2) break;
                }
                for(int i = 0; i < (int)size/2; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        array[size - i - 1, j] = array[i, j];
                    }
                }
            }
            else if(mode == 2) //task 2
            {
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        array[i, j] = (i == 0 || j == size - 1 || j == 0 || i == size - 1) ? 1 : 0;
                    }
                }
            }
            else if(mode == 3) //task 3
            {
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        if(i == j || i + j == size - 1)
                        {
                            array[i, j] = 1;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect mode. returning zeros");
            }
            return array;
        }
        public static int[,] RandomMatrixCreator(int size) //creates matrix randomly
        {
            if (Check(size) < 0)
            {
                Console.WriteLine("Error. Incorrect size.");
                int[,] error = new int[1, 1];
                error[0, 0] = -1;
                return error;
            }
            else
            {
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Array is created randomly.");
            }
            Random ran = new Random();
            int[,] array = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    array[i, j] = ran.Next() / 100000000;
                }
            }
            return array; //if user entered incorrect mode, returns zero-filled matrix
        }
        public static double[] MatrixCalculator(int[,] array) //calculater minimum, maximum and average of any matrix
        {
            if(array[0,0] == -1) 
            {
                Console.WriteLine("Can't calculate because of incorrect size data. Returning zeros.");
                double[] error = new double[3];
                error[0] = error[1] = error[2] = 0;
                return error;
            }
            int size = (int)Sqrt(array.Length);
            double avg = 0;
            double[] res = new double[3];
            int max = array[0, 0];
            int min = array[0, 0];
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    avg += array[i, j];
                    if (j + 1 < size && array[i, j + 1] > max) max = array[i, j + 1];
                    if (j + 1 < size && array[i, j + 1] < min) min = array[i, j + 1];
                }
            }
            avg = avg / array.Length;
            res[0] = avg;
            res[1] = min;
            res[2] = max;
            return res;
        }
        static void Main(string[] args) //i divided code into methods, because i don't like when everything is in the Main block. For each action i created a method
        {
            while (true) //creates a loop, which can be stopped by user
            {
                int size = 0;
                Console.WriteLine("Enter array size (From 1 to 16). Then input creating mode (1 - first picture from task, 2 - second picture, 3 - third picture).");
                while (!int.TryParse(Console.ReadLine(), out size)) //i wanted this program to tell me that i entered incorrect information, that's why i didnt use do-while loop
                {
                    Console.WriteLine("Try again!");
                }
                int[,] matrix = RandomMatrixCreator(size); //calls a method to create matrix
                double[] result = MatrixCalculator(matrix); //calls a method to calculate values from the task
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Random matrix:");
                Console.WriteLine(new string('=', 100));
                Show(matrix); //shows matrix
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Minimum: {0}, Maximum: {1}, Average: {2}.", result[1], result[2], result[0]); //method returns an array of 3 elements - Average value, Minimum and Maximum values. I wanted to return a tuple with 3 elements, but i decided to perform returning with an array.
                Console.WriteLine(new string('=', 100));
                int mode = 0;
                Console.WriteLine("Now, enter mode: "); //here is the second part of a program
                while (!int.TryParse(Console.ReadLine(), out mode))
                {
                    Console.WriteLine("Try again!");
                }
                int[,] matrix2 = new int[size, size];
                matrix2 = MatrixCreator(size, mode); //calls a method to create matrix
                Console.WriteLine(new string('=', 100));
                Show(matrix2); //shows matrix
                Console.WriteLine(new string('=', 100));
                Console.WriteLine("Do you want to continue? Y/N"); //asking user what to do
                var a = Console.ReadKey();
                if (a.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    continue;
                }
                else break;
            }
            Console.Clear();
            Console.WriteLine("Bye!"); 
            Console.ReadKey();
        }
    }
}
