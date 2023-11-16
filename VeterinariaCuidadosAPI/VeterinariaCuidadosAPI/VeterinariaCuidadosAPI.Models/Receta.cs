using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaCuidadosAPI.Models
{
    public class Receta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CitaId { get; set; }

        public string Nombre_Factura { get; set; }

        public string Medicamentos { get; set; }

        public decimal PrecioTotal { get; set; }

        public string Estado_Pago { get; set; }
    }
}
