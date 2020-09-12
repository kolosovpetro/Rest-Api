using System.Linq;
using Api.Data.Context;
using Api.Repositories.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace Api.Tests.RepositorySqlServerTests
{
    [TestFixture]
    public class RepositorySqlServerTest
    {
        [Test]
        public void Repository_Sql_Server_Get_By_Id_Test()
        {
            var repository = new MoviesRepository(new RentalContextSqlServer());
            var movie = repository.GetById(8);
            movie.Title.Should().Be("Analyze This");
            movie.MovieId.Should().Be(8);
        }

        [Test]
        public void Repository_Sql_Server_GetAll_Test()
        {
            var repository = new MoviesRepository(new RentalContextSqlServer());
            var movies = repository.GetAll();
            movies.Count().Should().Be(10);
        }
    }
}