using System;

namespace BinaryImageConverter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Converter converter = new Converter();

            while (true)
            {
                try
                {
                    Console.WriteLine("0-exit; 1-convert image to bytes; 2-convert bytes to image; 3-convert image to binary; 4-convert binary to image:");
                    string path;
                    switch (Console.ReadLine())
                    {
                        case "0":
                            System.Environment.Exit(0);
                            break;
                        case "1":
                            Console.Write("Enter path to picture: ");
                            path = Console.ReadLine();
                        
                            converter.ImageToBytes(path);
                            continue;
                        case "2":
                            Console.Write("Enter path to bytes: ");
                            path = Console.ReadLine();
                        
                            converter.BytesToImage(path);
                            continue;
                        case "3":
                            Console.Write("Enter path to picture: ");
                            path = Console.ReadLine();
                        
                            converter.ImageToBinary(path);
                            continue;
                        case "4":
                            Console.Write("Enter path to binary code: ");
                            path = Console.ReadLine();
                        
                            converter.BinaryToImage(path);
                            continue;
                        default:
                            Console.Write("Invalid operation! \n");
                            continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}