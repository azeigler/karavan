using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karavan.Web.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public GpsCoordinates GpsCoordinates { get; set; }
        public string GoogleMapsUrl { get; set; }
    }
}