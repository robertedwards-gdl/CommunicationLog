using DentalServices.CommunicationLog.Interface;
using DentalServices.CommunicationLog.Model;
using MongoRepository;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentalServices.CommunicationLog.Extensions;

namespace DentalServices.CommunicationLog.Modules
{
    public class Communication: NancyModule
    {
        ICommunicationRepository _repo;
        public Communication(ICommunicationRepository repo)
        {
            _repo = repo;

            Get["/api/note/{noteId}"] = _ =>
            {
                try
                {
                    Note note = _repo.GetNote(_.noteId);

                    return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(note);
                }
                catch(Exception e)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
                }

            };

            Get["/api/note/{objectType}/{objectKey}"] = _ =>
            {
                try
                {
                    string type = _.objectType;
                    string key = _.objectKey;
                    Notes notes = _repo.GetNote(type, key);

                    return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(notes);
                }
                catch(Exception e)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
                }
            };

            Post["api/note/{objectType}/{objectkey}"] = _ =>
            {
                try
                {
                    var message = this.Bind<Note>(new BindingConfig { BodyOnly = true });

                    _repo.Save(message);

                    var response = (Response)"Note Added";

                    response.StatusCode = HttpStatusCode.Created;

                    return response;
                }
                catch (Exception e)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
                }
            };

            Get["/api/machine"] = _ =>
            {
                try
                {
                    System.Console.WriteLine("Visit /machine on " + System.Environment.MachineName);
                    var response = (Response)System.Environment.MachineName;

                    response.StatusCode = HttpStatusCode.OK;

                    return response;
                }
                catch (Exception e)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
                }
            };
        }
    }
}
