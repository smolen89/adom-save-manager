using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adom_Save_Manager.Utilities;

namespace Adom_Save_Manager
{
	public partial class MainWindow
	{
		private void InitLog()
		{
			txtLog.Clear();
			txtLog.AppendText( "------------------------------------------------------------", Color.Green, true );
			txtLog.AppendText( "Ancient Domains Of Mystery - Save Manager", Color.Green, true );
			txtLog.AppendText( "------------------------------------------------------------", Color.Green, true );
		}
		public void Log()
		{
			txtLog.AppendText( "", Color.Gray, true );
		}
		public void LogSeparate()
		{
			txtLog.AppendText( "------------------------------------------------------------", Color.Gray, true );
		}
		public void Log( string message )
		{
			txtLog.AppendText( message, Color.Gray, true );
		}
		public void LogWarning( string message )
		{
			txtLog.AppendText( message, Color.Yellow, true );
		}
		public void LogError( string message )
		{
			txtLog.AppendText( message, Color.Red, true );
		}
		public void LogInfo(string message )
		{
			txtLog.AppendText( message, Color.Green, true );
		}
	}
}
