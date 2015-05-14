using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Layout.MDS;
using Color = Microsoft.Msagl.Drawing.Color;
using Label = Microsoft.Msagl.Drawing.Label;
using MouseButtons = System.Windows.Forms.MouseButtons;
using Node = Microsoft.Msagl.Core.Layout.Node;
using Point = Microsoft.Msagl.Core.Geometry.Point;

namespace Gantt_CSharp
{
	public partial class CFormGantt : Form
	{
		private System.Windows.Forms.PropertyGrid propertyGrid1;

		public CFormGantt()
		{
			InitializeComponent();
			CreateGraph();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		//TODO GViewerOnMouseMove
		void CreateGraph()
		{
			Graph rGraph_Drawing = new Graph("graph");
			//graph.LayoutAlgorithmSettings=new MdsLayoutSettings();
			gViewer.BackColor = System.Drawing.Color.FromArgb(10, System.Drawing.Color.Red);
			ICurve rICurve_Rectangle = CurveFactory.CreateRectangle(10, 100, new Point());
			//Node rNode_Start = new Node(rICurve_Rectangle, "Start");
			//Microsoft.Msagl.Drawing.Node rNode_Drawing = new Microsoft.Msagl.Drawing.Node()
			string sStart = "Start";
			string sAS1 = "Arbeitsschritt 1";
			string sAS2 = "Arbeitsschritt 2";
			string sEnde = "Ende";
			Microsoft.Msagl.Drawing.Node rNode_Drawing_Start = new Microsoft.Msagl.Drawing.Node(sStart);
			Microsoft.Msagl.Drawing.Node rNode_Drawing_AS1 = new Microsoft.Msagl.Drawing.Node(sAS1);
			Microsoft.Msagl.Drawing.Node rNode_Drawing_AS2 = new Microsoft.Msagl.Drawing.Node(sAS2);
			Microsoft.Msagl.Drawing.Node rNode_Drawing_Ende = new Microsoft.Msagl.Drawing.Node(sEnde); 

			rGraph_Drawing.AddEdge(sStart, sAS1);
			rGraph_Drawing.AddEdge(sAS1, sAS2);
			rGraph_Drawing.AddEdge(sAS2, sEnde);

			rNode_Drawing_Start.Attr.Shape = Shape.Box;
			//TODO Nodes from geometry - to set rectangle length and width
			//TODO Some edges

			rGraph_Drawing.AddNode(rNode_Drawing_Start);
			//TODO Orientationg - horizontal Left to Right
			rGraph_Drawing.LayoutAlgorithmSettings = new SugiyamaLayoutSettings();
			gViewer.Graph = rGraph_Drawing;
			this.propertyGrid1.SelectedObject = rGraph_Drawing;
		}
	}
}
