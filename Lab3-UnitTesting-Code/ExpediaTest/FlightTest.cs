using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime dateFlightLeaves = new DateTime(2012, 5, 27); 
        private readonly DateTime dateFlightReturns = new DateTime(2012, 7, 3);
        private readonly int mileage = 100;

        [Test()]
        public void TestThatFlightnitializes()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTravelOnSameDay()
        {
            DateTime dateFlightLeaves = new DateTime(2012, 1, 1); 
            DateTime dateFlightReturns = new DateTime(2012, 1, 1);
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
            Assert.AreEqual(200, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTravelLongTrips()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
            Assert.AreEqual(940, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsIfEndDateIsLessThanStartDate()
        {
            DateTime dateFlightLeaves = new DateTime(2012, 2, 1);
            DateTime dateFlightReturns = new DateTime(2012, 1, 1);
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
        }

        [Test()]
        public void TestThatFlightHasCorrectMiles()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
            Assert.AreEqual(100, target.Miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, -1);
        }
        [Test()]
        public void TestThatOverrideBoolEqualsBaseObject()
        {
            Assert.False(Equals(null));
        }

        [Test()]
        public void TestThatOverrideBoolEqualsReturnsFlightObject()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, mileage);
            Assert.True(target.Equals(target));
        }
	}
}
