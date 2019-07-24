using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
    {
    public class SellerService
        {

        //readonly para a dependencia não ser alterada
        private readonly SalesWebMvcContext _context;


        public SellerService(SalesWebMvcContext context )
            {
            _context = context;
            }

        //retornar lista com todos sellers
        public List<Seller> FindAll ( )
            {
            return _context.Seller.ToList ( );
            } 

        public void Insert(Seller obj )
            {
            _context.Add( obj );
            _context.SaveChanges( );
            }

        }
    }
