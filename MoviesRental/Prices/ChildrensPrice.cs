namespace MoviesRental.Prices;

public class ChildrensPrice : Price
{
    public override int GetPriceCode()
    {
        return Movie.Childrens;
    }
}
