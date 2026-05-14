using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2__Creation_De_Mission
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ouvre d'abord l'authentification
            FormAuthentification fAuth = new FormAuthentification();
            if (fAuth.ShowDialog() == DialogResult.OK)
            {
                // Authentification réussie → ouvre le formulaire de création
                Application.Run(new FormCreationMission());
            }
            // Sinon l'application se ferme sans rien ouvrir
        }
    }
}
