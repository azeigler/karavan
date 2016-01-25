using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Karavan.Web.Helpers;
using Karavan.Web.Models;

namespace Karavan.Test.Tests
{
    [TestFixture]
    public class GoogleMapsTest
    {
        [TestCase]
        public void GetGoogleUrl()
        {
            var file = AppDomain.CurrentDomain.BaseDirectory + "/Content/Images/840.JPG";
            var coordinates = GoogleMapsHelper.GetCoordinates(file);
            Assert.IsNotNullOrEmpty(coordinates.ToString());

            var url = GoogleMapsHelper.GetMapsUrl(coordinates);
            Assert.IsNotNullOrEmpty(url.ToString());
            Assert.Pass("Lat: " + coordinates.Latitude.ToString() + " Long: " + coordinates.Longitude.ToString() + " Url: " + url.ToString());
        }

        [TestCase]
        public void GetPlaces()
        {
            var results = GoogleMapsHelper.SearchPlaces(new GpsCoordinates() { Latitude = 40.693162, Longitude = -74.0559406 });
            Assert.IsNotNullOrEmpty(results.ToString());
            var resultsMessage = "Results: ";
            foreach (var result in results)
            {
                resultsMessage += result.Name + ", ";
            }

            var closest = GoogleMapsHelper.GetClosestPlaces(results, new GpsCoordinates() { Latitude = 40.6923152, Longitude = -74.0574686 });
            Assert.IsNotNullOrEmpty(closest.ToString());
            var closestMessage = " Closest: ";
            foreach (var result in closest)
            {
                closestMessage += result.Name + ", ";
            }
            Assert.Pass(resultsMessage + closestMessage);
        }
    }
}