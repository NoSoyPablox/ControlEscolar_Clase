using ServiciosLinqEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar
{
    public class Mensaje
    {
        public bool error { get; set; }
        public string message { get; set; }
        public usuario usuario { get; set; }
    }
}