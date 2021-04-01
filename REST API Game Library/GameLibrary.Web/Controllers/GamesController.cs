using GameLibrary.Client;
using GameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameLibrary.Web.Controllers
{
    public class GamesController : Controller
    {
        IGameLibraryClient GameClient;
        public GamesController(IGameLibraryClient GameClient)
        {
            //var baseAddress = "https://localhost:44321/";
            //GameClient = new GameLibraryClient(baseAddress);
            this.GameClient = GameClient;
        }
        
        // GET: Games1
        public async Task<ActionResult> Index()
        {
            return View(await GameClient.GetAll());
        }

        // GET: Games1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games games = await GameClient.Get(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // GET: Games1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GameLibraryID,Name,Description,GameSystem,Rating")] Games games)
        {
            if (ModelState.IsValid)
            {
                await GameClient.Create(games);
                return RedirectToAction("Index");
            }

            return View(games);
        }

        // GET: Games1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games games = await GameClient.Get(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: Games1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Games games)
        {
            if (ModelState.IsValid)
            {
                await GameClient.Update(games);
                return RedirectToAction("Index");
            }
            return View(games);
        }

        // GET: Games1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games games = await GameClient.Get(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: Games1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await GameClient.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}