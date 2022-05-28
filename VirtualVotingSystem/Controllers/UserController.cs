using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telesign;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemEntities;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using VirtualVotingDemo;

namespace VirtualVotingSystem.Controllers
{
    [Authorize(Roles="User")]
    public class UserController : Controller
    {
        private readonly IUserBAL _userBAL;
        private static string verifyCode;
        private readonly ISMS _iSMS;
        private static int count=1;
        private static UserIdEntity userId = null;
        private static UserDetailEntity userDetail = null;
        public UserController(IUserBAL userBAL,ISMS iSMS)
        {
            _userBAL = userBAL;
            _iSMS = iSMS;
        }



        // <summary>
        // This method allows the user to login with their UserId
        // </summary>
        [HttpGet]
        public async Task<IActionResult> LoginUser()
        {
            string UserName = null;
            if (TempData.ContainsKey("UserID"))
            {
                UserName = TempData["UserID"].ToString();
            }

            (userId, userDetail) = _userBAL.GetUserDetailsByVvid(UserName);
            List<CandidateDetailEntity> candidateDetailEntities = await _userBAL.GetCandidateByRegion(userDetail);

            TempData["CandidateDetail"] = JsonConvert.SerializeObject(candidateDetailEntities);


            verifyCode=_iSMS.SendOTP(Convert.ToString(userDetail.MobileNumber));

            return RedirectToAction("EnterOTP");
        }

       

        // <summary>
        //This  Action Method asks user to enter OTP and confirms registration
        // </summary>

        [HttpGet]
        public IActionResult EnterOTP()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterOTP(string OTP)
        {
            if (OTP.Equals(verifyCode) && count < 2)
                return RedirectToAction("CastVote");
            else if (count < 3)
            {
                count++;
                ViewBag.Error = "Incorrect OTP... " + (4 - count) + " chances left";
                return View();
            }
            else
                return RedirectToAction("Index");
        }

        // <summary>
        //This Action Method allows user cast their vote
        // </summary>

        [HttpGet]
        public IActionResult CastVote()
        {
            List<CandidateDetailEntity> candidateDetail = null;


            if (TempData.ContainsKey("CandidateDetail"))
                candidateDetail = JsonConvert.DeserializeObject<List<CandidateDetailEntity>>((string)TempData["CandidateDetail"]);

            ViewBag.Candidate = candidateDetail;
            ViewBag.UserId = userId;
            ViewBag.UserDetail = userDetail;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CastVote(string candidateId)
        {
            CandidateDetailEntity candidateDetailEntity = await _userBAL.GetCandidateById(candidateId);
            _userBAL.CastVote(candidateDetailEntity, userId);
            return RedirectToAction("Success");
        }


        // <summary>
        //This  Action Method displays when user has casted the vote successfully
        // </summary>
        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

    }

}