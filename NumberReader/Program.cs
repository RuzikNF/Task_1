using System;
using System.IO;
using System.Security;

class NumberReader
{
    const string FILE_PATH = "../../../t.dat";
    static void Main()
    {
        try
        {
            FileStream f = new FileStream(FILE_PATH, FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            BinaryWriter fOut = new BinaryWriter(f);
            long n = f.Length / 4;
            int a;
            Console.WriteLine("Contents of the file:");
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }

            Console.WriteLine();
            Console.WriteLine("\nNumbers in the reverse order:");
            for (int i = (int) (n - 1); i >= 0; i--)
            {
                f.Seek(i * 4, SeekOrigin.Begin);
                Console.Write(fIn.ReadInt32() + " ");
            }

            for (int i = 0; i < n; i++)
            {
                f.Seek(i * 4, SeekOrigin.Begin);
                int num = fIn.ReadInt32();

                f.Seek(i * 4, SeekOrigin.Begin);
                fOut.Write(num * 5);
            }

            f.Seek(0, SeekOrigin.Begin);
            Console.WriteLine();
            Console.WriteLine("\nNew contents of the file:");
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }

            Console.WriteLine();
            fIn.Close();
            f.Close();
        }
        catch (IOException)
        {
            Console.Error.WriteLine("io: Unable to create file stream due to an i/o error, exiting...");
        }
        catch (SecurityException)
        {
            Console.Error.WriteLine("security: Not enough permissions to open stream on this file, exiting...");
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("env: Output file path given incorrectly, exiting...");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"error: {e.Message}");
        }
    }
}


