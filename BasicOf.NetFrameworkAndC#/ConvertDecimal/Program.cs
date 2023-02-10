using System;
using System.Collections;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;   
            int basesystem;
            int quantity = 1;
            string remainder;
            ArrayList conversnumber = new ArrayList();

            try
            {
                Console.Write("Enter an integer in decimal number:  ");
                number = Convert.ToInt32(Console.ReadLine());
                Console.Write("input a new base number system(from 2 to 20):  ");
                basesystem = Convert.ToInt32(Console.ReadLine());

                while(quantity != 0)
                {
                    quantity = number / basesystem;
                    remainder = (number % basesystem).ToString();
                    switch (remainder)
                    {
                        case "10": 
                            remainder = "A";
                            break;
                        case "11": 
                            remainder = "B";
                            break;
                        case "12":
                            remainder = "C";
                            break;
                        case "13":
                            remainder = "D";
                            break;
                        case "14":
                            remainder = "E";
                            break;
                        case "15":
                            remainder = "F";
                            break;
                        case "16":
                            remainder = "G";
                            break;
                        case "17":
                            remainder = "H";
                            break;
                        case "18":
                            remainder = "I";
                            break;
                        case "19":
                            remainder = "J";
                            break;
                            default:
                            break;

                    }
                    conversnumber.Add(remainder);
                    number = quantity;
                }
            }
            catch (Exception ex)
            {  }

            for(int i = conversnumber.Count-1; i >= 0; i--)
            
                Console.Write(conversnumber[i]);
            Console.WriteLine();

        }
    }
}