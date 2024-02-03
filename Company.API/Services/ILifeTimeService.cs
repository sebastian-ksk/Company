namespace Company.API.Services
{
    public interface ILifeTimeService
    {
        Guid GetTransient { get; }
        Guid GetScoped { get; }
        Guid GetSingleton { get; }
    }

    public class LifeTimeService : ILifeTimeService
    {
        private readonly ServiceSingleton serviceSingleton;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceTransient serviceTransient;

        public LifeTimeService(ServiceSingleton serviceSingleton, ServiceScoped serviceScoped, ServiceTransient serviceTransient) {
            this.serviceSingleton = serviceSingleton;
            this.serviceScoped = serviceScoped;
            this.serviceTransient = serviceTransient;
        }

        public Guid GetTransient => serviceTransient.Guid;
        public Guid GetScoped => serviceScoped.Guid;
        public Guid GetSingleton => serviceSingleton.Guid;

    }

    


    public class ServiceTransient
    {
      public Guid Guid = Guid.NewGuid();
    }

    public class ServiceScoped
    {
        public Guid Guid = Guid.NewGuid();
    }
    public class ServiceSingleton
    {
        public Guid Guid = Guid.NewGuid();
    }
}
