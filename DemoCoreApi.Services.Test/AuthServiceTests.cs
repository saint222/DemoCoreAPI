using AutoMapper;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.BusinessLogic.Implementation;
using DemoCoreAPI.BusinessLogic.Mapping;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.Data;
using DemoCoreAPI.Data.SQLServer;
using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;

namespace DemoCoreApi.Services.Test
{
    public class AuthServiceTests
    {
        private IMapper _mapper;
        private IRepository<UserDb> _repo;

        [SetUp]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = new Mapper(mapperConfig);
            _repo = new Mock<IRepository<UserDb>>().Object;
        }

        [Test]
        public void Test_Register_Success()
        {
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };
            var expResult = new RegisterAPIModel()
            {
                Message = "User has been created",
                Success = true
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                var actResult = service.Register(regModel);
                Assert.IsTrue(actResult.Message == expResult.Message);
                Assert.IsTrue(actResult.Success == expResult.Success);
            }
        }

        [Test]
        public void Test_Register_Fail()
        {
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };
            var unexpResult = new RegisterAPIModel()
            {
                Message = "User has not been created",
                Success = false
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                var actResult = service.Register(regModel);
                Assert.IsFalse(actResult.Message == unexpResult.Message);
                Assert.IsFalse(actResult.Success == unexpResult.Success);
            }
        }

        [Test]
        public void Test_Register_ArgumentNullException()
        {
            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentNullException>(() => service.Register(null));
            }
        }

        [Test]
        public void Test_Register_ArgumentException_Email()
        {
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "",
                PasswordConfirmation = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentException>(() => service.Register(regModel));
            }
        }

        [Test]
        public void Test_Register_PasswordMismatchException()
        {
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "AnotherPassword",
                PasswordConfirmation = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<PasswordMismatchException>(() => service.Register(regModel));
            }
        }

        [Test]
        public void Test_Register_ArgumentException_Password()
        {
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentException>(() => service.Register(regModel));
            }
        }

        [Test]
        public void Test_Register_EmailDuplicateException_Password()
        {
            var seed = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };
            var regModel = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                context.Database.EnsureDeleted(); // we need it here to run all the tests simultaneously
                var repo = new SqlServRepository<UserDb>(context);
                var service = new AuthService(repo, _mapper);
                service.Register(seed);
                Assert.Throws<EmailDuplicateException>(() => service.Register(regModel));
            }
        }

        [Test]
        public void Test_Login_ArgumentNullException()
        {
            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentNullException>(() => service.Login(null));
            }
        }

        [Test]
        public void Test_Login_ArgumentException_Email()
        {
            var logModel = new LoginBindingModel()
            {
                Email = "",
                Password = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentException>(() => service.Login(logModel));
            }
        }

        [Test]
        public void Test_Login_ArgumentException_Password()
        {
            var logModel = new LoginBindingModel()
            {
                Email = "sam@gmail.com",
                Password = ""
            };

            using (var context = GetContext())
            {
                var service = new AuthService(_repo, _mapper);
                Assert.Throws<ArgumentException>(() => service.Login(logModel));
            }
        }

        [Test]
        public void Test_Login_Fail()
        {
            var logModel = new LoginBindingModel()
            {
                Email = "sam@gmail.com",
                Password = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var repo = new SqlServRepository<UserDb>(context);
                var service = new AuthService(repo, _mapper);
                var response = service.Login(logModel);
                Assert.IsNull(response);                            // 404 NotFound
            }
        }

        [Test]
        public void Test_Login_Success()
        {
            var seed = new RegisterBindingModel()
            {
                FirstName = "Sam",
                LastName = "Sammuel",
                Age = 23,
                Email = "sam@gmail.com",
                Password = "Welcome20!9",
                PasswordConfirmation = "Welcome20!9"
            };
            var logModel = new LoginBindingModel()
            {
                Email = "sam@gmail.com",
                Password = "Welcome20!9"
            };

            using (var context = GetContext())
            {
                var repo = new SqlServRepository<UserDb>(context);
                var service = new AuthService(repo, _mapper);
                service.Register(seed);
                var response = service.Login(logModel);
                Assert.IsNotNull(response);
            }
        }

        private ApiContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "TempDemoCoreApiDb")
                .Options;
            var context = new ApiContext(options);

            return context;
        }
    }
}