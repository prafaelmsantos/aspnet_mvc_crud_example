using System.Collections.Generic;
using System.Linq;

namespace aspnet_mvc_crud_example.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }



        private static List<UserModel> usersList = new List<UserModel>();
        public static IQueryable<UserModel> UsersList
        {
            get
            {
                return usersList.AsQueryable();
            }
        }


        static UserModel()
        {
            usersList.Add(
                new UserModel { Id = 1, Name = "Pedro", Email = "pedro@email.com" });
            usersList.Add(
                new UserModel { Id = 2, Name = "Rafael", Email = "rafael@email.com" });
            usersList.Add(
                new UserModel { Id = 3, Name = "João", Email = "joao@email.com" });
            usersList.Add(
                new UserModel { Id = 4, Name = "Maria", Email = "maria@email.com" });
                
        }

        public static void Save(UserModel user)
        {
            var userExist = usersList.Find(u => u.Id == user.Id);
            if (userExist != null)
            {
                userExist.Name = user.Name;
                userExist.Email = user.Email;
            }
            else
            {

                int biggestId = UsersList.Any() ? UsersList.Max(u => u.Id) : 0;
                user.Id = biggestId + 1;
                usersList.Add(user);
            }
        }

        public static void Delete(int userId)
        {
            var userExist = usersList.Find(u => u.Id == userId);
            if (userExist != null)
            {
                usersList.Remove(userExist);
            }
        }
    }
}

