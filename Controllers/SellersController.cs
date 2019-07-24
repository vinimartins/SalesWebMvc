﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerservice;

        //construtor pra atribuir o valor do sellerservice
        public SellersController (SellerService sellerservice )
            {
            _sellerservice = sellerservice;
            }

        //chamando o que está no serviço "SellerService"    
        public IActionResult Index()
        {
            //retornando lista de sellers
            var list = _sellerservice.FindAll ( );
            return View(list);
        }

        public IActionResult Create( )
            {
            return View( );

            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
            {
            _sellerservice.Insert( seller );
            return RedirectToAction( nameof( Index ) );

            }
    }
}