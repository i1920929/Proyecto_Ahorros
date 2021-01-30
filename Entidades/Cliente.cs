using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public string CodCliente {get;set;}
        public string NombreCliente {get;set;}
        public string ApellidoClientePaterno {get;set;}
        public string ApellidoClienteMaterno { get; set; }
        public DateTime FechaNacimiento {get;set;}
    }
}
