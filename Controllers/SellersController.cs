﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
      
        //construtor pra atribuir o valor do sellerservice
        public SellersController (SellerService sellerService , DepartmentService departmentService)
            {

            _sellerService = sellerService;
            _departmentService = departmentService;

            }

        //chamando o que está no serviço "SellerService"    
        public IActionResult Index()
        {
            //retornando lista de sellers
            var list = _sellerService.FindAll ( );
            return View(list);
        }

        public IActionResult Create( )
            {
             
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments =  departments };
            
            return View(viewModel);

            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
            {
            _sellerService.Insert( seller );
            return RedirectToAction( nameof( Index ) );

            }
    }
}