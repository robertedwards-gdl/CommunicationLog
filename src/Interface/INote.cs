using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalServices.CommunicationLog.Interface
{
    public interface INote: IEntity<string>
    {
        string ObjectType { get; set; }
        string ObjectKey { get; set; }
        string NoteText { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedUTC { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedUTC { get; set; }

    }
}
