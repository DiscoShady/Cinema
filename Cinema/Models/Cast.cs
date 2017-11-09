using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models {
    public class Cast {
        public int Id { get; set; }
        public string Caracter { get; set; }
        public string Name { get; set; }
        public string Profile_Path { get; set; }
        public string Credit_Id { get; set; }
    }
}