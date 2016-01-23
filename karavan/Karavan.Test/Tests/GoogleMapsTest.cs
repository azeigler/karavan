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
            var file = "C:/Users/Ashley/Pictures/840.JPG";
            var coordinates = GoogleMapsHelper.GetCoordinates(file);
            var url = GoogleMapsHelper.GetMapsUrl(coordinates);

            var results = GoogleMapsHelper.SearchPlaces(new GpsCoordinates() { Latitude = 40.693162, Longitude = -74.0559406 });

            var closest = GoogleMapsHelper.GetClosestPlaces(results, new GpsCoordinates() { Latitude = 40.6923152, Longitude = -74.0574686 });
        }
    }
}