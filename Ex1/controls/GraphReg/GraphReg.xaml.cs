﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex1.controls.GraphReg
{
    /// <summary>
    /// Interaction logic for GraphReg.xaml
    /// </summary>
    public partial class GraphReg : UserControl
    {
        Polyline l;
        List<Point> p;
        public GraphReg()
        {
            InitializeComponent();
            l = new Polyline();
            PointCollection po = new PointCollection();
            po.Add(new Point(0, 0));
            po.Add(new Point(6, 6));
            l.Points = po;
            p = new List<Point>();
            p.Add(new Point(50, 50));
            DrawGraph();
        }
        // Draw a simple graph.
        private void DrawGraph()
        {
            const double margin = 10;
            double xmin = margin;
            double xmax = canGraph.Width - margin;
            double ymin = margin;
            double ymax = canGraph.Height - margin;
            const double step = 10;

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(canGraph.Width, ymax)));
            for (double x = xmin + step;
                x <= canGraph.Width - step; x += step)
            {
                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            canGraph.Children.Add(xaxis_path);

            // Make the Y ayis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(
                new Point(xmin, 0), new Point(xmin, canGraph.Height)));
            for (double y = step; y <= canGraph.Height - step; y += step)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y),
                    new Point(xmin + margin / 2, y)));
            }

            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;

            canGraph.Children.Add(yaxis_path);

            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue };
            Random rand = new Random();
            l.StrokeThickness = 1;
            l.Stroke = brushes[0];
            canGraph.Children.Add(l);
            // Display ellipses at the points.
            const float width = 4;
            const float radius = width / 2;
            foreach (Point point in p)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.SetValue(Canvas.LeftProperty, point.X - radius);
                ellipse.SetValue(Canvas.TopProperty, point.Y - radius);
                ellipse.Fill = brushes[0];
                ellipse.Stroke = brushes[0];
                ellipse.StrokeThickness = 1;
                ellipse.Width = width;
                ellipse.Height = width;
                canGraph.Children.Add(ellipse);
            }
            /*
            for (int data_set = 0; data_set < 3; data_set++)
            {
                int last_y = rand.Next((int)ymin, (int)ymax);

                PointCollection points = new PointCollection();
                for (double x = xmin; x <= xmax; x += step)
                {
                    last_y = rand.Next(last_y - 10, last_y + 10);
                    if (last_y < ymin) last_y = (int)ymin;
                    if (last_y > ymax) last_y = (int)ymax;
                    points.Add(new Point(x, last_y));
                }

                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 1;
                polyline.Stroke = brushes[data_set];
                polyline.Points = points;

                canGraph.Children.Add(polyline);
            }
            */
        }
       
    }
}