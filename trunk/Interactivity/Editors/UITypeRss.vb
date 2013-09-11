Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports openElement.WebElement.ElementWECommon.Interactivity.Forms


Namespace Elements.Interactivity.Editors

    Public Class UITypeRss
        Inherits UITypeEditor
        Private service As IWindowsFormsEditorService


        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then

                    Dim RssMeta As FrmRss.MetaRSS = openElement.Serialization.Clone(value)

                    Dim FrmRss As New FrmRss(RssMeta)
                    If FrmRss.ShowDialog = DialogResult.OK Then

                        Return FrmRss.RssMeta
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