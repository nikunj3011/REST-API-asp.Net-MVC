using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GameLibrary.DataAccess.Repo;
using GameLibrary.Entities;

namespace GameLibrary.Api.Controllers
{
    public class GamesController : ApiController
    {
        public IGameLibraryRepo gameLibraryRepo;

        public GamesController(IGameLibraryRepo gameLibraryRepo)
        {
            this.gameLibraryRepo = gameLibraryRepo;
        }

        // GET: api/Games
        public List<Games> GetGames()
        {
            return gameLibraryRepo.GetAll();
        }

        // GET: api/Games/5
        [ResponseType(typeof(Games))]
        public IHttpActionResult GetGames(int id)
        {
            Games games = gameLibraryRepo.Get(id);
            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGames(int id, Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games.GameLibraryID)
            {
                return BadRequest();
            }

            try
            {
                gameLibraryRepo.Update(games);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Games))]
        public IHttpActionResult PostGames(Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gameLibraryRepo.Create(games);

            return CreatedAtRoute("DefaultApi", new { id = games.GameLibraryID }, games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Games))]
        public IHttpActionResult DeleteGames(int id)
        {
            Games games = gameLibraryRepo.Get(id);
            if (games == null)
            {
                return NotFound();
            }

            gameLibraryRepo.Delete(games);

            return Ok(games);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        private bool GamesExists(int id)
        {
            return gameLibraryRepo.GetQueriable().Count(e => e.GameLibraryID == id) > 0;
        }
    }
}