using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Alvaro_20190269.Entidades
{
    public class TiposDeTareas
    {
        [Key]
        public int TipoDeTareaId { get; set; }
        public string Nombre { get; set; }
        public int TiempoAcomulado { get; set; }
    }
}
