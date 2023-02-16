using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApi.Models;
using CrudApi.Data;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("API/Controller")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosContext _context;
    

    public ProdutosController(ProdutosContext context) 
    {           
                 _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos(){
        return Ok (await _context.Produtos.ToListAsync());
    }

    
    [HttpPost]
    public async Task<ActionResult<Produtos>> PostProdutos(Produtos produtos){

        await _context.Produtos.AddAsync(produtos);
        await _context.SaveChangesAsync();

        return Ok(produtos);
    }

    [HttpPut]
    public async Task<ActionResult> PutProdutos(Produtos produtos){
        _context.Produtos.Update(produtos);
        await _context.SaveChangesAsync();
        return Ok("Successfully updated");
    }

     [HttpDelete ("{produtosId}")]
        public async Task<ActionResult> DeleteProdutos (int produtosId) {
            Produtos produtos = await _context.Produtos.FindAsync (produtosId);
            if (produtos == null)
                return NotFound ();

            _context.Remove (produtos);
            await _context.SaveChangesAsync ();
            return Ok ();
        }
        
    }
}   
