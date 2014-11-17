using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Objects;

namespace ContactosRESTful.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Contacto> Get()
        {
            using (ContactosDB db = new ContactosDB()) {
                return db.Contacto.ToList<Contacto>();
            }
            
        }

        // GET api/values/5
        public Contacto Get(int id)
        {
            using (ContactosDB db = new ContactosDB())
            {
                return db.Contacto.SingleOrDefault<Contacto>(b => b.Id == id);  
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Contacto nuevo)//int id, string nombre, string correo, string rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ContactosDB entities = new ContactosDB())
                    {
                        /*Contacto nuevo = new Contacto();
                        nuevo.Nombre = nombre;
                        nuevo.Correo = correo;
                        nuevo.Rol = rol;*/
                        /*Contacto temporal = new Contacto();
                        temporal.Nombre = "data_pst_";
                        temporal.Correo = "ALGO";
                        temporal.Rol = "ALGO";*/

                        entities.Contacto.Add(nuevo);

                        /*Contacto encontrado = entities.Contacto.SingleOrDefault<Contacto>(b => b.Nombre == "data_pst_");
                        encontrado.Nombre = nuevo.Nombre;
                        encontrado.Correo = nuevo.Correo;
                        encontrado.Rol = nuevo.Rol;*/
                        

                        //entities.Contacto.SqlQuery("INSERT INTO [dbo].[Contacto] ([Nombre], [Correo], [Rol]) VALUES (N'"+nuevo.Nombre+"   ', N'"+nuevo.Correo+"   ', N'"+nuevo.Rol+"  ')");
                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.GetType());
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Contacto value)
        {
            try
            {
                using (ContactosDB entities = new ContactosDB())
                {
                    Contacto Encontrado = entities.Contacto.SingleOrDefault<Contacto>(b => b.Id == id);
                    Encontrado.Id = value.Id;
                    Encontrado.Nombre = value.Nombre;
                    Encontrado.Correo = value.Correo;
                    Encontrado.Rol = value.Rol;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ContactosDB entities = new ContactosDB())
                {
                    Contacto contactoEncontrado = entities.Contacto.SingleOrDefault<Contacto>(b => b.Id == id);
                    entities.Contacto.Remove(contactoEncontrado);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}