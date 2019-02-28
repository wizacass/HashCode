using System;
using System.Collections.Generic;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        // static void Group(Slide[] slides, List<Slide> slides2)
        // {
        //     for(int i = 0; i < slides.Length; i++)
        //     {
        //         int maxPoints = 0;
        //         int nextSlide = -1;
        //         if(!slides[i].used)
        //         {
        //             for(int ii = 0;  ii < slides.Length; ii++)
        //             {
        //                 if(CalculatePoints(slides[i], slides[ii]) > maxPoints && !slides[ii].used)
        //                 {
        //                     maxPoints = CalculatePoints(slides[i], slides[ii]);
        //                     nextSlide = ii;
        //                 }
        //             }
        //             if(nextSlide != -1)
        //             {
        //                 slides2.Add(slides[nextSlide]);
        //             }
        //         }                
        //     }
        static void Group(List<Slide> slides, List<Slide> slides2)
        {                
            int i = 0;
            int nextSlide = -1;
            while(slides2.Count < slides.Count)
            {
                if(!slides[i].used)
                {
                    
                    int maxPoints = -1;
                        
                    for(int ii = 0; ii < slides.Count; ii++)
                    {
                        if(!slides[ii].used)
                        {
                            
                            if(CalculatePoints(slides[i], slides[ii]) > maxPoints && i != ii)
                            {
                                maxPoints = CalculatePoints(slides[i], slides[ii]);
                                nextSlide = ii;
                            }
                            
                        }
                        ii++;                                
                    }
                    
                        
                }
                
                }
                if (nextSlide != -1)
                {
                    slides2.Add(slides[(int)nextSlide]);
                    i = nextSlide;
                }
                
            }


        }

        static int CalculatePoints(Slide slide1, Slide slide2)
        {
            int common = 0;
            int unique1 = 0;
            int unique2 = 0;
            for(int i = 0; i < slide1._tags.Count; i++)
            {
                if(slide2._tags.Contains(slide1._tags[i]))
                    common++;                
            }
            unique1 = slide1._tags.Count - common;
            unique2 = slide2._tags.Count - common;
            if(common <= unique1 && common <= unique2)
                return common;
            else
            {
                if(unique1 <= unique2)
                    return unique1;
                else return unique2;
            }
        }

    }
}
