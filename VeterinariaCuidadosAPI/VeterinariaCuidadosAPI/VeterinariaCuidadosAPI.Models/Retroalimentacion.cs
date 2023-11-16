using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaCuidadosAPI.Models
{
    public class Retroalimentacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        public string UsuarioCorreo { get; set; }

        public string TextoComentario { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
