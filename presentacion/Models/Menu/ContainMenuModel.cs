using System;
using System.Collections.Generic;

namespace presentacion.Models.Menu
{
    public class ContainMenuModel
    {
        public string Nombre { get; set; }
        public List<HaveMenuModel> Tiene { get; set; }
    }
}
