using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for cake options.
    /// </summary>
    public interface ICakeOptionsDAO
    {
        ///<Summary>
        /// Returns a list of cake styles stored in our SQL database
        ///</Summary>
        List<Styles> GetAllCakeStyles();

        ///<Summary>
        /// Returns a list of cake sizes stored in our SQL database
        ///</Summary>
        List<Sizes> GetAllCakeSizes();

        

    }
}
