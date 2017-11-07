using DVDLibrary.Data.InterfaceAndFactory;
using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryAPI.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        //Gets dvd by id
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int dvdId)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetById(dvdId));
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateById(Dvd dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.Update(dvd);
            return Ok(dvd.DvdId);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateNewDvd(Dvd dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.Insert(dvd);
            return Ok(dvd.DvdId);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteById(int dvdId)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.Delete(dvdId);
            return Ok();
        }

    }
}
