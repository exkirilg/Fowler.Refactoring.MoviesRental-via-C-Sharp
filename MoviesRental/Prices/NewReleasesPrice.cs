namespace MoviesRental.Prices;

public class NewReleasesPrice : Price
{
    public override int GetPriceCode()
    {
        return Movie.NewRelease;
    }
}
