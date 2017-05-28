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
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;

namespace MSDNVideo.InformesWPF
{
    /// <summary>
    /// Control que presenta una gráfica de barras
    /// </summary>
    public partial class GraficaControl : UserControl
    {
        #region Campos

        private BindingList<ValorGrafica>   _valores = new BindingList<ValorGrafica>();
        private List<string>                _etiquetasY = new List<string>();
        Rect                                _superficieGrafica;
        double                              _rangoGrafica;
        List<Rectangle>                     _barras = new List<Rectangle>();
        List<TextBlock>                     _etiquetasValores = new List<TextBlock>();
        string                              _tituloX, 
                                            _tituloY;

        #endregion

        #region Constructor

        public GraficaControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Propiedades

        public BindingList<ValorGrafica> Valores
        {
            get
            {
                return _valores;
            }
            set
            {
                _valores = value;
            }
        }

        public string TituloX
        {
            get { return _tituloX; }
            set { _tituloX = value; }
        }

        public string TituloY
        {
            get { return _tituloY; }
            set { _tituloY = value; }
        }

        #endregion

        #region Métodos públicos

        public void CrearGrafica()
        {
            mainCanvas.Children.Clear();

            _superficieGrafica = new Rect(50, 0, this.Width - 60, this.Height - 40);
            CalcularEtiquetasY();

            CrearEjes();
            CrearRejilla();
            CrearEtiquetas();
            CrearValores();
        }

        public void AnimarBarras()
        {
            DoubleAnimationUsingKeyFrames anim;
            int i;
            double valorPixeles;

            for (i = 0; i < _valores.Count; i++)
            {
                valorPixeles = _valores[i].Valor / _rangoGrafica * (_superficieGrafica.Bottom - _superficieGrafica.Top);

                // Longitud de barra
                anim = new DoubleAnimationUsingKeyFrames();
                anim.Duration = new TimeSpan(0, 0, 1);
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(0, KeyTime.FromPercent(0)));
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(valorPixeles, KeyTime.FromPercent(1)));
                _barras[i].BeginAnimation(Rectangle.HeightProperty, anim);

                // Base de barra
                anim = new DoubleAnimationUsingKeyFrames();
                anim.Duration = new TimeSpan(0, 0, 1);
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(_superficieGrafica.BottomLeft.Y, KeyTime.FromPercent(0)));
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(_superficieGrafica.BottomLeft.Y - valorPixeles, KeyTime.FromPercent(1)));
                _barras[i].BeginAnimation(Canvas.TopProperty, anim);

                // Posición texto
                anim = new DoubleAnimationUsingKeyFrames();
                anim.Duration = new TimeSpan(0, 0, 1);
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(_superficieGrafica.BottomLeft.Y - 10, KeyTime.FromPercent(0)));
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(_superficieGrafica.BottomLeft.Y - valorPixeles - 10, KeyTime.FromPercent(1)));
                _etiquetasValores[i].BeginAnimation(Canvas.TopProperty, anim);
            }
        }

        #endregion

        #region Métodos auxiliares

        private void CrearValores()
        {
            int i;
            Point point;
            Rectangle rectangle;
            LinearGradientBrush brushRectangle;
            Brush brushStrokeRectangle;
            Brush brushFont;
            double valorPixeles;

            brushStrokeRectangle = new SolidColorBrush(Color.FromRgb(0, 50, 150)); ;
            brushRectangle = new LinearGradientBrush(Color.FromRgb(100, 200, 255), Color.FromRgb(50, 150, 250), new Point(0,1), new Point(.5,.5));
            brushFont = new SolidColorBrush(Color.FromRgb(150, 150, 144));

            point = _superficieGrafica.BottomLeft;
            for (i = 0; i < _valores.Count; i++)
            {
                // Barra
                valorPixeles = _valores[i].Valor / _rangoGrafica * (_superficieGrafica.Bottom - _superficieGrafica.Top);
                rectangle = new Rectangle();
                rectangle.Fill = brushRectangle;
                rectangle.Stroke = brushStrokeRectangle;
                rectangle.SetValue(Canvas.LeftProperty, point.X + 5);
                rectangle.SetValue(Canvas.TopProperty, point.Y - valorPixeles);
                rectangle.Width = (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count - 10;
                rectangle.Height = valorPixeles;

                DropShadowBitmapEffect effect = new DropShadowBitmapEffect();
                effect.Color = Color.FromArgb(120,0,0,0);
                effect.ShadowDepth = 3;
                effect.Direction = 45;
                effect.Softness = .2;
                rectangle.BitmapEffect = effect;
                mainCanvas.Children.Add(rectangle);
                _barras.Add(rectangle);

                point.X += (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count;
            }

            point = _superficieGrafica.BottomLeft;
            for (i = 0; i < _valores.Count; i++)
            {
                // Texto
                valorPixeles = _valores[i].Valor / _rangoGrafica * (_superficieGrafica.Bottom - _superficieGrafica.Top);
                TextBlock textBlock = new TextBlock();
                textBlock.Name = "TextoValor" + i.ToString();
                Binding binding = new Binding("");
                binding.Source = _valores[i].Valor.ToString(); ;
                textBlock.SetBinding(TextBlock.TextProperty, binding);

                //textBlock.Text = _valores[i].Valor.ToString();
                textBlock.TextAlignment = TextAlignment.Left;
                textBlock.FontFamily = new FontFamily("SegoeUI");
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Foreground = brushFont;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Width = 40;
                textBlock.SetValue(Canvas.LeftProperty, point.X + (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count / 2 - 8);
                textBlock.SetValue(Canvas.TopProperty, point.Y - valorPixeles - 10);
                textBlock.RenderTransform = new RotateTransform(-70, 0, 1);

                mainCanvas.Children.Add(textBlock);
                _etiquetasValores.Add(textBlock);

                point.X += (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count;
            }
        }

        private void CrearEtiquetas()
        {
            Typeface typeFace;
            int i;
            Brush brushFont;
            Point point;
            TextBlock textBlock;

            typeFace = new Typeface(new FontFamily("SegoeUI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
            brushFont = new SolidColorBrush(Color.FromRgb(150, 150, 144));

            // Eje vertical
            point = _superficieGrafica.BottomLeft;
            for (i = 0; i < _etiquetasY.Count; i++)
            {
                textBlock = new TextBlock();
                textBlock.Text = _etiquetasY[i];
                textBlock.TextAlignment = TextAlignment.Right;
                textBlock.FontFamily = new FontFamily("SegoeUI");
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Foreground = brushFont;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Width = 30;
                textBlock.SetValue(Canvas.LeftProperty, point.X - textBlock.Width - 10);
                textBlock.SetValue(Canvas.TopProperty, point.Y - 6);

                mainCanvas.Children.Add(textBlock);

                point.Y -= (_superficieGrafica.Bottom - _superficieGrafica.Top) / (_etiquetasY.Count-1);
            }

            // Eje horizontal
            point = _superficieGrafica.BottomLeft;
            for (i = 0; i < _valores.Count; i++)
            {
                textBlock = new TextBlock();
                textBlock.Text = _valores[i].Etiqueta;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.FontFamily = new FontFamily("SegoeUI");
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Foreground = brushFont;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Width = (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count;
                textBlock.SetValue(Canvas.LeftProperty, point.X);
                textBlock.SetValue(Canvas.TopProperty, point.Y + 5);

                mainCanvas.Children.Add(textBlock);

                point.X += (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count;
            }

            // Títulos
            textBlock = new TextBlock();
            textBlock.Text = _tituloX;
            textBlock.TextAlignment = TextAlignment.Right;
            textBlock.FontFamily = new FontFamily("SegoeUI");
            textBlock.FontWeight = FontWeights.Bold;
            textBlock.Foreground = brushFont;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Width = 150;
            textBlock.SetValue(Canvas.LeftProperty, _superficieGrafica.Right - 150);
            textBlock.SetValue(Canvas.TopProperty, _superficieGrafica.Bottom + 20);
            mainCanvas.Children.Add(textBlock);

            textBlock = new TextBlock();
            textBlock.Text = _tituloY;
            textBlock.TextAlignment = TextAlignment.Right;
            textBlock.FontFamily = new FontFamily("SegoeUI");
            textBlock.FontWeight = FontWeights.Bold;
            textBlock.Foreground = brushFont;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Width = 150;
            textBlock.SetValue(Canvas.LeftProperty, _superficieGrafica.Left - 47 - 150);
            textBlock.SetValue(Canvas.TopProperty, _superficieGrafica.Top);
            textBlock.RenderTransformOrigin = new Point(1, 0);
            textBlock.RenderTransform = new RotateTransform(-90);
            mainCanvas.Children.Add(textBlock);

        }

        private void CalcularEtiquetasY()
        {
            int maxEtiquetas = 7;
            int minEtiquetas = 4;
            double maxValue, normMaxValue;
            double step = 1;
            double valorEtiqueta;

            maxValue = (from valor in _valores select valor.Valor).Max();

            // Normalizamos
            normMaxValue = maxValue;
            while (normMaxValue > 10)
            {
                normMaxValue /= 10;
                step *= 10;
            }

            if (normMaxValue > maxEtiquetas)
                step *= 2;
            else if (normMaxValue < minEtiquetas)
                step /= 2;

            valorEtiqueta = 0;
            _etiquetasY.Clear();
            while (valorEtiqueta < maxValue)
            {
                _etiquetasY.Add(valorEtiqueta.ToString());
                valorEtiqueta += step;
            }
            _etiquetasY.Add(valorEtiqueta.ToString());
            _rangoGrafica = valorEtiqueta;
        }

        private void CrearRejilla()
        {
            int i;
            Point pIni, pEnd;
            Line line;

            pIni = _superficieGrafica.TopLeft;
            pEnd = _superficieGrafica.TopRight;

            for (i = 0; i < _etiquetasY.Count - 1; i++)
            {
                line = new Line();
                line.X1 = pIni.X;
                line.X2 = pEnd.X;
                line.Y1 = pIni.Y;
                line.Y2 = pEnd.Y;
                line.Stroke = new SolidColorBrush(Color.FromArgb(100, 120, 120, 110));
                line.StrokeThickness = 1;
                line.StrokeDashCap = PenLineCap.Round;
                line.StrokeDashArray.Add(10);
                line.StrokeDashArray.Add(10);
                mainCanvas.Children.Add(line);

                pIni.Y += (_superficieGrafica.Bottom - _superficieGrafica.Top) / (_etiquetasY.Count - 1);
                pEnd.Y = pIni.Y;
            }

            pIni = _superficieGrafica.TopLeft;
            pEnd = _superficieGrafica.BottomLeft;

            for (i = 0; i < _valores.Count; i++)
            {
                pIni.X += (_superficieGrafica.Right - _superficieGrafica.Left) / _valores.Count;
                pEnd.X = pIni.X;

                line = new Line();
                line.X1 = pIni.X;
                line.X2 = pEnd.X;
                line.Y1 = pIni.Y;
                line.Y2 = pEnd.Y;
                line.Stroke = new SolidColorBrush(Color.FromArgb(100, 120, 120, 110));
                line.StrokeThickness = 1;
                line.StrokeDashCap = PenLineCap.Round;
                line.StrokeDashArray.Add(10);
                line.StrokeDashArray.Add(10);
                mainCanvas.Children.Add(line);
            }

        }

        private void CrearEjes()
        {
            LineSegment line1, line2;
            Path path;
            PathFigure pathFigure;

            line1 = new LineSegment(new Point(_superficieGrafica.Left, _superficieGrafica.Bottom), true);
            line2 = new LineSegment(new Point(_superficieGrafica.Right + 5, _superficieGrafica.Bottom), true);

            pathFigure = new PathFigure(new Point(_superficieGrafica.Left, _superficieGrafica.Top - 5), new LineSegment[] { line1, line2 }, false);

            path = new Path();
            path.Stroke = new SolidColorBrush(Color.FromRgb(150, 150, 144));
            path.StrokeStartLineCap = PenLineCap.Round;
            path.StrokeEndLineCap = PenLineCap.Round;
            path.StrokeThickness = 1.5;
            path.Data = new PathGeometry(new PathFigure[] { pathFigure });

            mainCanvas.Children.Add(path);
        }

        #endregion

        #region "Clase ValorGrafica"
        public class ValorGrafica : INotifyPropertyChanged
        {
            private double _valor;
            private string _etiqueta;

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            public ValorGrafica(string etiqueta, double valor)
            {
                _etiqueta = etiqueta;
                _valor = valor;
            }

            public double Valor
            {
                get
                {
                    return _valor;
                }
                set
                {
                    _valor = value;
                    NotifyPropertyChange("Valor1");
                }
            }

            public string Etiqueta
            {
                get
                {
                    return _etiqueta;
                }
                set
                {
                    _etiqueta = value;
                    NotifyPropertyChange("Etiqueta");
                }
            }

            private void NotifyPropertyChange(string propiedad)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }

        }
        #endregion

        #region "Clase DoubleStringConverter"
        public class DoubleStringConverter : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {

                double d = (double)value;

                return d.ToString();

            }



            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {

                throw new NotImplementedException();

            }

        }

        #endregion
    }
}
