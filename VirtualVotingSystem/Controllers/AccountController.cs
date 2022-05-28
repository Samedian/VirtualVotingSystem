using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telesign;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using VirtualVotingDemo;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBAL _accountBAL;
        private readonly IGenerateID _generateID;
        private readonly ISMS _iSMS;
        private static string verifyCode;
        private static int count = 1;

        public AccountController(IAccountBAL accountBAL, IModelToEntityManager modelToEntityManager, IGenerateID generateID, ISMS iSMS)
        {
            _accountBAL = accountBAL;
            _generateID = generateID;
            _iSMS = iSMS;
        }



        // <summary>
        //This Action Method contains Main Home Page
        // </summary>
        public IActionResult Index()
        {
            return View();
        }

        // <summary>
        //This Action Method contains Login Page
        // </summary>

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
            {
                ViewBag.Error = true;

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Error = false;
            }
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            string roleassign = await _accountBAL.Login(UserName, Password);

            if (roleassign != null)
            {
                // HttpContext.Session.SetString("UserName", UserName);

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,UserName),
                    new Claim(ClaimTypes.Role,roleassign)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //TempData["UserID"] = HttpContext.Session.GetString("UserName");

                TempData["UserId"] = UserName;
                if (roleassign.Equals("Admin"))
                    return RedirectToAction("Index", "Admin");
                else
                    if (roleassign.Equals("User"))
                    return RedirectToActionPermanent("LoginUser", "User");
                else
                    return RedirectToAction("Login", "Account");
            }
            else
                return View();
        }


        // <summary>
        //This Action Method contains Register Page
        // </summary>

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(string AadharNumber)
        {
            UserDetailEntity userDetailEntity = await _accountBAL.GetUserDetailsByAadhar(AadharNumber);
            verifyCode = _iSMS.SendOTP(Convert.ToString(userDetailEntity.MobileNumber));
            TempData["UserDetailAccount"] = JsonConvert.SerializeObject(userDetailEntity);
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
            {
                return RedirectToAction("Credentials");
            }
            else if (count < 3)
            {
                count++;
                ViewBag.Error = "Incorrect OTP..." + (4 - count) + " chances left";
                return View();
            }
            else
                return RedirectToAction("Index");
        }


        // <summary>
        // This Action Method Checks credentials(Generated VVId)
        // </summary>
        public async Task<IActionResult> Credentials()
        {
            UserDetailEntity userDetail = null;
            if (TempData.ContainsKey("UserDetailAccount"))
                userDetail = JsonConvert.DeserializeObject<UserDetailEntity>((string)TempData["UserDetailAccount"]);

            string vvidGenerated = _generateID.GenerateId(userDetail);
            ViewBag.Id = vvidGenerated;
            ViewBag.User = userDetail.UserName;
           
            UserIdEntity userIdEntity = new UserIdEntity();
            userIdEntity.AadharNumber = userDetail.AadharNumber;
            userIdEntity.Vvid = vvidGenerated;
            int length = 10;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$%&*><!";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            userIdEntity.Pass = res.ToString();
            userIdEntity.IsCasted = false;

            string result = await _accountBAL.SaveId(userIdEntity);

            if (!result.Equals("Success"))
            {
                ViewBag.Error = result;
            }


            _iSMS.SendPassword(userDetail.MobileNumber.ToString(), userIdEntity);


            return View();
        }


        // <summary>
        // This method Shows the guidelines to be followed and describes the procedure
        // </summary>

        [HttpGet]
        public IActionResult Procedure()
        {
            return View();
        }

        // <summary>
        // This method Shows the Details about Virtual Voting System
        // </summary> 

        [HttpGet]
        public IActionResult AboutPage()
        {
            return View();
        }

        // <summary>
        // This method has contact details if user needs any help
        // </summary> 

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        // <summary>
        // This method contains Frequently Asked Questions that helps in clearing doubts for users 
        // </summary> 

        [HttpGet]
        public IActionResult FAQ()
        {
            return View();
        }
    }
}
