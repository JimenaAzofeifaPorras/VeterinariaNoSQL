using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaCuidadosAPI.Models
{
    public class Cliente
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Nombre { get; set; }
        public int Cedula { get; set; }
        public string? Correo { get; set; }
        public int Telefono { get; set; }
    }
}
