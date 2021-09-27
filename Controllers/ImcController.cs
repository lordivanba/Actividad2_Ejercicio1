using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad2_imc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImcController : Controller
    {
        [HttpGet("{altura}/{peso}")]
        public string Get(double Altura, double Peso) // Altura en metros y peso en kilogramos
        {
            Imc oImc = new Imc();
            oImc.altura = Altura;
            oImc.peso = Peso;
            oImc.valorImc = (Peso / (Altura*Altura));


            if (oImc.valorImc < 18.5)
            {
                oImc.Clasificacion = "Peso inferior al normal";
            }
            else if (oImc.valorImc > 18.5 && oImc.valorImc < 24.9)
            {
                oImc.Clasificacion = "Normal";
            }
            else if (oImc.valorImc > 25 && oImc.valorImc < 29.9)
            {
                oImc.Clasificacion = "Peso superior al normal";
            }
            else
            {
                oImc.Clasificacion = "Obesidad";
            }
            
            return $"Su indice de masa corporal es: {Math.Round(oImc.valorImc,2)} y se clasifica como: {oImc.Clasificacion}";
        }
    }
}
