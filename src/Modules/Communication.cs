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
#if DEBUG
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
#else
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
#endif
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
#if DEBUG
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
#else
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
#endif
                }
            };

            Post["api/note/{objectType}/{objectkey}"] = _ =>
            {
                try
                {
                    var message = this.Bind<Note>(new BindingConfig { BodyOnly = true });

                    _repo.Save(message);

                    var response = new ServiceResponse { Success = true, Message = "Note Created" };
                    return Negotiate
                        .WithModel(response)
                        .WithStatusCode(HttpStatusCode.Created);
                }
                catch (Exception e)
                {
#if DEBUG
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
#else
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
#endif
                }
            };

            Get["/api/machine"] = _ =>
            {
                try
                {
                    System.Console.WriteLine("Visit /machine on " + System.Environment.MachineName);
                    var response = new ServiceResponse { Success = true, Message = "Service running on " + System.Environment.MachineName };
                    return Negotiate
                        .WithModel(response)
                        .WithStatusCode(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
#if DEBUG
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest).WithModel(e);
#else
                    return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
#endif

                }
            };
        }
    }
}
