using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class ServiceManager :IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthentiactionService> _authentiactionService;
        public ServiceManager(
            IRepositoryManager repositoryMenager, 
            ILoggerService logger, 
            IMapper mapper,
            IBookLinks bookLinks,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            
            _bookService=new Lazy<IBookService>(()=> 
            new BookManager(repositoryMenager, logger, mapper,bookLinks));

            _authentiactionService =new Lazy<IAuthentiactionService>(()=> 
            new AuthenticationManager( logger, mapper,userManager,configuration));
        }

        public IBookService BookService => _bookService.Value;
        public IAuthentiactionService AuthenticationService => _authentiactionService.Value;
    }
}
