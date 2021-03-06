﻿namespace PetStore.Services.implementation
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Register(string name, string email)
        {
            var user = new User()
            {
                Name = name,
                Email = email
            };

            data.Users.Add(user);
            data.SaveChanges(); 
        }
        public bool Exists(int userId)
        {
            return data.Users.Any(x => x.Id == userId);
        }
    }
}
