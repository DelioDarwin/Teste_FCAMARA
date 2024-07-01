using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitMQUsuarioConsoleApplication
{
    public class Service
    {

        static HttpClient client = new HttpClient();

        public static bool SistemaExterno1_AddUsuario(API_SistemaExterno1.Models.Usuario usuario)
        {
            try
            { 
                var serialized = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                string sEndPointAdd = "https://localhost:7223/api/usuario/addusuario";

                HttpResponseMessage result = client.PostAsync(sEndPointAdd, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    //string sRetorno = result.Content.ReadAsStringAsync().Result;
                    //avaliacoRetorno = JsonConvert.DeserializeObject<Avaliacao>(sRetorno);

                    return true;
                
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool SistemaExterno2_AddUsuario(API_SistemaExterno2.Models.Usuario usuario)
        {
            try
            {
          
                var serialized = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                string sEndPointAdd = "https://localhost:7224/api/usuario/addusuario";

                HttpResponseMessage result = client.PostAsync(sEndPointAdd, content).Result;

                if (result.IsSuccessStatusCode)
                {
                    //string sRetorno = result.Content.ReadAsStringAsync().Result;
                    //avaliacoRetorno = JsonConvert.DeserializeObject<Avaliacao>(sRetorno);

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
