﻿using AutoMapper;
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
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthenticationService _authentiactionService;

        public ServiceManager(IBookService bookService, ICategoryService categoryService, IAuthenticationService authentiactionService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authentiactionService = authentiactionService;
        }

        public IBookService BookService => _bookService;
        public IAuthenticationService AuthenticationService => _authentiactionService;

        public ICategoryService CategoryService => _categoryService;

    }
}
