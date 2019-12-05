using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truextend.Models;

namespace Truextend.Service
{
    public class UserService : IUserService
    {
        List<User> users;

        public UserService()
        {
            users = new List<User>() {
                new User(){
                    id=1,
                    avatar_url= "https://avatars1.githubusercontent.com/u/9919?s=200&v=4",
                    github_url= "https://github.com/github",
                    name= "GitHub Repositories",
                    nickName= "GitHub"
                },
                new User(){
                    id=2,
                    github_url= "https://avatars1.githubusercontent.com/u/30177?s=200&v=4",
                    name= "Android Open Source",
                    nickName= "Android"
                },
                new User(){
                    id=3,
                    avatar_url= "https://avatars3.githubusercontent.com/u/18133?s=200&v=4",
                    github_url= "https://github.com/git",
                    name= "GIT SCM",
                    nickName= "git"
                },
                new User(){
                    id=4,
                    avatar_url= "https://avatars0.githubusercontent.com/u/1630826?s=200&v=4",
                    github_url= "https://github.com/gruntjs",
                    name= "GRUNT",
                    nickName= "GRUNT.js"
                },
                new User(){
                    id=5,
                    avatar_url= "https://avatars1.githubusercontent.com/u/1562726?s=200&v=4",
                    github_url= "https://github.com/d3",
                    name= "Data Driven Documents",
                    nickName= "D3.js"
                }
            };
        }

        public User creatUser(User newUser)
        {
            var lastUser = users.OrderByDescending(a => a.id).FirstOrDefault();
            var nextId = lastUser == null ? 1 : lastUser.id + 1;
            newUser.id = nextId;
            if (newUser.avatar_url == "")
            {
                newUser.avatar_url = "https://d1bvpoagx8hqbg.cloudfront.net/259/eb0a9acaa2c314784949cc8772ca01b3.jpg";
            }
            users.Add(newUser);
            return newUser;
        }

        public bool deleteUser(int id)
        {
            var userToDelete = users.Single(u => u.id == id);
            return users.Remove(userToDelete);
        }

        public User editUser(User editUser)
        {
            var userToUpdate = users.Single(u => u.id == editUser.id);
            userToUpdate.name = editUser.name;
            userToUpdate.nickName = editUser.nickName;
            userToUpdate.github_url = editUser.github_url;
            userToUpdate.avatar_url = editUser.avatar_url;
            if (userToUpdate.avatar_url == "" || userToUpdate.avatar_url == null) {
                userToUpdate.avatar_url = "https://d1bvpoagx8hqbg.cloudfront.net/259/eb0a9acaa2c314784949cc8772ca01b3.jpg";
            }
            return userToUpdate;
        }

        public User getUser(int id)
        {
            var user = users.SingleOrDefault(u => u.id == id);
            return user;
        }

        public List<User> getUsers()
        {
            var result = users;
            if (users.Exists(u => u.avatar_url == null)) {
                users.Single(u=>u.avatar_url == null).avatar_url= "https://d1bvpoagx8hqbg.cloudfront.net/259/eb0a9acaa2c314784949cc8772ca01b3.jpg";
            }
            return result.ToList();
        }
    }
}
