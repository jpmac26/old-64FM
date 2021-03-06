﻿Imports System.IO
Public Class ExportCCForm
    Dim ParentWindow As ColorCodeCopyPasteForm
    Dim CCPath As String = Application.StartupPath + "\CCs\"
    Dim colorcode As String

    Public Sub New(ByVal Text As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        colorcode = Text
    End Sub
    Private Sub OKbtn_Click(sender As Object, e As EventArgs) Handles OKbtn.Click
        'Dim CCLines As String() = colorcode.Split(vbCrLf)
        If Nametb.Text = "" Or Nametb.Text = " " Then
            MsgBox("You can't set a null name.", MsgBoxStyle.Critical, "Whoops.")
        Else
            If File.Exists(CCPath + Nametb.Text + ".64cc") = True Then
                Dim Confirmation As DialogResult = MessageBox.Show("There is already a colorcode with this name. You will overwrite it?", "SAME_NAME_FILE_DETECTED -- BZZT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Confirmation = DialogResult.Yes Then
                    Try
                        File.Delete(CCPath + Nametb.Text + ".64cc")
                        Using output As New StreamWriter(CCPath + Nametb.Text + ".64cc")

                            'For Each line As String In CCLines
                            '    output.WriteLine(line.TrimEnd(vbCrLf))
                            'Next

                            output.Write(colorcode)
                            MsgBox("Exported!", MsgBoxStyle.MsgBoxHelp, "Yay.")
                            output.Write(colorcode)

                            Me.Close()
                        End Using
                    Catch ex As Exception
                        MsgBox("I don't know, something happened. Make sure the file to delete was already there.", MsgBoxStyle.Information, "Welp.")
                    End Try
                Else
                    'Nothing.
                End If
            Else
                Try


                    Using output As New StreamWriter(CCPath + Nametb.Text + ".64cc")

                        'For Each line As String In CCLines
                        '    output.WriteLine(line.TrimEnd(vbCrLf))
                        'Next

                        output.Write(colorcode)
                        MsgBox("Exported!", MsgBoxStyle.Information, "Yay.")

                        'TODO: Make a new form for the CC mode addon type so we don't need to edit the CC form
                        'to make them. Instead, from that form edit the controls of the CC form.
                        Me.Close()

                    End Using
                Catch ex As Exception
                    'Gotta add regex
                    MsgBox("I don't know, something happened. Make sure you didn't add symbols like / ? * or something. (this will be temporal)", MsgBoxStyle.Information, "Welp.")

                End Try
            End If
        End If
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Me.Close()
    End Sub
End Class