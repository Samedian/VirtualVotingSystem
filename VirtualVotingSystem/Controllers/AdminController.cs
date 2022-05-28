using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemEntities;
using VirtualVotingSystemExceptions;

namespace VirtualVotingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminBAL _adminBAL;
        public AdminController(IAdminBAL adminBAL)
        {
            _adminBAL = adminBAL;
        }


        // <summary>
        // This method has the references to perform different actions based on Role logged in
        // </summary>
        public IActionResult Index()
        {
            String UserName = null;
            if (TempData.ContainsKey("UserID"))
            {
                UserName = TempData["UserID"].ToString();
            }
            return View();
        }

        // <summary>
        // This method allows the admin to add another admin
        // </summary>
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminCredentialEntity admin)
        {
            bool res = await _adminBAL.AddAdmin(admin);
            ViewBag.Error = res;
            return View();            //return RedirectToAction("Index");
        }


        // <summary>
        // This method allows the admin to update admin details
        // </summary>
        public IActionResult UpdateAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(AdminCredentialEntity admin)
        {
            try
            {
                AdminCredentialEntity adminCredential = await _adminBAL.UpdateAdmin(admin);
                if (adminCredential != null)
                {
                    ViewBag.Error = true;
                }
                else
                {
                    ViewBag.Error = false;
                }
            }
            catch (DataNotFound)
            {
                ViewBag.Error = false;
            }
            catch (SqlException)
            {
                ViewBag.Error = false;
            }
            catch (Exception)
            {
                ViewBag.Error = false;
            }
            return View();
        }

        // <summary>
        // This method allows the admin to add details of candidate standing for elections
        // </summary>

        public async Task<IActionResult> AddCandidate()
        {
            return await Task.FromResult(View());
        }
        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateDetailEntity candidate)
        {
            bool result = await _adminBAL.AddCandidate(candidate);
            ViewBag.Error = result;
                return View() ;
        }

        // <summary>
        // This method allows the admin to update details of candidate standing for elections
        // </summary>
        public IActionResult UpdateCandidate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(CandidateDetailEntity candidate)
        {

            try
            {
                CandidateDetailEntity candidateDetail = await _adminBAL.UpdateCandidate(candidate);
                if (candidateDetail != null)
                {
                    ViewBag.Error = true;
                }
                else
                {
                    ViewBag.Error = false;
                }
            }
            catch (DataNotFound)
            {
                ViewBag.Error = false;
            }
            catch (SqlException)
            {
                ViewBag.Error = false;
            }
            catch (Exception)
            {
                ViewBag.Error = false;
            }
            return View();
        }

    

    // <summary>
    // This method allows the admin to delete details of candidate standing for elections
    // </summary>
    public IActionResult DeleteCandidate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCandidate(string CandidateId)
        {
            bool res = await _adminBAL.DeleteCandidate(CandidateId);
            ViewBag.Error = res;
            return View();
        }

        // <summary>
        // This method allows to choose state name to display candidate details
        // </summary>
        public IActionResult GetCandidatesByState()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCandidatesByState(string state)
        {
            List<CandidateDetailEntity> candidates = await _adminBAL.GetCandidatesByState(state);
            TempData["Candidates"] = JsonConvert.SerializeObject(candidates);
            return RedirectToAction("ShowCandidatesByState", candidates);
        }

        // <summary>
        // This method displays candidate details based on State by using temp data
        // </summary>
        [HttpGet]
        public IActionResult ShowCandidatesByState()
        {
            List<CandidateDetailEntity> candidateDetailEntities = new List<CandidateDetailEntity>();
            candidateDetailEntities = JsonConvert.DeserializeObject<List<CandidateDetailEntity>>((string)TempData["Candidates"]);
            return View(candidateDetailEntities);
        }


        // <summary>
        // These 3 methods displays throughout the country
        // </summary>

        public async Task<IActionResult> GetCandidates()
        {
            List<CandidateDetailEntity> candidates = await _adminBAL.GetCandidates();
            return View(candidates);
        }



        // <summary>
        // These 3 methods displays candidate based on  CandidateId
        // </summary>

        public IActionResult GetCandidateById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCandidateById(string Id)
        {
            CandidateDetailEntity candidate = await _adminBAL.GetCandidatesById(Id);
            TempData["CandidateWithHighestVotesByState"] = JsonConvert.SerializeObject(candidate);
            return RedirectToAction("ShowCandidateById");
        }
        [HttpGet]
        public async Task<IActionResult> ShowCandidateById()
        {
            CandidateDetailEntity candidate = JsonConvert.DeserializeObject<CandidateDetailEntity>((string)TempData["CandidateWithHighestVotesByState"]);
            return await Task.FromResult(View(candidate));
        }
    }
}
