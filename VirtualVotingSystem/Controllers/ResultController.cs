using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystem.Controllers
{
    //[Authorize(Roles ="User/Admin")]
    public class ResultController : Controller
    {
        private IResultBAL _resultBAL;
        public ResultController(IResultBAL resultBAL)
        {
            _resultBAL = resultBAL;
        }


        // <summary>
        // This method contains references to view the results of elections
        // </summary>
        public IActionResult Index()
        {
            return View();
        }

        // <summary>
        // This method displays the candidate with highest votes based on state
        // </summary>
        public IActionResult GetCandidateWithHighestVotesByState()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCandidateWithHighestVotesByState(string state)
        {
            CandidateDetailEntity candidate = await _resultBAL.GetCandidateWithHighestVotesByState(state);
            TempData["CandidateWithHighestVotesByState"] = JsonConvert.SerializeObject(candidate);
            return RedirectToAction("ShowCandidateWithHighestVotesByState");
        }
        [HttpGet]
        public async Task<IActionResult> ShowCandidateWithHighestVotesByState()
        {
            CandidateDetailEntity candidate = JsonConvert.DeserializeObject<CandidateDetailEntity>((string)TempData["CandidateWithHighestVotesByState"]);
            return await Task.FromResult(View(candidate));
        }


        // <summary>
        // This method displays the candidate with least votes based on state
        // </summary>
        public IActionResult GetCandidateWithLeastVotesByState()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCandidateWithLeastVotesByState(string state)
        {
            CandidateDetailEntity candidate = await _resultBAL.GetCandidateWithLeastVotesByState(state);
            TempData["CandidateWithLeastVotesByState"] = JsonConvert.SerializeObject(candidate);
            return RedirectToAction("ShowCandidateWithLeastVotesByState");
        }
        [HttpGet]
        public async Task<IActionResult> ShowCandidateWithLeastVotesByState()
        {
            CandidateDetailEntity candidate = JsonConvert.DeserializeObject<CandidateDetailEntity>((string)TempData["CandidateWithLeastVotesByState"]);
            return await Task.FromResult(View(candidate));
        }


        // <summary>
        // This method displays count of votes of all the candidates based on state
        // </summary>
        public IActionResult GetCandidatesByState()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCandidatesByState(string state)
        {
            List<CandidateDetailEntity> candidates = await _resultBAL.GetCandidatesByState(state);
            TempData["Candidates"] = JsonConvert.SerializeObject(candidates);

            return RedirectToAction("ShowCandidatesByState", candidates);
        }
        [HttpGet]
        public IActionResult ShowCandidatesByState()
        {
            List<CandidateDetailEntity> candidateDetailEntities = new List<CandidateDetailEntity>();
            candidateDetailEntities = JsonConvert.DeserializeObject<List<CandidateDetailEntity>>((string)TempData["Candidates"]);
            return View(candidateDetailEntities);
        }


        // <summary>
        // This method displays the count of  votes of all candidates throughout the country
        // </summary>
        public async Task<IActionResult> GetCandidates()
        {
            List<CandidateDetailEntity> candidates = await _resultBAL.GetCandidates();

            return View(candidates);
        }
    }
}
