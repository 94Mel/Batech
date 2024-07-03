using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Batech.Models;

namespace Batech.Controllers
{
    [Authorize]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

       [Authorize(Roles = "SuperAdmin")]//SuperAdmin rolüne sahip olan user rolemanager a girebilir.
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [Authorize(Policy = "rolecreation")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        [Authorize(Policy = "rolecreation")]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                IdentityRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
                result = await _roleManager.CreateAsync(new IdentityRole { Name = model.Name });

            if (result.Succeeded)
            {
                //Başarılı...
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(string roleId)
        {
            // Retrieve the role by its ID
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                // Handle error if role is not found
                return NotFound();
            }

            var viewModel = new UpdateRoleViewModel
            {
                RoleId = role.Id,
                NewRoleName = role.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            // Retrieve the role by its ID
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                // Handle error if role is not found
                return NotFound();
            }

            // Update the role name
            role.Name = model.NewRoleName;

            // Update the role using RoleManager
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                // Role updated successfully
                return RedirectToAction("Index", "Role"); // Redirect to a suitable action
            }
            else
            {
                // Handle errors if the update was not successful
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model); // Return to the view with errors
            }
        }


    }
}