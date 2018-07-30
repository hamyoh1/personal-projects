<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ShipName_TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SpriteBrowse_Button = New System.Windows.Forms.Button()
        Me.SpriteLocation_TextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ShipPrice_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenShipSpriteDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ShipImage_Display = New System.Windows.Forms.PictureBox()
        Me.LoadSprite_Button = New System.Windows.Forms.Button()
        Me.StretchImage_Checkbox = New System.Windows.Forms.CheckBox()
        Me.shipSpeed_TextBox = New System.Windows.Forms.TextBox()
        Me.AssignID_Button = New System.Windows.Forms.Button()
        Me.shipDamage_TextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.shipHealth_TextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.explosionHeight_TextBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.explosionWidth_TextBox = New System.Windows.Forms.TextBox()
        Me.ExplSoundPlay_Button = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LoadExplSound_Button = New System.Windows.Forms.Button()
        Me.LoadExplSprite_Button = New System.Windows.Forms.Button()
        Me.ExplSoundBrowse_Button = New System.Windows.Forms.Button()
        Me.ExplSpriteBrowse_Button = New System.Windows.Forms.Button()
        Me.ExplSoundLocation_TextBox = New System.Windows.Forms.TextBox()
        Me.ExplSpriteLocation_TextBox = New System.Windows.Forms.TextBox()
        Me.ProjecSoundPlay_Button = New System.Windows.Forms.Button()
        Me.LoadProjecSound_Button = New System.Windows.Forms.Button()
        Me.ProjectileSoundBrowse_Button = New System.Windows.Forms.Button()
        Me.ProjecSoundLocation_TextBox = New System.Windows.Forms.TextBox()
        Me.LoadProjecSprite_Button = New System.Windows.Forms.Button()
        Me.ProjecSpriteBrowse_Button = New System.Windows.Forms.Button()
        Me.ProjecSpriteLocation_TextBox = New System.Windows.Forms.TextBox()
        Me.shipFiringTimer_TextBox = New System.Windows.Forms.TextBox()
        Me.shipProjecSpeed_TextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OpenProjectileSpriteDialog = New System.Windows.Forms.OpenFileDialog()
        Me.OpenProjectileSoundDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProjectileImage_Display = New System.Windows.Forms.PictureBox()
        Me.StretchImage_Checkbox2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DescriptionApply_Button = New System.Windows.Forms.Button()
        Me.Description_TextBox = New System.Windows.Forms.TextBox()
        Me.shipHeight_TextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.shipWidth_TextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Apply_Button = New System.Windows.Forms.Button()
        Me.shipClass_ComboBox = New System.Windows.Forms.ComboBox()
        Me.ID_TextBox = New System.Windows.Forms.TextBox()
        Me.OpenSHIPDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ClearAll_Button = New System.Windows.Forms.Button()
        Me.OpenExplosionSoundDialog = New System.Windows.Forms.OpenFileDialog()
        Me.OpenExplosionSpriteDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ExplosionImage_Display = New System.Windows.Forms.PictureBox()
        Me.StretchImage_Checkbox3 = New System.Windows.Forms.CheckBox()
        Me.DefaultExplSprite_Button = New System.Windows.Forms.Button()
        Me.DefaultExplSound_Button = New System.Windows.Forms.Button()
        Me.explosionTimer_TextBox = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ShipImage_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ProjectileImage_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ExplosionImage_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShipName_TextBox
        '
        Me.ShipName_TextBox.Location = New System.Drawing.Point(80, 38)
        Me.ShipName_TextBox.Name = "ShipName_TextBox"
        Me.ShipName_TextBox.Size = New System.Drawing.Size(182, 20)
        Me.ShipName_TextBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ship Name:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(934, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitProgramToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitProgramToolStripMenuItem
        '
        Me.ExitProgramToolStripMenuItem.Name = "ExitProgramToolStripMenuItem"
        Me.ExitProgramToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ExitProgramToolStripMenuItem.Text = "Exit Program"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Sprite: "
        '
        'SpriteBrowse_Button
        '
        Me.SpriteBrowse_Button.Location = New System.Drawing.Point(334, 112)
        Me.SpriteBrowse_Button.Name = "SpriteBrowse_Button"
        Me.SpriteBrowse_Button.Size = New System.Drawing.Size(67, 20)
        Me.SpriteBrowse_Button.TabIndex = 2
        Me.SpriteBrowse_Button.Text = "Browse..."
        Me.SpriteBrowse_Button.UseVisualStyleBackColor = True
        '
        'SpriteLocation_TextBox
        '
        Me.SpriteLocation_TextBox.AllowDrop = True
        Me.SpriteLocation_TextBox.Location = New System.Drawing.Point(83, 112)
        Me.SpriteLocation_TextBox.Name = "SpriteLocation_TextBox"
        Me.SpriteLocation_TextBox.Size = New System.Drawing.Size(245, 20)
        Me.SpriteLocation_TextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Price: "
        '
        'ShipPrice_TextBox
        '
        Me.ShipPrice_TextBox.Location = New System.Drawing.Point(83, 142)
        Me.ShipPrice_TextBox.MaxLength = 8
        Me.ShipPrice_TextBox.Name = "ShipPrice_TextBox"
        Me.ShipPrice_TextBox.Size = New System.Drawing.Size(66, 20)
        Me.ShipPrice_TextBox.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Speed: "
        '
        'OpenShipSpriteDialog
        '
        Me.OpenShipSpriteDialog.Title = "Ship Sprite"
        '
        'ShipImage_Display
        '
        Me.ShipImage_Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ShipImage_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShipImage_Display.Location = New System.Drawing.Point(666, 41)
        Me.ShipImage_Display.Name = "ShipImage_Display"
        Me.ShipImage_Display.Size = New System.Drawing.Size(256, 128)
        Me.ShipImage_Display.TabIndex = 11
        Me.ShipImage_Display.TabStop = False
        '
        'LoadSprite_Button
        '
        Me.LoadSprite_Button.Location = New System.Drawing.Point(407, 112)
        Me.LoadSprite_Button.Name = "LoadSprite_Button"
        Me.LoadSprite_Button.Size = New System.Drawing.Size(67, 20)
        Me.LoadSprite_Button.TabIndex = 3
        Me.LoadSprite_Button.Text = "Load"
        Me.LoadSprite_Button.UseVisualStyleBackColor = True
        '
        'StretchImage_Checkbox
        '
        Me.StretchImage_Checkbox.AutoSize = True
        Me.StretchImage_Checkbox.Location = New System.Drawing.Point(807, 175)
        Me.StretchImage_Checkbox.Name = "StretchImage_Checkbox"
        Me.StretchImage_Checkbox.Size = New System.Drawing.Size(115, 17)
        Me.StretchImage_Checkbox.TabIndex = 36
        Me.StretchImage_Checkbox.Text = "Fit Image to Border"
        Me.StretchImage_Checkbox.UseVisualStyleBackColor = True
        '
        'shipSpeed_TextBox
        '
        Me.shipSpeed_TextBox.Location = New System.Drawing.Point(205, 142)
        Me.shipSpeed_TextBox.MaxLength = 3
        Me.shipSpeed_TextBox.Name = "shipSpeed_TextBox"
        Me.shipSpeed_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.shipSpeed_TextBox.TabIndex = 5
        '
        'AssignID_Button
        '
        Me.AssignID_Button.Location = New System.Drawing.Point(195, 71)
        Me.AssignID_Button.Name = "AssignID_Button"
        Me.AssignID_Button.Size = New System.Drawing.Size(67, 30)
        Me.AssignID_Button.TabIndex = 1
        Me.AssignID_Button.Text = "Assign ID"
        Me.AssignID_Button.UseVisualStyleBackColor = True
        '
        'shipDamage_TextBox
        '
        Me.shipDamage_TextBox.Location = New System.Drawing.Point(301, 142)
        Me.shipDamage_TextBox.MaxLength = 3
        Me.shipDamage_TextBox.Name = "shipDamage_TextBox"
        Me.shipDamage_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.shipDamage_TextBox.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(245, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Damage:"
        '
        'shipHealth_TextBox
        '
        Me.shipHealth_TextBox.Location = New System.Drawing.Point(388, 142)
        Me.shipHealth_TextBox.MaxLength = 3
        Me.shipHealth_TextBox.Name = "shipHealth_TextBox"
        Me.shipHealth_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.shipHealth_TextBox.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(341, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Health:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Class:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.explosionTimer_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.DefaultExplSound_Button)
        Me.GroupBox1.Controls.Add(Me.DefaultExplSprite_Button)
        Me.GroupBox1.Controls.Add(Me.explosionHeight_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.explosionWidth_TextBox)
        Me.GroupBox1.Controls.Add(Me.ExplSoundPlay_Button)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.LoadExplSound_Button)
        Me.GroupBox1.Controls.Add(Me.LoadExplSprite_Button)
        Me.GroupBox1.Controls.Add(Me.ExplSoundBrowse_Button)
        Me.GroupBox1.Controls.Add(Me.ExplSpriteBrowse_Button)
        Me.GroupBox1.Controls.Add(Me.ExplSoundLocation_TextBox)
        Me.GroupBox1.Controls.Add(Me.ExplSpriteLocation_TextBox)
        Me.GroupBox1.Controls.Add(Me.ProjecSoundPlay_Button)
        Me.GroupBox1.Controls.Add(Me.LoadProjecSound_Button)
        Me.GroupBox1.Controls.Add(Me.ProjectileSoundBrowse_Button)
        Me.GroupBox1.Controls.Add(Me.ProjecSoundLocation_TextBox)
        Me.GroupBox1.Controls.Add(Me.LoadProjecSprite_Button)
        Me.GroupBox1.Controls.Add(Me.ProjecSpriteBrowse_Button)
        Me.GroupBox1.Controls.Add(Me.ProjecSpriteLocation_TextBox)
        Me.GroupBox1.Controls.Add(Me.shipFiringTimer_TextBox)
        Me.GroupBox1.Controls.Add(Me.shipProjecSpeed_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 222)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 177)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Projectile Properties"
        '
        'explosionHeight_TextBox
        '
        Me.explosionHeight_TextBox.Location = New System.Drawing.Point(269, 43)
        Me.explosionHeight_TextBox.MaxLength = 3
        Me.explosionHeight_TextBox.Name = "explosionHeight_TextBox"
        Me.explosionHeight_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.explosionHeight_TextBox.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Explosion Sound: "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(177, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Explosion Height:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Explosion Texture:"
        '
        'explosionWidth_TextBox
        '
        Me.explosionWidth_TextBox.Location = New System.Drawing.Point(269, 19)
        Me.explosionWidth_TextBox.MaxLength = 3
        Me.explosionWidth_TextBox.Name = "explosionWidth_TextBox"
        Me.explosionWidth_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.explosionWidth_TextBox.TabIndex = 13
        '
        'ExplSoundPlay_Button
        '
        Me.ExplSoundPlay_Button.Location = New System.Drawing.Point(399, 146)
        Me.ExplSoundPlay_Button.Name = "ExplSoundPlay_Button"
        Me.ExplSoundPlay_Button.Size = New System.Drawing.Size(67, 20)
        Me.ExplSoundPlay_Button.TabIndex = 30
        Me.ExplSoundPlay_Button.Text = "Play"
        Me.ExplSoundPlay_Button.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(177, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Explosion Width:"
        '
        'LoadExplSound_Button
        '
        Me.LoadExplSound_Button.Location = New System.Drawing.Point(326, 146)
        Me.LoadExplSound_Button.Name = "LoadExplSound_Button"
        Me.LoadExplSound_Button.Size = New System.Drawing.Size(67, 20)
        Me.LoadExplSound_Button.TabIndex = 29
        Me.LoadExplSound_Button.Text = "Load"
        Me.LoadExplSound_Button.UseVisualStyleBackColor = True
        '
        'LoadExplSprite_Button
        '
        Me.LoadExplSprite_Button.Location = New System.Drawing.Point(326, 120)
        Me.LoadExplSprite_Button.Name = "LoadExplSprite_Button"
        Me.LoadExplSprite_Button.Size = New System.Drawing.Size(67, 20)
        Me.LoadExplSprite_Button.TabIndex = 25
        Me.LoadExplSprite_Button.Text = "Load"
        Me.LoadExplSprite_Button.UseVisualStyleBackColor = True
        '
        'ExplSoundBrowse_Button
        '
        Me.ExplSoundBrowse_Button.Location = New System.Drawing.Point(253, 146)
        Me.ExplSoundBrowse_Button.Name = "ExplSoundBrowse_Button"
        Me.ExplSoundBrowse_Button.Size = New System.Drawing.Size(67, 20)
        Me.ExplSoundBrowse_Button.TabIndex = 28
        Me.ExplSoundBrowse_Button.Text = "Browse..."
        Me.ExplSoundBrowse_Button.UseVisualStyleBackColor = True
        '
        'ExplSpriteBrowse_Button
        '
        Me.ExplSpriteBrowse_Button.Location = New System.Drawing.Point(253, 120)
        Me.ExplSpriteBrowse_Button.Name = "ExplSpriteBrowse_Button"
        Me.ExplSpriteBrowse_Button.Size = New System.Drawing.Size(67, 20)
        Me.ExplSpriteBrowse_Button.TabIndex = 24
        Me.ExplSpriteBrowse_Button.Text = "Browse..."
        Me.ExplSpriteBrowse_Button.UseVisualStyleBackColor = True
        '
        'ExplSoundLocation_TextBox
        '
        Me.ExplSoundLocation_TextBox.Location = New System.Drawing.Point(110, 147)
        Me.ExplSoundLocation_TextBox.Name = "ExplSoundLocation_TextBox"
        Me.ExplSoundLocation_TextBox.Size = New System.Drawing.Size(137, 20)
        Me.ExplSoundLocation_TextBox.TabIndex = 27
        '
        'ExplSpriteLocation_TextBox
        '
        Me.ExplSpriteLocation_TextBox.Location = New System.Drawing.Point(110, 121)
        Me.ExplSpriteLocation_TextBox.Name = "ExplSpriteLocation_TextBox"
        Me.ExplSpriteLocation_TextBox.Size = New System.Drawing.Size(137, 20)
        Me.ExplSpriteLocation_TextBox.TabIndex = 23
        '
        'ProjecSoundPlay_Button
        '
        Me.ProjecSoundPlay_Button.Location = New System.Drawing.Point(399, 94)
        Me.ProjecSoundPlay_Button.Name = "ProjecSoundPlay_Button"
        Me.ProjecSoundPlay_Button.Size = New System.Drawing.Size(67, 20)
        Me.ProjecSoundPlay_Button.TabIndex = 22
        Me.ProjecSoundPlay_Button.Text = "Play"
        Me.ProjecSoundPlay_Button.UseVisualStyleBackColor = True
        '
        'LoadProjecSound_Button
        '
        Me.LoadProjecSound_Button.Location = New System.Drawing.Point(326, 94)
        Me.LoadProjecSound_Button.Name = "LoadProjecSound_Button"
        Me.LoadProjecSound_Button.Size = New System.Drawing.Size(67, 20)
        Me.LoadProjecSound_Button.TabIndex = 21
        Me.LoadProjecSound_Button.Text = "Load"
        Me.LoadProjecSound_Button.UseVisualStyleBackColor = True
        '
        'ProjectileSoundBrowse_Button
        '
        Me.ProjectileSoundBrowse_Button.Location = New System.Drawing.Point(253, 94)
        Me.ProjectileSoundBrowse_Button.Name = "ProjectileSoundBrowse_Button"
        Me.ProjectileSoundBrowse_Button.Size = New System.Drawing.Size(67, 20)
        Me.ProjectileSoundBrowse_Button.TabIndex = 20
        Me.ProjectileSoundBrowse_Button.Text = "Browse..."
        Me.ProjectileSoundBrowse_Button.UseVisualStyleBackColor = True
        '
        'ProjecSoundLocation_TextBox
        '
        Me.ProjecSoundLocation_TextBox.Location = New System.Drawing.Point(110, 95)
        Me.ProjecSoundLocation_TextBox.Name = "ProjecSoundLocation_TextBox"
        Me.ProjecSoundLocation_TextBox.Size = New System.Drawing.Size(137, 20)
        Me.ProjecSoundLocation_TextBox.TabIndex = 19
        '
        'LoadProjecSprite_Button
        '
        Me.LoadProjecSprite_Button.Location = New System.Drawing.Point(326, 68)
        Me.LoadProjecSprite_Button.Name = "LoadProjecSprite_Button"
        Me.LoadProjecSprite_Button.Size = New System.Drawing.Size(67, 20)
        Me.LoadProjecSprite_Button.TabIndex = 18
        Me.LoadProjecSprite_Button.Text = "Load"
        Me.LoadProjecSprite_Button.UseVisualStyleBackColor = True
        '
        'ProjecSpriteBrowse_Button
        '
        Me.ProjecSpriteBrowse_Button.Location = New System.Drawing.Point(253, 68)
        Me.ProjecSpriteBrowse_Button.Name = "ProjecSpriteBrowse_Button"
        Me.ProjecSpriteBrowse_Button.Size = New System.Drawing.Size(67, 20)
        Me.ProjecSpriteBrowse_Button.TabIndex = 17
        Me.ProjecSpriteBrowse_Button.Text = "Browse..."
        Me.ProjecSpriteBrowse_Button.UseVisualStyleBackColor = True
        '
        'ProjecSpriteLocation_TextBox
        '
        Me.ProjecSpriteLocation_TextBox.Location = New System.Drawing.Point(110, 69)
        Me.ProjecSpriteLocation_TextBox.Name = "ProjecSpriteLocation_TextBox"
        Me.ProjecSpriteLocation_TextBox.Size = New System.Drawing.Size(137, 20)
        Me.ProjecSpriteLocation_TextBox.TabIndex = 16
        '
        'shipFiringTimer_TextBox
        '
        Me.shipFiringTimer_TextBox.Location = New System.Drawing.Point(110, 43)
        Me.shipFiringTimer_TextBox.MaxLength = 3
        Me.shipFiringTimer_TextBox.Name = "shipFiringTimer_TextBox"
        Me.shipFiringTimer_TextBox.Size = New System.Drawing.Size(44, 20)
        Me.shipFiringTimer_TextBox.TabIndex = 12
        '
        'shipProjecSpeed_TextBox
        '
        Me.shipProjecSpeed_TextBox.Location = New System.Drawing.Point(110, 19)
        Me.shipProjecSpeed_TextBox.MaxLength = 3
        Me.shipProjecSpeed_TextBox.Name = "shipProjecSpeed_TextBox"
        Me.shipProjecSpeed_TextBox.Size = New System.Drawing.Size(44, 20)
        Me.shipProjecSpeed_TextBox.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(63, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Sound:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(67, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Sprite:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(40, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Firing Timer:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(63, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Speed:"
        '
        'OpenProjectileSpriteDialog
        '
        Me.OpenProjectileSpriteDialog.Title = "Projectile Sprite"
        '
        'OpenProjectileSoundDialog
        '
        Me.OpenProjectileSoundDialog.Title = "Projectile Sound"
        '
        'ProjectileImage_Display
        '
        Me.ProjectileImage_Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ProjectileImage_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectileImage_Display.Location = New System.Drawing.Point(794, 207)
        Me.ProjectileImage_Display.Name = "ProjectileImage_Display"
        Me.ProjectileImage_Display.Size = New System.Drawing.Size(128, 128)
        Me.ProjectileImage_Display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ProjectileImage_Display.TabIndex = 25
        Me.ProjectileImage_Display.TabStop = False
        '
        'StretchImage_Checkbox2
        '
        Me.StretchImage_Checkbox2.AutoSize = True
        Me.StretchImage_Checkbox2.Location = New System.Drawing.Point(807, 341)
        Me.StretchImage_Checkbox2.Name = "StretchImage_Checkbox2"
        Me.StretchImage_Checkbox2.Size = New System.Drawing.Size(115, 17)
        Me.StretchImage_Checkbox2.TabIndex = 37
        Me.StretchImage_Checkbox2.Text = "Fit Image to Border"
        Me.StretchImage_Checkbox2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DescriptionApply_Button)
        Me.GroupBox2.Controls.Add(Me.Description_TextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(592, 222)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 177)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Description"
        '
        'DescriptionApply_Button
        '
        Me.DescriptionApply_Button.Location = New System.Drawing.Point(112, 150)
        Me.DescriptionApply_Button.Name = "DescriptionApply_Button"
        Me.DescriptionApply_Button.Size = New System.Drawing.Size(67, 21)
        Me.DescriptionApply_Button.TabIndex = 33
        Me.DescriptionApply_Button.Text = "Apply"
        Me.DescriptionApply_Button.UseVisualStyleBackColor = True
        '
        'Description_TextBox
        '
        Me.Description_TextBox.Location = New System.Drawing.Point(7, 19)
        Me.Description_TextBox.Multiline = True
        Me.Description_TextBox.Name = "Description_TextBox"
        Me.Description_TextBox.Size = New System.Drawing.Size(172, 125)
        Me.Description_TextBox.TabIndex = 32
        '
        'shipHeight_TextBox
        '
        Me.shipHeight_TextBox.Location = New System.Drawing.Point(301, 203)
        Me.shipHeight_TextBox.MaxLength = 3
        Me.shipHeight_TextBox.Name = "shipHeight_TextBox"
        Me.shipHeight_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.shipHeight_TextBox.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 206)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Ship Height:"
        '
        'shipWidth_TextBox
        '
        Me.shipWidth_TextBox.Location = New System.Drawing.Point(301, 172)
        Me.shipWidth_TextBox.MaxLength = 3
        Me.shipWidth_TextBox.Name = "shipWidth_TextBox"
        Me.shipWidth_TextBox.Size = New System.Drawing.Size(34, 20)
        Me.shipWidth_TextBox.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(233, 175)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Ship Width:"
        '
        'Apply_Button
        '
        Me.Apply_Button.Location = New System.Drawing.Point(356, 32)
        Me.Apply_Button.Name = "Apply_Button"
        Me.Apply_Button.Size = New System.Drawing.Size(96, 30)
        Me.Apply_Button.TabIndex = 34
        Me.Apply_Button.Text = "Apply All"
        Me.Apply_Button.UseVisualStyleBackColor = True
        '
        'shipClass_ComboBox
        '
        Me.shipClass_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.shipClass_ComboBox.FormattingEnabled = True
        Me.shipClass_ComboBox.Items.AddRange(New Object() {"Drone", "Striker", "Fighter", "Tank"})
        Me.shipClass_ComboBox.Location = New System.Drawing.Point(83, 169)
        Me.shipClass_ComboBox.Name = "shipClass_ComboBox"
        Me.shipClass_ComboBox.Size = New System.Drawing.Size(66, 21)
        Me.shipClass_ComboBox.TabIndex = 8
        '
        'ID_TextBox
        '
        Me.ID_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ID_TextBox.Location = New System.Drawing.Point(83, 77)
        Me.ID_TextBox.MaxLength = 4
        Me.ID_TextBox.Name = "ID_TextBox"
        Me.ID_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_TextBox.TabIndex = 1
        '
        'OpenSHIPDialog
        '
        Me.OpenSHIPDialog.Title = "Load .ship File"
        '
        'ClearAll_Button
        '
        Me.ClearAll_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ClearAll_Button.Location = New System.Drawing.Point(467, 32)
        Me.ClearAll_Button.Name = "ClearAll_Button"
        Me.ClearAll_Button.Size = New System.Drawing.Size(96, 30)
        Me.ClearAll_Button.TabIndex = 35
        Me.ClearAll_Button.Text = "Clear All"
        Me.ClearAll_Button.UseVisualStyleBackColor = True
        '
        'OpenExplosionSoundDialog
        '
        Me.OpenExplosionSoundDialog.Title = "Explosion Sound"
        '
        'OpenExplosionSpriteDialog
        '
        Me.OpenExplosionSpriteDialog.Title = "Explosion Sprite"
        '
        'ExplosionImage_Display
        '
        Me.ExplosionImage_Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ExplosionImage_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExplosionImage_Display.Location = New System.Drawing.Point(15, 405)
        Me.ExplosionImage_Display.Name = "ExplosionImage_Display"
        Me.ExplosionImage_Display.Size = New System.Drawing.Size(512, 128)
        Me.ExplosionImage_Display.TabIndex = 34
        Me.ExplosionImage_Display.TabStop = False
        '
        'StretchImage_Checkbox3
        '
        Me.StretchImage_Checkbox3.AutoSize = True
        Me.StretchImage_Checkbox3.Location = New System.Drawing.Point(533, 516)
        Me.StretchImage_Checkbox3.Name = "StretchImage_Checkbox3"
        Me.StretchImage_Checkbox3.Size = New System.Drawing.Size(115, 17)
        Me.StretchImage_Checkbox3.TabIndex = 38
        Me.StretchImage_Checkbox3.Text = "Fit Image to Border"
        Me.StretchImage_Checkbox3.UseVisualStyleBackColor = True
        '
        'DefaultExplSprite_Button
        '
        Me.DefaultExplSprite_Button.Location = New System.Drawing.Point(481, 120)
        Me.DefaultExplSprite_Button.Name = "DefaultExplSprite_Button"
        Me.DefaultExplSprite_Button.Size = New System.Drawing.Size(67, 20)
        Me.DefaultExplSprite_Button.TabIndex = 26
        Me.DefaultExplSprite_Button.Text = "Default"
        Me.DefaultExplSprite_Button.UseVisualStyleBackColor = True
        '
        'DefaultExplSound_Button
        '
        Me.DefaultExplSound_Button.Location = New System.Drawing.Point(481, 147)
        Me.DefaultExplSound_Button.Name = "DefaultExplSound_Button"
        Me.DefaultExplSound_Button.Size = New System.Drawing.Size(67, 20)
        Me.DefaultExplSound_Button.TabIndex = 31
        Me.DefaultExplSound_Button.Text = "Default"
        Me.DefaultExplSound_Button.UseVisualStyleBackColor = True
        '
        'explosionTimer_TextBox
        '
        Me.explosionTimer_TextBox.Location = New System.Drawing.Point(399, 19)
        Me.explosionTimer_TextBox.MaxLength = 3
        Me.explosionTimer_TextBox.Name = "explosionTimer_TextBox"
        Me.explosionTimer_TextBox.Size = New System.Drawing.Size(44, 20)
        Me.explosionTimer_TextBox.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(316, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Explosion Timer:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 537)
        Me.Controls.Add(Me.StretchImage_Checkbox3)
        Me.Controls.Add(Me.ExplosionImage_Display)
        Me.Controls.Add(Me.ClearAll_Button)
        Me.Controls.Add(Me.ID_TextBox)
        Me.Controls.Add(Me.Apply_Button)
        Me.Controls.Add(Me.shipHeight_TextBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.shipWidth_TextBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StretchImage_Checkbox2)
        Me.Controls.Add(Me.ProjectileImage_Display)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.shipClass_ComboBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.shipHealth_TextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.shipDamage_TextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AssignID_Button)
        Me.Controls.Add(Me.shipSpeed_TextBox)
        Me.Controls.Add(Me.StretchImage_Checkbox)
        Me.Controls.Add(Me.LoadSprite_Button)
        Me.Controls.Add(Me.ShipImage_Display)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ShipPrice_TextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SpriteLocation_TextBox)
        Me.Controls.Add(Me.SpriteBrowse_Button)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShipName_TextBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "XML Ship Creator Tool"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ShipImage_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ProjectileImage_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ExplosionImage_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShipName_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SpriteBrowse_Button As System.Windows.Forms.Button
    Friend WithEvents SpriteLocation_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShipPrice_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenShipSpriteDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ShipImage_Display As System.Windows.Forms.PictureBox
    Friend WithEvents LoadSprite_Button As System.Windows.Forms.Button
    Friend WithEvents StretchImage_Checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents shipSpeed_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssignID_Button As System.Windows.Forms.Button
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents shipDamage_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents shipHealth_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents shipProjecSpeed_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents shipFiringTimer_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoadProjecSprite_Button As System.Windows.Forms.Button
    Friend WithEvents ProjecSpriteBrowse_Button As System.Windows.Forms.Button
    Friend WithEvents ProjecSpriteLocation_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoadProjecSound_Button As System.Windows.Forms.Button
    Friend WithEvents ProjectileSoundBrowse_Button As System.Windows.Forms.Button
    Friend WithEvents ProjecSoundLocation_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenProjectileSpriteDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenProjectileSoundDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProjectileImage_Display As System.Windows.Forms.PictureBox
    Friend WithEvents StretchImage_Checkbox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ProjecSoundPlay_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Description_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionApply_Button As System.Windows.Forms.Button
    Friend WithEvents shipHeight_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents shipWidth_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Apply_Button As System.Windows.Forms.Button
    Friend WithEvents shipClass_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ID_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenSHIPDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitProgramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAll_Button As System.Windows.Forms.Button
    Friend WithEvents ExplSoundBrowse_Button As System.Windows.Forms.Button
    Friend WithEvents ExplSpriteBrowse_Button As System.Windows.Forms.Button
    Friend WithEvents ExplSoundLocation_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExplSpriteLocation_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ExplSoundPlay_Button As System.Windows.Forms.Button
    Friend WithEvents LoadExplSound_Button As System.Windows.Forms.Button
    Friend WithEvents LoadExplSprite_Button As System.Windows.Forms.Button
    Friend WithEvents OpenExplosionSoundDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenExplosionSpriteDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExplosionImage_Display As System.Windows.Forms.PictureBox
    Friend WithEvents StretchImage_Checkbox3 As System.Windows.Forms.CheckBox
    Friend WithEvents explosionHeight_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents explosionWidth_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DefaultExplSound_Button As System.Windows.Forms.Button
    Friend WithEvents DefaultExplSprite_Button As System.Windows.Forms.Button
    Friend WithEvents explosionTimer_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label

End Class
