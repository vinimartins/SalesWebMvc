using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<Seller>> FindAllAsync( )
            {
            return await _context.Seller.ToListAsync( );
            }

        public async Task InsertAsync( Seller obj )
            {
            _context.Add( obj );
            await _context.SaveChangesAsync( );
            }

        public async Task<Seller> FindByIdAsync( int id )
            {
            return await _context.Seller.Include( obj => obj.Department ).FirstOrDefaultAsync( obj => obj.Id == id );

            }

        public async Task RemoveAsync( int id )
            {
            try
                {
                var obj = await _context.Seller.FindAsync( id );
                _context.Seller.Remove( obj );
                await _context.SaveChangesAsync( );

                }
            catch(DbUpdateException)
                {

                throw new IntegrityException("Can't delete seller because he/she has sales :D" );
                }
            }

        public async Task UpdateAsync( Seller obj )
            {

            bool hasAny = await _context.Seller.AnyAsync( x => x.Id == obj.Id );
            //id do obj ja tem que existir para fazer o update
            //se nao existir registro no bd algum vendedor com o Id passado
            if(!hasAny)
                {
                throw new NotFoundException( "Id not Found" );
                }

            //tenta dar o update no banco 
            try
                {
                _context.Update( obj );
                await _context.SaveChangesAsync( );

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
