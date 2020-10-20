using Api.Models.Models;
using Api.Repositories.Interfaces;
using Api.Services.Services;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;

namespace Api.Tests.MoqTests
{
    [TestFixture]
    public class MoviesServicesTest
    {
        private MoviesService _moviesService;
        private IRepository<Movies> _repository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRepository<Movies>>();
            _mapper = Substitute.For<IMapper>();
            _moviesService = new MoviesService(_repository, _mapper);
        }
    }
}