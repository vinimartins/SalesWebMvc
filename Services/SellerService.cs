using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
    {
    public class SellerService
        {

        //readonly para a dependencia não ser alterada
        private readonly SalesWebMvcContext _context;


        public SellerService( SalesWebMvcContext context )
            {
            _context = context;
            }

        //retornar lista com todos sellers
        public List<Seller> FindAll( )
            {
            return _context.Seller.ToList( );
            }

        public void Insert( Seller obj )
            {
            _context.Add( obj );
            _context.SaveChanges( );
            }

        public Seller FindById( int id )
            {
            return _context.Seller.Include( obj => obj.Department ).FirstOrDefault( obj => obj.Id == id );

            }

        public void Remove( int id )
            {
            var obj = _context.Seller.Find( id );
            _context.Seller.Remove( obj );
            _context.SaveChanges( );
            }

        public void Update( Seller obj )
            {
            //id do obj ja tem que existir para fazer o update
            //se nao existir registro no bd algum vendedor com o Id passado
            if(!_context.Seller.Any( x => x.Id == obj.Id ))
                {
                throw new NotFoundException( "Id not Found" );
                }

            //tenta dar o update no banco 
            try
                {
                _context.Update( obj );
                _context.SaveChanges( );

                }
            //se ocorrer este erro de acesso a dados
            catch(DbUpdateConcurrencyException e)
                {

                //lança exceção a nivel de serviço  
                throw new DbConcurrencyException( e.Message );

                }
            }

        }
    }
