using System.Text;

public class Photo
{
    public bool IsUsed { get; private set; }

    public int ID { get; }
    public int Count => _tags.Length;
    private string[] _tags;

    public Photo(string[] tags, int id)
    {
        _tags = tags;
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

        foreach (string tag in _tags)
        {
            sb.Append($"{tag} ");
        }

        return sb.ToString();
    }
}
