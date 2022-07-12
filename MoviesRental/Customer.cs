﻿namespace MoviesRental;

public class Customer
{
    public string Name { get; }
    public List<Rental> Rentals { get; } = new();

    public Customer(string name)
    {
        Name = name;
    }

    public void AddRental(Rental rental)
    {
        Rentals.Add(rental);
    }

    public string Statement()
    {
        double totalAmount = 0;
        int frequentRentalPoints = 0;

        string result = $"Rental for {Name}\n";

        foreach (var aRental in Rentals)
        {
            double thisAmount = aRental.GetCharge();

            frequentRentalPoints++;

            if (aRental.Movie.PriceCode == Movie.NewRelease && aRental.DaysRented > 1)
                frequentRentalPoints++;

            result += $"\t{aRental.Movie.Title}\t{thisAmount}\n";
            totalAmount += thisAmount;
        }

        result += $"The amount of debt is {totalAmount}\n";
        result += $"You earned {frequentRentalPoints} for activity";

        return result;
    }
}