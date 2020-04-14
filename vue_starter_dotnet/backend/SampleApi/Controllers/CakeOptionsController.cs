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
        public List<Flavors> GetAllFlavors()
        {
            return cakeOptionsDao.GetAllCakeFlavors();
        }

        /// <summary>
        /// returns a list of all sizes from the sizes table
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllSizes")]
        public List<Sizes> GetAllSizes()
        {
            return cakeOptionsDao.GetAllCakeSizes();
        }

        /// <summary>
        /// returns a list of all styles from the styles table
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllStyles")]
        public List<Styles> GetAllStyles()
        {
            return cakeOptionsDao.GetAllCakeStyles();
        }

        [HttpPost("newFlavor")]
        public IActionResult Create([FromBody] Flavors flavor)
        {
            bool result = false;
            if (cakeOptionsDao.AddFlavorOption(flavor))
            {
                result = true;
            }
            return Ok(result);
        }
        [HttpPost("newFilling")]
        public IActionResult Create([FromBody] Fillings filling)
        {
            bool result = false;
            if (cakeOptionsDao.AddFillingOption(filling))
            {
                result = true;
            }
            return Ok(result);
        }
        [HttpPost("newFrosting")]
        public IActionResult Create([FromBody] Frostings frosting)
        {
            bool result = false;
            if (cakeOptionsDao.AddFrostingOption(frosting))
            {
                result = true;
            }
            return Ok(result);
        }
        [HttpPost("newFilling")]
        public IActionResult Create([FromBody] Styles style)
        {
            bool result = false;
            if (cakeOptionsDao.AddStyleOption(style))
            {
                result = true;
            }
            return Ok(result);
        }

    }
}