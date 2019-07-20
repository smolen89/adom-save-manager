using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adom_Save_Manager
{
	public partial class MainWindow
	{
		private int currentSlotSelected;

		#region Game states

		private enum GameState
		{
			isPlaying,
			isDeath,
			isNothing,
			isSaving
		}

		private GameState states = GameState.isNothing;

		private GameState old_states = GameState.isNothing;

		private void OnChangeState( GameState state )
		{

			if (state == GameState.isSaving && old_states == GameState.isPlaying)
			{
				LogInfo( "Zapisałeś? Nie zesraj się" );
				states = GameState.isNothing;
				old_states = GameState.isSaving;
				Thread.Sleep( 300 );
				AutoBackup();
				Log( "Backup zapisany" );
			}
			else if (state == GameState.isPlaying && old_states != GameState.isPlaying)
			{
				Log( "" );
				LogError( "Nakurwiasz węgorza!!!!!!" );
				Log( "" );
				states = GameState.isNothing;
				old_states = GameState.isPlaying;
			}
			else if (state == GameState.isDeath && old_states != GameState.isDeath)
			{
				LogWarning( "[*] A kto umarł ten nie żyje [*]" );
				states = GameState.isNothing;
				old_states = GameState.isDeath;
				AutoRestore();
			}
		}

		private bool CheckStateChange()
		{
			// SVG & BAK	Save Event or Nothing
			if (File.Exists( Adom_Path_SVG ) && File.Exists( Adom_Path_BAK ))
			{
				states = GameState.isSaving;
			}
			// --- & BAK	isPlaying
			else if (!File.Exists( Adom_Path_SVG ) && File.Exists( Adom_Path_BAK ))
			{
				states = GameState.isPlaying;
			}
			// --- & ---	Death event
			else if (!File.Exists( Adom_Path_SVG ) && !File.Exists( Adom_Path_BAK ))
			{
				states = GameState.isDeath;
			}
			// SVG & ---	First save
			else if (File.Exists( Adom_Path_SVG ) && !File.Exists( Adom_Path_BAK ))
			{
				states = GameState.isSaving;
			}
			// ??? & ???
			else
			{
				states = GameState.isNothing;
			}

			if (states != old_states && states != GameState.isNothing)
				return true;
			else
				return false;

		}

		#endregion

		#region Adom save file and path

		/// <summary>
		/// Curent adom save file selected
		/// </summary>
		private string Selected_Name { get; set; }

		private string Adom_Filename_SVG
		{
			get { return Selected_Name + ".svg"; }
		}

		private string Adom_Filename_BAK
		{
			get { return Selected_Name + ".bak"; }
		}

		private string Adom_Path_SVG
		{
			get { return Path.Combine( path_AdomSaveFolder, Adom_Filename_SVG ); }
		}

		private string Adom_Path_BAK
		{
			get { return Path.Combine( path_AdomSaveFolder, Adom_Filename_BAK ); }
		}

		#endregion

		#region Profile files and path

		private string Profile_Path
		{
			get { return string.IsNullOrEmpty( Selected_Name ) ? null : Path.Combine( path_profileDirectory, Selected_Name ); }
		}

		private string Get_Profile_SlotDefault_SVG
		{
			get { return string.IsNullOrEmpty( Profile_Path ) ? null : Path.Combine( Profile_Path, "000.svg" ); }
		}

		private string Get_Profile_SlotDefault_BAK
		{
			get { return string.IsNullOrEmpty( Profile_Path ) ? null : Path.Combine( Profile_Path, "000.bak" ); }
		}

		private string Get_Profile_SlotDefault_TXT
		{
			get { return string.IsNullOrEmpty( Profile_Path ) ? null : Path.Combine( Profile_Path, "000.txt" ); }
		}

		private int Get_ProfileSlotsCount
		{
			get
			{
				return Directory.GetFiles( Profile_Path, "*.svg" ).Length;
			}
		}

		private string[] Get_Profile_Files_SVG
		{
			get { return Directory.EnumerateFiles( Profile_Path, "*.svg" ).ToArray(); }
		}

		private string[] Get_Profile_Files_BAK
		{
			get { return Directory.EnumerateFiles( Profile_Path, "*.bak" ).ToArray(); }
		}

		private string[] Get_Profile_Files_TXT
		{
			get { return Directory.EnumerateFiles( Profile_Path, "*.txt" ).ToArray(); }
		}

		#endregion

		#region Path files and folders

		/// <summary>
		/// Ścieżka folderu Moje Dokumenty
		/// </summary>
		private string path_MyDocuments
		{
			get { return Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ); }
		}

		/// <summary>
		/// Ścieżka folderu Adom w Moich dokumentach
		/// </summary>
		private string path_AdomFolder
		{
			get { return Path.Combine( path_MyDocuments, "ADOM" ); }
		}

		/// <summary>
		/// Ścieżka do Adom plik EXE do uruchomienia gry
		/// </summary>
		private string path_AdomExeFile
		{
			//TODO AdomExeRun
			get { return ""; }
		}

		/// <summary>
		/// Ścieżka do folderu zapisu Adoma 'Adom/adom_dat/savedg/'
		/// </summary>
		private string path_AdomSaveFolder
		{
			// TODO jeśli sam nie znajdzie folderu zapisu trzeba będzie znaleźć go ręcznie!!!
			get { return Path.Combine( Path.Combine( path_AdomFolder, "adom_dat" ), "savedg" ); }
		}

		/// <summary>
		/// Ścieżka do zapisywania profili 'Adom/adom_dat/savedg_backup'
		/// </summary>
		private string path_profileDirectory
		{
			get { return Path.Combine( Path.Combine( path_AdomFolder, "adom_dat" ), "savedg_backup" ); }
		}

		/// <summary>
		/// zwraca wszystkie pliki z folderu zapisu Adoma
		/// </summary>
		private string[] Get_AdomSaveFiles
		{
			get { return Directory.GetDirectories( path_AdomSaveFolder ); }
		}

		/// <summary>
		/// Zwraca wszystkie pliki *.svg z folderu zapisu Adoma
		/// </summary>
		private string[] Get_AdomSaveFiles_SVG
		{
			get { return Directory.EnumerateFiles( path_AdomSaveFolder, "*.svg" ).ToArray(); }
		}

		/// <summary>
		/// Zwraca wszystkie pliki *.bak z folderu zapisu Adoma
		/// </summary>
		private string[] Get_AdomSaveFiles_BAK
		{
			get { return Directory.EnumerateFiles( path_AdomSaveFolder, "*.bak" ).ToArray(); }
		}

		#endregion

	}
}
