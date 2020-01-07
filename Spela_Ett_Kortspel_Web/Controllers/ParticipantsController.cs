using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels;
using Spela_Ett_Kortspel_Web.Models.ViewModels;
using Spela_Ett_Kortspel_Viktor_Hoerwing;

namespace Spela_Ett_Kortspel_Web.Controllers
{
    public class ParticipantsController : Controller
    {
        ParticipantsService service;
        public ParticipantsController(ParticipantsService service)
        {
            this.service = service;
        }
        [Route("")]
        [Route("winners/index")]
        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            ViewBag.sortOrder = sortOrder;
            var viewModel = service.GetDropDownItems();
            return View(viewModel);
        }
        [Route("")]
        [Route("winners/index")]
        [HttpPost]
        public IActionResult GameDetails(GameCreateVM game)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var viewModel = service.StartGame(game.Name, game.SelectedNumberOfOpponents);
            service.AddWinnerToDatabase(viewModel.First());
            return View(viewModel);
        }
    }
}