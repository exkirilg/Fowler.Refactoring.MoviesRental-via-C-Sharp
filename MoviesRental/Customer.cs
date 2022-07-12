namespace MoviesRental;

public class Customer
{
    public string Name { get; }
    public List<Rental> Rentals { get; } = new();

    public Customer(string name)
    {
        Name = name;
    }

    public void AddRental(Rental rental)
    {
        Rentals.Add(rental);
    }

    public string Statement()
    {
        string result = $"Rental for {Name}\n";

        foreach (var aRental in Rentals)
            result += $"\t{aRental.Movie.Title}\t{aRental.GetCharge()}\n";

        result += $"The amount of debt is {GetTotalCharge()}\n";
        result += $"You earned {GetTotalFrequentRenterPoints()} for activity";

        return result;
    }
    public string HTMLStatement()
    {
        string result = $"<h1>Rental for <em>{Name}</em></h1>";

        result += "<ul>";
        foreach (var aRental in Rentals)
            result += $"<li>{aRental.Movie.Title} - {aRental.GetCharge()}</li>";
        result += "</ul>";

        result += $"<p>The amount of debt is <em>{GetTotalCharge()}</em></p>";
        result += $"<p>You earned <em>{GetTotalFrequentRenterPoints()}</em> for activity</p>";

        return result;
    }

    private double GetTotalCharge()
    {
        return Rentals.Sum(r => r.GetCharge());
    }
    private int GetTotalFrequentRenterPoints()
    {
        return Rentals.Sum(r => r.GetFrequentRenterPoints());
    }
}
