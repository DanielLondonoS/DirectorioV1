using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.DataAccess.Contracts.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        //private readonly DirectorioV1DBContext _directorioV1DBContext;
        //private readonly UserManager<UsuariosEntity> userManager;
        //private readonly SignInManager<UsuariosEntity> signInManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        //public UsuariosRepository(
        //    DirectorioV1DBContext directorioV1DBContext,
        //    UserManager<UsuariosEntity> userManager,
        //    SignInManager<UsuariosEntity> signInManager,
        //    RoleManager<IdentityRole> roleManager)
        //{
        //    this._directorioV1DBContext = directorioV1DBContext;
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //    this.roleManager = roleManager;
        //}
        //public async Task<IdentityResult> AddUserAsync(UsuariosEntity user, string password)
        //{
        //    return await this.userManager.CreateAsync(user, password);
        //}

        //public async Task AddUserToRoleAsync(UsuariosEntity user, string roleName)
        //{
        //    await this.userManager.AddToRoleAsync(user, roleName);
        //}

        //public async Task<IdentityResult> ChangePasswordAsync(UsuariosEntity user, string oldPassword, string newPassword)
        //{
        //    return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        //}

        //public async Task CheckRoleAsync(string roleName)
        //{
        //    var roleExists = await this.roleManager.RoleExistsAsync(roleName);
        //    if (!roleExists)
        //    {
        //        await this.roleManager.CreateAsync(new IdentityRole
        //        {
        //            Name = roleName
        //        });
        //    }
        //}

        //public async Task<UsuariosEntity> GetUserByEmailAsync(string email)
        //{
        //    return await this.userManager.FindByEmailAsync(email);
        //}

        //public async Task<bool> IsUserInRoleAsync(UsuariosEntity user, string roleName)
        //{
        //    return await this.userManager.IsInRoleAsync(user, roleName);
        //}

        //public async Task<SignInResult> LoginAsync(LoginViewModel model)
        //{
        //    return await this.signInManager.PasswordSignInAsync(
        //        model.Username,
        //        model.Password,
        //        model.RememberMe,
        //        false);
        //}

        //public async Task LogoutAsync()
        //{
        //    await this.signInManager.SignOutAsync();
        //}

        //public async Task<IdentityResult> UpdateUserAsync(UsuariosEntity user)
        //{
        //    return await this.userManager.UpdateAsync(user);
        //}

        //public async Task<SignInResult> ValidatePasswordAsync(UsuariosEntity user, string password)
        //{
        //    return await this.signInManager.CheckPasswordSignInAsync(
        //        user,
        //        password,
        //        false);
        //}

        //public async Task<IdentityResult> ConfirmEmailAsync(UsuariosEntity user, string token)
        //{
        //    return await this.userManager.ConfirmEmailAsync(user, token);
        //}

        //public async Task<string> GenerateEmailConfirmationTokenAsync(UsuariosEntity user)
        //{
        //    return await this.userManager.GenerateEmailConfirmationTokenAsync(user);
        //}

        //public async Task<UsuariosEntity> GetUserByIdAsync(string userId)
        //{
        //    return await this.userManager.FindByIdAsync(userId);
        //}

        //public async Task<string> GeneratePasswordResetTokenAsync(UsuariosEntity user)
        //{
        //    return await this.userManager.GeneratePasswordResetTokenAsync(user);
        //}

        //public async Task<IdentityResult> ResetPasswordAsync(UsuariosEntity user, string token, string password)
        //{
        //    return await this.userManager.ResetPasswordAsync(user, token, password);
        //}

        //public async Task<List<UsuariosEntity>> GetAllUsersAsync()
        //{
        //    return await this.userManager.Users
        //        .OrderBy(u => u.Nombre)
        //        .ThenBy(u => u.Apellido)
        //        .ToListAsync();
        //}

        //public async Task RemoveUserFromRoleAsync(UsuariosEntity user, string roleName)
        //{
        //    await this.userManager.RemoveFromRoleAsync(user, roleName);
        //}

        //public async Task DeleteUserAsync(UsuariosEntity user)
        //{
        //    await this.userManager.DeleteAsync(user);
        //}
    }
}
