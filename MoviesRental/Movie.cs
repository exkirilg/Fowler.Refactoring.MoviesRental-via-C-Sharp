using MoviesRental.Prices;

namespace MoviesRental;

public class Movie
{
    public const int Regular = 0;
    public const int NewRelease = 1;
    public const int Childrens = 2;

    private Price _price;

    public string Title { get; }
    public int PriceCode {
        get => _price.GetPriceCode();
        set
        {
            switch (value)
            {
                case Regular:
                    _price = new RegularPrice();
                    break;
                case NewRelease:
                    _price = new NewReleasesPrice();
                    break;
                case Childrens:
                    _price = new ChildrensPrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect price code");
            }
        }
    }

    public Movie(string title, int priceCode)
    {
        Title = title;
        PriceCode = priceCode;
    }

    public double GetCharge(int daysRented)
    {
        return _price.GetCharge(daysRented);
    }
    public int GetFrequentRenterPoints(int daysRented)
    {
        return _price.GetFrequentRenterPoints(daysRented);
    }
}
