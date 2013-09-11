Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports openElement.WebElement


Namespace Elements.Media.Editors


    Public Class UITypeVideo
        Inherits UITypeEditor



        Private service As IWindowsFormsEditorService


        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then

                    Dim _VideoLinks As Dictionary(Of String, LinksManager.Link) = openElement.Serialization.Clone(value)

                    Dim frmVideo As New openElement.WebElement.ElementWECommon.Media.Forms.FrmVideo(_VideoLinks, Utils.GetPageCultureContext(context))
                    If service.ShowDialog(frmVideo) = DialogResult.OK Then
                        Return frmVideo.Links
                    Else
                        Return value
                    End If

                Else
                    Return value
                End If

            End If

            Return MyBase.EditValue(context, provider, value)

        End Function

        Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle

            If (Not context Is Nothing And Not context.Instance Is Nothing) Then
                Return UITypeEditorEditStyle.Modal
            End If

            Return MyBase.GetEditStyle(context)


        End Function


    End Class
End Namespace
