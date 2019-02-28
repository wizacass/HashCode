using System.Text;

public class Photo
{
    public bool IsUsed { get; private set; }

    public int ID { get; }
    public int Count => Tags.Length;
    public string[] Tags;

    public Photo(string[] tags, int id)
    {
        Tags = tags;
        IsUsed = false;
        ID = id;
    }

    public void Use()
    {
        IsUsed = true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (string tag in Tags)
        {
            sb.Append($"{tag} ");
        }

        return sb.ToString();
    }
}
