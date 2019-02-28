using System.Collections.Generic;
using System.Linq;

public class Slide
{
    public int Photo1 { get; }
    public int? Photo2 { get; }
    public bool IsUsed { get; private set; }

    public int Count => _tags.Count;
    public List<string> _tags;

    public Slide(int photo1, string[] tags1, int? photo2 = null, string[] tags2 = null)
    {
        Photo1 = photo1;
        Photo2 = photo2;
        IsUsed = false;

        _tags = tags1.ToList();

        if (tags1 != null || tags2.Length > 0)
        {
            FillTags(tags2);
        }
    }

    private void FillTags(string[] tags)
    {
        foreach (string tag in tags)
        {
            if (!_tags.Contains(tag))
            {
                _tags.Add(tag);
            }
        }
    }

    public void Use()
    {
        IsUsed = true;
    }
}