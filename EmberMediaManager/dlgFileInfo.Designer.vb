﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFileInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Video Streams", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Audio Streams", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Subtitles Stream", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "H264", "Progressive"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "AC3", "English"}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("1")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgFileInfo))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lvStreams = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemoveSet = New System.Windows.Forms.Button()
        Me.btnEditSet = New System.Windows.Forms.Button()
        Me.btnNewSet = New System.Windows.Forms.Button()
        Me.lblStreamType = New System.Windows.Forms.Label()
        Me.cbStreamType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(660, 325)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 0
        Me.Cancel_Button.Text = "Close"
        '
        'lvStreams
        '
        Me.lvStreams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvStreams.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvStreams.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lvStreams.FullRowSelect = True
        ListViewGroup1.Header = "Video Streams"
        ListViewGroup1.Name = "VideoStreams"
        ListViewGroup2.Header = "Audio Streams"
        ListViewGroup2.Name = "AudioStreams"
        ListViewGroup3.Header = "Subtitles Stream"
        ListViewGroup3.Name = "SubtitlesStream"
        Me.lvStreams.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lvStreams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup2
        ListViewItem3.Group = ListViewGroup3
        Me.lvStreams.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lvStreams.Location = New System.Drawing.Point(4, 7)
        Me.lvStreams.MultiSelect = False
        Me.lvStreams.Name = "lvStreams"
        Me.lvStreams.Size = New System.Drawing.Size(862, 315)
        Me.lvStreams.TabIndex = 1
        Me.lvStreams.UseCompatibleStateImageBehavior = False
        Me.lvStreams.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 25
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Width = 90
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 78
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Width = 120
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Width = 120
        '
        'btnRemoveSet
        '
        Me.btnRemoveSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveSet.Enabled = False
        Me.btnRemoveSet.Image = CType(resources.GetObject("btnRemoveSet.Image"), System.Drawing.Image)
        Me.btnRemoveSet.Location = New System.Drawing.Point(269, 326)
        Me.btnRemoveSet.Name = "btnRemoveSet"
        Me.btnRemoveSet.Size = New System.Drawing.Size(23, 23)
        Me.btnRemoveSet.TabIndex = 6
        Me.btnRemoveSet.UseVisualStyleBackColor = True
        '
        'btnEditSet
        '
        Me.btnEditSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditSet.Enabled = False
        Me.btnEditSet.Image = CType(resources.GetObject("btnEditSet.Image"), System.Drawing.Image)
        Me.btnEditSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditSet.Location = New System.Drawing.Point(240, 326)
        Me.btnEditSet.Name = "btnEditSet"
        Me.btnEditSet.Size = New System.Drawing.Size(23, 23)
        Me.btnEditSet.TabIndex = 5
        Me.btnEditSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditSet.UseVisualStyleBackColor = True
        '
        'btnNewSet
        '
        Me.btnNewSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNewSet.Enabled = False
        Me.btnNewSet.Image = CType(resources.GetObject("btnNewSet.Image"), System.Drawing.Image)
        Me.btnNewSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewSet.Location = New System.Drawing.Point(192, 326)
        Me.btnNewSet.Name = "btnNewSet"
        Me.btnNewSet.Size = New System.Drawing.Size(23, 23)
        Me.btnNewSet.TabIndex = 4
        Me.btnNewSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewSet.UseVisualStyleBackColor = True
        '
        'lblStreamType
        '
        Me.lblStreamType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStreamType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStreamType.Location = New System.Drawing.Point(6, 330)
        Me.lblStreamType.Name = "lblStreamType"
        Me.lblStreamType.Size = New System.Drawing.Size(78, 15)
        Me.lblStreamType.TabIndex = 2
        Me.lblStreamType.Text = "Stream Type"
        Me.lblStreamType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbStreamType
        '
        Me.cbStreamType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbStreamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStreamType.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.cbStreamType.FormattingEnabled = True
        Me.cbStreamType.Items.AddRange(New Object() {"Video", "Audio", "Subtitle"})
        Me.cbStreamType.Location = New System.Drawing.Point(96, 327)
        Me.cbStreamType.Name = "cbStreamType"
        Me.cbStreamType.Size = New System.Drawing.Size(93, 21)
        Me.cbStreamType.TabIndex = 3
        '
        'dlgFileInfo
        '
        Me.AcceptButton = Me.Cancel_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(874, 354)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.lblStreamType)
        Me.Controls.Add(Me.cbStreamType)
        Me.Controls.Add(Me.btnRemoveSet)
        Me.Controls.Add(Me.btnEditSet)
        Me.Controls.Add(Me.btnNewSet)
        Me.Controls.Add(Me.lvStreams)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFileInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Meta Data Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lvStreams As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRemoveSet As System.Windows.Forms.Button
    Friend WithEvents btnEditSet As System.Windows.Forms.Button
    Friend WithEvents btnNewSet As System.Windows.Forms.Button
    Friend WithEvents lblStreamType As System.Windows.Forms.Label
    Friend WithEvents cbStreamType As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader

End Class
