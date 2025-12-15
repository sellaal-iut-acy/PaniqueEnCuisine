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
        private List<PNJ> clients_servie = new List<PNJ>();

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

        public List<PNJ> Clients_servie
        {
            get
            {
                return this.clients_servie;
            }

            set
            {
                this.clients_servie = value;
            }
        }

        public ManagerClients(List<PNJ> clients)
        {
            this.clients = clients;
        }
        public void AjouterClient(PNJ client)
        {
            client.current_Image.Tag = "PNJ";
            client.current_Image.Name = client.Nom;
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
        public void move_PNJ(PNJ PNJ,Image img_pnj)
        {
            Console.WriteLine($"Déplacement du PNJ  de {PNJ.Vitesse} pixels vers le bas.");
            Canvas.SetTop(img_pnj, Canvas.GetTop(img_pnj) + PNJ.Vitesse);
        }

        public void move_all_PNJ(Canvas grille)
        {
            ManagerColision colision = new ManagerColision();
            /*
            foreach (PNJ client in this.clients_servie)
            {

                Console.WriteLine($"Le PNJ  {client.Nom}avance.");
                move_PNJ(client, client.Curenent_Image);


            }
            */
            foreach (PNJ client in this.Clients)
            {
                Console.WriteLine($"Vérification de la collision pour le PNJ {client.Nom}.");
                if (!colision.VerifierColision(grille,client.Curenent_Image, client) || !colision.VerifierColision_PNJ_To_PNJ(grille,client)  || client.Est_Servi())
                {
                    move_PNJ(client, client.Curenent_Image);
                    Console.WriteLine($"Le PNJ  {client.Nom} avance  de {client.Vitesse}.");
                }   
                else
                    Console.WriteLine("Le PNJ ne peut pas avancer en raison d'une collision.");

            
            }

            
        }

    }
}
