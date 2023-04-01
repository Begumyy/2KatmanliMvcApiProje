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
    public class SatilanlarsController : ApiController
    {
        private apimvccrudEntities db = new apimvccrudEntities();

        // GET: api/Satilanlars
        public IQueryable<Satilanlar> GetSatilanlars()
        {
            return db.Satilanlars;
        }

        // GET: api/Satilanlars/5
        [ResponseType(typeof(Satilanlar))]
        public async Task<IHttpActionResult> GetSatilanlar(int id)
        {
            Satilanlar satilanlar = await db.Satilanlars.FindAsync(id);
            if (satilanlar == null)
            {
                return NotFound();
            }

            return Ok(satilanlar);
        }

        // PUT: api/Satilanlars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSatilanlar(int id, Satilanlar satilanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != satilanlar.SatilanNo)
            {
                return BadRequest();
            }

            db.Entry(satilanlar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatilanlarExists(id))
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

        // POST: api/Satilanlars
        [ResponseType(typeof(Satilanlar))]
        public async Task<IHttpActionResult> PostSatilanlar(Satilanlar satilanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Satilanlars.Add(satilanlar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = satilanlar.SatilanNo }, satilanlar);
        }

        // DELETE: api/Satilanlars/5
        [ResponseType(typeof(Satilanlar))]
        public async Task<IHttpActionResult> DeleteSatilanlar(int id)
        {
            Satilanlar satilanlar = await db.Satilanlars.FindAsync(id);
            if (satilanlar == null)
            {
                return NotFound();
            }

            db.Satilanlars.Remove(satilanlar);
            await db.SaveChangesAsync();

            return Ok(satilanlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SatilanlarExists(int id)
        {
            return db.Satilanlars.Count(e => e.SatilanNo == id) > 0;
        }
    }
}