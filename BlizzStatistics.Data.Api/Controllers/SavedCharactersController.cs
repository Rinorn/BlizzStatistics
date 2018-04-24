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
    public class SavedCharactersController : ApiController
    {
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/SavedCharacters
        public IQueryable<SavedCharacter> GetSavedCharacters()
        {
            return db.SavedCharacters;
        }

        // GET: api/SavedCharacters/5
        [ResponseType(typeof(SavedCharacter))]
        public async Task<IHttpActionResult> GetSavedCharacter(string id)
        {
            SavedCharacter savedCharacter = await db.SavedCharacters.FindAsync(id);
            if (savedCharacter == null)
            {
                return NotFound();
            }

            return Ok(savedCharacter);
        }

        // PUT: api/SavedCharacters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSavedCharacter(int id, SavedCharacter savedCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedCharacter.id)
            {
                return BadRequest();
            }

            db.Entry(savedCharacter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedCharacterExists(id))
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

        // POST: api/SavedCharacters
        [ResponseType(typeof(SavedCharacter))]
        public async Task<IHttpActionResult> PostSavedCharacter(SavedCharacter savedCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SavedCharacters.Add(savedCharacter);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SavedCharacterExists(savedCharacter.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { Name = savedCharacter.name }, savedCharacter);
        }

        // DELETE: api/SavedCharacters/5
        [ResponseType(typeof(SavedCharacter))]
        public async Task<IHttpActionResult> DeleteSavedCharacter(string id)
        {
            SavedCharacter savedCharacter = await db.SavedCharacters.FindAsync(id);
            if (savedCharacter == null)
            {
                return NotFound();
            }

            db.SavedCharacters.Remove(savedCharacter);
            await db.SaveChangesAsync();

            return Ok(savedCharacter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SavedCharacterExists(int id)
        {
            return db.SavedCharacters.Count(e => e.id == id) > 0;
        }
    }
}