﻿using Notes.Server.Core.Interfaces;

namespace Notes.Server.Core.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(providedPassword, hashedPassword);
        }
    }
}
