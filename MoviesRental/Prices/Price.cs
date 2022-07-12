namespace MoviesRental.Prices;

public abstract class Price
{
    public abstract int GetPriceCode();
    public abstract double GetCharge(int daysRented);
    public int GetFrequentRenterPoints(int daysRented)
    {
        if (GetPriceCode() == Movie.NewRelease && daysRented > 1)
            return 2;

        return 1;
    }
}
