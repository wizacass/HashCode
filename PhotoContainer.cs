public class PhotoContainer
{
    public int Count { get; private set; }

    private Photo[] _photos;

    public PhotoContainer(int count)
    {
        _photos = new Photo[count];
        Count = 0;
    }

    public void Add(Photo photo)
    {

    }
}