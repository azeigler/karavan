using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using ExifLib;
using Karavan.Web.Models;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Karavan.Web.Helpers
{
    public class GoogleMapsHelper
    {
        public static string GetMapsUrl(GpsCoordinates coordinates)
        {
            return ("https://www.google.com/maps/embed/v1/place?q=" 
                + coordinates.Latitude + "%C2%B0%20" + "%2C%20" 
                + coordinates.Longitude + "%C2%B0%20" 
                + "&key=AIzaSyB8g2JYH9TFBFvbbS_3AWlsUYpYaBWFWkw");
        }

        public static GpsCoordinates GetCoordinates(string imageFileName)
        {
            using (var reader = new ExifReader(imageFileName))
            {
                Double[] latitude, longitude;
                var latitudeRef = "";
                var longitudeRef = "";                

               if (reader.GetTagValue(ExifTags.GPSLatitude, out latitude)
                    && reader.GetTagValue(ExifTags.GPSLongitude, out longitude)
                    && reader.GetTagValue(ExifTags.GPSLatitudeRef, out latitudeRef)
                    && reader.GetTagValue(ExifTags.GPSLongitudeRef, out longitudeRef))
                {
                    var longitudeTotal = longitude[0] + longitude[1] / 60 + longitude[2] / 3600;
                    var latitudeTotal = latitude[0] + latitude[1] / 60 + latitude[2] / 3600;

                    return new GpsCoordinates()
                    {
                        Latitude = (latitudeRef == "N" ? 1 : -1) * latitudeTotal,
                        Longitude = (longitudeRef == "E" ? 1 : -1) * longitudeTotal,
                    };
                }

                return new GpsCoordinates()
                {
                    Latitude = 0,
                    Longitude = 0,
                };
            }
        }

        public static List<Place> SearchPlaces(GpsCoordinates coordinates)
        {
            var places = new List<Place>();
            var url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" 
                      + coordinates.Latitude + "," + coordinates.Longitude
                      + "&radius=1000&key=AIzaSyB8g2JYH9TFBFvbbS_3AWlsUYpYaBWFWkw";            
            using (var client = new WebClient())
            {
                var results = JObject.Parse(client.DownloadString(url));                

                foreach (var result in results["results"])
                {
                    places.Add(new Place()
                    {
                        Name = result["name"].ToString(),
                        Id = result["place_id"].ToString(),
                        Coordinates = new GpsCoordinates()
                        {
                            Latitude = (double)result["geometry"]["location"]["lat"],
                            Longitude = (double)result["geometry"]["location"]["lng"]
                        }
                    });
                }
            }
            return places;
        }

        public static List<Place> GetClosestPlaces(List<Place> places, GpsCoordinates refPoint)
        {
            var distances = new Dictionary<Place, double>();
            foreach (var place in places)
            {
                distances.Add(place, CalculateDistance(refPoint, place.Coordinates));
            }
            var topTen = distances.OrderBy(x => x.Value).Take(10).Select(x => x.Key).ToList();
            return topTen;
        }

        private static double CalculateDistance(GpsCoordinates startLocation, GpsCoordinates destination)
        {
            var longitudeDif = destination.Longitude - startLocation.Longitude;
            var latitudeDif = destination.Latitude - startLocation.Latitude;
            var stepOne = Math.Pow(Math.Sin(latitudeDif / 2), 2) + Math.Cos(startLocation.Latitude) * Math.Cos(destination.Latitude) * Math.Pow(Math.Sin(longitudeDif / 2), 2);
            var stepTwo = 2 * Math.Atan2(Math.Sqrt(stepOne), Math.Sqrt(1 - stepOne));
            var distance = 6371 * stepTwo;
            return distance;
        }
    }
}