namespace Ch6Lab.Models;

public class ListInfo
{
    public List<User> Users { get; set; }
    public  UserField Field { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)Data.Users.Count / PageSize);

}