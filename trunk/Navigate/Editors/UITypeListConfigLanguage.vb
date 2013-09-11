Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Windows.Forms
Imports WebElement.Elements.Navigate.WEFlag

Namespace Elements.Navigate.Editors

    Public Class UITypeListConfigLanguage
        Inherits UITypeEditor

        Private service As IWindowsFormsEditorService


        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then
                    Dim ListConfigLanguage As List(Of openElement.WebElement.DataType.WEConfigLanguage) = openElement.Serialization.Clone(value)
                    Dim ElementWEFlag As WEFlag = context.Instance

                    Dim FrmListOfObj As New openElement.WebElement.ElementWECommon.Navigate.Forms.FrmListConfigLanguage(ListConfigLanguage, ElementWEFlag.Page)
                    If service.ShowDialog(FrmListOfObj) = DialogResult.OK Then
                        Return ListConfigLanguage
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