Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports openElement.WebElement
Imports System.Windows.Forms
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Form.Forms

Namespace Elements.Form.Editors

    Public Class UITypeWESendFormConfig
        Inherits UITypeEditor

        Private service As IWindowsFormsEditorService

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then


                    Dim culture As String = Utils.GetPageCultureContext(context)

                    Dim frmWESendFormConfig As New FrmWESendFormConfig(value, CType(context.Instance, ElementBase))

                    If service.ShowDialog(frmWESendFormConfig) = DialogResult.OK Then

                        Return frmWESendFormConfig.SendFormConfig
                    Else
                        Return value
                    End If

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


