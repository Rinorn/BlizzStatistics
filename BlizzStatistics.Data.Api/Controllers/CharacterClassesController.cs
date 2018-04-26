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
    public class CharacterClassesController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/CharacterClasses
        /// <summary>
        /// Gets the character classes.
        /// </summary>
        /// <returns></returns>
        public IQueryable<CharacterClass> GetCharacterClasses()
        {
            return db.CharacterClasses;
        }

        // GET: api/CharacterClasses/5
        /// <summary>
        /// Gets the character class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Puts the character class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="characterClass">The character class.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacterClass(int id, CharacterClass characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterClass.Id)
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
        /// <summary>
        /// Posts the character class.
        /// </summary>
        /// <param name="characterClass">The character class.</param>
        /// <returns></returns>
        [ResponseType(typeof(CharacterClass))]
        public async Task<IHttpActionResult> PostCharacterClass(CharacterClass characterClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CharacterClasses.Add(characterClass);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = characterClass.Id }, characterClass);
        }

        // DELETE: api/CharacterClasses/5
        /// <summary>
        /// Deletes the character class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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
        /// Characters the class exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool CharacterClassExists(int id)
        {
            return db.CharacterClasses.Count(e => e.Id == id) > 0;
        }
    }
}