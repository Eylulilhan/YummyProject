using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
       
        public string ImageUrl { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string VideoUrl { get; set; }
        [NotMapped]
        
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        
        public HttpPostedFileBase VideoFile { get; set; }

    }
}