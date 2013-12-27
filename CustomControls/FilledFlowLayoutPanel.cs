using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public class FilledFlowLayoutPanel : FlowLayoutPanel
    {
        public FilledFlowLayoutPanel()
            : base()
        {
            Layout += FilledFlowLayoutPanel_Layout;
            FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        }

        void FilledFlowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            if (Controls.Count <= 0) 
                return;

 	        Controls[0].Dock = DockStyle.None;
            int skip = 1;
            foreach (Control control in Controls)
            {
                if (skip != 0)
                {
                    skip--;
                    continue;
                }
                control.Dock = DockStyle.Top;
            }
            Controls[0].Width = DisplayRectangle.Width - Controls[0].Margin.Horizontal;
        }

        /*private void fLP1_Layout(object sender, LayoutEventArgs e) {  
           fLP1.Controls[0].Dock = DockStyle.None;  
           for (int i = 1; i < fLP1.Controls.Count; i++) {  
            fLP1.Controls[i].Dock = DockStyle.Top;  
           }  
           fLP1.Controls[0].Width =   
        fLP1.DisplayRectangle.Width fLP1.Controls[0].Margin.Horizontal;  
          }  
  
          // Where the flow layout is set up as  
           this.fLP1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;  
           this.fLP1.Size = new System.Drawing.Size(175, 180);  
           this.fLP1.Layout += new System.Windows.Forms.LayoutEventHandler(this.fLP1_Layout); 
        }*/
    }
}
