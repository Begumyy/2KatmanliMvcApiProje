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
    public class SubelersController : ApiController
    {
        private apimvccrudEntities db = new apimvccrudEntities();

        // GET: api/Subelers
        public IQueryable<Subeler> GetSubelers()
        {
            return db.Subelers;
        }

        // GET: api/Subelers/5
        [ResponseType(typeof(Subeler))]
        public async Task<IHttpActionResult> GetSubeler(int id)
        {
            Subeler subeler = await db.Subelers.FindAsync(id);
            if (subeler == null)
            {
                return NotFound();
            }

            return Ok(subeler);
        }

        // PUT: api/Subelers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubeler(int id, Subeler subeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subeler.SubeNo)
            {
                return BadRequest();
            }

            db.Entry(subeler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubelerExists(id))
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

        // POST: api/Subelers
        [ResponseType(typeof(Subeler))]
        public async Task<IHttpActionResult> PostSubeler(Subeler subeler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subelers.Add(subeler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subeler.SubeNo }, subeler);
        }

        // DELETE: api/Subelers/5
        [ResponseType(typeof(Subeler))]
        public async Task<IHttpActionResult> DeleteSubeler(int id)
        {
            Subeler subeler = await db.Subelers.FindAsync(id);
            if (subeler == null)
            {
                return NotFound();
            }

            db.Subelers.Remove(subeler);
            await db.SaveChangesAsync();

            return Ok(subeler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubelerExists(int id)
        {
            return db.Subelers.Count(e => e.SubeNo == id) > 0;
        }
    }
}