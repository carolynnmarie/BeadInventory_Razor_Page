using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeadDotNetApp.Models{
    public class StringingMaterial{
        
        public int ID {get; set;}
        public string Category {get; set;}
        public string Material {get; set;}
        public string Color {get; set;}
        public double Price_Per_Foot {get; set;}
        public string Brand {get; set;}
        public string Description {get; set;}
    }
}