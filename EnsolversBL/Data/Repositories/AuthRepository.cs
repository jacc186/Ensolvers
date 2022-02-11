using EnsolversBL.Data.Interface;
using EnsolversBL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EnsolversContext context;

        public AuthRepository(EnsolversContext context)
        {
            this.context = context;
        }

        public async Task<User> Login(string correo, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Correo == correo);
            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user; 
        }
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordhash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePassword(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string correo)
        {
            if (await context.Users.AnyAsync(u => u.Correo == correo))
                return true;

            return false;
        }
    }
}
