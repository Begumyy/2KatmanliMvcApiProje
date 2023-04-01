using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using _2katmanlimvcapiornekproje.Models;

namespace _2katmanlimvcapiornekproje.Controllers
{
    public class FirmalarsController : ApiController
    {
        private apimvccrudEntities db = new apimvccrudEntities();

        // GET: api/Firmalars
        public IQueryable<Firmalar> GetFirmalars()
        {
            return db.Firmalars;
        }

        // GET: api/Firmalars/5
        [ResponseType(typeof(Firmalar))]
        public async Task<IHttpActionResult> GetFirmalar(int id)
        {
            Firmalar firmalar = await db.Firmalars.FindAsync(id);
            if (firmalar == null)
            {
                return NotFound();
            }

            return Ok(firmalar);
        }

        // PUT: api/Firmalars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFirmalar(int id, Firmalar firmalar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firmalar.FirmaNo)
            {
                return BadRequest();
            }

            db.Entry(firmalar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmalarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Firmalars
        [ResponseType(typeof(Firmalar))]
        public async Task<IHttpActionResult> PostFirmalar(Firmalar firmalar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Firmalars.Add(firmalar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = firmalar.FirmaNo }, firmalar);
        }

        // DELETE: api/Firmalars/5
        [ResponseType(typeof(Firmalar))]
        public async Task<IHttpActionResult> DeleteFirmalar(int id)
        {
            Firmalar firmalar = await db.Firmalars.FindAsync(id);
            if (firmalar == null)
            {
                return NotFound();
            }

            db.Firmalars.Remove(firmalar);
            await db.SaveChangesAsync();

            return Ok(firmalar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirmalarExists(int id)
        {
            return db.Firmalars.Count(e => e.FirmaNo == id) > 0;
        }
    }
}