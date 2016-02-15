using DevStation.Domain;
using DevStation.Infrastructure;
using DevStation.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStation.Services
{
    public class UserService
    {
        private UserRepository _userRepo;
        private JobRepository _jobRepo;
        private ApplicationUserManager _userManagerRepo;

        public UserService(UserRepository userRepo, JobRepository jobRepo, ApplicationUserManager userManagerRepo)
        {
            _userRepo = userRepo;
            _jobRepo = jobRepo;
            _userManagerRepo = userManagerRepo;
        }

        public void UpdateDevProfile(string firstName, string lastName, string phoneNumber, string email, string skillSet, string username)
        {
            var updatedUser = new ApplicationUser
            {
                UserName = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                SkillSet = skillSet,
            };

            _userRepo.UpdateUser(updatedUser);
            
        }

        public DeveloperDTO UserByUserName(string userName)
        {
            var userToMap = _userRepo.UserByUserName(userName);
            DeveloperDTO userToReturn;

            if (userToMap.CurrentJob != null && userToMap.CompletedJobs == null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    CurrentJob = (new JobDTO()
                    {
                        Id = userToMap.CurrentJob.Id,
                        Title = userToMap.CurrentJob.Title,
                        Description = userToMap.CurrentJob.Description
                    })
                };
            }
            else if (userToMap.CurrentJob == null && userToMap.CompletedJobs != null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    SkillSet = userToMap.SkillSet,
                    CompletedJobs = (from j in userToMap.CompletedJobs
                                     select new JobDTO()
                                     {
                                         Id = j.Id,
                                         Title = j.Title,
                                         Description = j.Description
                                     }).ToList()
                };
            }
            else if (userToMap.CurrentJob == null && userToMap.CompletedJobs == null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    SkillSet = userToMap.SkillSet
                };
            }
            return userToReturn = new DeveloperDTO()
            {
                FirstName = userToMap.FirstName,
                LastName = userToMap.LastName,
                Email = userToMap.Email,
                PhoneNumber = userToMap.PhoneNumber,
                Img = userToMap.Img,
                SkillSet = userToMap.SkillSet,
                CurrentJob = (new JobDTO()
                {
                    Id = userToMap.CurrentJob.Id,
                    Title = userToMap.CurrentJob.Title,
                    Description = userToMap.CurrentJob.Description
                }),
                CompletedJobs = (from j in userToMap.CompletedJobs
                                 select new JobDTO()
                                 {
                                     Id = j.Id,
                                     Title = j.Title,
                                     Description = j.Description
                                 }).ToList()
            };
        }
    }
}