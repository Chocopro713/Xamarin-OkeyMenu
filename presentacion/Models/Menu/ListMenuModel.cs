using System;
using System.Collections.Generic;

namespace presentacion.Models.Menu
{
    public class ListMenuModel
    {
        public string Tipo { get; set; }
        public long Precio { get; set; }
        public List<ContainMenuModel> Contiene { get; set; }
    }
}
