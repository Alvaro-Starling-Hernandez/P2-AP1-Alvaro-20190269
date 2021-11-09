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

namespace P2_AP1_Alvaro_20190269.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos proyecto = new Proyectos();

        public rProyectos()
        {
            InitializeComponent();

            TipoDeTaeaComboBox.ItemsSource = TiposDeTareasBLL.GetTiposDeTareas();
            TipoDeTaeaComboBox.SelectedValuePath = "TipoDeTareaId";
            TipoDeTaeaComboBox.DisplayMemberPath = "Nombre";
        }
        
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }

        private void Limpiar()
        {
            this.proyecto = new Proyectos();
            this.DataContext = proyecto;
        }

        private bool Validar()
        {
            bool esValido = true;

            if(DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la descripcion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(DetalleDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la descripcion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Proyecto = ProyectosBLL.Buscar(proyecto.ProyectoId);

            if (Proyecto != null)
            {
                this.proyecto = Proyecto;
                this.DataContext = proyecto;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ProyectosDetalle
            {
                ProyectoDetalleId = this.proyecto.ProyectoId,
                TiposDeTareas = (TiposDeTareas)TipoDeTaeaComboBox.SelectedItem,
                Requerimiento = RequerimientoTextBox.Text,
                Tiempo = Utilidades.ToInt(TiempoTextBox.Text)
            };

            proyecto.TiempoTotal += Utilidades.ToInt(TiempoTextBox.Text);

            proyecto.Detalle.Add(detalle);
            Cargar();

        }

       

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ProyectosBLL.Guardar(proyecto);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transferencia Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transferencia fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(proyecto.ProyectoId))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = (ProyectosDetalle)DetalleDataGrid.SelectedItem;

            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyecto.TiempoTotal -= detalle.Tiempo;

                proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}
