using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Ingrediente")]
    public class IngredienteController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                string sql = @"Select * from Ingredientes";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Ingredientes>(sql).ToList().Select(x => new { x.Ingrediente, x.Descripcion }).ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        



        [ResponseType(typeof(Ingredientes))]
        [HttpGet]
        [Route("~/api/Ingrediente/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Ingredientes";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Ingredientes>(sql).Where(a => a.IdIngrediente == id).ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return NotFound();
            }
        }
        [Route("api/Ingrediente/Platos/{id}")]
        [HttpGet]
        public IHttpActionResult Platos(int id)
        {
            try
            {
                string sql = @"select P.Plato from Platos P
                inner join PlatoIngrediente P_I
                On P.IdPlato = P_I.Plato
                Where P_I.Ingrediente = @id";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Clase2>(sql, new SqlParameter("@id", id)).ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return NotFound();
            }
        }

        private IHttpActionResult Post([FromBody] JObject json)
        {
            try
            {
                using (var db = new Restaurantes())
                {
                    Ingredientes ingrediente = JsonConvert.DeserializeObject<Ingredientes>(json.ToString());
                    db.Ingredientes.Add(ingrediente);
                    db.SaveChanges();
                    return Ok(ingrediente);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Conflict, ex.Message);
            }
        }

        private IHttpActionResult Delete(int id)
        {
            try
            {
                using (var db = new Restaurantes())
                {
                    Ingredientes ingrediente = db.Ingredientes.Find(id);
                    db.Ingredientes.Remove(ingrediente);
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Elemento eliminado");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Conflict, ex.Message);
            }
        }
    }
}
