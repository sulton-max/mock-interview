namespace MockInterview.DAL.Models.Query;

public class PaginationOptions
{
    private int _pageSize;
    private int _pageToken;

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value <= 0)
                throw new ArgumentException();
            _pageSize = value;
        }
    }

    public int PageToken
    {
        get => _pageToken;
        set
        {
            if (value <= 0)
                throw new ArgumentException();
            _pageToken = value;
        }
    }
}