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
        double result = 0;

        switch (PriceCode)
        {
            case Regular:
                result += 2;
                if (daysRented > 2)
                    result += (daysRented - 2) * 1.5;
                break;
            case NewRelease:
                result += daysRented * 3;
                break;
            case Childrens:
                result += 1.5;
                if (daysRented > 3)
                    result += (daysRented - 3) * 1.5;
                break;
        }

        return result;
    }
    public int GetFrequentRenterPoints(int daysRented)
    {
        if (PriceCode == NewRelease && daysRented > 1)
            return 2;

        return 1;
    }
}
