using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoongService
{
    public class ForwardGeocodeDTOResponse
    {
        public PlusCode PlusCode { get; set; }
        public List<Result> Results { get; set; }
        public string Status { get; set; }
    }
    public class PlusCode
    {
        public string CompoundCode { get; set; }
        public string GlobalCode { get; set; }
    }
    public class Result
    {
        public List<AddressComponent> AddressComponents { get; set; }
        public string FormattedAddress { get; set; }
        public Geometry Geometry { get; set; }
        public string PlaceId { get; set; }
        public string Reference { get; set; }
        public PlusCode PlusCode { get; set; }
        public List<string> Types { get; set; }
    }
    public class AddressComponent
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
    public class Geometry
    {
        public Location Location { get; set; }
    }
    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
