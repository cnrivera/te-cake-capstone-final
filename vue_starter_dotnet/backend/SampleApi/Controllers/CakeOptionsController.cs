using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;
using SampleApi.Models.Account;
using SampleApi.Providers.Security;

namespace SampleApi.Controllers
{
    /// <summary>
    /// Creates a new cake controller used to get a list of cakes/create new cake
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CakeOptionsController : ControllerBase
    {
        private ICakeOptionsDAO cakeOptionsDao;

        
        public CakeOptionsController(ICakeOptionsDAO cakeOptionsDao)
        {
            this.cakeOptionsDao = cakeOptionsDao;
        }

        /// <summary>
        /// returns a list of all frostings from the frostings table
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllFrostings")]
        public List<Frostings> GetAllFrostings()
        {
            return cakeOptionsDao.GetAllCakeFrostings();
        }

        /// <summary>
        /// returns a list of all fillings from the fillings table
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllFillings")]
        public List<Fillings> GetAllFillings()
        {
            return cakeOptionsDao.GetAllCakeFillings();
        }

        /// <summary>
        /// returns a list of all flavors from the flavors table
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllFlavors")]
        public List<Fillings> GetAllFlavors()
        {
            return cakeOptionsDao.GetAllCakeFlavors();
        }



    }
}