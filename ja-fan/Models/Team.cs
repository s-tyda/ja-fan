namespace ja_fan.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public IList<Nickname>? Nicknames { get; set; }
}