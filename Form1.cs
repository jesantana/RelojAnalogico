using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace nuevaprueba
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		private readonly int seg,min,hor;
		private double angse,angmi,angho;
		private System.Windows.Forms.Label label1;
		private Color cman;

		public Form1()
		{
			cman=Color.Blue;
			InitializeComponent();
			if(pb.Width!=pb.Height)pb.Height=pb.Width;
			seg=(pb.Width/2)-5;
			min=(pb.Width/2)-6;
			hor=(pb.Width/2)-8;
			DateTime d=DateTime.Now;
			int hora;			
			if(d.Hour>12)hora=d.Hour-12;
			else if(d.Hour==0)hora=12;
            else hora=d.Hour;		
			angse=d.Second*6;
			angmi=(d.Minute*6+angse/60)%360;
			angho=(hora*30+angmi/12)%360;
			
			
			
		}

		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pb = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pb
			// 
			this.pb.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.pb.Location = new System.Drawing.Point(32, 24);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(180, 180);
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Paint);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(232, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.pb});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
		public Color ColorManecillas
		{
			get {return this.cman;}
			set{cman=value;}
		}

		protected double ARad(double anggrad){
		return anggrad*Math.PI/180;
		
		}

		protected void DibujaManec(int largo,double angulo,Graphics g,Pen p,int gordo)
		{
			int cx=pb.Width/2;
			int cy=pb.Height/2;
			p.Width=gordo;
			g.DrawLine(p,cx,cy,(float)(cx+(Math.Sin(ARad(angulo))*largo)),(float)(cy-(Math.Cos(ARad(angulo))*largo)));
		}
		private void pb_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush sb=new SolidBrush(Color.Gray);
			Graphics g=e.Graphics;
			g.FillEllipse(sb,0,0,pb.Width,pb.Height);		
			sb.Color=Color.LightBlue;
			g.FillEllipse(sb,5,5,pb.Width-10,pb.Height-10);
			sb.Color=Color.Red;
			g.FillEllipse(sb,(pb.Width/2)-5,(pb.Height/2)-5,10,10);
			this.DibujaNumeros(g);
			Pen p=new Pen(this.cman);
			DibujaManec(this.seg,this.angse,g,p,1);
			DibujaManec(this.min,this.angmi,g,p,2);
			DibujaManec(this.hor,this.angho,g,p,5);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			double aux;
			this.angse=(angse+6)%360;
			aux=0.1;
			this.angmi=(angmi+(aux))%360;
			aux=Math.Pow(120,-1);
			this.angho=(angho+(aux))%360;
			pb.Refresh();
			
		}
		public void DibujaNumeros(Graphics g)
		{
		int ang=30;
			int largo=(pb.Width-20)/2;
			int cx=pb.Width/2;
			int cy=pb.Height/2;
			Font f=new Font(FontFamily.GenericSansSerif,12);
			SolidBrush sb=new SolidBrush(Color.Blue);
			for(int i=1;i<13;i++,ang+=30)
			
			g.DrawString(i.ToString(),f,sb,(float)(cx+(Math.Sin(ARad(ang))*largo)-5),(float)(cy-(Math.Cos(ARad(ang))*largo)-5));
		}
	
	}
}
