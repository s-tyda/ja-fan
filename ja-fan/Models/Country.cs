namespace ja_fan.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Team>? Teams { get; set; }
}