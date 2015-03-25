using DentalServices.CommunicationLog.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalServices.CommunicationLog.Model
{
    public class Note : INote
    {
        public string ObjectType { get; set; }
        public string ObjectKey { get; set; }
        public string NoteText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedUTC { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedUTC { get; set; }

        public string ChrisWoolum { get; set; }

     
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}
