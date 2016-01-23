using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karavan.Web.Models
{
    public class Place
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public GpsCoordinates Coordinates { get; set; }
    }
}