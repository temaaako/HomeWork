using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        Main();
    }

    private void Main()
    {
        Console.WriteLine("================================");
        Console.Write("Введите кол-во строк: ");
        int getmassive0 = int.Parse(Console.ReadLine());
        Console.Write("Введите кол-во столбцов: ");
        int getmassive1 = int.Parse(Console.ReadLine());
        Console.WriteLine("================================");

        int[,] nums = new int[getmassive0, getmassive1];

        int Right = nums.GetLength(1);
        int down = nums.GetLength(0);
        int up = 0;
        int left = 0;
        int count = nums.GetLength(0) * nums.GetLength(1);
        int num = 0;


        while (count > num)
        {
            if (count > num)
            {
                for (int i = left; i < Right; i++) 
                {
                    nums[up, i] = num;
                    num++;
                }
            }

            up++;
            if (count > num)
            {
                for (int i = up; i < down; i++) 
                {
                    nums[i, Right - 1] = num;
                    num++;
                }
            }

            Right--;
            if (count > num)
            {
                for (int i = Right; i > left + 1; i--) 
                {
                    nums[down - 1, i] = num;
                    num++;
                }
            }

            down--;
            if (count > num)
            {
                for (int i = down; i > up; i--) 
                {
                    nums[i, left] = num;
                    num++;
                }
                left++;
            }
        }

        for (int i = 0; i < nums.GetLength(0); i++)
        {
            for (int j = 0; j < nums.GetLength(1); j++)
            {
                Console.Write(nums[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }

}
