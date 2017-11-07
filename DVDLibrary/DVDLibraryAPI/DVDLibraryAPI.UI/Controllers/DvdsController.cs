using DVDLibrary.Data.InterfaceAndFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDLibraryAPI.UI.Controllers
{
    public class DvdsController : ApiController
    {
        [Route("dvds/{category}/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchDvds(string category, string searchTerm)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetBySearch(category, searchTerm));
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetAll());
        }
    }
}
