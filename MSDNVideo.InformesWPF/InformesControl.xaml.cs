using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSDNVideo.InformesWPF
{
    /// <summary>
    /// Control que presenta los tres informes
    /// </summary>
    public partial class InformesControl : UserControl
    {
        #region Constructor

        public InformesControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Propiedades

        public GraficaControl GraficaVentas
        {
            get { return graficaVentas; }
        }

        public GraficaControl GraficaStocks
        {
            get { return graficaStocks; }
        }

        public GraficaControl GraficaSaldos
        {
            get { return graficaSaldos; }
        }

        #endregion

        #region Métodos públicos

        public void EstablecerSalud(string textoSalud, int salud, int grafica)
        {
            TextBlock textBlockSalud;

            if (grafica == 1)
                textBlockSalud = saludVentas;
            else if(grafica == 2)
                textBlockSalud = saludStocks;
            else
                textBlockSalud = saludSaldos;

            Rectangle rect = ((Rectangle)((Grid)textBlockSalud.Parent).Children[0]);

            if (salud == 0)
            {
                // Verde
                rect.Fill = new SolidColorBrush(Color.FromRgb(160, 242, 176));
                rect.Stroke = new SolidColorBrush(Color.FromRgb(88, 129, 96));
            }
            else if (salud == 1)
            {
                // Amarillo
                rect.Fill = new SolidColorBrush(Color.FromRgb(246, 245, 138));
                rect.Stroke = new SolidColorBrush(Color.FromRgb(129, 129, 88));
            }
            else
            {
                // Rojo
                rect.Fill = new SolidColorBrush(Color.FromRgb(246, 138, 138));
                rect.Stroke = new SolidColorBrush(Color.FromRgb(129, 88, 88));
            }

            textBlockSalud.Text = textoSalud;
        }

        #endregion

        #region Tratamiento de eventos

        private void anteriorButton_Click(object sender, RoutedEventArgs e)
        {
            zapPanel.CurrentItemIndex -= 1;
            if (zapPanel.CurrentItemIndex == 0)
                anteriorButton.IsEnabled = false;
            
            siguienteButton.IsEnabled = true;
            UpdateInforme();
        }

        private void siguienteButton_Click(object sender, RoutedEventArgs e)
        {
            zapPanel.CurrentItemIndex += 1;
            if (zapPanel.CurrentItemIndex == 2)
                siguienteButton.IsEnabled = false;

            anteriorButton.IsEnabled = true;
            UpdateInforme();
        }

        #endregion

        #region Métodos auxiliares

        private void UpdateInforme()
        {
            GraficaControl grafica;

            if (zapPanel.CurrentItemIndex == 0)
            {
                nombreInforme.Text = "Estado ventas";
                grafica = graficaVentas;
            }
            else if (zapPanel.CurrentItemIndex == 1)
            {
                nombreInforme.Text = "Estado stocks";
                grafica = graficaStocks;
            }
            else
            {
                nombreInforme.Text = "Estado saldos";
                grafica = graficaSaldos;
            }

            grafica.AnimarBarras();
        }

        #endregion
    }
}
