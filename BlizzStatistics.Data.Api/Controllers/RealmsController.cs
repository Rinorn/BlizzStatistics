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
using BlizzStatistics.DataAccess;
using ClassLibrary1;

namespace BlizzStatistics.Data.Api.Controllers
{
    public class RealmsController : ApiController
    {
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/Realms
        public IQueryable<Realm> GetRealms()
        {
            return db.Realms;
        }

        // GET: api/Realms/5
        [ResponseType(typeof(Realm))]
        public async Task<IHttpActionResult> GetRealm(int id)
        {
            Realm realm = await db.Realms.FindAsync(id);
            if (realm == null)
            {
                return NotFound();
            }

            return Ok(realm);
        }

        // PUT: api/Realms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRealm(int id, Realm realm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realm.DbId)
            {
                return BadRequest();
            }

            db.Entry(realm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealmExists(id))
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

        // POST: api/Realms
        [ResponseType(typeof(Realm))]
        public async Task<IHttpActionResult> PostRealm(Realm realm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realms.Add(realm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = realm.DbId }, realm);
        }

        // DELETE: api/Realms/5
        [ResponseType(typeof(Realm))]
        public async Task<IHttpActionResult> DeleteRealm(int id)
        {
            Realm realm = await db.Realms.FindAsync(id);
            if (realm == null)
            {
                return NotFound();
            }

            db.Realms.Remove(realm);
            await db.SaveChangesAsync();

            return Ok(realm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealmExists(int id)
        {
            return db.Realms.Count(e => e.DbId == id) > 0;
        }
    }
}