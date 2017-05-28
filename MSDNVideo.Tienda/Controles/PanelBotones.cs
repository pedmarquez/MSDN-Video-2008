using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSDNVideo.Comun;
using MSDNVideo.InformesWPF;

namespace MSDNVideo.Tienda
{
    public delegate void BotonClickedEventHandler(int botonIndex);

    public partial class PanelBotones : UserControl
    {
        public event BotonClickedEventHandler BotonClicked;

        public PanelBotones()
        {
            InitializeComponent();
        }

        public void GenerarInformes()
        {
            SaludInforme saludInforme;
            BindingList<GraficaControl.ValorGrafica> valores;
            int i;
            string diasSemana = "LMXJVSD";
            string textoSalud;

            // Informe de ventas
            BindingList<InformeVentas> informeVentas = ConnectionHelper.ServiceClient.Informes_ObtenerInformeVentas(out saludInforme);
            valores = new BindingList<GraficaControl.ValorGrafica>();
            for (i = 0; i < informeVentas.Count; i++)
            {
                valores.Add(new GraficaControl.ValorGrafica(diasSemana[informeVentas[i].DiaSemana - 1].ToString(), (double)(informeVentas[i].Alquileres + informeVentas[i].Ventas)));
            }

            if (saludInforme == SaludInforme.Positivo)
                textoSalud = "Las ventas se reparten uniformemente por los días de la semana";
            else if (saludInforme == SaludInforme.Neutro)
                textoSalud = "Las ventas sufren algunos desvíos según el día de la semana";
            else
                textoSalud = "Las ventas sufren grandes desvíos según el día de la semana";

            informesControl1.EstablecerSalud(textoSalud, (int)saludInforme, 1);
            informesControl1.GraficaVentas.Valores = valores;
            informesControl1.GraficaVentas.CrearGrafica();

            // Informe de Stock
            BindingList<InformeStock> informeStock = ConnectionHelper.ServiceClient.Informes_ObtenerInformeStock(out saludInforme);
            valores = new BindingList<GraficaControl.ValorGrafica>();
            for (i = 0; i < informeStock.Count; i++)
            {
                valores.Add(new GraficaControl.ValorGrafica(informeStock[i].Unidades.ToString(), informeStock[i].NumPeliculas));
            }

            if (saludInforme == SaludInforme.Positivo)
                textoSalud = "El porcentaje de películas con bajo stock es bajo";
            else if (saludInforme == SaludInforme.Neutro)
                textoSalud = "El porcentaje de películas con bajo stock es medio";
            else
                textoSalud = "Existe un importante porcentaje de películas con bajo stock";

            informesControl1.EstablecerSalud(textoSalud, (int)saludInforme, 2);
            informesControl1.GraficaStocks.Valores = valores;
            informesControl1.GraficaStocks.CrearGrafica();

            // Informe de Saldos
            BindingList<InformeSaldos> informeSaldos = ConnectionHelper.ServiceClient.Informes_ObtenerInformeSaldos(out saludInforme);
            valores = new BindingList<GraficaControl.ValorGrafica>();
            for (i = 0; i < informeSaldos.Count; i++)
            {
                valores.Add(new GraficaControl.ValorGrafica(informeSaldos[i].Saldo.ToString(), informeSaldos[i].NumSocios));
            }

            if (saludInforme == SaludInforme.Positivo)
                textoSalud = "El porcentaje de socios con tarjeta a punto de recargar es alto";
            else if (saludInforme == SaludInforme.Neutro)
                textoSalud = "El porcentaje de socios con tarjeta a punto de recargar es medio";
            else
                textoSalud = "El porcentaje de socios con tarjeta a punto de recargar es bajo";

            informesControl1.EstablecerSalud(textoSalud, (int)saludInforme, 3);
            informesControl1.GraficaSaldos.Valores = valores;
            informesControl1.GraficaSaldos.CrearGrafica();

        }

        private void btn_CheckedChanged(object sender, EventArgs e)
        {
            int botonIndex;
            RadioButton boton;

            boton = (RadioButton)sender;
            if (boton.Tag != null)
            {
                if (boton.Checked && BotonClicked != null)
                {
                    botonIndex = int.Parse(boton.Tag.ToString());
                    BotonClicked(botonIndex);
                }
            }
        }
    }
}
