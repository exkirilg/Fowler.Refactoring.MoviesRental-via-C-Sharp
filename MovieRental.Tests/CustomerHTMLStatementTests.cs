namespace MovieRental.Tests;

public class CustomerHTMLStatementTests
{
    private const string MovieTitle = "TestMovie";
    private const string CustomerName = "TestCustomer";

    private Customer CreateCustomerInstanceWithMovieRental(int moviePriceCode, int daysRented)
    {
        var movie = new Movie(MovieTitle, moviePriceCode);
        var rental = new Rental(movie, daysRented);

        var customer = new Customer(CustomerName);
        customer.AddRental(rental);

        return customer;
    }

    [Theory]
    [InlineData(
        Movie.Regular,
        1,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 2</li></ul>" +
        $"<p>The amount of debt is <em>2</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    [InlineData(
        Movie.Regular,
        5,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 6.5</li></ul>" +
        $"<p>The amount of debt is <em>6.5</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    [InlineData(
        Movie.Regular,
        10,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 14</li></ul>" +
        $"<p>The amount of debt is <em>14</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    public void RegularMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.HTMLStatement();
        Assert.Equal(expectedStatement, result);
    }

    [Theory]
    [InlineData(
        Movie.NewRelease,
        1,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 3</li></ul>" +
        $"<p>The amount of debt is <em>3</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    [InlineData(
        Movie.NewRelease,
        5,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 15</li></ul>" +
        $"<p>The amount of debt is <em>15</em></p><p>You earned <em>2</em> for activity</p>"
    )]
    [InlineData(
        Movie.NewRelease,
        10,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 30</li></ul>" +
        $"<p>The amount of debt is <em>30</em></p><p>You earned <em>2</em> for activity</p>"
    )]
    public void NewReleaseMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.HTMLStatement();
        Assert.Equal(expectedStatement, result);
    }

    [Theory]
    [InlineData(
        Movie.Childrens,
        1,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 1.5</li></ul>" +
        $"<p>The amount of debt is <em>1.5</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    [InlineData(
        Movie.Childrens,
        5,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 4.5</li></ul>" +
        $"<p>The amount of debt is <em>4.5</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    [InlineData(
        Movie.Childrens,
        10,
        $"<h1>Rental for <em>{CustomerName}</em></h1>" +
        $"<ul><li>{MovieTitle} - 12</li></ul>" +
        $"<p>The amount of debt is <em>12</em></p><p>You earned <em>1</em> for activity</p>"
    )]
    public void ChildrensMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.HTMLStatement();
        Assert.Equal(expectedStatement, result);
    }

    [Fact]
    public void MultipleMovies()
    {
        var expectedResult = $"<h1>Rental for <em>{CustomerName}</em></h1>";
        expectedResult += "<ul>";

        var customer = new Customer(CustomerName);
        
        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.Regular), 5)
        );
        expectedResult += $"<li>{MovieTitle} - 6.5</li>";

        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.NewRelease), 5)
        );
        expectedResult += $"<li>{MovieTitle} - 15</li>";

        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.Childrens), 5)
        );
        expectedResult += $"<li>{MovieTitle} - 4.5</li>";

        expectedResult += "</ul>";

        expectedResult += $"<p>The amount of debt is <em>26</em></p><p>You earned <em>4</em> for activity</p>";

        var result = customer.HTMLStatement();

        Assert.Equal(expectedResult, result);        
    }
}
