using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Front.Models;
using Newtonsoft.Json;

namespace Front
{
    public partial class Default : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarUsuariosAplicacaoInterna();
            ListarUsuariosAplicacaoExterna1();
            ListarUsuariosAplicacaoExterna2();
            ListarLogErros();
        }


        public void ListarUsuariosAplicacaoInterna()
        {
            string sEndPoint = "https://localhost:7222/api/usuario/usuariolist"; 
            HttpResponseMessage response = client.GetAsync(sEndPoint).Result;
            List<Usuario> usr = null;
            if (response.IsSuccessStatusCode)
            {
                string sRetorno = response.Content.ReadAsStringAsync().Result;
                usr = JsonConvert.DeserializeObject<List<Usuario>>(sRetorno);

                //var list = new List<Usuario> { usr };
          

                if (usr != null)
                {
                    grvAplicacaoInterna.DataSource = usr;
                    grvAplicacaoInterna.DataBind();
                }
                else
                {
                    grvAplicacaoInterna.DataSource = null;
                    grvAplicacaoInterna.DataBind();
                }

               
            }

        }

        public void ListarUsuariosAplicacaoExterna1()
        {
            try
            {           
                string sEndPoint = "https://localhost:7223/api/usuario/usuariolist";
                HttpResponseMessage response = client.GetAsync(sEndPoint).Result;
                List<Usuario> usr = null;
                if (response.IsSuccessStatusCode)
                {
                    string sRetorno = response.Content.ReadAsStringAsync().Result;
                    usr = JsonConvert.DeserializeObject<List<Usuario>>(sRetorno);

                    //var list = new List<Usuario> { usr };


                    if (usr != null)
                    {
                        grvAplicacoExterna1.DataSource = usr;
                        grvAplicacoExterna1.DataBind();
                    }
                    else
                    {
                        grvAplicacoExterna1.DataSource = null;
                        grvAplicacoExterna1.DataBind();
                    }
                }
            }
            catch (Exception)
            {

     
            }

        }

        public void ListarUsuariosAplicacaoExterna2()
        {
            try
            {

           
                string sEndPoint = "https://localhost:7224/api/usuario/usuariolist";
                HttpResponseMessage response = client.GetAsync(sEndPoint).Result;
                List<Usuario> usr = null;
                if (response.IsSuccessStatusCode)
                {
                    string sRetorno = response.Content.ReadAsStringAsync().Result;
                    usr = JsonConvert.DeserializeObject<List<Usuario>>(sRetorno);

                    //var list = new List<Usuario> { usr };


                    if (usr != null)
                    {
                        grvAplicacoExterna2.DataSource = usr;
                        grvAplicacoExterna2.DataBind();
                    }
                    else
                    {
                        grvAplicacoExterna2.DataSource = null;
                        grvAplicacoExterna2.DataBind();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void ListarLogErros()
        {
            try
            {

                string sEndPoint = "https://localhost:7222/api/usuario/logerroList";
                HttpResponseMessage response = client.GetAsync(sEndPoint).Result;
                List<LogErro> usr = null;
                if (response.IsSuccessStatusCode)
                {
                    string sRetorno = response.Content.ReadAsStringAsync().Result;
                    usr = JsonConvert.DeserializeObject<List<LogErro>>(sRetorno);

                    //var list = new List<Usuario> { usr };

                    if (usr != null)
                    {
                        grvLogErros.DataSource = usr;
                        grvLogErros.DataBind();
                    }
                    else
                    {
                        grvLogErros.DataSource = null;
                        grvLogErros.DataBind();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}