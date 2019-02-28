using System;
using System.Collections.Generic;
using System.IO;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ProcessFile("a_example.txt");
            Console.WriteLine("Hello World!");
        }

        static Tuple<List<Photo>, List<Photo>> ProcessFile(string filename)
        {
            var horizontal = new List<Photo>();
            var vertical = new List<Photo>();

            using (var reader = new StreamReader(filename))
            {
                int count = int.Parse(reader.ReadLine());
                int id = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split();

                    var tags = new string[line.Length - 2];
                    for (int i = 2; i < line.Length; i++)
                    {
                        tags[i - 2] = line[i];
                    }

                    //TODO: sort by Count
                    if (line[0].Equals("H"))
                    {
                        horizontal.Add(new Photo(tags, id++));
                    }
                    else
                    {
                        vertical.Add(new Photo(tags, id++));
                    }
                }
            }

            return new Tuple<List<Photo>, List<Photo>>(horizontal, vertical);
        }
    }
}
