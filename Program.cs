using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace hashr
{
    class Program
    {   //        0   1          2    3        4     5        7:for errors 8:for output
        // HASHR -a <algorythm> -f <filepath> -o <output path> size:7
        static void Main(string[] args)
        {
            if (args.Length <1)
            {
                while (true)
                {


                    Console.Write("> ");
                    string inp = Console.ReadLine();
                    if (inp.ToLower() == "exit")
                    {
                        Environment.Exit(0);
                    }
                    if (File.Exists(inp.Replace("\"", "")))
                    {
                        Console.WriteLine("File detected, hashing.");
                        Console.WriteLine($"SHA1: {cryptography.sha1FromFile(inp.Replace("\"", ""))}");
                    }
                    else
                    {
                        Console.WriteLine("Text detected, hashing.");
                        Console.WriteLine($"SHA1: {cryptography.sha1(inp)}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"SHA1: {helper.executeargs(args)}");
            }
        }

    }
    class helper
    {
        public static string executeargs(string[] args)
        {
            if (args[0].ToLower() == "-e" || args[0].ToLower() == "exit")
            {
                Environment.Exit(0);
            }
            if (args[0].ToLower()=="-a"&&args[1].ToLower()=="sha1"&&args[2].ToLower()=="-t")//SHA1 & text
            {
                return cryptography.sha1(args[3]);
            }
            if (args[0].ToLower() == "-a" && args[1].ToLower() == "sha1" && args[2].ToLower() == "-f")//SHA1 & file
            {
                return cryptography.sha1FromFile(args[3]);
            }
            if (args[0] == "-h")//help
            {
                visuals.help();
                return null;

            }
            return "invalid args type -h to view valid arguments";
        }
    }
    class visuals
    {

        public static void help()
        {
            List<string> helpcmds = new List<string>();
            helpcmds.Add("    -h           USAGE: \"Hashr.exe -h\"         Explaination: shows help");
            helpcmds.Add("    -a           USAGE: \"Hashr.exe -a SHA1 \" | \"Hashr.exe -a MD5\"         Explaination: shows this screen");
            helpcmds.Add("    -t           USAGE: \"Hashr.exe -a <algorythm> -t <Text>\"         Explaination: shows this screen");
            helpcmds.Add("    -b           USAGE: \"Hashr.exe -a <algorythm> -b <bytearray>\"         Explaination: shows this screen");
            helpcmds.Add("    -f           USAGE: \"Hashr.exe -a <algorythm> -f <filepath>\"         Explaination: hashes file and if outfile is nnot present displays console");
            helpcmds.Add("    -o           USAGE: \"Hashr.exe -a <algorythm> -f <filepath> -o <filepath>\"         Explaination: sets output path for hashed file");

            for (int i = 0; i < Console.WindowWidth/2; i++)
            {
                Console.Write("-=");
            }
            foreach (string cmd in helpcmds)
            {
                Console.WriteLine(cmd);
                Console.WriteLine("");
            }
            for (int i = 0; i < Console.WindowWidth/2; i++)
            {
                Console.Write("-=");
            }

        }
    }
    class cryptography
    {
        private static SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
        private static SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
        private static SHA384CryptoServiceProvider SHA384 = new SHA384CryptoServiceProvider();
        private static SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        public static byte[] sha1(byte[] plainbytes)
        {
            return SHA1.ComputeHash(plainbytes);
        }
        public static string sha1(string plaintext)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in SHA1.ComputeHash(Encoding.UTF8.GetBytes(plaintext)))
            {
               sb.Append( b.ToString("x2"));
            }

            return sb.ToString();
        }
        public static string sha1FromFile(string path)
        {
            StringBuilder sb = new StringBuilder();

            if (File.Exists(path))
            {
                foreach (byte b in SHA1.ComputeHash(File.ReadAllBytes(path)))
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public static string sha1FromFileToFile(string filepath, string topath="deafult")
        {

            if (File.Exists(filepath))
            {
                string path = filepath + ".SHA1";
                if (File.Exists(topath))
                {
                    path = topath+".SHA1";
                }

                File.WriteAllBytes(path,SHA1.ComputeHash(File.ReadAllBytes(filepath)));
                return path;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
