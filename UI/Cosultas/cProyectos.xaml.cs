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
    /// Interaction logic for cProyectos.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void Buscar_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Proyectos> listado = new List<Proyectos>();

            if (Criterio_TextBox.Text.Trim().Length > 0)
            {
                switch (Filtro_ComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.ProyectoId == Utilidades.ToInt(Criterio_TextBox.Text)
                                );
                            else
                                listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(Criterio_TextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 1:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.Descripcion.ToLower().Contains(Criterio_TextBox.Text.ToLower())
                                );
                            else
                                listado = ProyectosBLL.GetList(d => d.Descripcion.ToLower().Contains(Criterio_TextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 2:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    c => c.Fecha.Date >= Desde_DataPicker.SelectedDate &&
                                    c.Fecha.Date <= Hasta_DatePicker.SelectedDate &&
                                    c.TiempoTotal == Utilidades.ToInt(Criterio_TextBox.Text)
                                );
                            else
                                listado = ProyectosBLL.GetList(e => e.TiempoTotal == Utilidades.ToInt(Criterio_TextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;


                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
