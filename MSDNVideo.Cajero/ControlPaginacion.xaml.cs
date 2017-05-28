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

namespace MSDNVideo.Cajero
{

    /// <summary>
    /// Interaction logic for ControlPaginacion.xaml
    /// </summary>
    public partial class ControlPaginacion : UserControl
    {
        static readonly DependencyProperty NumElementosProperty;
        static readonly DependencyProperty ElementosPaginaProperty;
        static readonly DependencyProperty ElementoActualProperty;

        public event EventHandler<PaginationChangedEventArgs> PaginationChanged;

        private bool _isLoadingItems;

        static ControlPaginacion()
        {
            ControlPaginacion.NumElementosProperty = DependencyProperty.Register(
                "NumElementos", typeof(int), typeof(ControlPaginacion));

            ControlPaginacion.ElementosPaginaProperty = DependencyProperty.Register(
                "ElementosPagina", typeof(int), typeof(ControlPaginacion));

            ControlPaginacion.ElementoActualProperty = DependencyProperty.Register(
                "ElementoActual", typeof(int), typeof(ControlPaginacion));
        }

        public ControlPaginacion()
        {
            InitializeComponent();
        }

        public int NumElementos
        {
            get
            {
                return (int)base.GetValue(ControlPaginacion.NumElementosProperty); ;
            }
            set
            {
                base.SetValue(ControlPaginacion.NumElementosProperty, value);
            }
        }

        public int ElementosPagina
        {
            get
            {
                return (int)base.GetValue(ControlPaginacion.ElementosPaginaProperty); ;
            }
            set
            {
                base.SetValue(ControlPaginacion.ElementosPaginaProperty, value);
            }
        }

        public int ElementoActual
        {
            get
            {
                return (int)base.GetValue(ControlPaginacion.ElementoActualProperty); ;
            }
            set
            {
                base.SetValue(ControlPaginacion.ElementoActualProperty, value);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> numPaginas = new List<int>();
            int i;
            int paginaActual = ElementoActual / ElementosPagina;
            int numPaginasTotal = NumElementos / ElementosPagina + 1;
            int paginasMostradas = numPaginasTotal > 10 ? 10 : numPaginasTotal;
            int paginaInicial = paginaActual < 4 ? 1 : paginaActual - 3;

            for (i = paginaInicial; i < paginaInicial + paginasMostradas && i < numPaginasTotal + 1; i++)
            {
                numPaginas.Add(i);
            }


            _isLoadingItems = true;

            ObjectDataProvider dataSource = (ObjectDataProvider)Resources["Paginas"];
            dataSource.ObjectType = null;
            dataSource.ObjectInstance = numPaginas.ToArray();

            lstPaginas.SelectedIndex = paginaActual - paginaInicial + 1;

            _isLoadingItems = false;

            if (paginaActual == 0)
                pthAnterior.Visibility = Visibility.Hidden;
            if (paginaActual == numPaginasTotal - 1)
                pthSiguiente.Visibility = Visibility.Hidden;

        }

        private void lstPaginas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaginationChanged != null && !_isLoadingItems)
            {
                PaginationChanged(this, new PaginationChangedEventArgs((int)lstPaginas.SelectedItem));
            }

        }

        private void pthAnterior_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lstPaginas.SelectedIndex--;
        }

        private void pthSiguiente_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lstPaginas.SelectedIndex++;
        }
    }

    public class PaginationChangedEventArgs : EventArgs
    {
        private int _paginaSeleccionada;

        public PaginationChangedEventArgs(int paginaSeleccionada)
            : base()
        {
            _paginaSeleccionada = paginaSeleccionada;
        }

        public int PaginaSeleccionada
        {
            get
            {
                return _paginaSeleccionada;
            }
        }
    }

}
