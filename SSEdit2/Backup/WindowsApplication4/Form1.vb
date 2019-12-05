Public Class Form1

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile.ShowDialog()
        Loading.Visible = True
        TabControl1.Enabled = True
        LoadValues("")
        Me.Text = "CSEdit <2>   Beta 0.7  " + OpenFile.FileName
        WBTB.Enabled = True
        JVTB.Enabled = True
        SPTB.Enabled = True
        LVTB.Enabled = True
        TRTB.Enabled = True
        WETB.Enabled = True
        LATB.Enabled = True
        SHTB.Enabled = True
    End Sub
    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox4.Click, ListBox5.Click, ListBox6.Click, ListBox7.Click, ListBox8.Click, ListBox1.Click, ListBox10.Click
        Dim Value(), temp As String

        PopulateShipValueBar(sender.Text)
        Input.Visible = False
        If Form3.Visible = True Then

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(Application.StartupPath + "\" + "template.sss")
            Value = Split(sender.text, "=")
            Do
                temp = sr.ReadLine
                If InStr(temp, Value(0)) > 1 Then
                    Form3.HelpText.Text = temp
                End If
            Loop Until sr.EndOfStream
            sr.Close()
        End If

    End Sub
    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog.ShowDialog()
        ListBox1.Font = FontDialog.Font
        ListBox2.Font = FontDialog.Font
        ListBox3.Font = FontDialog.Font
        ListBox4.Font = FontDialog.Font
        ListBox5.Font = FontDialog.Font
        ListBox6.Font = FontDialog.Font
        ListBox7.Font = FontDialog.Font
        ListBox8.Font = FontDialog.Font
        ListBox9.Font = FontDialog.Font
        ListBox10.Font = FontDialog.Font
        Form3.HelpText.Font = FontDialog.Font

    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        ShowInputBox(Me.ListBox1.Text, "Warbird")
    End Sub
    Private Sub ListBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowInputBox(Me.ListBox2.Text, "Javelin")
    End Sub
    Private Sub ListBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowInputBox(Me.ListBox3.Text, "Spider")
    End Sub
    Private Sub ListBox4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox4.DoubleClick
        ShowInputBox(Me.ListBox4.Text, "Leviathan")
    End Sub
    Private Sub ListBox5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox5.DoubleClick
        ShowInputBox(Me.ListBox5.Text, "Terrier")
    End Sub
    Private Sub ListBox6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox6.DoubleClick
        ShowInputBox(Me.ListBox6.Text, "Weasel")
    End Sub
    Private Sub ListBox7_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox7.DoubleClick
        ShowInputBox(Me.ListBox7.Text, "Lancaster")
    End Sub
    Private Sub ListBox8_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox8.DoubleClick
        ShowInputBox(Me.ListBox8.Text, "Shark")
    End Sub
    Private Sub ListBox10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox10.DoubleClick
        ShowInputBox(Me.ListBox10.Text, ListBox9.Text)
    End Sub
    Private Sub ShowInputBox(ByVal Text As String, ByVal Shipclass As String)
        Dim LocalMousePosition As Point
        'Bring up the editbox near the mouse on a LB doubleclick
        LocalMousePosition = ListBox1.PointToClient(System.Windows.Forms.Cursor.Position)
        Input.Left = (LocalMousePosition.X + 65)
        Input.Top = (LocalMousePosition.Y + 45)
        Dim myString As String = Text
        'Split the setting and value and save them to input.tag for saving if user presses enter
        Dim myArray() As String = Split(myString, "=")
        Input.Text = myArray(1)
        Input.Tag = Shipclass + " " + myArray(0)
        Me.Input.Visible = True
    End Sub
    Private Sub LoadValues(ByVal Opt As String)
        'This block here Gets all the currently selected indexes of listboxes n resets em after reload of config
        Dim LB1, LB2, LB3, LB4, LB5, LB6, LB7, LB8, LT1, LT2, LT3, LT4, LT5, LT6, LT7, LT8 As Integer ' LB is selected item in listboxes.. LT is the top item in the listbox
        LB1 = ListBox1.SelectedIndex
        LT1 = ListBox1.TopIndex
        LB2 = ListBox2.SelectedIndex
        LT2 = ListBox2.TopIndex
        LB3 = ListBox3.SelectedIndex
        LT3 = ListBox3.TopIndex
        LB4 = ListBox4.SelectedIndex
        LT4 = ListBox4.TopIndex
        LB5 = ListBox5.SelectedIndex
        LT5 = ListBox5.TopIndex
        LB6 = ListBox6.SelectedIndex
        LT6 = ListBox6.TopIndex
        LB7 = ListBox7.SelectedIndex
        LT7 = ListBox7.TopIndex
        LB8 = ListBox8.SelectedIndex
        LT8 = ListBox8.TopIndex

        'This bit shows the loading screen if not just refreshing the values
        If Opt = "" Then
            Loading.Visible = True
        End If

        Dim Temp1 As String
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()

        'Next block is the main loading engine for the .cfg.. much improved over last shitty slow version!
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(OpenFile.FileName)

        Do
            Select Case sr.ReadLine
                Case "[Warbird]"
                    Do
                        Temp1 = sr.ReadLine

                        If Temp1 <> "" Then ListBox1.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 1
                Case "[Javelin]"
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox2.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 2
                Case "[Spider]"
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox3.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 3
                Case "[Leviathan]"
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox4.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 4
                Case "[Terrier]"
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox5.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 5
                Case ("[Weasel]")
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox6.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 6
                Case ("[Lancaster]")
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox7.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 7
                Case ("[Shark]")
                    Do
                        Temp1 = sr.ReadLine
                        If Temp1 <> "" Then ListBox8.Items.Add(Temp1)
                    Loop Until Temp1 = ""
                    Loading.ProgressBar1.Value = 8
                Case Else
            End Select
        Loop Until sr.EndOfStream
        sr.Close()
        Loading.Visible = False

        'This block resets all the selected indexs after a refresh of values
        ListBox1.TopIndex = LT1
        ListBox1.SelectedIndex = LB1
        ListBox2.TopIndex = LT2
        ListBox2.SelectedIndex = LB2
        ListBox3.TopIndex = LT3
        ListBox3.SelectedIndex = LB3
        ListBox4.TopIndex = LT4
        ListBox4.SelectedIndex = LB4
        ListBox5.TopIndex = LT5
        ListBox5.SelectedIndex = LB5
        ListBox6.TopIndex = LT6
        ListBox6.SelectedIndex = LB6
        ListBox7.TopIndex = LT7
        ListBox7.SelectedIndex = LB7
        ListBox8.TopIndex = LT8
        ListBox8.SelectedIndex = LB8
    End Sub
    Private Sub PopulateShipValueBar(ByVal Text As String)
        Dim myString As String = Text
        ' Returns an array containing "Look", "at", and "these!".
        Dim myArray() As String = Split(myString, "=")
        WBTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Warbird", myArray(0)))
        JVTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Javelin", myArray(0)))
        SPTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Spider", myArray(0)))
        LVTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Leviathan", myArray(0)))
        TRTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Terrier", myArray(0)))
        WETB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Weasel", myArray(0)))
        LATB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Lancaster", myArray(0)))
        SHTB.Text = (INIread.ReadIniValue(OpenFile.FileName, "Shark", myArray(0)))
    End Sub
    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Input.Visible = False
    End Sub
    Private Sub Form1_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        TabControl1.Width = (Me.Width - 120)
        TabControl1.Height = (Me.Height - 70)
    End Sub
    Private Sub Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Input.KeyPress


        If AscW(e.KeyChar) = 13 Then ' on enter .. save the value!
            Dim Array() As String = Split(Input.Tag)

            INIwrite.WriteIniValue(OpenFile.FileName, Array(0), Array(1), Input.Text)
            Input.Visible = False
            LoadValues("Refresh")
        End If

    End Sub
    Private Sub SettingHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingHelpToolStripMenuItem.Click
        If Form3.Visible = False Then
            Form3.Visible = True
        Else
            Form3.Visible = False

        End If
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        If Form5.Visible = False Then
            Form5.Visible = True
        Else
            Form5.Visible = False

        End If

    End Sub
    Private Sub SelectSameValueandLevelViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectSameValueandLevelViewToolStripMenuItem.Click
        Dim LBTop, LBSel As Integer

        Select Case TabControl1.SelectedIndex
            Case 0
                LBTop = ListBox1.TopIndex
                LBSel = ListBox1.SelectedIndex
            Case 1
                LBTop = ListBox2.TopIndex
                LBSel = ListBox2.SelectedIndex
            Case 2
                LBTop = ListBox3.TopIndex
                LBSel = ListBox3.SelectedIndex
            Case 3
                LBTop = ListBox4.TopIndex
                LBSel = ListBox4.SelectedIndex
            Case 4
                LBTop = ListBox5.TopIndex
                LBSel = ListBox5.SelectedIndex
            Case 5
                LBTop = ListBox6.TopIndex
                LBSel = ListBox6.SelectedIndex
            Case 6
                LBTop = ListBox7.TopIndex
                LBSel = ListBox7.SelectedIndex
            Case 7
                LBTop = ListBox8.TopIndex
                LBSel = ListBox8.SelectedIndex
            Case 8
        End Select
        ListBox1.TopIndex = LBTop
        ListBox1.SelectedIndex = LBSel

        ListBox2.TopIndex = LBTop
        ListBox2.SelectedIndex = LBSel

        ListBox3.TopIndex = LBTop
        ListBox3.SelectedIndex = LBSel

        ListBox4.TopIndex = LBTop
        ListBox4.SelectedIndex = LBSel

        ListBox5.TopIndex = LBTop
        ListBox5.SelectedIndex = LBSel

        ListBox6.TopIndex = LBTop
        ListBox6.SelectedIndex = LBSel

        ListBox7.TopIndex = LBTop
        ListBox7.SelectedIndex = LBSel

        ListBox8.TopIndex = LBTop
        ListBox8.SelectedIndex = LBSel


    End Sub
    Private Sub AllowMultipleSelectionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllowMultipleSelectionsToolStripMenuItem.Click
        If AllowMultipleSelectionsToolStripMenuItem.Checked Then
            ListBox1.SelectionMode = SelectionMode.MultiExtended
            ListBox2.SelectionMode = SelectionMode.MultiExtended
            ListBox3.SelectionMode = SelectionMode.MultiExtended
            ListBox4.SelectionMode = SelectionMode.MultiExtended
            ListBox5.SelectionMode = SelectionMode.MultiExtended
            ListBox6.SelectionMode = SelectionMode.MultiExtended
            ListBox7.SelectionMode = SelectionMode.MultiExtended
            ListBox8.SelectionMode = SelectionMode.MultiExtended
        Else
            ListBox1.SelectionMode = SelectionMode.One
            ListBox2.SelectionMode = SelectionMode.One
            ListBox3.SelectionMode = SelectionMode.One
            ListBox4.SelectionMode = SelectionMode.One
            ListBox5.SelectionMode = SelectionMode.One
            ListBox6.SelectionMode = SelectionMode.One
            ListBox7.SelectionMode = SelectionMode.One
            ListBox8.SelectionMode = SelectionMode.One
        End If



    End Sub
    Private Sub SortAlphabeticallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SortAlphabeticallyToolStripMenuItem.Click
        If SortAlphabeticallyToolStripMenuItem.Checked = True Then
            ListBox1.Sorted = True
            ListBox2.Sorted = True
            ListBox3.Sorted = True
            ListBox4.Sorted = True
            ListBox5.Sorted = True
            ListBox6.Sorted = True
            ListBox7.Sorted = True
            ListBox8.Sorted = True
        Else
            ListBox1.Sorted = False
            ListBox2.Sorted = False
            ListBox3.Sorted = False
            ListBox4.Sorted = False
            ListBox5.Sorted = False
            ListBox6.Sorted = False
            ListBox7.Sorted = False
            ListBox8.Sorted = False
            LoadValues("Refresh")
        End If
    End Sub
    Private Sub ListBox9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox9.Click
        ListBox10.Items.Clear()
        Input.Visible = False

        Dim Temp1 As String
        Dim Temp2 As String
        Dim Temp3 As String
        Temp2 = "[" + ListBox9.Text + "]"

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(OpenFile.FileName)
        Do
            Temp1 = sr.ReadLine
            If Temp1 = Temp2 Then
                Do
                    Temp3 = sr.ReadLine
                    If Temp3 <> "" Then ListBox10.Items.Add(Temp3)
                Loop Until Temp3 = ""


            End If
        Loop Until sr.EndOfStream
        sr.Close()

    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If Form4.Visible = False Then
            Form4.Visible = True
        Else
            Form4.Visible = False

        End If
    End Sub
    Private Sub WBTB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WBTB.KeyPress, WETB.KeyPress, TRTB.KeyPress, SPTB.KeyPress, SHTB.KeyPress, LVTB.KeyPress, LATB.KeyPress, JVTB.KeyPress
        Dim Value() As String
        Dim count As Integer

        '   Value(0) = ""
        If AscW(e.KeyChar) = 13 Then

            Select Case TabControl1.SelectedIndex
                Case 0
                    For Count = 0 To (ListBox1.SelectedItems.Count - 1)

                        Value = Split(ListBox1.SelectedItems.Item(Count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 1

                    For count = 0 To (ListBox2.SelectedItems.Count - 1)
                        Value = Split(ListBox2.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next


                Case 2
                    For count = 0 To (ListBox3.SelectedItems.Count - 1)
                        Value = Split(ListBox3.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 3
                    For count = 0 To (ListBox4.SelectedItems.Count - 1)
                        Value = Split(ListBox4.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 4
                    For count = 0 To (ListBox5.SelectedItems.Count - 1)
                        Value = Split(ListBox5.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 5
                    For count = 0 To (ListBox6.SelectedItems.Count - 1)
                        Value = Split(ListBox6.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 6
                    For count = 0 To (ListBox7.SelectedItems.Count - 1)
                        Value = Split(ListBox7.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next

                Case 7
                    For count = 0 To (ListBox8.SelectedItems.Count - 1)
                        Value = Split(ListBox8.SelectedItems.Item(count), "=")
                        INIwrite.WriteIniValue(OpenFile.FileName, sender.tag, Value(0), sender.text)
                    Next
                Case 8

                Case Else

            End Select
            LoadValues("Refresh")
            PopulateShipValueBar(Value(0))
        End If

    End Sub
    Private Sub AllShipsPopupMenuClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllToolStripMenuItem1.Click
        Dim a As Integer
        Dim Count As Integer
        Dim Value() As String
        Dim Ships() As String = {"Warbird", "Javelin", "Spider", "Leviathan", "Terrier", "Weasel", "Lancaster", "Shark"}

        Select Case TabControl1.SelectedIndex
            Case 0
                For Count = 0 To (ListBox1.SelectedItems.Count - 1)

                    Value = Split(ListBox1.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 1
                For Count = 0 To (ListBox2.SelectedItems.Count - 1)

                    Value = Split(ListBox2.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 2
                For Count = 0 To (ListBox3.SelectedItems.Count - 1)

                    Value = Split(ListBox3.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 3
                For Count = 0 To (ListBox4.SelectedItems.Count - 1)

                    Value = Split(ListBox4.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 4
                For Count = 0 To (ListBox5.SelectedItems.Count - 1)

                    Value = Split(ListBox5.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 5
                For Count = 0 To (ListBox6.SelectedItems.Count - 1)

                    Value = Split(ListBox6.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 6
                For Count = 0 To (ListBox7.SelectedItems.Count - 1)

                    Value = Split(ListBox7.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
            Case 7
                For Count = 0 To (ListBox8.SelectedItems.Count - 1)

                    Value = Split(ListBox8.SelectedItems.Item(Count), "=")
                    For a = 0 To 7
                        INIwrite.WriteIniValue(OpenFile.FileName, Ships(a), Value(0), Value(1))
                    Next
                Next
        End Select

        LoadValues("Refresh")
        PopulateShipValueBar(Value(0))

    End Sub
    Private Sub WarbirdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarbirdToolStripMenuItem.Click, WeaselToolStripMenuItem.Click, TerrierToolStripMenuItem.Click, SpiderToolStripMenuItem.Click, LeviathanToolStripMenuItem.Click, LancasterToolStripMenuItem.Click, ALLToolStripMenuItem.Click, JavelinToolStripMenuItem1.Click, AllToolStripMenuItem1.Click
        Dim Value(), Temp As String
        Dim Count As Integer

        Select Case TabControl1.SelectedIndex
            Case 0
                For Count = 0 To (ListBox1.SelectedItems.Count - 1)

                    Value = Split(ListBox1.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 1

                For Count = 0 To (ListBox2.SelectedItems.Count - 1)
                    Value = Split(ListBox2.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next


            Case 2
                For Count = 0 To (ListBox3.SelectedItems.Count - 1)
                    Value = Split(ListBox3.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 3
                For Count = 0 To (ListBox4.SelectedItems.Count - 1)
                    Value = Split(ListBox4.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 4
                For Count = 0 To (ListBox5.SelectedItems.Count - 1)
                    Value = Split(ListBox5.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 5
                For Count = 0 To (ListBox6.SelectedItems.Count - 1)
                    Value = Split(ListBox6.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 6
                For Count = 0 To (ListBox7.SelectedItems.Count - 1)
                    Value = Split(ListBox7.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next

            Case 7
                For Count = 0 To (ListBox8.SelectedItems.Count - 1)
                    Value = Split(ListBox8.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, sender.text, Value(0), Value(1))
                Next
            Case 8

            Case Else

        End Select




        LoadValues("Refresh")
        PopulateShipValueBar(Value(0))
    End Sub

    
    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        LoadValues("")
    End Sub

    Private Sub CustomToolStripMenuItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        MsgBox(e.KeyCode)
    End Sub

   
    Private Sub CopySettingFromMItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarbirdToolStripMenuItem1.Click, TerrierToolStripMenuItem1.Click, SpiderToolStripMenuItem1.Click, SharkToolStripMenuItem.Click, LeviathanToolStripMenuItem1.Click, LancasterToolStripMenuItem1.Click, JavelinToolStripMenuItem.Click
        Dim Value(), Temp As String
        Dim Count As Integer

        Select Case TabControl1.SelectedIndex
            Case 0
                For Count = 0 To (ListBox1.SelectedItems.Count - 1)

                    Value = Split(ListBox1.SelectedItems.Item(Count), "=")
                    Temp = INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))
                    
                    INIwrite.WriteIniValue(OpenFile.FileName, ListBox1.Text, Value(0), Temp)

                Next
            Case 1

                For Count = 0 To (ListBox2.SelectedItems.Count - 1)
                    Value = Split(ListBox2.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "[Javelin]", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next


            Case 2
                For Count = 0 To (ListBox3.SelectedItems.Count - 1)
                    Value = Split(ListBox3.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Spider", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next
            Case 3
                For Count = 0 To (ListBox4.SelectedItems.Count - 1)
                    Value = Split(ListBox4.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Leviathan", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next
            Case 4
                For Count = 0 To (ListBox5.SelectedItems.Count - 1)
                    Value = Split(ListBox5.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Terrier", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next
            Case 5
                For Count = 0 To (ListBox6.SelectedItems.Count - 1)
                    Value = Split(ListBox6.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Weasel", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next
            Case 6
                For Count = 0 To (ListBox7.SelectedItems.Count - 1)
                    Value = Split(ListBox7.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Lancaster", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next

            Case 7
                For Count = 0 To (ListBox8.SelectedItems.Count - 1)
                    Value = Split(ListBox8.SelectedItems.Item(Count), "=")
                    INIwrite.WriteIniValue(OpenFile.FileName, "Shark", Value(0), (INIread.ReadIniValue(OpenFile.FileName, sender.text, Value(0))))
                Next
            Case 8

            Case Else

        End Select




        LoadValues("Refresh")

    End Sub

    
End Class
