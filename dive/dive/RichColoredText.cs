using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dive
{
    public class RichColoredText
    {
        public RichColoredText() { }
        public RichColoredText(string text_, System.Drawing.Color color_) {
            this.text = text_;
            this.color = color_;
        }
        public string text;
        public System.Drawing.Color color;
    }
}
