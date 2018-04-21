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
    public class CharacterClassesController : ApiController
    {
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/CharacterClasses
        public IQueryable<CharacterClass> GetCharacterClasses()
        {
            return db.CharacterClasses;
        }

        // GET: api/CharacterClasses/5
        [ResponseType(typeof(CharacterClass))]
        public async Task<IHttpActionResult> GetCharacterClass(int id)
        {
            CharacterClass characterClass = await db.CharacterClasses.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }

            return Ok(characterClass);
        }

        // PUT: api/CharacterClasses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacterClass(int id, CharacterClass characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterClass.id)
            {
                return BadRequest();
            }

            db.Entry(characterClass).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterClassExists(id))
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

        // POST: api/CharacterClasses
        [ResponseType(typeof(CharacterClass))]
        public async Task<IHttpActionResult> PostCharacterClass(CharacterClass characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CharacterClasses.Add(characterClass);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = characterClass.id }, characterClass);
        }

        // DELETE: api/CharacterClasses/5
        [ResponseType(typeof(CharacterClass))]
        public async Task<IHttpActionResult> DeleteCharacterClass(int id)
        {
            CharacterClass characterClass = await db.CharacterClasses.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }

            db.CharacterClasses.Remove(characterClass);
            await db.SaveChangesAsync();

            return Ok(characterClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterClassExists(int id)
        {
            return db.CharacterClasses.Count(e => e.id == id) > 0;
        }
    }
}