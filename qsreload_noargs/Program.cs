using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qlik.Engine;

// Autor: Caio Lobato
// Uma alternativa para fazer o reload no QSense Dekstop especificando o nome do .qvf no codigo


namespace qsreload_noargs
{
    class Program
    {
        static void Main()
        {

            ILocation location = Qlik.Engine.Location.FromUri(new Uri("ws://127.0.0.1:4848")); // url do Qlik Sense Desktop
            location.AsDirectConnectionToPersonalEdition();
            var appIdentifier = location.AppWithNameOrDefault("TesteAutoReload.qvf"); // !!!! IMPORTANTE: ESPECIFICAR O QVF AQUI!!

            if (appIdentifier == null)
            {
                Console.WriteLine(@"The app does not exist."); // caso o app não for encontrado
            }
            else
            {
                var app = location.App(appIdentifier);
                var reloadSucceded = app.DoReload();
                if (reloadSucceded)
                {
                    app.DoSave();
                    Console.WriteLine(@"The app is reloaded and saved."); // reload OK
                    //Console.WriteLine("Time: " + appIdentifier.LastReloadTime);
                }
                else
                {
                    Console.WriteLine(@"Reload failed."); // reload Falha
                }
            }
        }



    }
}
