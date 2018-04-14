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
using Biblioteca.Entidades;
using Biblioteca.DALC;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para BuscarCliente.xaml
    /// </summary>
    public partial class BuscarCliente : Window
    {
        Clientes cl = new Clientes();
        public BuscarCliente()
        {
            InitializeComponent();
            
        }

      

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
             dtListado.ItemsSource = ListadoClientes.ToList();
            dtListado.Items.Refresh();
        }
    }
}
