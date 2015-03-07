namespace DentalServices.CommunicationLog
{
    using DentalServices.CommunicationLog.DataAccess;
    using DentalServices.CommunicationLog.Interface;
    using DentalServices.CommunicationLog.Model;
    using MongoRepository;
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //    //container.Register<INote, Note>().AsSingleton();
            container.Register<IRepository<Note>, MongoRepository<Note>>().AsSingleton();
            container.Register<ICommunicationRepository, CommunicationRepository>().AsSingleton();
        }
    }
}