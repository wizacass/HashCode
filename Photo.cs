using System.Text;

public class Photo
{
    public bool IsUsed { get; private set; }
    public int Count => _tags.Length;
    private string[] _tags;

    public Photo(string[] tags)
    {
        _tags = tags;
        IsUsed = false;
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
