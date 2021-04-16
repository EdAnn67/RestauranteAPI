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
    [AllowAnonymous]
    [RoutePrefix("api/Plato")]
    public class PlatoController : ApiController
    {

        [ResponseType(typeof(Platos))]
        public IEnumerable<Platos> Get()
        {
            try
            {
                string sql = @"SELECT * FROM Platos";
                using (var db = new Restaurantes())
                {
                    return db.Database.SqlQuery<Platos>(sql).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("~/api/Plato/Etiquetas/")]
        [HttpGet]
        public IHttpActionResult NumeroEtiquetas()
        {
            try
            {
                string sql = @"select P.Plato, count(*) as NumeroEtiquetas
                from PlatoEtiqueta as PE
                inner join Platos as P
                On P.IdPlato = PE.IdPlato
                Group By P.Plato;";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Clase4>(sql).ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("~/api/Plato/Ingredientes/")]
        [HttpGet]
        public IHttpActionResult Ingredientes()
        {
            try
            {
                string sql = @"select P.Plato, count(*) as NumeroIngredientes 
                from PlatoIngrediente as P_I
                inner join Platos as P
                On P_I.Plato = P.IdPlato
                Group By P.Plato;";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Clase2>(sql).ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("~/api/Plato/Ultimo/")]
        [HttpGet]
        public IHttpActionResult Ultimo()
        {
            try
            {
                string sql = @"select Top 3 *
                From Platos
                order by IdPlato DESC;";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Platos>(sql).ToList());
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
                string sql = @"Select * From Platos";
                using (var db = new Restaurantes())
                {
                    return Ok(db.Database.SqlQuery<Platos>(sql).Where(a => a.IdPlato == id).ToList());
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
                    Platos plato = JsonConvert.DeserializeObject<Platos>(json.ToString());
                    db.Platos.Add(plato);
                    db.SaveChanges();
                    return Ok(plato);
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
                    Platos plato = db.Platos.Find(id);
                    db.Platos.Remove(plato);
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
