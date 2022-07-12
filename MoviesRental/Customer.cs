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
        double totalAmount = 0;
        int frequentRentalPoints = 0;

        string result = $"Rental for {Name}\n";

        foreach (var rental in Rentals)
        {
            double thisAmount = amountFor(rental);

            frequentRentalPoints++;

            if (rental.Movie.PriceCode == Movie.NewRelease && rental.DaysRented > 1)
                frequentRentalPoints++;

            result += $"\t{rental.Movie.Title}\t{thisAmount}\n";
            totalAmount += thisAmount;
        }

        result += $"The amount of debt is {totalAmount}\n";
        result += $"You earned {frequentRentalPoints} for activity";

        return result;
    }

    private double amountFor(Rental aRental)
    {
        double result = 0;

        switch (aRental.Movie.PriceCode)
        {
            case Movie.Regular:
                result += 2;
                if (aRental.DaysRented > 2)
                    result += (aRental.DaysRented - 2) * 1.5;
                break;
            case Movie.NewRelease:
                result += aRental.DaysRented * 3;
                break;
            case Movie.Childrens:
                result += 1.5;
                if (aRental.DaysRented > 3)
                    result += (aRental.DaysRented - 3) * 1.5;
                break;
        }

        return result;
    }
}
