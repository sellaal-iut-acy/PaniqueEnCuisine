using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    internal class ManagerClients
    {
        private List<PNJ> clients = new List<PNJ>();

        public List<PNJ> Clients
        {
            get
            {
                return this.clients;
            }

            set
            {
                this.clients = value;
            }
        }

        public ManagerClients(List<PNJ> clients)
        {
            this.clients = clients;
        }
        public void AjouterClient(PNJ client)
        {
           this.clients.Add(client);
        }
        public void RetirerClient(PNJ client)
        {
            this.clients.Remove(client);
        }

        public void afficher_Clients(Canvas grille )
        {
            int espace_entre_clients = 0;
            Console.WriteLine($"Affichage de {this.clients.Count} clients.");
            foreach (PNJ client in this.clients)
            {
                client.Afficher_PNJ(grille,50,100,750,0 + espace_entre_clients);
                espace_entre_clients += (int)client.Curenent_Image.Width + 20 ;
            }
        }
    }
}
