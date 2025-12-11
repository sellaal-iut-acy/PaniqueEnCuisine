using System.Windows;
using System.Windows.Input;

namespace PaniqueEnCuisine
{
    public partial class FenetreConfigTouches : Window
    {
        public FenetreConfigTouches()
        {
            InitializeComponent();

            // Charger les touches actuelles dans les TextBox
            TB_Haut.Text = ManagerSettings.KeyHaut.ToString();
            TB_Bas.Text = ManagerSettings.KeyBas.ToString();
            TB_Gauche.Text = ManagerSettings.KeyGauche.ToString();
            TB_Droite.Text = ManagerSettings.KeyDroite.ToString();
            TB_Sprint.Text = ManagerSettings.KeySprint.ToString();
            TB_Action.Text = ManagerSettings.KeyAction.ToString();
        }

        private void TB_Haut_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeyHaut != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeyHaut = e.Key;
            TB_Haut.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void TB_Bas_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeyBas != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeyBas = e.Key;
            TB_Bas.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void TB_Gauche_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeyGauche != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeyGauche = e.Key;
            TB_Gauche.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void TB_Droite_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeyDroite != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeyDroite = e.Key;
            TB_Droite.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void TB_Sprint_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeySprint != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeySprint = e.Key;
            TB_Sprint.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void TB_Action_KeyDown(object sender, KeyEventArgs e)
        {
            if (ManagerSettings.KeyAlreadyUsed(e.Key) && ManagerSettings.KeyAction != e.Key)
            {
                MessageBox.Show("Cette touche est déjà utilisée !");
                e.Handled = true;
                return;
            }

            ManagerSettings.KeyAction = e.Key;
            TB_Action.Text = e.Key.ToString();
            e.Handled = true;
        }


        private void ButtonFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
