﻿using AutoFixture;
using SFF.Datasource.Model;
using Xunit;

namespace SFF.Tests.MovieTests
{
    public class RentLogicTests
    {
        [Fact]
        public void Does_a_max_rented_capicity_exist()
        {
            // Arrange
            var fixture = new Fixture();
            var title = fixture.Create<string>();
            var duration = fixture.Create<int>();

            var movie = new Movie(title, duration);

            // Act

            // Assert
            Assert.True(movie.NumberOfMaxSimultaneouslyRented > 0);
        }

        [Fact]
        public void Can_you_change_the_number_of_times_a_movie_can_be_rented()
        {
            // Arrange
            var fixture = new Fixture();
            var title = fixture.Create<string>();
            var duration = fixture.Create<int>();
            var movie = new Movie(title, duration);

            var exectedNumberOfTimesYouCanRent = 10;

            // Act
            movie.NumberOfMaxSimultaneouslyRented = exectedNumberOfTimesYouCanRent;

            // Assert
            Assert.Equal(movie.NumberOfMaxSimultaneouslyRented, exectedNumberOfTimesYouCanRent);
        }

        [Fact]
        public void Is_it_possible_to_rent_more_than_allowed()
        {
            // Arrange
            var fixture = new Fixture();
            var title = fixture.Create<string>();
            var duration = fixture.Create<int>();
            var movie = new Movie(title, duration);

            var numberOfTimesYouCanRent = 10;

            // Act
            movie.NumberOfMaxSimultaneouslyRented = numberOfTimesYouCanRent;

            // Assert
            // Test if you can rent a movie over the set limit
            Assert.Throws<ExceedingMaxRentCapReachedException>(() => movie.RentMovie(numberOfTimesYouCanRent + 1));
        }

        [Fact]
        public void Is_it_possible_to_mark_a_movie_as_rented()
        {
            // Arrange
            var fixture = new Fixture();
            var title = fixture.Create<string>();
            var duration = fixture.Create<int>();
            var movie = new Movie(title, duration);

            // Act
            movie.IsRented = true;
            // Assert
            Assert.True(movie.IsRented);
        }
    }
}