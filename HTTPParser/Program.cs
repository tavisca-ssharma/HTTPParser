using System;
using System.Collections.Generic;
using System.IO;

namespace HTTPParser
{
    class Program
    {
        public static Dictionary<string, string> ParseString(string filename)
        {
            var temp = new Dictionary<string, string>();
            using (StreamReader file = new StreamReader(filename))
            {
                string line = file.ReadLine();
                string[] s = line.Split(new[] { ' ' }, 2);
                temp.Add("HttpAndVersion", s[0]);
                temp.Add("StatusCode", s[1]);

                while ((line = file.ReadLine()) != null)
                {

                    if (line.Contains(":"))
                    {
                        string[] sp = line.Split(new[] { ':' }, 2);
                        temp.Add(sp[0], sp[1]);
                    }
                    else
                    {
                        break;
                    }

                }

                string data = file.ReadToEnd();
                temp.Add("Payload", data);
                file.Close();

            }

            return temp;
        }
        static void Main(string[] args)
        {
            var finalDict = ParseString("InputHeader.txt");
            foreach (var entry in finalDict)
            {
                if(entry.Value != "")
                    Console.WriteLine($"{entry.Key} --> {entry.Value}");
                else
                    Console.WriteLine($"{entry.Key} --> No {entry.Key} in header");
            }

            Console.ReadLine();
        }
    }
}
