using DentalServices.CommunicationLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalServices.CommunicationLog.Interface
{
    public interface ICommunicationRepository
    {
        bool Save(Note note);
        Note GetNote(string id);
        Notes GetNote(string objectType, string objectKey);
    }
}
