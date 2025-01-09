using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EvaluacionAPI.Data;
using EvaluacionAPI.Models;

namespace EvaluacionAPI.Controllers
{
    public class ProductoController : ApiController
    {
        //Get api controller
        public List<producto> Get()
        {
            return ProductoData.Listar();
        }

        //Post api controller
        public bool Post([FromBody] producto oProducto)
        {
            Console.WriteLine(oProducto);
            return ProductoData.Registrar(oProducto);
        }

        //Put api controller
        public bool Put([FromBody] producto oProducto)
        {
            return ProductoData.Modificar(oProducto);
        }

        //Delete api controller
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }

    }
}