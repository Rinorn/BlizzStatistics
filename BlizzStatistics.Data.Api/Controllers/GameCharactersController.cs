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
    public class GameCharactersController : ApiController
    {
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/GameCharacters
        public IQueryable<GameCharacter> GetGameCharacters()
        {
            return db.GameCharacters;
        }

        // GET: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public async Task<IHttpActionResult> GetGameCharacter(string id)
        {
            GameCharacter gameCharacter = await db.GameCharacters.FindAsync(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            return Ok(gameCharacter);
        }

        // PUT: api/GameCharacters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGameCharacter(string id, GameCharacter gameCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameCharacter.UserId)
            {
                return BadRequest();
            }

            db.Entry(gameCharacter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCharacterExists(id))
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

        // POST: api/GameCharacters
        [ResponseType(typeof(GameCharacter))]
        public async Task<IHttpActionResult> PostGameCharacter(GameCharacter gameCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameCharacters.Add(gameCharacter);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameCharacterExists(gameCharacter.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gameCharacter.UserId }, gameCharacter);
        }

        // DELETE: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public async Task<IHttpActionResult> DeleteGameCharacter(string id)
        {
            GameCharacter gameCharacter = await db.GameCharacters.FindAsync(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            db.GameCharacters.Remove(gameCharacter);
            await db.SaveChangesAsync();

            return Ok(gameCharacter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameCharacterExists(string id)
        {
            return db.GameCharacters.Count(e => e.UserId == id) > 0;
        }
    }
}