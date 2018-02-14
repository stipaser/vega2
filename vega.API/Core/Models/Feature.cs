using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vega.API.Core.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }
    }
}