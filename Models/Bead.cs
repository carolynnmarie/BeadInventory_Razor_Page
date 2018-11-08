using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeadDotNetApp.Models{
    public class Bead{

        public int ID {get; set;}
        public string Material {get; set;}
        public string Shape {get; set;}
        public string Color {get; set;}
        public int SizeMM {get; set;}
        public int Quantity {get; set;}
        public decimal PricePoint {get; set;}
        public string Brand {get; set;}
    }
}
