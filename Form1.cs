using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adom_Save_Manager.Utilities;
using Microsoft.VisualBasic;


namespace Adom_Save_Manager
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			InitLog();
			size_WindowLogOff = new Size( 730, 459 - txtLog.Height );
		}
		private Size size_WindowLogOn = new Size(730, 459);
		private Size size_WindowLogOff;
		private const string AppVersion = "0.1.0";

		private void SetWindowSize()
		{
			if (check_ShowLog.Checked)
			{
				this.Size = size_WindowLogOn;
				txtLog.Visible = true;
			}
			else
			{
				this.Size = size_WindowLogOff;
				txtLog.Visible = false;
			}
			Properties.Settings.Default.LogWindow = txtLog.Visible;
			Properties.Settings.Default.Save();
		}

		private void MainWindow_Load( object sender, EventArgs e )
		{
			CheckProfileFolderValidation();

			Text = string.Format( $"Ancient Domains Of Mystery - Save Manager v{AppVersion}" );

			check_ShowLog.Checked = Properties.Settings.Default.LogWindow;
			check_ShowDateSlot.Checked = Properties.Settings.Default.ShowDateSlot;

			SetWindowSize();
			LogInfo( "Aplikacja załadowana" );
			LogSeparate();
			btn_AdomSaveFileRefresh.PerformClick();
			Update_All_State();

			Timer.Enabled = true;

		}

		//***

		private void btn_AdomSaveFileRefresh_Click( object sender, EventArgs e )
		{
			LogInfo( "	Odświerzanie listy zapisanych stanów gry:" );

			list_AdomSaveFiles.Items.Clear();
			list_AdomSaveFiles.Items.AddRange( Get_ListSaveFiles().Items );

			foreach (object item in list_AdomSaveFiles.Items)
			{
				if (!isProfileExist( item as string ))
					Log( $"	Znaleziono plik zapisu bez profilu: {list_AdomSaveFiles.GetItemText( item )}" );
				else
					Log( $"	Znaleziono plik zapisu: {list_AdomSaveFiles.GetItemText( item )}" );
			}

			// Enumerate all profiles from folder
			foreach (string AllProfiles in Directory.EnumerateDirectories( path_profileDirectory ))
			{
				// We need directory name without path
				string castString = Path.GetFileName(AllProfiles);

				// check who is not in adom list and add it
				if (!list_AdomSaveFiles.Items.Contains( castString ))
				{
					Log( $"	Znaleziono profil bez pliku zapisu: {castString}" );
					list_AdomSaveFiles.Items.Add( castString );
				}
			}

			if (list_AdomSaveFiles.Items.Count <= 0)
			{
				list_AdomSaveFiles.Enabled = false;
				Log( "	(Lista jest pusta)" );
			}
			Log( "" );
		}

		private void btn_CreateProfile_Click( object sender, EventArgs e )
		{
			if (!isProfileExist( Selected_Name ))
			{
				// Create Profile
				CreateProfile( Selected_Name );
			}
			else
			{
				// Remove Profile
				DialogResult dr = MessageBox.Show(
					$"Czy chcesz skasować profil '{(list_Slots.SelectedItem as string)}'?",
					"Kasowanie",
					MessageBoxButtons.YesNo,MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2);

				if (dr.ToString() == "Yes")
				{
					Directory.Delete( Path.Combine( path_profileDirectory, Selected_Name ), true );
					LogInfo( $"Skasowano profil: {Selected_Name}" );
					Log( "" );
					btn_AdomSaveFileRefresh.PerformClick();
				}
			}
			Update_All_State();
		}

		private void btn_BackupDefault_Click( object sender, EventArgs e )
		{
			BackupToDefault();
		}

		private void btn_RestoreDefault_Click( object sender, EventArgs e )
		{
			RestoreFromDefault();
		}

		private void btn_BackupNew_Click( object sender, EventArgs e )
		{
			BackupToProfileNew();
		}

		private void btn_BackupProfile_Click( object sender, EventArgs e )
		{
			BackupToProfile();
		}

		private void btn_RestoreProfile_Click( object sender, EventArgs e )
		{
			RestoreFromProfile();
		}

		private void btn_RemoveSlot_Click( object sender, EventArgs e )
		{
			// jeżeli jest zaznaczony default
			if (currentSlotSelected < 1)
			{
				LogError( "Slotu 'Default' nie można skasować ręcznie!!!" );
				return;
			}

			DialogResult dr = MessageBox.Show(
				$"Czy chcesz skasować slot '{(list_Slots.SelectedItem as string)}'?",
				"Kasowanie",
				MessageBoxButtons.YesNo,MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);

			if (dr.ToString() == "Yes")
			{
				string tempName = File.ReadAllText( Path.Combine( Profile_Path, FileName( currentSlotSelected, ".txt" ) ) );
				int tempInt = Get_Profile_Files_TXT.Length - 1;

				// jeżeli jest zaznaczony ostatni plik to nie musi pozostałych przenosić
				if (currentSlotSelected < (list_Slots.Items.Count - 1))
				{
					for (int Loop = currentSlotSelected; Loop < tempInt; Loop++)
					{
						Log( Loop.ToString() );
						File.Copy( Path.Combine( Profile_Path, FileName( Loop + 1, ".txt" ) ),
								   Path.Combine( Profile_Path, FileName( Loop, ".txt" ) ), true );

						File.Copy( Path.Combine( Profile_Path, FileName( Loop + 1, ".svg" ) ),
								   Path.Combine( Profile_Path, FileName( Loop, ".svg" ) ), true );

						if (File.Exists( Path.Combine( Profile_Path, FileName( Loop + 1, ".bak" ) ) ))
						{
							File.Copy( Path.Combine( Profile_Path, FileName( Loop + 1, ".bak" ) ),
									   Path.Combine( Profile_Path, FileName( Loop, ".bak" ) ), true );
						}
						else
							File.Delete( Path.Combine( Profile_Path, FileName( Loop, ".bak" ) ) );
					}
				}
				File.Delete( Path.Combine( Profile_Path, FileName( tempInt, ".txt" ) ) );
				File.Delete( Path.Combine( Profile_Path, FileName( tempInt, ".svg" ) ) );
				File.Delete( Path.Combine( Profile_Path, FileName( tempInt, ".bak" ) ) );
				LogInfo( $"Skasowano slot: {tempName}" );

				Log( "" );
				RefreshProfileList();
			}
		}

		//***

		private void list_AdomSaveFiles_SelectedValueChanged( object sender, EventArgs e )
		{
			if (list_AdomSaveFiles.SelectedItem == null)
				return;

			Selected_Name = list_AdomSaveFiles.SelectedItem.ToString();

			bool isAdomFileExist = Get_AdomSaveFiles_BAK.Contains( Path.Combine( path_AdomSaveFolder, Selected_Name + ".bak" ) );
			bool isProfile = isProfileExist( Selected_Name );

			LogInfo( $"Zaznaczono pozycję: {Selected_Name}" );
			Log( string.Format( "	Profil: {0}", isProfile ? "Istnieje" : "Nie istnieje" ) );
			Log( string.Format( "	Adom Save: {0}", isAdomFileExist ? "Istnieje" : "Nie istnieje" ) );

			RefreshProfileList();
			Log( "" );
			Update_All_State();
		}

		private void list_Slots_SelectedValueChanged( object sender, EventArgs e )
		{
			currentSlotSelected = list_Slots.SelectedIndex;
			this.Text = "Selected: " + currentSlotSelected;
			Update_All_State();
		}

		private void list_Slots_DoubleClick( object sender, EventArgs e )
		{
			if (list_Slots.SelectedIndex == 0)
			{
				LogError( "Nie po to jest nazwane default, byś mógł ot tak zmienić nazwę!" );
				return;
			}

			string oldName = File.ReadAllText(Get_Profile_Files_TXT[list_Slots.SelectedIndex]);

			string newName = Interaction.InputBox( "Wpisz nową nazwę: ", "Zmiana nazwy", oldName );

			if (string.IsNullOrEmpty( newName ))
				return;

			File.WriteAllText( Path.Combine( Profile_Path, FileName( currentSlotSelected, ".txt" ) ), newName );

			LogInfo( $"Zmieniono nazwę slotu '{oldName}' na '{newName}" );

			Log( "" );
			int lastindex = list_Slots.SelectedIndex;
			RefreshProfileList();
			list_Slots.SelectedIndex = lastindex;
		}

		//***

		private void check_ShowLog_CheckStateChanged( object sender, EventArgs e )
		{
			SetWindowSize();
		}

		private void check_ShowDateSlot_CheckedChanged( object sender, EventArgs e )
		{
			Properties.Settings.Default.ShowDateSlot = check_ShowDateSlot.Checked;
			int lastindex = list_Slots.SelectedIndex;
			RefreshProfileList();
			list_Slots.SelectedIndex = lastindex;
		}

		private void check_AutoRestoreDefault_CheckedChanged( object sender, EventArgs e )
		{
			if (check_AutoRestoreDefault.Checked)
			{
				check_AutoRestoreProfile.Checked = false;
			}

		}

		private void check_AutoRestoreProfile_CheckedChanged( object sender, EventArgs e )
		{
			if (check_AutoRestoreProfile.Checked)
			{
				check_AutoRestoreDefault.Checked = false;
			}

		}
		//***

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (list_AdomSaveFiles.SelectedItems.Count > 0 && CheckStateChange())
				OnChangeState( states );

		}

		private void Update_All_State()
		{
			// Profil nie istnieje
			if (!isProfileExist( Selected_Name ))
			{
				// Create Profile
				btn_CreateProfile.Text = "Create Profile";
				box_Profile.Enabled = false;
			}
			else
			{
				// Remove Profile
				btn_CreateProfile.Text = "Remove Profile";
				box_Profile.Enabled = true;
			}

			// są sloty
			if (list_Slots.Items.Count > 1)
			{
				list_Slots.Enabled = true;
				btn_RemoveSlot.Enabled = true;
				btn_RestoreProfile.Enabled = true;
				btn_BackupProfile.Enabled = true;
				check_AutoBackupProfile.Enabled = true;
				check_AutoRestoreProfile.Enabled = true;
			}
			else
			{
				list_Slots.Enabled = false;
				btn_RemoveSlot.Enabled = false;
				btn_RestoreProfile.Enabled = false;
				btn_BackupProfile.Enabled = false;
				check_AutoBackupProfile.Enabled = false;
				check_AutoBackupProfile.Checked = false;
				check_AutoRestoreProfile.Checked = false;
				check_AutoRestoreProfile.Enabled = false;
			}

			// plik w adomFiles nie istnieje (profil tak)
			// can restore from def/slot
			// can remove
			if (!Get_AdomSaveFiles_BAK.Contains( Path.Combine( path_AdomSaveFolder, Selected_Name + ".bak" ) ))
			{
				btn_BackupDefault.Enabled = false;
				btn_BackupNew.Enabled = false;
				btn_BackupProfile.Enabled = false;
			}
			else
			{
				btn_BackupDefault.Enabled = true;
				btn_BackupNew.Enabled = true;
			}


		}


	}
}
