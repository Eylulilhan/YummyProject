﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YummyProject.Models;

namespace YummyProject.Context
{
    public class YummyContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }    
        public DbSet<Booking> Bookings { get; set; }    
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Chef> chefs { get; set; }    
        public DbSet<ChefSocial> ChefSocials { get; set; }    
        public DbSet<ContactInfo> ContactInfos { get; set; }    
        public DbSet<Event> events{ get; set; }    
        public DbSet<Feature> features{ get; set; }    
        public DbSet<Message> messages{ get; set; }    
        public DbSet<PhotoGallery> PhotoGalleries{ get; set; }    
        public DbSet<Product> Products{ get; set; }    
        public DbSet<Service> Services{ get; set; }    
        public DbSet<Testimonial> Testimonials{ get; set; }  
        public DbSet<Admin> Admins{ get; set; }  
        public DbSet<SocialMedia> SocialMedias{ get; set; }  
        
    }
}