using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Adom_Save_Manager
{
	public partial class MainWindow
	{

		/// <summary>
		/// Zwraca listę Save'ów
		/// </summary>
		/// <returns></returns>
		private ListBox Get_ListSaveFiles()
		{
			ListBox item_List = new ListBox();

			foreach (string item in Get_AdomSaveFiles_SVG)
			{
				item_List.Items.Add( Path.GetFileNameWithoutExtension( item ) );
			}

			return item_List;
		}

		private ListBox Get_ListProfileSlots()
		{
			ListBox item_List = new ListBox();

			if (!isProfileExist( Selected_Name ))
				return item_List;

			string CreationTime = "";

			foreach (string item in Get_Profile_Files_TXT)
			{
				if (check_ShowDateSlot.Checked)
					CreationTime = $"[{File.GetLastWriteTime( Get_Profile_Files_SVG[Get_Profile_Files_TXT.ToList().IndexOf( item )] )}] ";

				item_List.Items.Add( $"{CreationTime}{File.ReadAllText( item )}" );
			}
			return item_List;

		}

		private bool isProfileExist( string name )
		{
			return name == null ? false : Directory.Exists( Path.Combine( path_profileDirectory, name ) );
		}

		private void CreateProfile( string name )
		{
			LogInfo( $"Tworzenie profilu: {name}" );
			// Create Profile Folder
			if (!Directory.Exists( Path.Combine( path_profileDirectory, name ) ))
			{
				Directory.CreateDirectory( Path.Combine( path_profileDirectory, name ) );
				Log( "	Stworzono folder profilu" );
			}

			BackupToDefault();
		}

		private void RefreshProfileList()
		{
			if (!isProfileExist( Selected_Name ))
			{
				list_Slots.Items.Clear();
				return;
			}

			list_Slots.Items.Clear();
			list_Slots.Items.AddRange( Get_ListProfileSlots().Items );

			for (int i = 1; i < list_Slots.Items.Count; i++)
			{
				Log( $"	Znaleziono slot: {list_Slots.Items[i]}" );
			}

			if (list_Slots.Items.Count <= 1)
			{
				Log( "	Brak slotów gry" );
			}
		}


		#region Backup/Restore

		private void BackupToDefault()
		{
			// Sprawdzenie czy wsztstkie pliki ok
			File.Copy( Adom_Path_SVG, Get_Profile_SlotDefault_SVG, true );

			if (File.Exists( Adom_Path_BAK ))
				File.Copy( Adom_Path_BAK, Get_Profile_SlotDefault_BAK, true );

			File.WriteAllText( Get_Profile_SlotDefault_TXT, "[Default]" );

			Log( "	Zapisono w slocie 'Default'" );

			int lastindex = list_Slots.SelectedIndex;
			RefreshProfileList();
			list_Slots.SelectedIndex = lastindex;
		}
		private void RestoreFromDefault()
		{
			File.Copy( Get_Profile_SlotDefault_SVG, Adom_Path_SVG, true );

			if (File.Exists( Get_Profile_SlotDefault_BAK ))
				File.Copy( Get_Profile_SlotDefault_BAK, Adom_Path_BAK, true );

			Log( "	Przywrócono ze slotu 'Default'" );
		}

		private void BackupToProfile()
		{
			string pathToProfile_SVG = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".svg" ));
			string pathToProfile_BAK = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".bak" ) );
			string pathToProfile_TXT = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".txt" ) );

			if (currentSlotSelected == 0)
			{
				LogWarning( "Lamusie od zapisywania do [default] masz inny przycisk!!!" );
				BackupToDefault();
				return;
			}

			File.Copy( Adom_Path_SVG, pathToProfile_SVG, true );

			if (File.Exists( Adom_Path_BAK ))
				File.Copy( Adom_Path_BAK, pathToProfile_BAK, true );


			Log( $"	Zapisono w slocie '{File.ReadAllText( pathToProfile_TXT )}'" );

			int lastindex = list_Slots.SelectedIndex;
			RefreshProfileList();
			list_Slots.SelectedIndex = lastindex;
		}
		private void RestoreFromProfile()
		{
			string pathToProfile_SVG = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".svg" ));
			string pathToProfile_BAK = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".bak" ) );
			string pathToProfile_TXT = Path.Combine( Profile_Path, FileName( currentSlotSelected, ".txt" ) );

			if (currentSlotSelected == 0)
			{
				LogWarning( "Lamusie od wczytywania z [default] masz inny przycisk!!!" );
				RestoreFromDefault();
				return;
			}

			File.Copy( pathToProfile_SVG, Adom_Path_SVG, true );

			if (File.Exists( pathToProfile_BAK ))
				File.Copy( pathToProfile_BAK, Adom_Path_BAK, true );

			Log( $"	Przywrócono ze slotu '{File.ReadAllText( pathToProfile_TXT )}'" );
		}


		private void AutoBackup()
		{
			if (check_AutoBackupDefault.Checked)
				BackupToDefault();

			if (check_AutoBackupProfile.Checked)
				BackupToProfile();
		}
		private void AutoRestore()
		{
			if (check_AutoRestoreDefault.Checked)
				RestoreFromDefault();

			if (check_AutoRestoreProfile.Checked)
				RestoreFromProfile();
		}

		private void BackupToProfileNew()
		{
			int newIndex = list_Slots.Items.Count;

			string pathToProfile_SVG = Path.Combine( Profile_Path, FileName( newIndex, ".svg" ) );
			string pathToProfile_BAK = Path.Combine( Profile_Path, FileName( newIndex, ".bak" ) );
			string pathToProfile_TXT = Path.Combine( Profile_Path, FileName( newIndex, ".txt" ));

			File.Copy( Adom_Path_SVG, pathToProfile_SVG, true );

			if (File.Exists( Adom_Path_BAK ))
				File.Copy( Adom_Path_BAK, pathToProfile_BAK, true );

			File.WriteAllText( pathToProfile_TXT, "Slot" );

			LogInfo( "Stworzono nowy slot" );
			RefreshProfileList();
			Update_All_State();
			list_Slots.SelectedIndex = list_Slots.Items.Count - 1;
			Log( "" );
		}

		#endregion

		private void CheckProfileFolderValidation()
		{
			// path_AdomFolder
			Log( $"Validating: {path_AdomFolder}" );
			if (Directory.Exists( path_AdomFolder ))
				LogInfo( "	Result: OK" );
			else
			{
				LogError( "	Result: False" );
				Log( "	Folder is not exist!" );
			}

			// adom_dat
			Log( $"Validating: {Path.Combine( path_AdomFolder, "adom_dat" )}" );
			if (Directory.Exists( Path.Combine( path_AdomFolder, "adom_dat" ) ))
				LogInfo( "	Result: OK" );
			else
			{
				LogError( "	Result: False" );
				Log( "	Folder is not exist!" );
			}

			// savedg
			Log( $"Validating: {Path.Combine( path_AdomFolder, "adom_dat", "savedg" )}" );
			if (Directory.Exists( Path.Combine( path_AdomFolder, "adom_dat", "savedg" ) ))
				LogInfo( "	Result: OK" );
			else
			{
				LogError( "	Result: False" );
				Log( "	Folder is not exist!" );
			}

			// savedg_backup
			if (Directory.Exists( Path.Combine( path_AdomFolder, "adom_dat" ) ))
			{
				Log( $"Validating: {Path.Combine( path_AdomFolder, "adom_dat", "savedg_backup" )}" );
				if (Directory.Exists( Path.Combine( path_AdomFolder, "adom_dat", "savedg_backup" ) ))
					LogInfo( "	Result: OK" );
				else
				{
					LogWarning( "	Result: False" );
					Log( "	Profiles directory not exist! Tying to create it." );
					Directory.CreateDirectory( path_profileDirectory );
					if (Directory.Exists( path_profileDirectory ))
					{
						Log( "	Create Profiles folder is done!" );
						LogInfo( "	Result: OK" );
					}
					else
					{
						LogError( "	Result: False" );
						LogError( "Fatal Error!! I can't create folder 'savedg_backup' maybe u try create it for me?" );
					}
				}
			}

		}
		private string FileName( int num )
		{
			return FileName( num, "" );
		}
		private string FileName( int num, string dot )
		{
			return string.Format( "{0:D3}{1}", num, dot );
		}

	}

}
