using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClienteDotNet
{
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync() {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:1718/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.Write("Probando: HTTP GET:\nIngrese ID a buscar: ");
                int id = 0;
                HttpResponseMessage response;
                Uri gizmoUrl;
                try
                {
                    id = int.Parse(Console.Read().ToString());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex + "NECESITO UN ENTERO para funcionar");
                }
                try { 
                    response = await client.GetAsync("api/values/"+id);
                
                    if (response.IsSuccessStatusCode)
                    {
                        Contacto contacto = await response.Content.ReadAsAsync<Contacto>();
                        Console.WriteLine("{0}\t${1}\t{2}\t{3}", contacto.Id, contacto.Nombre, contacto.Correo, contacto.Rol);
                    }
                }
                catch (HttpRequestException e)
                {
                    
                }
                Console.WriteLine();
                Console.Write("Probando HTTP POST (se genera una id random por posible conflicto en la BD)\n");
                var gizmo = new Contacto() { Nombre = "Gizmo", Correo = "Gizmo@a.com", Rol = "Alumno" };
                response = await client.PostAsJsonAsync("api/values", gizmo);
                if (response.IsSuccessStatusCode)
                {
                    gizmoUrl = response.Headers.Location;
                    Console.WriteLine();
                    Console.Write("Probando HTTP PUT (utilizando el anterior)");
                    gizmo.Correo = "a@giz.com";
                    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);
                    Console.WriteLine();
                    Console.Write("Probando HTTP DELETE (eliminando as gizmo)");
                    response = await client.DeleteAsync(gizmoUrl);
                    Console.WriteLine();
                }

            }
        }
    }
}
