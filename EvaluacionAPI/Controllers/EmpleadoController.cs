using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EvaluacionAPI.Context;
using EvaluacionAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace EvaluacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public EmpleadoController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> Get()
        {
            return context.Empleado.Include(x => x.Clientes).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerEmpleado")]

        public ActionResult<Empleado> Get(int id)
        {
            var empleado = context.Empleado.Include(x => x.Clientes).FirstOrDefault(x => x.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return empleado;
        }
        [HttpPost]

        public ActionResult Post([FromBody] Empleado empleado)
        {
            context.Empleado.Add(empleado);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerEmpleado", new { id = empleado.Id }, empleado);
        }
        [HttpPut("{id}")]

        public ActionResult Put([FromBody] Empleado empleado, int id)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }
            context.Entry(empleado).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]

        public ActionResult<Empleado> Delete(int id)
        {
            var empleado = context.Empleado.FirstOrDefault(x => x.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            //Podemos utilizar context.Autor.remove(autor)
            context.Entry(empleado).State = EntityState.Deleted;
            context.SaveChanges();
            return empleado;

        }
    }
}
