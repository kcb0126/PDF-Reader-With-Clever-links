using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace View
{
    public partial class Popup : UserControl
    {
        public Popup()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(122, 139, 235), Color.FromArgb(193, 201, 243), -45F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private string _comment;

        public string PopupPath;

        public string Comment { get
            {
                return _comment;
            }
            set
            {
                _comment = value ?? "";
                rchComment.Text = "";
                if(_comment == "")
                {
                    return;
                }
                int lastSlash = PopupPath.LastIndexOf('\\');
                string popupDir = PopupPath.Substring(0, lastSlash + 1);
                string[] lines = _comment.Split('\n');
                foreach(var line in lines)
                {
                    var colonPos = line.IndexOf(':');
                    if(colonPos == -1)
                    {
                        string content = line;
                        rchComment.Select(rchComment.Text.Length, 0);
                        rchComment.SelectionFont = new Font(rchComment.SelectionFont, FontStyle.Regular);
                        rchComment.SelectedText = content + "\n\n";
                    }
                    else
                    {
                        string name = line.Substring(0, colonPos);
                        string content = line.Substring(colonPos + 1);

                        if(name.ToUpper() == "IMAGE")
                        {
                            picImage.Load(popupDir + content.Trim());

                            continue;
                        }

                        rchComment.Select(rchComment.Text.Length, 0);
                        rchComment.SelectionFont = new Font(rchComment.SelectionFont, FontStyle.Bold);
                        rchComment.SelectedText = name + ":\n";

                        rchComment.Select(rchComment.Text.Length, 0);
                        rchComment.SelectionFont = new Font(rchComment.SelectionFont, FontStyle.Regular);
                        rchComment.SelectedText = content + "\n\n";
                    }
                }
                if(rchComment.Text.Length >= 2)
                {
                    rchComment.Text.Remove(rchComment.Text.Length - 2, 2);
                }
            }
        }

        private void rchComment_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
    }
}
