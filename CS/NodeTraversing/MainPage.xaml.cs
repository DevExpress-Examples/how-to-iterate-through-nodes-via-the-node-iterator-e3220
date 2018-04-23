using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;

namespace NodeTraversing {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = Stuff.GetStuff();
        }

        private void SmartExpandNodes(int minChildCount) {
            TreeListNodeIterator nodeIterator = new TreeListNodeIterator(treeListView.Nodes, true);
            while (nodeIterator.MoveNext())
                nodeIterator.Current.IsExpanded = nodeIterator.Current.Nodes.Count >= minChildCount;
        }

        private void grid_Loaded(object sender, RoutedEventArgs e) {
            SmartExpandNodes(4);
        }
    }
}
