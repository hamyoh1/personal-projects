Imports System.IO

Public Class Form1

    Dim imgStr As String
    Dim loadLocation As String
    Dim boxImage As Image
    Dim ID As Integer
    Dim Price As String
    Dim fmt As String = "0000"
    Dim soundLocation As String
    Dim shipName As String
    Dim sprite As String
    Dim speed As String
    Dim damage As String
    Dim health As String
    Dim shipWidth As String
    Dim shipHeight As String
    Dim shipClass As String
    Dim projecSpeed As String
    Dim firingTimer As String
    Dim projecSprite As String
    Dim projecSound As String
    Dim description As String
    Dim canSave As Boolean = False
    Dim fullSpritePath As String
    Dim fullProjecSpritePath As String
    Dim fullProjecSoundPath As String

    Dim explSprite As String
    Dim explSound As String
    Dim explWidth As String
    Dim explHeight As String
    Dim fullExplSpritePath As String
    Dim fullExplSoundPath As String
    Dim explSoundLocation As String
    Dim explTimer As String

    Private Sub SpriteBrowse_Button_Click(sender As Object, e As EventArgs) Handles SpriteBrowse_Button.Click
        Me.OpenShipSpriteDialog.ShowDialog()
    End Sub
    Private Sub ProjecSpriteBrowse_Button_Click(sender As Object, e As EventArgs) Handles ProjecSpriteBrowse_Button.Click
        Me.OpenProjectileSpriteDialog.ShowDialog()
    End Sub
    Private Sub ProjectileSoundBrowse_Button_Click(sender As Object, e As EventArgs) Handles ProjectileSoundBrowse_Button.Click
        Me.OpenProjectileSoundDialog.ShowDialog()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenShipSpriteDialog.Filter = "PNG (*.png)|*.png|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.JPEG)|*.JPEG"
        OpenProjectileSpriteDialog.Filter = "PNG (*.png)|*.png|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.JPEG)|*.JPEG"
        OpenProjectileSoundDialog.Filter = "WAV (*.wav)|*.wav"
        OpenSHIPDialog.Filter = "SHIP (*.ship)|*.ship"
        OpenExplosionSpriteDialog.Filter = "PNG (*.png)|*.png|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.JPEG)|*.JPEG"
        OpenExplosionSoundDialog.Filter = "WAV (*.wav)|*.wav"
        sprite = ""
        projecSprite = ""
        projecSound = ""
        explSprite = ""
        explSound = ""
        ID_TextBox.Text() = 0
        ID = ID_TextBox.Text()
        ID_TextBox.Text = ID.ToString(fmt)
        ShipImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
        ProjectileImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
        ExplosionImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenShipSpriteDialog.FileOk
        imgStr = OpenShipSpriteDialog.InitialDirectory() & OpenShipSpriteDialog.FileName
        SpriteLocation_TextBox.Text = imgStr
    End Sub

    Private Sub LoadSprite_Button_Click(sender As Object, e As EventArgs) Handles LoadSprite_Button.Click
        imgStr = SpriteLocation_TextBox.Text()
        If My.Computer.FileSystem.FileExists(imgStr) Then
            boxImage = Image.FromFile(imgStr)
            ShipImage_Display.Image() = boxImage
            fullSpritePath = System.IO.Path.GetFullPath(imgStr)
            sprite = System.IO.Path.GetFileNameWithoutExtension(imgStr)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub StretchImage_Checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles StretchImage_Checkbox.CheckedChanged
        If StretchImage_Checkbox.Checked Then
            ShipImage_Display.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf Not StretchImage_Checkbox.Checked Then
            ShipImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
        End If

    End Sub

    Private Sub AssignID_Button_Click(sender As Object, e As EventArgs) Handles AssignID_Button.Click
        ID = ID_TextBox.Text()
        ID_TextBox.Text = ID.ToString(fmt)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Ship Object Creation Tool made by Zac Hamid (2014)" + vbCrLf + "This program exports information into a file for importing into my game!" + vbCrLf + "All ships will be saved in the 'Ships' folder in the folder with the .exe for this application!", MsgBoxStyle.OkOnly, "About")
    End Sub

    Private Sub OpenProjectileSpriteDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenProjectileSpriteDialog.FileOk
        imgStr = OpenProjectileSpriteDialog.InitialDirectory() & OpenProjectileSpriteDialog.FileName
        ProjecSpriteLocation_TextBox.Text = imgStr
    End Sub

    Private Sub StretchImage_Checkbox2_CheckedChanged(sender As Object, e As EventArgs) Handles StretchImage_Checkbox2.CheckedChanged
        If StretchImage_Checkbox2.Checked Then
            ProjectileImage_Display.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf Not StretchImage_Checkbox2.Checked Then
            ProjectileImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub

    Private Sub LoadProjecSprite_Button_Click(sender As Object, e As EventArgs) Handles LoadProjecSprite_Button.Click
        imgStr = ProjecSpriteLocation_TextBox.Text()
        If My.Computer.FileSystem.FileExists(imgStr) Then
            boxImage = Image.FromFile(imgStr)
            ProjectileImage_Display.Image() = boxImage
            fullProjecSpritePath = System.IO.Path.GetFullPath(imgStr)
            projecSprite = System.IO.Path.GetFileNameWithoutExtension(imgStr)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub OpenProjectileSoundDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenProjectileSoundDialog.FileOk
        imgStr = OpenProjectileSoundDialog.InitialDirectory() & OpenProjectileSoundDialog.FileName
        ProjecSoundLocation_TextBox.Text = imgStr
        soundLocation = imgStr
    End Sub

    Private Sub ProjecSoundPlay_Button_Click(sender As Object, e As EventArgs) Handles ProjecSoundPlay_Button.Click
        If My.Computer.FileSystem.FileExists(soundLocation) Then
            My.Computer.Audio.Play(soundLocation, AudioPlayMode.Background)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub LoadProjecSound_Button_Click(sender As Object, e As EventArgs) Handles LoadProjecSound_Button.Click
        soundLocation = ProjecSoundLocation_TextBox.Text()
        If My.Computer.FileSystem.FileExists(soundLocation) Then
            fullProjecSoundPath = System.IO.Path.GetFullPath(soundLocation)
            projecSound = System.IO.Path.GetFileNameWithoutExtension(soundLocation)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub DescriptionApply_Button_Click(sender As Object, e As EventArgs) Handles DescriptionApply_Button.Click
        description = Description_TextBox.Text()
    End Sub

    Private Sub Apply_Button_Click(sender As Object, e As EventArgs) Handles Apply_Button.Click
        If (ShipName_TextBox.TextLength > 0 And ID_TextBox.TextLength = 4 And ShipPrice_TextBox.TextLength > 0 And shipSpeed_TextBox.TextLength > 0 And shipDamage_TextBox.TextLength > 0 And shipHealth_TextBox.TextLength > 0 And shipWidth_TextBox.TextLength > 0 And shipHeight_TextBox.TextLength > 0 And Description_TextBox.TextLength > 0 And shipClass_ComboBox.Text.Length > 0 And projecSprite.Length > 0 And projecSound.Length > 0 And sprite.Length > 0 And shipProjecSpeed_TextBox.TextLength > 0 And shipFiringTimer_TextBox.TextLength > 0 And SpriteLocation_TextBox.TextLength > 0 And ProjecSpriteLocation_TextBox.TextLength > 0 And ProjecSoundLocation_TextBox.TextLength > 0 And ExplSpriteLocation_TextBox.TextLength > 0 And ExplSoundLocation_TextBox.TextLength > 0 And explosionWidth_TextBox.TextLength > 0 And explosionHeight_TextBox.TextLength > 0 And explosionTimer_TextBox.TextLength > 0) Then
            shipName = ShipName_TextBox.Text()
            ID = Convert.ToInt32(ID_TextBox.Text())
            Price = ShipPrice_TextBox.Text()
            speed = shipSpeed_TextBox.Text()
            damage = shipDamage_TextBox.Text()
            health = shipHealth_TextBox.Text()
            shipWidth = shipWidth_TextBox.Text()
            shipHeight = shipHeight_TextBox.Text()
            shipClass = shipClass_ComboBox.Text()
            description = Description_TextBox.Text()
            firingTimer = shipFiringTimer_TextBox.Text()
            projecSpeed = shipProjecSpeed_TextBox.Text()
            explWidth = explosionWidth_TextBox.Text()
            explHeight = explosionHeight_TextBox.Text()
            explTimer = explosionTimer_TextBox.Text()
            LoadProjecSprite_Button_Click(sender, e)
            LoadSprite_Button_Click(sender, e)
            LoadProjecSound_Button_Click(sender, e)
            LoadExplSprite_Button_Click(sender, e)
            LoadExplSound_Button_Click(sender, e)
            canSave = True
        Else
            MsgBox("Please fill in all fields!", MsgBoxStyle.Exclamation, "Fields Incomplete!")
            canSave = False
        End If
    End Sub

    Sub ReadFile()
        Dim loadFile As New StreamReader(loadLocation, True)
        shipName = loadFile.ReadLine()
        ID = loadFile.ReadLine()
        sprite = loadFile.ReadLine()
        Price = loadFile.ReadLine()
        speed = loadFile.ReadLine()
        damage = loadFile.ReadLine()
        health = loadFile.ReadLine()
        shipClass = loadFile.ReadLine()
        projecSpeed = loadFile.ReadLine()
        firingTimer = loadFile.ReadLine()
        projecSprite = loadFile.ReadLine()
        projecSound = loadFile.ReadLine()
        explSprite = loadFile.ReadLine()
        explSound = loadFile.ReadLine()
        explWidth = loadFile.ReadLine()
        explHeight = loadFile.ReadLine()
        explTimer = loadFile.ReadLine()
        description = loadFile.ReadLine()
        shipWidth = loadFile.ReadLine()
        shipHeight = loadFile.ReadLine()
        loadFile.Close()
        MsgBox("File loaded successfully! Press apply all to load external files.", MsgBoxStyle.OkOnly, "Load Successful!")
        CompleteRefresh()
    End Sub

    Sub WriteToFile()
        Dim file As System.IO.StreamWriter
        Dim loadFile As System.IO.StreamWriter
        System.IO.Directory.CreateDirectory("Ships/" + (ID.ToString(fmt) + "-" + shipName))

        
        Dim shipSpriteName As String = "Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + System.IO.Path.GetFileName(fullSpritePath)
        Try
            My.Computer.FileSystem.CopyFile(fullSpritePath, (shipSpriteName), True)
        Catch ioEx As IO.IOException
            'ignore this directory'
        Catch authEx As UnauthorizedAccessException
            'ignore this directory'
        Catch ex As Exception
            Throw
        End Try

        Dim projecSpriteName As String = "Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + System.IO.Path.GetFileName(fullProjecSpritePath)
        Try
            My.Computer.FileSystem.CopyFile(fullProjecSpritePath, (projecSpriteName), True)
        Catch ioEx As IO.IOException
            'ignore this directory'
        Catch authEx As UnauthorizedAccessException
            'ignore this directory'
        Catch ex As Exception
            Throw
        End Try

        Dim projecSoundName As String = "Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + System.IO.Path.GetFileName(fullProjecSoundPath)
        Try
            My.Computer.FileSystem.CopyFile(fullProjecSoundPath, (projecSoundName), True)
        Catch ioEx As IO.IOException
            'ignore this directory'
        Catch authEx As UnauthorizedAccessException
            'ignore this directory'
        Catch ex As Exception
            Throw
        End Try

        Dim explSpriteName As String = "Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + System.IO.Path.GetFileName(fullExplSpritePath)
        Try
            My.Computer.FileSystem.CopyFile(fullExplSpritePath, (explSpriteName), True)
        Catch ioEx As IO.IOException
            'ignore this directory'
        Catch authEx As UnauthorizedAccessException
            'ignore this directory'
        Catch ex As Exception
            Throw
        End Try

        Dim explSoundName As String = "Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + System.IO.Path.GetFileName(fullExplSoundPath)
        Try
            My.Computer.FileSystem.CopyFile(fullExplSoundPath, (explSoundName), True)
        Catch ioEx As IO.IOException
            'ignore this directory'
        Catch authEx As UnauthorizedAccessException
            'ignore this directory'
        Catch ex As Exception
            Throw
        End Try

        file = My.Computer.FileSystem.OpenTextFileWriter("Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + ID.ToString(fmt) + "-" + shipName + ".txt", False)
        file.WriteLine("<!-- " + shipName + " -->")
        file.WriteLine("<Ship>")
        file.WriteLine("<Name>" + shipName + "</Name>")
        file.WriteLine("<ID>" + ID.ToString(fmt) + "</ID>")
        file.WriteLine("<Texture>" + sprite + "</Texture>")
        file.WriteLine("<Price>" + Price + "</Price>")
        file.WriteLine("<Speed>" + speed + "</Speed>")
        file.WriteLine("<Damage>" + damage + "</Damage>")
        file.WriteLine("<Health>" + health + "</Health>")
        file.WriteLine("<Class>" + shipClass + "</Class>")
        file.WriteLine("<ProjecSpeed>" + projecSpeed + "</ProjecSpeed>")
        file.WriteLine("<FiringTimer>" + firingTimer + "</FiringTimer>")
        file.WriteLine("<ProjectileSprite>" + projecSprite + "</ProjectileSprite>")
        file.WriteLine("<FireSound>" + projecSound + "</FireSound>")
        file.WriteLine("<ExplosionTexture>" + explSprite + "</ExplosionTexture>")
        file.WriteLine("<ExplosionSound>" + explSound + "</ExplosionSound>")
        file.WriteLine("<ExplosionWidth>" + explWidth + "</ExplosionWidth>")
        file.WriteLine("<ExplosionHeight>" + explHeight + "</ExplosionHeight>")
        file.WriteLine("<ExplosionTimer>" + explTimer + "</ExplosionTimer>")
        file.WriteLine("<Description>" + description + "</Description>")
        file.WriteLine("<Width>" + shipWidth + "</Width>")
        file.WriteLine("<Height>" + shipHeight + "</Height>")
        file.WriteLine("</Ship>")
        MsgBox(".txt file saved successfully!", vbOKOnly, "Save Successful!")
        file.Close()

        loadFile = My.Computer.FileSystem.OpenTextFileWriter("Ships/" + (ID.ToString(fmt) + "-" + shipName) + "/" + ID.ToString(fmt) + "-" + shipName + ".ship", False)
        loadFile.WriteLine(shipName)
        loadFile.WriteLine(ID.ToString(fmt))
        loadFile.WriteLine(shipSpriteName)
        loadFile.WriteLine(Price)
        loadFile.WriteLine(speed)
        loadFile.WriteLine(damage)
        loadFile.WriteLine(health)
        loadFile.WriteLine(shipClass)
        loadFile.WriteLine(projecSpeed)
        loadFile.WriteLine(firingTimer)
        loadFile.WriteLine(projecSpriteName)
        loadFile.WriteLine(projecSoundName)
        loadFile.WriteLine(explSpriteName)
        loadFile.WriteLine(explSoundName)
        loadFile.WriteLine(explWidth)
        loadFile.WriteLine(explHeight)
        loadFile.WriteLine(explTimer)
        loadFile.WriteLine(description)
        loadFile.WriteLine(shipWidth)
        loadFile.WriteLine(shipHeight)
        MsgBox(".ship file saved successfully!", vbOKOnly, "Save Successful!")
        loadFile.Close()
        MsgBox("File saved successfully!", MsgBoxStyle.OkOnly, "Save Successful!")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If canSave Then
            WriteToFile()
        Else
            MsgBox("Please fill in all fields!", MsgBoxStyle.Exclamation, "Fields Incomplete!")
        End If
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        OpenSHIPDialog.ShowDialog()
    End Sub

    Private Sub OpenSHIPDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenSHIPDialog.FileOk
        loadLocation = OpenSHIPDialog.InitialDirectory & OpenSHIPDialog.FileName
        ReadFile()
    End Sub

    Sub CompleteRefresh()
        ShipName_TextBox.Text = shipName
        ID_TextBox.Text = ID.ToString(fmt)
        SpriteLocation_TextBox.Text = sprite
        ShipPrice_TextBox.Text = Price
        shipSpeed_TextBox.Text = speed
        shipDamage_TextBox.Text = damage
        shipHealth_TextBox.Text = health
        shipClass_ComboBox.Text = shipClass
        shipProjecSpeed_TextBox.Text = projecSpeed
        shipFiringTimer_TextBox.Text = firingTimer
        ProjecSpriteLocation_TextBox.Text = projecSprite
        ProjecSoundLocation_TextBox.Text = projecSound
        ExplSpriteLocation_TextBox.Text = explSprite
        ExplSoundLocation_TextBox.Text = explSound
        explosionWidth_TextBox.Text = explWidth
        explosionHeight_TextBox.Text = explHeight
        explosionTimer_TextBox.Text = explTimer
        Description_TextBox.Text = description
        shipWidth_TextBox.Text = shipWidth
        shipHeight_TextBox.Text = shipHeight
    End Sub

    Private Sub ExitProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitProgramToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClearAll_Button_Click(sender As Object, e As EventArgs) Handles ClearAll_Button.Click

        ShipName_TextBox.Text = ""
        ID_TextBox.Text = "0000"
        SpriteLocation_TextBox.Text = ""
        ShipPrice_TextBox.Text = ""
        shipSpeed_TextBox.Text = ""
        shipDamage_TextBox.Text = ""
        shipHealth_TextBox.Text = ""
        shipClass_ComboBox.Text = ""
        shipProjecSpeed_TextBox.Text = ""
        shipFiringTimer_TextBox.Text = ""
        ProjecSpriteLocation_TextBox.Text = ""
        ProjecSoundLocation_TextBox.Text = ""
        ExplSpriteLocation_TextBox.Text = ""
        ExplSoundLocation_TextBox.Text = ""
        explosionWidth_TextBox.Text = ""
        explosionHeight_TextBox.Text = ""
        explosionTimer_TextBox.Text = ""
        Description_TextBox.Text = ""
        shipWidth_TextBox.Text = ""
        shipHeight_TextBox.Text = ""
        shipName = ""
        ShipImage_Display.Image = Nothing
        ProjectileImage_Display.Image = Nothing
        ExplosionImage_Display.Image = Nothing

    End Sub

    Private Sub ExplSpriteBrowse_Button_Click(sender As Object, e As EventArgs) Handles ExplSpriteBrowse_Button.Click
        Me.OpenExplosionSpriteDialog.ShowDialog()
    End Sub

    Private Sub ExplSoundBrowse_Button_Click(sender As Object, e As EventArgs) Handles ExplSoundBrowse_Button.Click
        Me.OpenExplosionSoundDialog.ShowDialog()
    End Sub

    Private Sub OpenExplosionSpriteDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenExplosionSpriteDialog.FileOk
        imgStr = OpenExplosionSpriteDialog.InitialDirectory() & OpenExplosionSpriteDialog.FileName
        ExplSpriteLocation_TextBox.Text() = imgStr
    End Sub

    Private Sub LoadExplSprite_Button_Click(sender As Object, e As EventArgs) Handles LoadExplSprite_Button.Click
        imgStr = ExplSpriteLocation_TextBox.Text()
        If My.Computer.FileSystem.FileExists(imgStr) Then
            boxImage = Image.FromFile(imgStr)
            ExplosionImage_Display.Image() = boxImage
            fullExplSpritePath = System.IO.Path.GetFullPath(imgStr)
            explSprite = System.IO.Path.GetFileNameWithoutExtension(imgStr)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub StretchImage_Checkbox3_CheckedChanged(sender As Object, e As EventArgs) Handles StretchImage_Checkbox3.CheckedChanged
        If StretchImage_Checkbox3.Checked Then
            ExplosionImage_Display.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf Not StretchImage_Checkbox3.Checked Then
            ExplosionImage_Display.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub

    Private Sub DefaultExplSprite_Button_Click(sender As Object, e As EventArgs) Handles DefaultExplSprite_Button.Click
        imgStr = "defaultexplosionimage.png"
        explSprite = imgStr
        ExplSpriteLocation_TextBox.Text() = imgStr
        fullExplSpritePath = explSprite
    End Sub

    Private Sub LoadExplSound_Button_Click(sender As Object, e As EventArgs) Handles LoadExplSound_Button.Click
        explSoundLocation = ExplSoundLocation_TextBox.Text()
        If My.Computer.FileSystem.FileExists(explSoundLocation) Then
            fullExplSoundPath = System.IO.Path.GetFullPath(explSoundLocation)
            explSound = System.IO.Path.GetFileNameWithoutExtension(explSoundLocation)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub ExplSoundPlay_Button_Click(sender As Object, e As EventArgs) Handles ExplSoundPlay_Button.Click
        If My.Computer.FileSystem.FileExists(explSoundLocation) Then
            My.Computer.Audio.Play(explSoundLocation, AudioPlayMode.Background)
        Else
            MsgBox("ERROR: File not found or path does not exist!", MsgBoxStyle.Exclamation, "Couldn't Find File")
        End If
    End Sub

    Private Sub DefaultExplSound_Button_Click(sender As Object, e As EventArgs) Handles DefaultExplSound_Button.Click
        explSoundLocation = "defaultexplosionsound.wav"
        ExplSoundLocation_TextBox.Text() = explSoundLocation
        fullExplSoundPath = explSoundLocation
    End Sub

    Private Sub OpenExplosionSoundDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenExplosionSoundDialog.FileOk
        explSoundLocation = OpenExplosionSoundDialog.InitialDirectory() & OpenExplosionSoundDialog.FileName
        ExplSoundLocation_TextBox.Text() = explSoundLocation
    End Sub

End Class