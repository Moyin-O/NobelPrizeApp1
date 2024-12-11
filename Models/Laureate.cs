using System.Collections.Generic;

namespace NobelPrizeApp.Models
{
    public class Laureate
    {
        public string Id { get; set; } = string.Empty;
        public Name KnownName { get; set; } = new Name();
        public Name GivenName { get; set; } = new Name();
        public Name FamilyName { get; set; } = new Name();
        public Name FullName { get; set; } = new Name();
        public string Gender { get; set; } = string.Empty;
        public Birth Birth { get; set; } = new Birth();
        public List<NobelPrize> NobelPrizes { get; set; } = new List<NobelPrize>();
        public Wikipedia Wikipedia { get; set; } = new Wikipedia();
    }

    public class Name
    {
        public string En { get; set; } = string.Empty;
        public string Se { get; set; } = string.Empty;
    }

    public class Birth
    {
        public string Date { get; set; } = string.Empty;
        public Place Place { get; set; } = new Place();
    }

    public class Place
    {
        public City City { get; set; } = new City();
        public Country Country { get; set; } = new Country();
    }

    public class City
    {
        public string En { get; set; } = string.Empty;
    }

    public class Country
    {
        public string En { get; set; } = string.Empty;
    }

    public class NobelPrize
    {
        public string AwardYear { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
        public Motivation Motivation { get; set; } = new Motivation();
    }

    public class Category
    {
        public string En { get; set; } = string.Empty;
    }

    public class Motivation
    {
        public string En { get; set; } = string.Empty;
    }

    public class Wikipedia
    {
        public string English { get; set; } = string.Empty;
    }
}