using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndreasCoroiu.Controls
{
    public class ToggleButton : Button
    {
        public enum ToggleStates : uint
        {
            On = 1, Off = 0
        }

        public event EventHandler ToggleOn;
        public event EventHandler ToggleOff;

        [Category("Appearance")]
        public string TextOff { get; set; }
        [Category("Appearance")]
        public string TextOn { get; set; }
        [Category("Data")] [SettingsBindable(true)]
        public ToggleStates ToggleState { get; set; }

        private TablessTabControl _view;
        [Category("Data")]
        public TablessTabControl View
        {
            get { return _view; }
            set
            {
                if (value != null)
                {
                    if (_view != null)
                        this._view.SelectedIndexChanged -= OnViewSelectedIndexChanged;
                    this._view = value;
                    this._view.SelectedIndexChanged += OnViewSelectedIndexChanged;
                }
            }
        }

        public override string Text
        {
            get
            {
                switch (ToggleState)
                {
                    case ToggleStates.Off:
                        return TextOff;
                    case ToggleStates.On:
                        return TextOn;
                    default:
                        return "No state";
                }
            }
        }

        public ToggleButton()
        {
            this.TextOff = "Off";
            this.TextOn = "On";
            this.ToggleState = ToggleStates.Off;
        }

        public ToggleButton(string offText, string onText)
        {
            TextOn = offText;
            TextOff = onText;
        }

        protected void OnViewSelectedIndexChanged(Object sender, EventArgs e)
        {
            ToggleState = (ToggleStates)_view.SelectedIndex;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            switch (ToggleState)
            {
                case ToggleStates.Off:
                    ToggleState = ToggleStates.On;
                    if (ToggleOn != null) ToggleOn(this, e);
                    break;
                case ToggleStates.On:
                    ToggleState = ToggleStates.Off;
                    if (ToggleOff != null) ToggleOff(this, e);
                    break;
            }
            base.Invalidate();

            if (_view != null)
                _view.SelectedIndex = (int) ToggleState;
        }
    }
}
