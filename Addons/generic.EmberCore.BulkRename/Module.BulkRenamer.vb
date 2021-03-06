﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports EmberAPI

Public Class BulkRenamerModule
    Implements Interfaces.GenericModule

#Region "Delegates"

    Public Delegate Sub Delegate_SetToolsStripItem(value As System.Windows.Forms.ToolStripItem)
    Public Delegate Sub Delegate_RemoveToolsStripItem(value As System.Windows.Forms.ToolStripItem)
    Public Delegate Sub Delegate_DropDownItemsAdd(value As System.Windows.Forms.ToolStripMenuItem, tsi As System.Windows.Forms.ToolStripMenuItem)

#End Region 'Fields

#Region "Fields"

    Private WithEvents mnuMainToolsRenamer As New System.Windows.Forms.ToolStripMenuItem
    Private MySettings As New _MySettings
    Private WithEvents cmnuTrayToolsRenamer As New System.Windows.Forms.ToolStripMenuItem
    Private _AssemblyName As String = String.Empty
    Private _enabled As Boolean = False
    Private _Name As String = "Renamer"
    Private _setup As frmSettingsHolder
    Private cmnuRenamer_Movies As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuRenamer_Episodes As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuRenamer_Shows As New System.Windows.Forms.ToolStripMenuItem
    Private cmnuSep_Movies As New System.Windows.Forms.ToolStripSeparator
    Private cmnuSep_Episodes As New System.Windows.Forms.ToolStripSeparator
    Private cmnuSep_Shows As New System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmnuRenamerAuto_Movie As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_Movie As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuRenamerAuto_TVEpisode As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_TVEpisode As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuRenamerAuto_TVShow As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmnuRenamerManual_TVShows As New System.Windows.Forms.ToolStripMenuItem

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object)) Implements Interfaces.GenericModule.GenericEvent

    Public Event ModuleEnabledChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer) Implements Interfaces.GenericModule.ModuleSetupChanged

    Public Event ModuleSettingsChanged() Implements Interfaces.GenericModule.ModuleSettingsChanged

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType) Implements Interfaces.GenericModule.ModuleType
        Get
            Return New List(Of Enums.ModuleEventType)(New Enums.ModuleEventType() {Enums.ModuleEventType.AfterEdit_Movie, Enums.ModuleEventType.ScraperMulti_Movie, Enums.ModuleEventType.ScraperSingle_Movie, _
                                                                                   Enums.ModuleEventType.AfterEdit_TVEpisode, Enums.ModuleEventType.ScraperMulti_TVEpisode, Enums.ModuleEventType.ScraperSingle_TVEpisode, _
                                                                                   Enums.ModuleEventType.AfterUpdateDB_TV})
        End Get
    End Property

    Property Enabled() As Boolean Implements Interfaces.GenericModule.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If
        End Set
    End Property

    ReadOnly Property ModuleName() As String Implements Interfaces.GenericModule.ModuleName
        Get
            Return _Name
        End Get
    End Property

    ReadOnly Property ModuleVersion() As String Implements Interfaces.GenericModule.ModuleVersion
        Get
            Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object, ByRef _dbmovie As Structures.DBMovie, ByRef _dbtv As Structures.DBTV) As Interfaces.ModuleResult Implements Interfaces.GenericModule.RunGeneric
        Select Case mType
            Case Enums.ModuleEventType.AfterEdit_Movie
                If MySettings.RenameEdit_Movies AndAlso Not String.IsNullOrEmpty(MySettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Movies) Then
                    Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_refparam, EmberAPI.Structures.DBMovie)
                    Dim BatchMode As Boolean = DirectCast(_params(0), Boolean)
                    Dim ToNFO As Boolean = DirectCast(_params(1), Boolean)
                    Dim ShowErrors As Boolean = DirectCast(_params(2), Boolean)
                    FileFolderRenamer.RenameSingle_Movie(tDBMovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, BatchMode, ToNFO, ShowErrors, True)
                End If
            Case Enums.ModuleEventType.ScraperMulti_Movie
                If MySettings.RenameMulti_Movies AndAlso Master.GlobalScrapeMod.NFO AndAlso (Not String.IsNullOrEmpty(MySettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Movies)) Then
                    'Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_refparam, EmberAPI.Structures.DBMovie)
                    FileFolderRenamer.RenameSingle_Movie(_dbmovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, False, False, False, False)
                End If
            Case Enums.ModuleEventType.ScraperSingle_Movie
                If MySettings.RenameSingle_Movies AndAlso Master.GlobalScrapeMod.NFO AndAlso (Not String.IsNullOrEmpty(MySettings.FoldersPattern_Movies) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Movies)) Then
                    'Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_refparam, EmberAPI.Structures.DBMovie)
                    FileFolderRenamer.RenameSingle_Movie(_dbmovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, False, False, False, True)
                End If
            Case Enums.ModuleEventType.AfterEdit_TVEpisode
                If MySettings.RenameEdit_Episodes AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                    Dim tDBTV As EmberAPI.Structures.DBTV = DirectCast(_refparam, EmberAPI.Structures.DBTV)
                    Dim BatchMode As Boolean = DirectCast(_params(0), Boolean)
                    Dim ToNFO As Boolean = DirectCast(_params(1), Boolean)
                    Dim ShowErrors As Boolean = DirectCast(_params(2), Boolean)
                    FileFolderRenamer.RenameSingle_Episode(tDBTV, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, BatchMode, ToNFO, ShowErrors, True)
                End If
            Case Enums.ModuleEventType.AfterUpdateDB_TV
                If MySettings.RenameUpdate_Episodes AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                    Dim BatchMode As Boolean = DirectCast(_params(0), Boolean)
                    Dim ToNFO As Boolean = DirectCast(_params(1), Boolean)
                    Dim ShowErrors As Boolean = DirectCast(_params(2), Boolean)
                    Dim ToDB As Boolean = DirectCast(_params(3), Boolean)
                    Dim Source As String = DirectCast(_params(4), String)
                    Dim FFRenamer As New FileFolderRenamer
                    FFRenamer.RenameAfterUpdateDB_TV(Source, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, BatchMode, ToNFO, ShowErrors, ToDB)
                End If
            Case Enums.ModuleEventType.ScraperMulti_TVEpisode
                If MySettings.RenameMulti_Shows AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                    'Dim tDBTV As EmberAPI.Structures.DBTV = DirectCast(_refparam, EmberAPI.Structures.DBTV)
                    FileFolderRenamer.RenameSingle_Episode(_dbtv, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, True, False, False, False)
                End If
            Case Enums.ModuleEventType.ScraperSingle_TVEpisode
                If MySettings.RenameSingle_Shows AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern_Episodes) Then
                    'Dim tDBTV As EmberAPI.Structures.DBTV = DirectCast(_refparam, EmberAPI.Structures.DBTV)
                    FileFolderRenamer.RenameSingle_Episode(_dbtv, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, False, False, False, True)
                End If
        End Select
        Return New Interfaces.ModuleResult With {.breakChain = False}
    End Function

    Private Sub cmnuRenamerAuto_TVEpisode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerAuto_TVEpisode.Click
        Cursor.Current = Cursors.WaitCursor
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.Item(0, indX).Value)
        FileFolderRenamer.RenameSingle_Episode(Master.currShow, MySettings.FoldersPattern_Seasons, MySettings.FilesPattern_Episodes, False, True, True, True)
        RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {ID, indX}))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_TVEpisode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerManual_TVEpisode.Click
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListEpisodes.Item(0, indX).Value)
        Using dRenameManual As New dlgRenameManual_TVEpisode
            Select Case dRenameManual.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVEpisode, New List(Of Object)(New Object() {ID, indX}))
            End Select
        End Using
    End Sub

    Private Sub cmnuRenamerAuto_Movie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerAuto_Movie.Click
        Cursor.Current = Cursors.WaitCursor
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListMovies.Item(0, indX).Value)
        FileFolderRenamer.RenameSingle_Movie(Master.currMovie, MySettings.FoldersPattern_Movies, MySettings.FilesPattern_Movies, False, True, True, True)
        RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_Movie, New List(Of Object)(New Object() {ID, indX}))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_Movie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerManual_Movie.Click
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListMovies.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListMovies.Item(0, indX).Value)
        Using dRenameManual As New dlgRenameManual_Movie
            Select Case dRenameManual.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_Movie, New List(Of Object)(New Object() {ID, indX}))
            End Select
        End Using
    End Sub

    Private Sub cmnuRenamerAuto_TVShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerAuto_TVShow.Click
        Cursor.Current = Cursors.WaitCursor
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListShows.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListShows.Item(0, indX).Value)
        FileFolderRenamer.RenameSingle_Show(Master.currShow, MySettings.FoldersPattern_Shows, False, False, True, True)
        RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVShow, New List(Of Object)(New Object() {ID, indX}))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmnuRenamerManual_TVShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuRenamerManual_TVShows.Click
        Dim indX As Integer = ModulesManager.Instance.RuntimeObjects.MediaListShows.SelectedRows(0).Index
        Dim ID As Integer = Convert.ToInt32(ModulesManager.Instance.RuntimeObjects.MediaListShows.Item(0, indX).Value)
        Using dRenameManual As New dlgRenameManual_TVShow
            Select Case dRenameManual.ShowDialog()
                Case Windows.Forms.DialogResult.OK
                    RaiseEvent GenericEvent(Enums.ModuleEventType.AfterEdit_TVShow, New List(Of Object)(New Object() {ID, indX}))
            End Select
        End Using
    End Sub

    Sub Disable()
        Dim tsi As New ToolStripMenuItem
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("mnuMainTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(mnuMainToolsRenamer)
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(cmnuTrayToolsRenamer)
        'cmnuMovies
        RemoveToolsStripItem_Movies(cmnuSep_Movies)
        RemoveToolsStripItem_Movies(cmnuRenamer_Movies)
        'cmnuEpisodes
        RemoveToolsStripItem_Episodes(cmnuSep_Episodes)
        RemoveToolsStripItem_Episodes(cmnuRenamer_Episodes)
        'cmnuShows
        RemoveToolsStripItem_Shows(cmnuSep_Shows)
        RemoveToolsStripItem_Shows(cmnuRenamer_Shows)
    End Sub

    Public Sub RemoveToolsStripItem_Episodes(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Episodes), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Items.Remove(value)
    End Sub

    Public Sub RemoveToolsStripItem_Movies(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuMovieList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuMovieList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Movies), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuMovieList.Items.Remove(value)
    End Sub

    Public Sub RemoveToolsStripItem_Shows(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVShowList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Invoke(New Delegate_RemoveToolsStripItem(AddressOf RemoveToolsStripItem_Shows), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Items.Remove(value)
    End Sub

    Sub Enable()
        Dim tsi As New ToolStripMenuItem
        mnuMainToolsRenamer.Image = New Bitmap(My.Resources.icon)
        mnuMainToolsRenamer.Text = Master.eLang.GetString(291, "Bulk &Renamer")
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("mnuMainTools"), ToolStripMenuItem)
        mnuMainToolsRenamer.Tag = New Structures.ModulesMenus With {.ForMovies = True, .IfTabMovies = True, .ForTVShows = True, .IfTabTVShows = True}
        DropDownItemsAdd(mnuMainToolsRenamer, tsi)
        cmnuTrayToolsRenamer.Image = New Bitmap(My.Resources.icon)
        cmnuTrayToolsRenamer.Text = Master.eLang.GetString(291, "Bulk &Renamer")
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayTools"), ToolStripMenuItem)
        tsi.DropDownItems.Add(cmnuTrayToolsRenamer)

        'cmnuMovies
        cmnuRenamer_Movies.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Movies.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Movies.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuRenamerAuto_Movie.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_Movie.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Movies.DropDownItems.Add(cmnuRenamerAuto_Movie)
        cmnuRenamer_Movies.DropDownItems.Add(cmnuRenamerManual_Movie)

        SetToolsStripItem_Movies(cmnuSep_Movies)
        SetToolsStripItem_Movies(cmnuRenamer_Movies)

        'cmnuEpisodes
        cmnuRenamer_Episodes.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Episodes.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Episodes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuRenamerAuto_TVEpisode.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_TVEpisode.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerAuto_TVEpisode)
        cmnuRenamer_Episodes.DropDownItems.Add(cmnuRenamerManual_TVEpisode)

        SetToolsStripItem_Episodes(cmnuSep_Episodes)
        SetToolsStripItem_Episodes(cmnuRenamer_Episodes)

        'cmnuShows
        cmnuRenamer_Shows.Image = New Bitmap(My.Resources.icon)
        cmnuRenamer_Shows.Text = Master.eLang.GetString(257, "Rename")
        cmnuRenamer_Shows.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        cmnuRenamerAuto_TVShow.Text = Master.eLang.GetString(293, "Auto")
        cmnuRenamerManual_TVShows.Text = Master.eLang.GetString(294, "Manual")
        cmnuRenamer_Shows.DropDownItems.Add(cmnuRenamerAuto_TVShow)
        cmnuRenamer_Shows.DropDownItems.Add(cmnuRenamerManual_TVShows)

        SetToolsStripItem_Shows(cmnuSep_Shows)
        SetToolsStripItem_Shows(cmnuRenamer_Shows)
    End Sub

    Public Sub DropDownItemsAdd(value As System.Windows.Forms.ToolStripMenuItem, tsi As System.Windows.Forms.ToolStripMenuItem)
        If (tsi.Owner.InvokeRequired) Then
            tsi.Owner.Invoke(New Delegate_DropDownItemsAdd(AddressOf DropDownItemsAdd), New Object() {value, tsi})
            Exit Sub
        End If
        tsi.DropDownItems.Add(mnuMainToolsRenamer)
    End Sub

    Public Sub SetToolsStripItem_Episodes(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Episodes), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVEpisodeList.Items.Add(value)
    End Sub

    Public Sub SetToolsStripItem_Movies(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuMovieList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuMovieList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Movies), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuMovieList.Items.Add(value)
    End Sub

    Public Sub SetToolsStripItem_Shows(value As System.Windows.Forms.ToolStripItem)
        If (ModulesManager.Instance.RuntimeObjects.MenuTVShowList.InvokeRequired) Then
            ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Invoke(New Delegate_SetToolsStripItem(AddressOf SetToolsStripItem_Shows), New Object() {value})
            Exit Sub
        End If
        ModulesManager.Instance.RuntimeObjects.MenuTVShowList.Items.Add(value)
    End Sub

    Private Sub Handle_ModuleSettingsChanged()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub Handle_SetupChanged(ByVal state As Boolean, ByVal difforder As Integer)
        RaiseEvent ModuleEnabledChanged(Me._Name, state, difforder)
    End Sub

    Sub Init(ByVal sAssemblyName As String, ByVal sExecutable As String) Implements Interfaces.GenericModule.Init
        _AssemblyName = sAssemblyName
        LoadSettings()
    End Sub

    Function InjectSetup() As Containers.SettingsPanel Implements Interfaces.GenericModule.InjectSetup
        Dim SPanel As New Containers.SettingsPanel
        Me._setup = New frmSettingsHolder
        Me._setup.chkEnabled.Checked = Me._enabled
        Me._setup.txtFolderPatternMovies.Text = MySettings.FoldersPattern_Movies
        Me._setup.txtFolderPatternSeasons.Text = MySettings.FoldersPattern_Seasons
        Me._setup.txtFolderPatternShows.Text = MySettings.FoldersPattern_Shows
        Me._setup.txtFilePatternEpisodes.Text = MySettings.FilesPattern_Episodes
        Me._setup.txtFilePatternMovies.Text = MySettings.FilesPattern_Movies
        Me._setup.chkBulkRenamer.Checked = MySettings.BulkRenamer
        Me._setup.chkGenericModule.Checked = MySettings.GenericModule
        Me._setup.chkRenameEditMovies.Checked = MySettings.RenameEdit_Movies
        Me._setup.chkRenameEditEpisodes.Checked = MySettings.RenameEdit_Episodes
        Me._setup.chkRenameMultiMovies.Checked = MySettings.RenameMulti_Movies
        Me._setup.chkRenameMultiShows.Checked = MySettings.RenameMulti_Shows
        Me._setup.chkRenameSingleMovies.Checked = MySettings.RenameSingle_Movies
        Me._setup.chkRenameSingleShows.Checked = MySettings.RenameSingle_Shows
        Me._setup.chkRenameUpdateEpisodes.Checked = MySettings.RenameUpdate_Episodes
        SPanel.Name = Me._Name
        SPanel.Text = Master.eLang.GetString(295, "Renamer")
        SPanel.Prefix = "Renamer_"
        SPanel.Type = Master.eLang.GetString(802, "Modules")
        SPanel.ImageIndex = If(Me._enabled, 9, 10)
        SPanel.Order = 100
        SPanel.Panel = Me._setup.pnlSettings()
        AddHandler _setup.ModuleEnabledChanged, AddressOf Handle_SetupChanged
        AddHandler _setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
        Return SPanel
    End Function

    Sub LoadSettings()
        MySettings.FoldersPattern_Movies = clsAdvancedSettings.GetSetting("FoldersPattern", "$T {($Y)}", , Enums.Content_Type.Movie)
        MySettings.FoldersPattern_Seasons = clsAdvancedSettings.GetSetting("FoldersPattern", "Season $K?", , Enums.Content_Type.Season)
        MySettings.FoldersPattern_Shows = clsAdvancedSettings.GetSetting("FoldersPattern", "$Z", , Enums.Content_Type.Show)
        MySettings.FilesPattern_Episodes = clsAdvancedSettings.GetSetting("FilesPattern", "$Z - $WS?E?{ - $T}", , Enums.Content_Type.Episode)
        MySettings.FilesPattern_Movies = clsAdvancedSettings.GetSetting("FilesPattern", "$T{.$S}", , Enums.Content_Type.Movie)
        MySettings.RenameEdit_Movies = clsAdvancedSettings.GetBooleanSetting("RenameEdit", False, , Enums.Content_Type.Movie)
        MySettings.RenameEdit_Episodes = clsAdvancedSettings.GetBooleanSetting("RenameEdit", False, , Enums.Content_Type.Show)
        MySettings.RenameMulti_Movies = clsAdvancedSettings.GetBooleanSetting("RenameMulti", False, , Enums.Content_Type.Movie)
        MySettings.RenameMulti_Shows = clsAdvancedSettings.GetBooleanSetting("RenameMulti", False, , Enums.Content_Type.Show)
        MySettings.RenameSingle_Movies = clsAdvancedSettings.GetBooleanSetting("RenameSingle", False, , Enums.Content_Type.Movie)
        MySettings.RenameSingle_Shows = clsAdvancedSettings.GetBooleanSetting("RenameSingle", False, , Enums.Content_Type.Show)
        MySettings.RenameUpdate_Episodes = clsAdvancedSettings.GetBooleanSetting("RenameUpdate", False, , Enums.Content_Type.Episode)
        MySettings.BulkRenamer = clsAdvancedSettings.GetBooleanSetting("BulkRenamer", True)
        MySettings.GenericModule = clsAdvancedSettings.GetBooleanSetting("GenericModule", True)
    End Sub

    Private Sub mnuMainToolsRenamer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainToolsRenamer.Click, cmnuTrayToolsRenamer.Click

        RaiseEvent GenericEvent(Enums.ModuleEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", False}))
        Select Case ModulesManager.Instance.RuntimeObjects.MediaTabSelected
            Case 0
                Using dBulkRename As New dlgBulkRenamer_Movie
                    dBulkRename.FilterMovies = ModulesManager.Instance.RuntimeObjects.FilterMovies
                    dBulkRename.FilterMoviesSearch = ModulesManager.Instance.RuntimeObjects.FilterMoviesSearch
                    dBulkRename.FilterMoviesType = ModulesManager.Instance.RuntimeObjects.FilterMoviesType
                    dBulkRename.txtFilePattern.Text = MySettings.FilesPattern_Movies
                    dBulkRename.txtFolderPattern.Text = MySettings.FoldersPattern_Movies
                    Try
                        If dBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            ModulesManager.Instance.RuntimeObjects.InvokeLoadMedia(New Structures.Scans With {.Movies = True}, String.Empty)
                        End If
                    Catch ex As Exception
                    End Try
                End Using
            Case 2
                Using dBulkRename As New dlgBulkRenamer_TV
                    dBulkRename.FilterShows = ModulesManager.Instance.RuntimeObjects.FilterShows
                    dBulkRename.FilterShowsSearch = ModulesManager.Instance.RuntimeObjects.FilterShowsSearch
                    dBulkRename.FilterShowsType = ModulesManager.Instance.RuntimeObjects.FilterShowsType
                    dBulkRename.txtFilePatternEpisodes.Text = MySettings.FilesPattern_Episodes
                    dBulkRename.txtFolderPatternSeasons.Text = MySettings.FoldersPattern_Seasons
                    dBulkRename.txtFolderPatternShows.Text = MySettings.FoldersPattern_Shows
                    Try
                        If dBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            ModulesManager.Instance.RuntimeObjects.InvokeLoadMedia(New Structures.Scans With {.TV = True}, String.Empty)
                        End If
                    Catch ex As Exception
                    End Try
                End Using
        End Select
        RaiseEvent GenericEvent(Enums.ModuleEventType.Generic, New List(Of Object)(New Object() {"controlsenabled", True}))
    End Sub

    Sub SaveEmberExternalModule(ByVal DoDispose As Boolean) Implements Interfaces.GenericModule.SaveSetup
        Me._enabled = Me._setup.chkEnabled.Checked
        MySettings.BulkRenamer = Me._setup.chkBulkRenamer.Checked
        MySettings.FoldersPattern_Movies = Me._setup.txtFolderPatternMovies.Text
        MySettings.FoldersPattern_Seasons = Me._setup.txtFolderPatternSeasons.Text
        MySettings.FoldersPattern_Shows = Me._setup.txtFolderPatternShows.Text
        MySettings.FilesPattern_Episodes = Me._setup.txtFilePatternEpisodes.Text
        MySettings.FilesPattern_Movies = Me._setup.txtFilePatternMovies.Text
        MySettings.RenameEdit_Movies = Me._setup.chkRenameEditMovies.Checked
        MySettings.RenameEdit_Episodes = Me._setup.chkRenameEditEpisodes.Checked
        MySettings.RenameMulti_Movies = Me._setup.chkRenameMultiMovies.Checked
        MySettings.RenameMulti_Shows = Me._setup.chkRenameMultiShows.Checked
        MySettings.RenameSingle_Movies = Me._setup.chkRenameSingleMovies.Checked
        MySettings.RenameSingle_Shows = Me._setup.chkRenameSingleShows.Checked
        MySettings.RenameUpdate_Episodes = Me._setup.chkRenameUpdateEpisodes.Checked
        MySettings.GenericModule = Me._setup.chkGenericModule.Checked
        SaveSettings()
        If DoDispose Then
            RemoveHandler Me._setup.ModuleEnabledChanged, AddressOf Handle_SetupChanged
            RemoveHandler Me._setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
            _setup.Dispose()
        End If
    End Sub

    Sub SaveSettings()
        Using settings = New clsAdvancedSettings()
            settings.SetSetting("FoldersPattern", MySettings.FoldersPattern_Movies, , , Enums.Content_Type.Movie)
            settings.SetSetting("FoldersPattern", MySettings.FoldersPattern_Seasons, , , Enums.Content_Type.Season)
            settings.SetSetting("FoldersPattern", MySettings.FoldersPattern_Shows, , , Enums.Content_Type.Show)
            settings.SetSetting("FilesPattern", MySettings.FilesPattern_Episodes, , , Enums.Content_Type.Episode)
            settings.SetSetting("FilesPattern", MySettings.FilesPattern_Movies, , , Enums.Content_Type.Movie)
            settings.SetBooleanSetting("RenameEdit", MySettings.RenameEdit_Movies, , , Enums.Content_Type.Movie)
            settings.SetBooleanSetting("RenameEdit", MySettings.RenameEdit_Episodes, , , Enums.Content_Type.Show)
            settings.SetBooleanSetting("RenameMulti", MySettings.RenameMulti_Movies, , , Enums.Content_Type.Movie)
            settings.SetBooleanSetting("RenameMulti", MySettings.RenameMulti_Shows, , , Enums.Content_Type.Show)
            settings.SetBooleanSetting("RenameSingle", MySettings.RenameSingle_Movies, , , Enums.Content_Type.Movie)
            settings.SetBooleanSetting("RenameSingle", MySettings.RenameSingle_Shows, , , Enums.Content_Type.Show)
            settings.SetBooleanSetting("RenameUpdate", MySettings.RenameUpdate_Episodes, , , Enums.Content_Type.Episode)
            settings.SetBooleanSetting("BulkRenamer", MySettings.BulkRenamer)
            settings.SetBooleanSetting("GenericModule", MySettings.GenericModule)
        End Using
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure _MySettings

#Region "Fields"

        Dim BulkRenamer As Boolean
        Dim FilesPattern_Episodes As String
        Dim FilesPattern_Movies As String
        Dim FoldersPattern_Movies As String
        Dim FoldersPattern_Seasons As String
        Dim FoldersPattern_Shows As String
        Dim GenericModule As Boolean
        Dim RenameEdit_Movies As Boolean
        Dim RenameEdit_Episodes As Boolean
        Dim RenameMulti_Movies As Boolean
        Dim RenameMulti_Shows As Boolean
        Dim RenameSingle_Movies As Boolean
        Dim RenameSingle_Shows As Boolean
        Dim RenameUpdate_Episodes As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class