using System;
using System.IO;
using System.Security;

class Program
{
    const string FILE_PATH = "../../../t.dat";
    static void Main()
    {
        try
        {
            FileStream fs = new FileStream(FILE_PATH, FileMode.Create);
            BinaryWriter fOut = new BinaryWriter(fs);
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(i);
            fOut.Close();
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
