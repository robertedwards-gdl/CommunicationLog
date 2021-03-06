﻿using DentalServices.CommunicationLog.Interface;
using DentalServices.CommunicationLog.Model;
using DentalServices.CommunicationLog.Extensions;
using MongoDB.Bson;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalServices.CommunicationLog.DataAccess
{
    public class CommunicationRepository : MongoRepository<Note>, ICommunicationRepository
    {
        public bool Save(Note note)
        {
            if (!note.IsValid()) { throw new ArgumentException("Note data is invalid"); }

            Note current = null;

            if (!string.IsNullOrEmpty(note.Id))
            {
                current = this.First(n => n.Id == note.Id);
            }

            if (current != null)
            {
                if (!current.CreatedBy.Equals(note.ModifiedBy, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("cannot update notes created by another user.");
                }

                note.ModifiedUTC = (note.ModifiedUTC == DateTime.MinValue) ? DateTime.Now : note.ModifiedUTC;

                this.Update(note);

                return true;
            }

            note.ObjectType = note.ObjectType.ToLower();
            this.Add(note);

            return true;
        }

        public Note GetNote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid parameter");
            }

            var objectId = new ObjectId(id);
            var note = this.GetById(objectId);

            return note;
        }

        public Notes GetNote(string objectType, string objectKey)
        {
            if(string.IsNullOrEmpty(objectType) || string.IsNullOrEmpty(objectKey))
            {
                throw new ArgumentException("Invalid parameter");
            }

            var list = this.Where(n => n.ObjectType == objectType && n.ObjectKey == objectKey).ToList();

            var notes = new Notes();

            notes.AddRange(list);

            return notes;
        }
    }
}
