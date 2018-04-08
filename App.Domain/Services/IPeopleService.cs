
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Models;

namespace App.Domain.Services
{
    /// <summary>
    /// People data source
    /// </summary>
    public interface IPeopleService
    {
        /// <summary>
        /// returns list of <c>People</c>. 
        /// 
        /// See <see cref="App.Domain.Models.People.Person"/>
        /// </summary>
        /// <returns></returns>
        Task<ICollection<People.Person>> GetPeopleAsync();
    }
}
