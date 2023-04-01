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
    public class ImalatlarsController : ApiController
    {
        private apimvccrudEntities db = new apimvccrudEntities();

        // GET: api/Imalatlars
        public IQueryable<Imalatlar> GetImalatlars()
        {
            return db.Imalatlars;
        }

        // GET: api/Imalatlars/5
        [ResponseType(typeof(Imalatlar))]
        public async Task<IHttpActionResult> GetImalatlar(int id)
        {
            Imalatlar imalatlar = await db.Imalatlars.FindAsync(id);
            if (imalatlar == null)
            {
                return NotFound();
            }

            return Ok(imalatlar);
        }

        // PUT: api/Imalatlars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutImalatlar(int id, Imalatlar imalatlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imalatlar.ImalatNo)
            {
                return BadRequest();
            }

            db.Entry(imalatlar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImalatlarExists(id))
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

        // POST: api/Imalatlars
        [ResponseType(typeof(Imalatlar))]
        public async Task<IHttpActionResult> PostImalatlar(Imalatlar imalatlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Imalatlars.Add(imalatlar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = imalatlar.ImalatNo }, imalatlar);
        }

        // DELETE: api/Imalatlars/5
        [ResponseType(typeof(Imalatlar))]
        public async Task<IHttpActionResult> DeleteImalatlar(int id)
        {
            Imalatlar imalatlar = await db.Imalatlars.FindAsync(id);
            if (imalatlar == null)
            {
                return NotFound();
            }

            db.Imalatlars.Remove(imalatlar);
            await db.SaveChangesAsync();

            return Ok(imalatlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImalatlarExists(int id)
        {
            return db.Imalatlars.Count(e => e.ImalatNo == id) > 0;
        }
    }
}