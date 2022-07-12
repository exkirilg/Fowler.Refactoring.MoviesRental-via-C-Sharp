namespace MovieRental.Tests;

public class CustomerStatementTests
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
    [InlineData(Movie.Regular, 1, $"Rental for {CustomerName}\n\t{MovieTitle}\t2\nThe amount of debt is 2\nYou earned 1 for activity")]
    [InlineData(Movie.Regular, 5, $"Rental for {CustomerName}\n\t{MovieTitle}\t6.5\nThe amount of debt is 6.5\nYou earned 1 for activity")]
    [InlineData(Movie.Regular, 10, $"Rental for {CustomerName}\n\t{MovieTitle}\t14\nThe amount of debt is 14\nYou earned 1 for activity")]
    public void RegularMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.Statement();
        Assert.Equal(expectedStatement, result);
    }

    [Theory]
    [InlineData(Movie.NewRelease, 1, $"Rental for {CustomerName}\n\t{MovieTitle}\t3\nThe amount of debt is 3\nYou earned 1 for activity")]
    [InlineData(Movie.NewRelease, 5, $"Rental for {CustomerName}\n\t{MovieTitle}\t15\nThe amount of debt is 15\nYou earned 2 for activity")]
    [InlineData(Movie.NewRelease, 10, $"Rental for {CustomerName}\n\t{MovieTitle}\t30\nThe amount of debt is 30\nYou earned 2 for activity")]
    public void NewReleaseMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.Statement();
        Assert.Equal(expectedStatement, result);
    }

    [Theory]
    [InlineData(Movie.Childrens, 1, $"Rental for {CustomerName}\n\t{MovieTitle}\t1.5\nThe amount of debt is 1.5\nYou earned 1 for activity")]
    [InlineData(Movie.Childrens, 5, $"Rental for {CustomerName}\n\t{MovieTitle}\t4.5\nThe amount of debt is 4.5\nYou earned 1 for activity")]
    [InlineData(Movie.Childrens, 10, $"Rental for {CustomerName}\n\t{MovieTitle}\t12\nThe amount of debt is 12\nYou earned 1 for activity")]
    public void ChildrensMovie(int priceCode, int daysRented, string expectedStatement)
    {
        var customer = CreateCustomerInstanceWithMovieRental(priceCode, daysRented);

        var result = customer.Statement();
        Assert.Equal(expectedStatement, result);
    }

    [Fact]
    public void MultipleMovies()
    {
        var expectedResult = $"Rental for {CustomerName}\n";

        var customer = new Customer(CustomerName);
        
        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.Regular), 5)
        );
        expectedResult += $"\t{MovieTitle}\t6.5\n";

        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.NewRelease), 5)
        );
        expectedResult += $"\t{MovieTitle}\t15\n";

        customer.AddRental(
            new Rental(new Movie(MovieTitle, Movie.Childrens), 5)
        );
        expectedResult += $"\t{MovieTitle}\t4.5\n";

        expectedResult += $"The amount of debt is 26\nYou earned 4 for activity";

        var result = customer.Statement();

        Assert.Equal(expectedResult, result);        
    }
}
