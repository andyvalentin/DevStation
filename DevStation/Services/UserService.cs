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

        public UserService(UserRepository userRepo, JobRepository jobRepo)
        {
            _userRepo = userRepo;
            _jobRepo = jobRepo;
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
                    Position = userToMap.Position,
                    SkillSet = userToMap.SkillSet,
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
                    Position = userToMap.Position,
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
            else if (userToMap.CurrentJob != null && userToMap.CompletedJobs != null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    Position = userToMap.Position,
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
            return userToReturn = new DeveloperDTO()
            {
                FirstName = userToMap.FirstName,
                LastName = userToMap.LastName,
                Email = userToMap.Email,
                PhoneNumber = userToMap.PhoneNumber,
                Position = userToMap.Position,
                Img = userToMap.Img,
                SkillSet = userToMap.SkillSet
            };
        }
    }
}