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
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

using MSDNVideo.Comun;
using MSDNVideo.Cajero.MSDNVideoServices;
using System.ComponentModel;

namespace MSDNVideo.Cajero
{
    public delegate void IntroEndedHandler(object sender, EventArgs args);

    /// <summary>
    /// Interaction logic for IntroControl.xaml
    /// </summary>
    public partial class IntroControl : UserControl
    {
        private BindingList<Pelicula> _peliculas;
        private TranslateTransform _materialTransform;

        public event IntroEndedHandler IntroEnded;
        public event IntroEndedHandler IntroHidden;

        public IntroControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtenemos las películas de estreno del servidor
            ObtenerPeliculas();
            this.DataContext = _peliculas;

            // Inicializamos material proyectado sobre los fotogramas
            VisualBrush visualBrush;
            Material material;

            visualBrush = new VisualBrush(listaPeliculas);
            _materialTransform = new TranslateTransform(0, 0);

            visualBrush.Transform = _materialTransform;

            RenderOptions.SetCachingHint(visualBrush, CachingHint.Cache);

            material = new DiffuseMaterial(visualBrush);

            curvaFotogramas.Material = material;
            curvaFotogramas.BackMaterial = material;

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new EventHandler(AnimStart), this, null);
        }

        private void AnimStart(object sender, EventArgs e)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation anim = new DoubleAnimation(-1.1, 0, new Duration(new TimeSpan(0, 0, 0, 15, 0)), FillBehavior.HoldEnd);
            anim.DecelerationRatio = .3;

            _materialTransform.BeginAnimation(TranslateTransform.XProperty, anim);
        }

        private void ObtenerPeliculas()
        {
            FiltroPeliculas filtro;
            int total;

            filtro = new FiltroPeliculas();
            filtro.Novedad = true;
            filtro.CamposFiltrado = (int)CamposFiltro.Novedad;
            filtro.IncluirTotal = false;
            filtro.InicioPagina = 0;
            filtro.PeliculasPagina = 10;

            _peliculas = ConnectionHelper.ServiceClient.Peliculas_ObtenerPeliculasPorFiltro(out total, filtro, false, false);
        }

        private void AnimateSelectedItem()
        {
            Storyboard sb = new Storyboard();
            double materialOffset;

            materialOffset = -(double)listaPeliculas.SelectedIndex / (double)listaPeliculas.Items.Count;
            DoubleAnimation anim = new DoubleAnimation(_materialTransform.X, materialOffset, new Duration(new TimeSpan(0, 0, 4)), FillBehavior.HoldEnd);
            anim.AccelerationRatio = .3;
            anim.DecelerationRatio = .3;
            
            _materialTransform.BeginAnimation(TranslateTransform.XProperty, anim);

        }

        private void ListaPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void trailerVideo_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MediaElement video = (MediaElement)sender;
            if (video.Visibility == Visibility.Visible)
                video.Play();
            else
                video.Stop();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Storyboard fadeOut = (Storyboard)this.Resources["FadeOut"];
            this.BeginStoryboard(fadeOut);

            if (IntroEnded != null)
                IntroEnded(this, new EventArgs());
        }

        private void FadeOut_Completed(object sender, EventArgs e)
        {
            if (IntroHidden != null)
                IntroHidden(this, new EventArgs());
        }

        private void FadeOutSinopsis_Completed(object sender, EventArgs e)
        {
            Storyboard fadeIn = (Storyboard)this.Resources["FadeInSinopsis"];
            this.BeginStoryboard(fadeIn);

            if (listaPeliculas.SelectedIndex < listaPeliculas.Items.Count - 1)
                listaPeliculas.SelectedIndex++;
            else
                listaPeliculas.SelectedIndex = 0;
        }

        private void FadeInSinopsis_Completed(object sender, EventArgs e)
        {
            AnimateSelectedItem();
        }
    }
}
