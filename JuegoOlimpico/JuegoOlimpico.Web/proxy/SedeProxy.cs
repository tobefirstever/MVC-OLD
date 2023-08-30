using JuegoOlimpico.Web.Dto.Sede;
using JuegoOlimpico.Web.Models;
using JuegoOlimpico.Web.Utilitario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JuegoOlimpico.Web.proxy
{
    public class SedeProxy
    {
        private readonly WebApiJuegoOlimpico webApiJuegoOlimpico = new WebApiJuegoOlimpico();


        public async Task<List<PaisModel>> ListarPais(string token)
        {

            string jsonResponse = await webApiJuegoOlimpico.EnviarPeticionGet(Constantes.Pais.Listar, token);

            var paisResponse = JsonConvert.DeserializeObject<Response<List<PaisResponseDto>>>(jsonResponse).Data;

            List<PaisModel> paisModels = paisResponse.Select(x => new PaisModel
            {
                Id = x.IdPais,
                Nombre = x.NombrePais

            }).ToList();


            return paisModels;

        }

        public async Task<List<SedeModel>> ListarSede(string token)
        {

            string jsonResponse = await webApiJuegoOlimpico.EnviarPeticionGet(Constantes.Sede.Listar, token);

            var paisResponse = JsonConvert.DeserializeObject<Response<List<SedeResponseDto>>>(jsonResponse).Data;

            List<SedeModel> paisModels = paisResponse.Select(x => new SedeModel
            {
                IdSede = x.IdSede,
                IdPais = x.IdPais,
                NombreSede = x.NombreSede,
                NombrePais = x.NombrePais,
                NroComplejos = x.NroComplejos,
                Presupuesto = x.Presupuesto

            }).ToList();


            return paisModels;

        }

        public async Task<SedeModel> ObtenerSede(int id , string token)
        {

            string url = $"{Constantes.Sede.Obtener}{id}";

            string jsonResponse = await webApiJuegoOlimpico.EnviarPeticionGet(url, token);

            var sedeResponse = JsonConvert.DeserializeObject<Response<SedeResponseDto>>(jsonResponse).Data;

            SedeModel paisModels = new SedeModel
            {
                IdSede = sedeResponse.IdSede,
                IdPais = sedeResponse.IdPais,
                NombreSede = sedeResponse.NombreSede,
                NombrePais = sedeResponse.NombrePais,
                NroComplejos = sedeResponse.NroComplejos,
                Presupuesto = sedeResponse.Presupuesto
            };


            return paisModels;

        }

        public async Task<bool> Insertar(RegistrarSedeModel registrarSedeModel, string token)
        {

            SedeRequestDto sedeRequestDto = new SedeRequestDto
            {
                IdPais = registrarSedeModel.IdPais,
                IdSede = registrarSedeModel.IdSede,
                NombreSede = registrarSedeModel.NombreSede,
                NroComplejos = registrarSedeModel.NroComplejos,
                Presupuesto = registrarSedeModel.Presupuesto
            };

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionPost<SedeRequestDto>(sedeRequestDto, Constantes.Sede.Crear, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

        public async Task<bool> Actualizar(RegistrarSedeModel registrarSedeModel, string token)
        {
            SedeRequestDto sedeRequestDto = new SedeRequestDto
            {
                IdPais = registrarSedeModel.IdPais,
                IdSede = registrarSedeModel.IdSede,
                NombreSede = registrarSedeModel.NombreSede,
                NroComplejos = registrarSedeModel.NroComplejos,
                Presupuesto = registrarSedeModel.Presupuesto
            };


            string url = $"{Constantes.Sede.Actualizar}{sedeRequestDto.IdSede}";

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionPut<SedeRequestDto>(sedeRequestDto, url, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

        public async Task<bool> Eliminar(int id, string token)
        {
            string url = $"{Constantes.Sede.Eliminar}{id}";

            string jsonText = await webApiJuegoOlimpico.EnviarPeticionDelete(url, token);

            var respuesta = JsonConvert.DeserializeObject<Response<bool>>(jsonText).Data;

            return respuesta;
        }

    }
}