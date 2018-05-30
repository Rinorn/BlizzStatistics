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
    public class ExceptionHandlersController : ApiController
    {
        private BlizzStatisticsContext db = new BlizzStatisticsContext();

        // GET: api/ExceptionHandlers
        public IQueryable<ExceptionHandler> GetExceptionHandlers()
        {
            return db.ExceptionHandlers;
        }

        // GET: api/ExceptionHandlers/5
        [ResponseType(typeof(ExceptionHandler))]
        public async Task<IHttpActionResult> GetExceptionHandler(int id)
        {
            ExceptionHandler exceptionHandler = await db.ExceptionHandlers.FindAsync(id);
            if (exceptionHandler == null)
            {
                return NotFound();
            }

            return Ok(exceptionHandler);
        }

        // PUT: api/ExceptionHandlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExceptionHandler(int id, ExceptionHandler exceptionHandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exceptionHandler.Id)
            {
                return BadRequest();
            }

            db.Entry(exceptionHandler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExceptionHandlerExists(id))
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

        // POST: api/ExceptionHandlers
        [ResponseType(typeof(ExceptionHandler))]
        public async Task<IHttpActionResult> PostExceptionHandler(ExceptionHandler exceptionHandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExceptionHandlers.Add(exceptionHandler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exceptionHandler.Id }, exceptionHandler);
        }

        // DELETE: api/ExceptionHandlers/5
        [ResponseType(typeof(ExceptionHandler))]
        public async Task<IHttpActionResult> DeleteExceptionHandler(int id)
        {
            ExceptionHandler exceptionHandler = await db.ExceptionHandlers.FindAsync(id);
            if (exceptionHandler == null)
            {
                return NotFound();
            }

            db.ExceptionHandlers.Remove(exceptionHandler);
            await db.SaveChangesAsync();

            return Ok(exceptionHandler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExceptionHandlerExists(int id)
        {
            return db.ExceptionHandlers.Count(e => e.Id == id) > 0;
        }
    }
}