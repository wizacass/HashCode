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
        _photos[Count++] = photo;

        int i = Count - 1; // insert index
        while (i >= 0 && _photos[i].Count < _photos[i - 1].Count)
        {
            Photo tmp = _photos[i - 1];
            _photos[i - 1] = _photos[i];
            _photos[i] = tmp;
        }
    }
}
