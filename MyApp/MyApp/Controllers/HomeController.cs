using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessModel;
using DataLayer;
using Microsoft.AspNetCore.Authentication;
using MyApp.ModelView;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MyApp.Controllers
{


    public class HomeController : Controller
    {
       
   
        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        [ActionName("Add")]
        public ActionResult Add_Cus(Customer customer)
        {
            if (ModelState.IsValid)
            {
                new CustomerDAO().AddCustomer(customer);
                return RedirectToAction("ViewCustomer");
            }

            return View();
        }
        [HttpGet]
  
        public ActionResult Edit(int id)
        {
            var editValue = new CustomerDAO().GetAllCustomer().Where(x => x.CustomerID == id).FirstOrDefault();

            return View(editValue);
        }

        [HttpPost]
  
        [ActionName("Edit")]
        public ActionResult Edit_Cus(Customer customer)
        {
            new CustomerDAO().Edit(customer);
            return RedirectToAction("ViewCustomer");
        }

        [Route("ViewCustomer")]
        public IActionResult ViewCustomer()
        {
            List<Customer> objCustomer = new CustomerDAO().GetAllCustomer().ToList();
            return View(objCustomer);
        }

        
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {

            LoginModelView objLoginModel = new LoginModelView();
            objLoginModel.ReturnUrl = "/";
            return View(objLoginModel);

        }

        [HttpPost]
        [Route("login")]
        public async Task <IActionResult> Login(LoginModelView objLoginModelView)
        {
          
            if(ModelState.IsValid)
            {
                var user = new CustomerDAO().GetAllCustomer().Where(x => x.UserName == objLoginModelView.UserName && x.Password==objLoginModelView.Password ).FirstOrDefault();
                if(user==null)
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.CustomerID)),
                        new Claim(ClaimTypes.Name,user.UserName),
                     

                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModelView.RememberLogin
                    });

                    return RedirectToAction("index","image");
                }

                   
            }
            return View();
        }
      
        
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
