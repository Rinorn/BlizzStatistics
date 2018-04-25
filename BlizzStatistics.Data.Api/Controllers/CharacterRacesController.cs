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
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/CharacterRaces
        public IQueryable<CharacterRace> GetCharacterRaces()
        {
            return db.CharacterRaces;
        }

        // GET: api/CharacterRaces/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterRaceExists(int id)
        {
            return db.CharacterRaces.Count(e => e.Id == id) > 0;
        }
    }
}