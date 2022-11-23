using fiap2022.core.Contexts;
using fiap2022.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiap2022.Controllers
{
    public class TimeController : Controller
    {
        private DataContext _dataContext;

        public TimeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var times = await _dataContext.Times.ToListAsync();
            return View(times);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Time model)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.AddAsync(model);
                await _dataContext.SaveChangesAsync();
                //TODO:Redirect

                return RedirectToAction("Index");
                
            }


            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ////select top 1, se ele nao existe throw de uma exception
            //var time = await  _dataContext.Times.First

            ////select top 2, se ele encontra 1 retorna, se acha 2 da thow se nao acha nenhum da throw
            //var time = await  _dataContext.Times.`

            ////select top 2, se encontra mais de 1 da erro, se nao encontra nenhum retorna NULL
            //var time = await  _dataContext.Times.SingleOrDefault
            ////select top 1, senao encontra retorna NULL
            //var time = await  _dataContext.Times.FirstOrDefault

            var time = await _dataContext.Times.FirstOrDefaultAsync(a => a.Id == id);
            //if(time == null)
            //    //return 404

            return View(time);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Time time)
        {
            if (ModelState.IsValid)
            {
                //var objet =_dataContext.Times
                 _dataContext.Update(time);
                await _dataContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(time);

        }


        [HttpPost]
        //[HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var time =await _dataContext.Times.FirstOrDefaultAsync(a => a.Id == id);
            _dataContext.Remove(time);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [HttpPost]
        public IActionResult VerificaNome(string nome)
        {
            //acesso ao db
            if (nome != "teste")
            {
                return Json($"o nome {nome} 'e invalido");
            }

            return Json(true);
        }
    }
}
