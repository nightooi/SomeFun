using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;


namespace SomeFun
{
    public class MyTextElement : FrameworkElement
    {
        //maybe need a DI element to bind the point;
        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartPoint. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point), typeof(MyTextElement), new ElementMetaDataPoint());

        protected override void OnRender(DrawingContext drawingContext)
        {
            var a =new FormattedText("👮‍",
                new System.Globalization.CultureInfo("en-us"), 
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                40, 
                Brushes.Blue, 
                VisualTreeHelper.GetDpi(this).PixelsPerDip);
            drawingContext.DrawText(a, StartPoint);
            base.OnRender(drawingContext);
        }
    }
    public class ElementMetaDataPoint : FrameworkPropertyMetadata
    {
        public ElementMetaDataPoint() : base(default(Point))
        {
            this.AffectsRender = true;
        }
    }
}