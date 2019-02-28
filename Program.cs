using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ProcessFile("a_example.txt");
            Console.WriteLine("data done");

            var verticalSlides = VerticalsToSlides(data.Item2);
            Console.WriteLine("vertical done");

            var allSlides = verticalSlides.Concat(ToSlides(data.Item1)).ToList();
            Console.WriteLine("slides done");

            var grouped = new List<Slide>();
            Group(allSlides, grouped);
            Console.WriteLine("group done");


            Console.WriteLine(grouped.Count);
            foreach (var slide in grouped)
            {
                Console.WriteLine(slide.ToString());
            }

            Console.WriteLine("Hello World!");
        }

        static List<Slide> ToSlides(List<Photo> photos)
        {
            var slides = new List<Slide>();
            foreach (var photo in photos)
            {
                slides.Add(new Slide(photo.ID, photo.Tags));
            }
            return slides;
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

                    for (int j = 0; j < slides.Count; j++)
                    {
                        if (!slides[j].IsUsed)
                        {
                            if (CalculatePoints(slides[i], slides[j]) > maxPoints && i != j)
                            {
                                maxPoints = CalculatePoints(slides[i], slides[j]);
                                nextSlide = j;
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
                {
                    common++;
                }
            }
            unique1 = slide1._tags.Count - common;
            unique2 = slide2._tags.Count - common;
            if (common <= unique1 && common <= unique2)
            {
                return common;
            }
            else
            {
                if (unique1 <= unique2)
                {
                    return unique1;
                }
                else
                {
                    return unique2;
                }
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

        public static List<Slide> VerticalsToSlides(List<Photo> vertical)
        {
            var slides = new List<Slide>();
            for (int i = vertical.Count / 2 + vertical.Count % 2; i < vertical.Count; i++)
            {
                var overlap = new int[vertical.Count / 2 + vertical.Count % 2];
                for (int j = 0; j < vertical.Count / 2 + vertical.Count % 2; j++)
                {
                    if (vertical[j].IsUsed)
                    {
                        overlap[j] = 101;
                        continue;
                    }
                    overlap[j] = vertical[i].Tags.Intersect(vertical[j].Tags).Count();
                }
                int indexOMin = Array.LastIndexOf(overlap, overlap.Min());
                vertical[i].Use();
                vertical[indexOMin].Use();
                var slide = new Slide(vertical[i].ID, vertical[i].Tags, vertical[indexOMin].ID, vertical[indexOMin].Tags);
                slides.Add(slide);
            }
            return slides;
        }
    }
}
