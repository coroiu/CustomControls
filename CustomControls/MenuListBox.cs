using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndreasCoroiu.Controls
{
    public class MenuListBox : ListBox
    {
        private TablessTabControl _view;
        public TablessTabControl View
        {
            get { return _view; }
            set
            {
                if (_view != null)
                    this._view.SelectedIndexChanged -= OnViewSelectedIndexChanged;
                this._view = value;
                this._view.SelectedIndexChanged += OnViewSelectedIndexChanged;
            }
        }

        private TextRenderingHint _hint = TextRenderingHint.ClearTypeGridFit;
        public TextRenderingHint TextRenderingHint
        {
            get { return this._hint; }
            set { this._hint = value; }
        }

        public MenuListBox()
        {
            DrawItem += Draw;
            this.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 8);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (_view != null) 
                _view.SelectedIndex = SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }

        protected void OnViewSelectedIndexChanged(Object sender, EventArgs e)
        {
            SelectedIndex = _view.SelectedIndex;
        }

        void Draw(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          Brushes.LightCyan : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.TextRenderingHint = _hint;
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                     new SolidBrush(ForeColor), e.Bounds, StringFormat.GenericDefault);
        }

        public override DrawMode DrawMode
        {
            get
            {
                return System.Windows.Forms.DrawMode.OwnerDrawFixed;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return Color.Black;
            }
        }
    }
}
