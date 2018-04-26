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
    public class CharacterRacesController : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/CharacterRaces
        /// <summary>
        /// Gets the character races.
        /// </summary>
        /// <returns></returns>
        public IQueryable<CharacterRace> GetCharacterRaces()
        {
            return db.CharacterRaces;
        }

        // GET: api/CharacterRaces/5
        /// <summary>
        /// Gets the character race.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(CharacterRace))]
        public async Task<IHttpActionResult> GetCharacterRace(int id)
        {
            CharacterRace characterRace = await db.CharacterRaces.FindAsync(id);
            if (characterRace == null)
            {
                return NotFound();
            }

            return Ok(characterRace);
        }

        // PUT: api/CharacterRaces/5
        /// <summary>
        /// Puts the character race.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="characterRace">The character race.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacterRace(int id, CharacterRace characterRace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterRace.Id)
            {
                return BadRequest();
            }

            db.Entry(characterRace).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterRaceExists(id))
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

        // POST: api/CharacterRaces
        /// <summary>
        /// Posts the character race.
        /// </summary>
        /// <param name="characterRace">The character race.</param>
        /// <returns></returns>
        [ResponseType(typeof(CharacterRace))]
        public async Task<IHttpActionResult> PostCharacterRace(CharacterRace characterRace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CharacterRaces.Add(characterRace);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = characterRace.Id }, characterRace);
        }

        // DELETE: api/CharacterRaces/5
        /// <summary>
        /// Deletes the character race.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(CharacterRace))]
        public async Task<IHttpActionResult> DeleteCharacterRace(int id)
        {
            CharacterRace characterRace = await db.CharacterRaces.FindAsync(id);
            if (characterRace == null)
            {
                return NotFound();
            }

            db.CharacterRaces.Remove(characterRace);
            await db.SaveChangesAsync();

            return Ok(characterRace);
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
        /// Characters the race exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool CharacterRaceExists(int id)
        {
            return db.CharacterRaces.Count(e => e.Id == id) > 0;
        }
    }
}