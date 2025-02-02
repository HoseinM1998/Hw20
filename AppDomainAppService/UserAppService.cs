using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.User;
using AppDomainCore.Dto;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using AppInfraDbInMemory;
using Microsoft.AspNetCore.Identity;

namespace AppDomainAppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserAppService(IUserService userService , UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //public async Task<IdentityResult> Register(User user,CancellationToken cancellationToken)
        //{
        //    //try
        //    //{
        //    //    await _userService.Add(user, cancellationToken);
        //    //    return user;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new Exception("Error Add User");
        //    //}
        //    //user.RoleId = 1;

        //    var result = await _userManager.CreateAsync(user,"12345@");

        //    if (result.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(user, "Admin");
        //    }
        //    return result;

        //}

        //public async Task<IdentityResult> Login(string username, string password, CancellationToken cancellationToken)
        //{
        //    //var user =await _userService.GetByUserName(username, cancellationToken);
        //    //if (user == null)
        //    //{
        //    //    return false;
        //    //}

        //    //if (user.Password != password)
        //    //{
        //    //    return false;
        //    //}
        //    //InMemory.CurentUser = user;
        //    //return true;


        //    var result =
        //        await _singInManager.PasswordSignInAsync(username, password, isPersistent: true,
        //            lockoutOnFailure: false);
        //    return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        //}



        public async Task<IdentityResult> Register(UserDto model, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = model.UserName,
                Mobile = model.Mobile,
                RoleId = 1
            };

            var result = await _userManager.CreateAsync(user, "12345");

            if (result.Succeeded)
            {
                bool roleExists = await _roleManager.RoleExistsAsync("Admin");
                if (roleExists)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    throw new Exception("Role 'Admin' does not exist in the database.");
                }
            }

            return result;
        }




        public async Task<IdentityResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }



        public void Logout()
        {
            InMemory.CurentUser=null;
            
        }
    }
}
