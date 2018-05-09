using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BlizzStatistics.DataAccess;
using ClassLibrary1;

namespace BlizzStatistics.Data.Api.Controllers
{
    public class SavedCharactersController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/SavedCharacters
        /// <summary>
        /// Gets the saved characters.
        /// </summary>
        /// <returns></returns>
        public IQueryable<SavedCharacter> GetSavedCharacters()
        {
            return db.SavedCharacters;
        }

        // GET: api/SavedCharacters/5
        /// <summary>
        /// Gets the saved character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(SavedCharacter))]
        public async Task<IHttpActionResult> GetSavedCharacter(int id)
        {
            SavedCharacter savedCharacter = await db.SavedCharacters.FindAsync(id);
            if (savedCharacter == null)
            {
                return NotFound();
            }

            return Ok(savedCharacter);
        }

        // PUT: api/SavedCharacters/5
        /// <summary>
        /// Puts the saved character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="savedCharacter">The saved character.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSavedCharacter(int id, SavedCharacter savedCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedCharacter.Id)
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
        /// <summary>
        /// Posts the saved character.
        /// </summary>
        /// <param name="savedCharacter">The saved character.</param>
        /// <returns></returns>
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
                if (SavedCharacterExists(savedCharacter.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new {savedCharacter.Name }, savedCharacter);
        }

        // DELETE: api/SavedCharacters/5
        /// <summary>
        /// Deletes the saved character.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(SavedCharacter))]
        public async Task<IHttpActionResult> DeleteSavedCharacter(int id)
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

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Saveds the character exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool SavedCharacterExists(int id)
        {
            return db.SavedCharacters.Count(e => e.Id == id) > 0;
        }
    }
}