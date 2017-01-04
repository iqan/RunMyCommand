using System;
using System.Diagnostics;

namespace RunCommand
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string extraArgs = string.Empty;
            if(args.Length == 0)
            {
                Console.WriteLine("Please enter command and/or arguments.");
                Console.WriteLine("Usage: dotnet RunCommand.dll <command> <arg1> <arg1> ...");
            }
            else
            {
                extraArgs = MakeArgString(args);
                Process proc = new Process();
                proc.StartInfo.FileName = args[0];
                proc.StartInfo.Arguments = extraArgs;
                proc.StartInfo.UseShellExecute = false; 
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                var output = proc.StandardOutput.ReadToEnd ();
                Console.WriteLine("stdout: {0}", output);
            }
        }

        private static string MakeArgString(string[] args)
        {
            string ex = String.Empty;
            if(args.Length > 1)
            {
                for(int i=1; i<args.Length; i++)
                {
                    ex += args[i] + " ";
                }
            }
            return ex;
        }
    }
}
