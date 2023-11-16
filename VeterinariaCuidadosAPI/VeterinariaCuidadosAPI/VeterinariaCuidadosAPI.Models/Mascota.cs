using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaCuidadosAPI.Models
{
    public class Mascota
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Especie { get; set; }

        public string Raza { get; set; }

        public int Edad { get; set; }
        public string DueñoId { get; set; } // Referencia al ID del usuario dueño
    }
}
