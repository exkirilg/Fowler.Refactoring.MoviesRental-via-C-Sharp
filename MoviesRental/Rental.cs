namespace MoviesRental;

public class Rental
{
    public Movie Movie { get; }
    public int DaysRented { get; }

    public Rental(Movie movie, int daysRented)
    {
        Movie = movie;
        DaysRented = daysRented;
    }

    public double GetCharge()
    {
        double result = 0;

        switch (Movie.PriceCode)
        {
            case Movie.Regular:
                result += 2;
                if (DaysRented > 2)
                    result += (DaysRented - 2) * 1.5;
                break;
            case Movie.NewRelease:
                result += DaysRented * 3;
                break;
            case Movie.Childrens:
                result += 1.5;
                if (DaysRented > 3)
                    result += (DaysRented - 3) * 1.5;
                break;
        }

        return result;
    }
}
