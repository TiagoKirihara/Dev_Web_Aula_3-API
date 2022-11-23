using fiap2022.core.Contexts;
using fiap2022.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiap2022.api.Controllers
{
    //[Route("api/times")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private DataContext _dataContext;
        
        public TimesController(DataContext context)
        {
            this._dataContext = context;
        }

        [HttpGet]
        public IList<Time> Get()
        {
            return _dataContext.Times.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Time>>Get(int id)
        {
            var time = _dataContext.Times.FirstOrDefault(x => x.Id == id);
            
            if (time == null)
                return NotFound();
            return time;
        }

        [HttpPost]
        public async Task<ActionResult<Time>> Post(Time time)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Times.Add(time);
                await _dataContext.SaveChangesAsync();
                return Created($"/api/times/{time.Id}", time);
            }
            
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Time> Put(int id, Time time)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Attach(time);
                _dataContext.SaveChanges();
                return time;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult Delete(int id)
        {
            var time = _dataContext.Times.FirstOrDefault(a => a.Id == id);
            if (time == null)
                return NotFound();
            _dataContext.Times.Remove(time);
            _dataContext.SaveChanges();

            return NoContent();
        }

    }
}
