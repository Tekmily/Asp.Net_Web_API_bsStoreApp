using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager :IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryMenager, ILoggerService logger,IMapper mapper,IDataShaper<BookDto> shaper)
        {
            _bookService=new Lazy<IBookService>(()=> new BookManager(repositoryMenager,logger,mapper,shaper));

        }

        public IBookService BookService => _bookService.Value;
    }
}
