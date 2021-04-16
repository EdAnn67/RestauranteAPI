using System;
using System.Collections.Generic;
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
    public class CategoriaController : ApiController
    {

        [ResponseType(typeof(Ingredientes))]
        public IEnumerable<Categoria> Get()
        {
            try
            {
                string sql = @"SELECT * FROM Categoria";
                using (var db = new Restaurantes())
                {
                    return db.Database.SqlQuery<Categoria>(sql).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("api/Categoria/NPlatos")]
        [HttpGet]
        public IHttpActionResult NPlatos()
        {
            try
            {
                string sql = @"select C.Categoria1, count(*) as NumeroPlatos 
                from Categoria as C 
                inner join Platos as P
                On C.IdCategoria = P.IdPlato
                Group By C.Categoria1;";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Clase1>(sql).ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Categoria";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Categoria>(sql).Where(a => a.IdCategoria == id).ToList());
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
                    Categoria cat = JsonConvert.DeserializeObject<Categoria>(json.ToString());
                    db.Categoria.Add(cat);
                    db.SaveChanges();
                    return Ok(cat);
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
                    Categoria cat = db.Categoria.Find(id);
                    db.Categoria.Remove(cat);
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
