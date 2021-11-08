using P2_AP1_Alvaro_20190269.BLL;
using P2_AP1_Alvaro_20190269.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P2_AP1_Alvaro_20190269.UI.Cosultas
{
    /// <summary>
    /// Interaction logic for cTiposDeTareas.xaml
    /// </summary>
    public partial class cTiposDeTareas : Window
    {
        public cTiposDeTareas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TiposDeTareas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = TiposDeTareasBLL.GetList(e => e.TipoDeTareaId == (Utilidades.ToInt(CriterioTextBox.Text)));
                        break;
                    case 1:
                        listado = TiposDeTareasBLL.GetList(e => e.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 2:
                        listado = TiposDeTareasBLL.GetList(e => e.TiempoAcomulado == (Utilidades.ToInt(CriterioTextBox.Text)));
                        break;

                }
            }
            else
            {
                listado = TiposDeTareasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
