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

        static void Group(List<Slide> slides, List<Slide> slides2)
        {
            int i = 0;
            int nextSlide = -1;
            while (slides2.Count < slides.Count)
            {
                if (!slides[i].IsUsed)
                {

                    int maxPoints = -1;

                    for (int ii = 0; ii < slides.Count; ii++)
                    {
                        if (!slides[ii].IsUsed)
                        {

                            if (CalculatePoints(slides[i], slides[ii]) > maxPoints && i != ii)
                            {
                                maxPoints = CalculatePoints(slides[i], slides[ii]);
                                nextSlide = ii;
                            }

                        }
                    }
                }

            }
            if (nextSlide != -1)
            {
                var current = slides[nextSlide];
                slides2.Add(current);
                current.Use();
                i = nextSlide;
            }

        }


        static int CalculatePoints(Slide slide1, Slide slide2)
        {
            int common = 0;
            int unique1 = 0;
            int unique2 = 0;
            for (int i = 0; i < slide1._tags.Count; i++)
            {
                if (slide2._tags.Contains(slide1._tags[i]))
                    common++;
            }
            unique1 = slide1._tags.Count - common;
            unique2 = slide2._tags.Count - common;
            if (common <= unique1 && common <= unique2)
                return common;
            else
            {
                if (unique1 <= unique2)
                    return unique1;
                else return unique2;
            }
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
