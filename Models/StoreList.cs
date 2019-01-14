using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;

namespace BeadDotNetApp.Models{
    
    public class StoreList{
        
        public int ID {get;set;}
        public ICollection<Bead> beads {get;set;}
        public ICollection<Finding> findings {get;set;}
        public ICollection<StringingMaterial> stringingMaterial {get;set;}
    }
}