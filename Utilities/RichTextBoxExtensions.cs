using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adom_Save_Manager.Utilities
{
	public static class RichTextBoxExtensions
	{
		public static void AppendText( this RichTextBox box, string text, Color color, bool AddNewLine = true )
		{
			box.SuspendLayout();
			box.SelectionColor = color;
			box.AppendText( AddNewLine
				? $"{text}{Environment.NewLine}"
				: text );
			box.ScrollToCaret();
			box.ResumeLayout();
		}
	}
}
