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

        public IList<DeveloperDTO> AllDevList()
        {
            return (from d in _userRepo.DevList()
                    select new DeveloperDTO()
                    {
                        Img = d.Img,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        PhoneNumber = d.PhoneNumber,
                        Email = d.Email,
                        SkillSet = d.SkillSet
                    }).ToList();

        }

        public IList<DeveloperDTO> SearchDevs(string searchTerm)
        {
            return (from d in _userRepo.SearchDevs(searchTerm)
                    select new DeveloperDTO()
                    {
                        Img = d.Img,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        PhoneNumber = d.PhoneNumber,
                        Email = d.Email,
                        SkillSet = d.SkillSet
                    }).ToList();
        }

        public void DevAcceptJob(int id, string username) {
            var currentJob = _jobRepo.JobById(id);            
            var currentUser = _userRepo.UserByUserName(username);
            currentJob.Active = false;
            currentUser.CurrentJob = currentJob;
            _userRepo.SaveChanges();

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

        public EmployerDTO EmployerByUserName(string userName)
        {
            var userToMap = _userRepo.EmployerByUserName(userName);
            EmployerDTO userToReturn;
            if (userToMap.JobRequests != null)
            {
                return userToReturn = new EmployerDTO()
                {
                    UserName = userToMap.UserName,
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    Company = userToMap.Company,
                    Position = userToMap.Position,
                    IsEmployer = true,
                    JobRequests = (from j in userToMap.JobRequests
                                   where j.Active
                                   select new JobDTO()
                                   {
                                       Id = j.Id,
                                       Title = j.Title,
                                       Description = j.Description
                                   }).ToList()
                };
            }
            return userToReturn = new EmployerDTO()
            {
                UserName = userToMap.UserName,
                FirstName = userToMap.FirstName,
                LastName = userToMap.LastName,
                Email = userToMap.Email,
                PhoneNumber = userToMap.PhoneNumber,
                Img = userToMap.Img,
                Company = userToMap.Company,
                Position = userToMap.Position,
                IsEmployer = true
            };
        }

        public DeveloperDTO UserByUserName(string userName)
        {
            var userToMap = _userRepo.UserByUserName(userName);
            DeveloperDTO userToReturn;

            if (userToMap.CurrentJob != null && userToMap.CompletedJobs == null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    UserName = userToMap.UserName,
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Position = userToMap.Position,
                    SkillSet = userToMap.SkillSet,
                    Img = userToMap.Img,
                    IsEmployer = false,
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
                    UserName = userToMap.UserName,
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    Position = userToMap.Position,
                    SkillSet = userToMap.SkillSet,
                    IsEmployer = false,
                    CompletedJobs = (from j in userToMap.CompletedJobs
                                     select new JobDTO()
                                     {
                                         Id = j.Id,
                                         Title = j.Title,
                                         Description = j.Description.Substring(0, 25)
                                     }).ToList()
                };
            }
            else if (userToMap.CurrentJob != null && userToMap.CompletedJobs != null)
            {
                return userToReturn = new DeveloperDTO()
                {
                    UserName = userToMap.UserName,
                    FirstName = userToMap.FirstName,
                    LastName = userToMap.LastName,
                    Email = userToMap.Email,
                    PhoneNumber = userToMap.PhoneNumber,
                    Img = userToMap.Img,
                    Position = userToMap.Position,
                    SkillSet = userToMap.SkillSet,
                    IsEmployer = false,
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
                                         Description = j.Description.Substring(0, 15)
                                     }).ToList()
                };
            }
            return userToReturn = new DeveloperDTO()
            {
                UserName = userToMap.UserName,
                FirstName = userToMap.FirstName,
                LastName = userToMap.LastName,
                Email = userToMap.Email,
                PhoneNumber = userToMap.PhoneNumber,
                Position = userToMap.Position,
                Img = userToMap.Img,
                SkillSet = userToMap.SkillSet,
                IsEmployer = false
            };
        }
    }
}