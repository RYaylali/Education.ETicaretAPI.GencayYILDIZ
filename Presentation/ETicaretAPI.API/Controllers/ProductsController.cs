
using ETicaretAPI.Application.Repository;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProducReadRepository _producReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;


        public ProductsController(IProducReadRepository producReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepositrory customerWriteRepositrory, IOrderReadRepository orderReadRepository)
        {
            _producReadRepository = producReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        //[HttpGet]
        //public async Task Get()
        //{
        //    //_productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new(){ Id=Guid.NewGuid(),Name ="Product 1", Price=100,CreatedDate=DateTime.UtcNow ,Stock=18},
        //    //    new(){ Id=Guid.NewGuid(),Name ="Product 2", Price=200,CreatedDate=DateTime.UtcNow ,Stock=14},
        //    //    new(){ Id=Guid.NewGuid(),Name ="Product 3", Price=300,CreatedDate=DateTime.UtcNow ,Stock=200},
        //    //});
        //    //await _productWriteRepository.SaveAsync();

        //    Product p = await _producReadRepository.GetByIdAsync("1b6d5a51-5cc3-4dfd-83fa-3ba25a090b3f",false);//bu şekilde traking false edilerek görsel işlemler veri tabanına işlenmeden yapılabilir
        //    p.Name = "Ahmet";
        //    await _productWriteRepository.SaveAsync();

        //    //2 adet hata aldı;
        //    //1. hatada  projemiz ilk başta addscope olarak oluşturduğu için her istekde tek nesne oluşuyordu.faakat biz burda 2 adet repo kullandığımız için scope da hata verdi bu gidermek için projemizi singletona çevirdik ve her istekte farklı nesne oluşturmasını sağladık
        //    //2.hata da  createddate datetime.now desteklemedi ve datetime.utcnow çevirerek atlattık
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( _producReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _producReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _producReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();

        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _producReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

    }
}
