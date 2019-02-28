using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public List<Slide> VerticalsToSlides(List<Photo>vertical)
        {
            List<Slide> slides = new List<Slide>();
            for(int i = vertical.Count/2 + vertical.Count%2; i < vertical.Count;i ++)
            {
                int[] overlap = new int[vertical.Count/2 + vertical.Count%2];
                for(int j = 0; j < vertical.Count/2 + vertical.Count%2;j ++)
                {
                    if(vertical[j].used)
                    {
                        overlap[j] = 101;
                        continue;                        
                    }
                    overlap[j] = vertical[i].Tags.overlap(vertical[j].Tags).Count;
                }
                int indexOMin = Array.IndexOf(overlap, overlap.Min());
                vertical[i].used = true;
                vertical[indexOMin].used = true;
                Slide slide = new Slide(vertical[i].ID, vertical[i].Tags, vertical[indexOMin].ID, vertical[indexOMin].Tags);
                slides.Add(slide);
            }
            return slides;
        }
    }
}