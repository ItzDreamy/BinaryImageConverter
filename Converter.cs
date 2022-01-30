using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace BinaryImageConverter
{
    public class Converter
    {
        public void ImageToBytes(string pathToImage)
        {
            Console.WriteLine("Converting started...");
            string imageBytes = string.Join(" ", File.ReadAllBytes(pathToImage));
            File.WriteAllText("bytes.txt", imageBytes);
            
            Console.WriteLine("Success!");
        }

        public void BytesToImage(string pathToBytes)
        {
            string[] bytesInString = File.ReadAllText(pathToBytes).Split(' ');
            byte[] imageBytes = new byte[bytesInString.Length];
            
            for (int i = 0; i < imageBytes.Length; i++)
                imageBytes[i] = Convert.ToByte(bytesInString[i]);

            using (Bitmap bitmap = new Bitmap(new MemoryStream(imageBytes)))
                bitmap.Save("image.png", ImageFormat.Png);

            Console.WriteLine("Success!");
        }
        
        public void ImageToBinary(string pathToImage)
        {
            Console.WriteLine("Converting started...");
            byte[] bytes = File.ReadAllBytes(pathToImage);

            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var b in bytes)
                stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

            string imageBinary = stringBuilder.ToString();
            
            File.WriteAllText("binary.txt", imageBinary);

            Console.WriteLine("Success!");
        }

        public void BinaryToImage(string pathToBinary)
        {
            string binary = File.ReadAllText(pathToBinary);

            byte[] bytes = new byte[binary.Length / 8];
            
            for(int i = 0; i < bytes.Length; ++i)
                bytes[i] = Convert.ToByte(binary.Substring(8 * i, 8), 2);

            using (Bitmap bitmap = new Bitmap(new MemoryStream(bytes)))
                bitmap.Save("image.png", ImageFormat.Png);
            
            Console.WriteLine("Success!");
        }
    }
}