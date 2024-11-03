using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SomeFun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Random rand = new();
        private List<PointAnimationUsingPath> ElemList = new();
        public MainWindow()
        {
            InitializeComponent();
            CreateElements(20);
            int i = 0;
            foreach(var elem in ElemList)
            {
                ((MyTextElement)this.Top.Children[2 + i]).Loaded += (o, e) => { ((MyTextElement)o).BeginAnimation(MyTextElement.StartPointProperty, elem); };
                i++;
            }

            // Create a NameScope for the page so that
            // we can use Storyboards
            // Create the EllipseGeometry to animate.

            // Register the EllipseGeometry's name with
            // the page so that it can be targeted by a
            // storyboard.
            // Create a Path element to display the geometry.
            // Create a Canvas to contain ellipsePath
            // and add it to the page.
            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = TextEl.StartPoint;
            PolyLineSegment pBezierSegment = new PolyLineSegment();
            pBezierSegment.Points.Add(new Point(35, 0));
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(160, 100));
            pBezierSegment.Points.Add(new Point(180, 190));
            pBezierSegment.Points.Add(new Point(285, 200));
            pBezierSegment.Points.Add(new Point(310, 100));
            pBezierSegment.Points.Add(new Point(305, 300 ));
            pBezierSegment.Points.Add(new Point(40, 90));
            pBezierSegment.Points.Add(new Point(39, 349));
            pBezierSegment.Points.Add(new Point(393, 390));
            pBezierSegment.Points.Add(new Point(290, 394));
            pBezierSegment.Points.Add(new Point(100, 90));
            pBezierSegment.Points.Add(new Point(90, 300));
            pBezierSegment.Points.Add(new Point(159, 200));
            pBezierSegment.Points.Add(new Point(203, 310));
            pBezierSegment.Points.Add(new Point(310, 400));
            pBezierSegment.Points.Add(new Point(109, 34));
            pBezierSegment.Points.Add(new Point(0, 0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(15);
            centerPointAnimation.FillBehavior = FillBehavior.HoldEnd;

            PathGeometry animationPath2 = new PathGeometry();
            PathFigure pFigure2 = new PathFigure();
            pFigure2.StartPoint = SecondElement.StartPoint;
            PolyLineSegment pBezierSegment2 = new PolyLineSegment();
            pBezierSegment2.Points.Add(new Point(145, 50));
            pBezierSegment2.Points.Add(new Point(155, 90));
            pBezierSegment2.Points.Add(new Point(150, 300));
            pBezierSegment2.Points.Add(new Point(170, 190));
            pBezierSegment2.Points.Add(new Point(215, 400));
            pBezierSegment2.Points.Add(new Point(380, 200));
            pBezierSegment2.Points.Add(new Point(345, 300 ));
            pBezierSegment2.Points.Add(new Point(40, 90));
            pBezierSegment2.Points.Add(new Point(39, 349));
            pBezierSegment2.Points.Add(new Point(393, 390));
            pBezierSegment2.Points.Add(new Point(290, 394));
            pBezierSegment2.Points.Add(new Point(100, 90));
            pBezierSegment2.Points.Add(new Point(90, 300));
            pBezierSegment2.Points.Add(new Point(159, 200));
            pBezierSegment2.Points.Add(new Point(203, 310));
            pBezierSegment2.Points.Add(new Point(380, 400));
            pBezierSegment2.Points.Add(new Point(15, 134));
            pBezierSegment2.Points.Add(new Point(30, 50));
            pFigure2.Segments.Add(pBezierSegment2);
            animationPath2.Figures.Add(pFigure2);

            // Freeze the PathGeometry for performance benefits.
            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation2 =
                new PointAnimationUsingPath();
            centerPointAnimation2.PathGeometry = animationPath2;
            centerPointAnimation2.Duration = TimeSpan.FromSeconds(15);
            centerPointAnimation2.FillBehavior = FillBehavior.HoldEnd;

            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".

            // Create a Storyboard to contain and apply the animation.

            // Start the Storyboard when ellipsePath is loaded.
            TextEl.Loaded += delegate (object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                TextEl.BeginAnimation(MyTextElement.StartPointProperty, centerPointAnimation);
            };
            SecondElement.Loaded += delegate (object sender, RoutedEventArgs e) { SecondElement.BeginAnimation(MyTextElement.StartPointProperty, centerPointAnimation2); };
            // Storyboard.SetTargetName(animation, "Some");
            // Storyboard.SetTargetProperty(animation, new PropertyPath(Some.Height));
            // pathStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            // pathStoryBoard.AutoReverse = true;
            // pathStoryBoard.Children.Add(animation);

        }
        private void CreateElements(int amount)
        {
            Point startPos;
            PolyLineSegment lineSeg;
            PathFigure pathFig;
            PathGeometry pathGeo;
            PointAnimationUsingPath pointAnim;
            for(int i=0; i< amount; i++)
            {
                startPos = new Point(rand.Next(0,1000), rand.Next(0, 1000));
                var elem = new MyTextElement() { StartPoint = startPos };
                this.Top.Children.Add(elem);
                pathGeo = new();
                lineSeg = new();
                for(int k = 100; k > 0; k--)
                {
                    lineSeg.Points.Add(new Point(rand.Next(0, 1000), rand.Next(0, 1000)));
                }
                pathFig = new PathFigure()
                {
                    StartPoint = startPos,
                };
                pathFig.Segments.Add(lineSeg);
                pathGeo.Figures.Add(pathFig);
                pointAnim = new();

                pointAnim.PathGeometry = pathGeo;
                pointAnim.Duration = TimeSpan.FromSeconds(200);
                pointAnim.FillBehavior = FillBehavior.HoldEnd;
                ElemList.Add(pointAnim);
            }
        }
    }
}