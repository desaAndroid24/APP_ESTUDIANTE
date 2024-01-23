using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_ESTUDIANTE
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            cargaSelector("UP_T_FORMATOS_S", sel_formato, 1);
        }

        private void cargaSelector(string s_sp, Picker o_picker_c, int i_casilla)
        {
            ConBDMySQL cBD = new ConBDMySQL();
            MySqlConnection conn = cBD.getConnecccion();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = s_sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                o_picker_c.Items.Add(reader[i_casilla].ToString());
            }

            conn.Close();
        }

        private void Button_Clicked2(object sender, EventArgs args)
        {
            int index = sel_formato.SelectedIndex;
            string valor = sel_formato.SelectedItem.ToString();

            var detailPage = new DistribuidorPage();
            Navigation.PushModalAsync(detailPage);

            DisplayAlert(valor, index.ToString(), "Aceptar");
        }

        /*private void Button_Clicked(object sender, EventArgs args)
        {
            ConBDMySQL cBD = new ConBDMySQL();
            MySqlConnection conn = cBD.getConnecccion();
            String nombreUsuario = nombreEntry.Text;
            String query = "INSERT INTO usuarios (usuario) VALUES(?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
            cmd.ExecuteNonQuery();
            conn.Close();

            DisplayAlert("Usuario", nombreUsuario, "Aceptar");
            
        }*/
    }
}
