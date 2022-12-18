namespace MockInterview.DAL.Models.Query;

public class SortOptions
{
    public string SortField { get; set; } = null!;
    
    public bool SortAscending { get; set; }
}