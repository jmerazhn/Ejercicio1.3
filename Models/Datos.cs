using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1._3.Models
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombres { get; set; }

        [MaxLength(60)]
        public string Apellidos { get; set; }

        public string Edad { get; set; }

        [MaxLength(60)]
        public string Correo { get; set; }

        [MaxLength(60)]
        public string Direccion { get; set; }

    }
}
