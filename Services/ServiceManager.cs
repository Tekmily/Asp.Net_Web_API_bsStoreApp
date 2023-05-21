using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class ServiceManager :IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryMenager, ILoggerService logger, IMapper mapper,IBookLinks bookLinks)
        {
            _bookService=new Lazy<IBookService>(()=> new BookManager(repositoryMenager, logger, mapper,bookLinks));

        }

        public IBookService BookService => _bookService.Value;
    }
}
