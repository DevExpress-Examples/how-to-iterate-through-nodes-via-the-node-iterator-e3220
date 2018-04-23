Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace NodeTraversing
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = Stuff.GetStuff()
		End Sub

		Private Sub SmartExpandNodes(ByVal minChildCount As Integer)
			Dim nodeIterator As New TreeListNodeIterator(treeListView.Nodes, True)
			Do While nodeIterator.MoveNext()
				nodeIterator.Current.IsExpanded = nodeIterator.Current.Nodes.Count >= minChildCount
			Loop
		End Sub

		Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			SmartExpandNodes(4)
		End Sub
	End Class
End Namespace
