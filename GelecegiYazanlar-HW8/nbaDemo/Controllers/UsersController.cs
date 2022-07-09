using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Responses;
using nbaDemo.Web.Extensions;
using nbaDemo.Web.Models;
using nbaDemo.Web.Models.Favorite;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace nbaDemo.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ITeamService teamService;
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, ITeamService teamService, IPlayerService playerService, IMapper mapper)
        {
            this.userService = userService;
            this.teamService = teamService;
            this.playerService = playerService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model, string returnURL)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(model.Username, model.Password);

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                }

                ModelState.AddModelError("Login", "Username or password is invalid.");

            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult MyFavorites()
        {
            var favoritePlayersCollection = GetFavoritePlayersCollectionFromSession();
            var favoriteTeamsCollection = GetFavoriteTeamsCollectionFromSession();
            var model = new FavoriteCollectionsViewModel
            {
                FavoritePlayersCollection = favoritePlayersCollection,
                FavoriteTeamsCollection = favoriteTeamsCollection
            };

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;
            return View();
        }

        public async Task<IActionResult> AddPlayerToFavorite(int id)
        {
            if (await playerService.IsExist(id))
            {
                var player = await playerService.GetPlayerById(id);
                var playerListResponse = mapper.Map<PlayerListResponse>(player);
                FavoritePlayersCollection favoritePlayersCollection = GetFavoritePlayersCollectionFromSession();
                var result = favoritePlayersCollection.FindPlayer(playerListResponse.ID);
                if (!result)
                {
                    favoritePlayersCollection.AddPlayer(new FavoritePlayer { Player = playerListResponse });
                    SaveFavoritePlayersCollectionToSession(favoritePlayersCollection);
                }
                else
                {
                    return Json($"{player.FullName} is already in your favorite players list.");
                }

                return Json($"{player.FullName} is added to favorites.");
            }

            return NotFound();
        }

        public async Task<IActionResult> AddTeamToFavorite(int id)
        {
            if (await teamService.IsExist(id))
            {
                var team = await teamService.GetTeamById(id);
                var teamListResponse = mapper.Map<TeamListResponse>(team);
                FavoriteTeamsCollection favoriteTeamsCollection = GetFavoriteTeamsCollectionFromSession();
                var result = favoriteTeamsCollection.FindPlayer(teamListResponse.ID);
                if (!result)
                {
                    favoriteTeamsCollection.AddPlayer(new FavoriteTeam { Team = teamListResponse });
                    SaveFavoriteTeamsCollectionToSession(favoriteTeamsCollection);
                }
                else
                {
                    return Json($"{team.Name} is already in your favorite players list.");
                }

                return Json($"{team.Name} is added to favorites.");
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult RemovePlayerFromFavorite(int id)
        {
            FavoritePlayersCollection playersCollection = GetFavoritePlayersCollectionFromSession();
            playersCollection.Delete(id);
            SaveFavoritePlayersCollectionToSession(playersCollection);
            return Json("Successfully deleted.");
        }

        [HttpPost]
        public IActionResult RemoveTeamFromFavorite(int id)
        {
            FavoriteTeamsCollection teamsCollection = GetFavoriteTeamsCollectionFromSession();
            teamsCollection.Delete(id);
            SaveFavoriteTeamsCollectionToSession(teamsCollection);
            return Json("Successfully deleted.");
        }

        private FavoritePlayersCollection GetFavoritePlayersCollectionFromSession()
        {
            FavoritePlayersCollection playersCollection = null;
            playersCollection = HttpContext.Session.GetJSON<FavoritePlayersCollection>("My Favorite Players") ?? new FavoritePlayersCollection();

            return playersCollection;
        }

        private void SaveFavoritePlayersCollectionToSession(FavoritePlayersCollection favoritePlayersCollection)
        {
            HttpContext.Session.SetJSON("My Favorite Players", favoritePlayersCollection);
        }

        private FavoriteTeamsCollection GetFavoriteTeamsCollectionFromSession()
        {
            FavoriteTeamsCollection teamsCollection = null;
            teamsCollection = HttpContext.Session.GetJSON<FavoriteTeamsCollection>("My Favorite Teams") ?? new FavoriteTeamsCollection();

            return teamsCollection;
        }

        private void SaveFavoriteTeamsCollectionToSession(FavoriteTeamsCollection favoriteTeamsCollection)
        {
            HttpContext.Session.SetJSON("My Favorite Teams", favoriteTeamsCollection);
        }
    }
}
