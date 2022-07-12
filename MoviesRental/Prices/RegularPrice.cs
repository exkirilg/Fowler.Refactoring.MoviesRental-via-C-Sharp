namespace MoviesRental.Prices;

public class RegularPrice : Price
{
    public override int GetPriceCode()
    {
        return Movie.Regular;
    }
}
