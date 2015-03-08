using DentalServices.CommunicationLog.Model;
using Nancy.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DentalServices.CommunicationLog.Extensions
{
    internal static class RequestExtensions
    {
        public static string ReadAsString(this RequestStream requestStream)
        {
            using (var reader = new StreamReader(requestStream))
            {
                return reader.ReadToEnd();
            }
        }

        public static bool IsValid(this Note note)
        {
            if(string.IsNullOrEmpty(note.NoteText) || string.IsNullOrEmpty(note.CreatedBy) || note.CreatedUTC == DateTime.MinValue)
            {
                return false;
            }

            return true;
        }
    }
}