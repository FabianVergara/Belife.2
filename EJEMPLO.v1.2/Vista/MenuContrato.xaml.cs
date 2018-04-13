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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MenuContrato.xaml
    /// </summary>
    public partial class MenuContrato : Window
    {
        public MenuContrato()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {


            lblFaltaFiltro.Content = ("");
            if (cboFiltro.SelectedIndex == 1)
            {

            }
            if (cboFiltro.SelectedIndex == 2)
            {

            }
            if (cboFiltro.SelectedIndex == 3)
            {

            }
            if (cboFiltro.SelectedIndex == 0)
            {
                lblFaltaFiltro.Content = ("Seleccione Filtro");

                lblFaltaFiltro.Foreground = Brushes.Red;
            }
        }
    }
}
