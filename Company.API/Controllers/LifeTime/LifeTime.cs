using Company.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers.LifeTime
{
    public class LifeTime : Controller
    {
        private readonly ILifeTimeService lifeTimeServiceA;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public LifeTime(ILifeTimeService lifeTimeServiceA, ServiceTransient serviceTransient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton )
        {
            this.lifeTimeServiceA = lifeTimeServiceA;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        [HttpGet("Guid")]
        [ResponseCache(Duration =10)]
        //[Authorize]
        public IActionResult GetGuids()
        {
            return Ok(new
            {
                LifeTime_Transient = serviceTransient.Guid,
                ServiceA_Transient = lifeTimeServiceA.GetTransient,
                LifeTime_Scoped = serviceScoped.Guid,
                ServiceA_Scoped = lifeTimeServiceA.GetScoped,
                LifeTime_Singleton = serviceSingleton.Guid,               
                ServiceA_Singleton = lifeTimeServiceA.GetSingleton
            });
        }
    }
}
