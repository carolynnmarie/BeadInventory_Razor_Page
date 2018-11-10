using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeadDotNetApp.Models{

    public class Finding{

        public int ID {get;set;}
        public string FindingCategory {get;set;}
        public string Material {get;set;}
        public string Description {get;set;}
        public string Color {get;set;}
        public double Length_CM {get;set;}
        public double Price_Point {get;set;}
        public string Brand {get;set;}

    }
}