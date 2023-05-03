using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;
using LoupGaroup.Classes;
using LoupGaroup.Pages;

namespace LoupGaroup
{
    /// <summary>
    /// Récupérer un id int userId = (int)Application.Current.Properties["UserId"];
    /// Sauvegarder un id ou autre : Application.Current.Properties["UserId"] = userId; await Application.Current.SavePropertiesAsync();
    /// </summary>
    public partial class MainPage : ContentPage
    {
        static readonly HttpClient connectApi = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
        }

        private void VerifConnect(object sender, EventArgs e)
        {
            // Code de l'EventHandler "VerifConnect" ici
            VerifConnectAPI();
        }
        public async Task VerifConnectAPI()
        {
            string recupMail = mail.Text;
            string recupPass = mdp.Text;
            //appeler l'api pour vérifier si les informations sont correct.
            var url = "http://127.0.0.1:8000/api/getUser/"+ recupMail;
            HttpResponseMessage response = await connectApi.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Utilisateurs utilisateur = JsonConvert.DeserializeObject<Utilisateurs>(responseBody);

            if(utilisateur.Mail == recupMail & utilisateur.Mdp == recupPass) {
                connectOuiNon.TextColor = Color.LightGreen;
                connectOuiNon.Text = "Vous êtes connecter!";
                Application.Current.Properties["UserId"] = utilisateur.Id;
                await Application.Current.SavePropertiesAsync();
                await Navigation.PushModalAsync(new Pages.Accueil());

            }
            else
            {
                connectOuiNon.TextColor = Color.Red;
                connectOuiNon.Text = "Erreur dans votre saisies!";
            }

        }
    }
}
