using AutoFixture;
using GeodesicCurveChallenge.Business.Managers;
using GeodesicCurveChallenge.Business.Managers.Interfaces;
using GeodesicCurveChallenge.Business.Models;
using Moq;
using System;
using Xunit;

namespace GeodesicCurveChallenge.UnitTests.BusinessLayer.Managers
{
    public class DistanceManagerTests : IDisposable
    {
        private readonly Fixture _fixture;
        private readonly Mock<DistanceFactory> _distanceFactory;
        private readonly IDistanceManager _distanceManager;

        public DistanceManagerTests()
        {
            _fixture = new Fixture();
            _distanceFactory = new Mock<DistanceFactory>(MockBehavior.Strict);
            _distanceManager = new DistanceManager(_distanceFactory.Object);
        }

        [Fact]
        public void Model_Null_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model = null;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Model_CityOne_Null_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityOne = null;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Model_CityTwo_Null_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityTwo = null;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Latitude_BiggerThan90_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityOne.Latitude = 124;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Latitude_LessThanMinus90_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityOne.Latitude = -278;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Longitude_BiggerThan180_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityOne.Latitude = 197;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Longitude_LessThanMinus180_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            model.CityOne.Latitude = -325;
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual == 0);
        }

        [Fact]
        public void Distance_Null_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            var distance = _fixture.Create<Distance>();
            distance = null;
            _distanceFactory.Setup(x => x.createDistance("Cosines")).Returns(distance);
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual==0);
        }

        [Fact]
        public void Distance_NotNull_Test()
        {
            var model = _fixture.Create<GeodesicCurve>();
            var distance = _fixture.Create<Distance>();
            _distanceFactory.Setup(x => x.createDistance("Cosines")).Returns(distance);
            var actual = _distanceManager.Calculate(model);
            Assert.True(actual > 0);
        }

        public void Dispose()
        {
            _distanceFactory.VerifyAll();
        }
    }
}
