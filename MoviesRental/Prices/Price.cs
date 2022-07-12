namespace MoviesRental.Prices;

public abstract class Price
{
    public abstract int GetPriceCode();
    public abstract double GetCharge(int daysRented);
}
