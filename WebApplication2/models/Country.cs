namespace WebApplication2.models;

public class Country
{
    public int IdCountry { get; set; }
    public string Name { get; set; }
    public ICollection<Country_Trip> Country_Trips { get; set; }
}