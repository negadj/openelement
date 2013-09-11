Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports openElement.WebElement
Imports System.Windows.Forms
Imports openElement.WebElement.ElementWECommon.Form.Forms



Namespace Elements.Form.Editors

    <openElement.WebElement.Common.Attributes.OEObsolete(1, 31)> _
    Public Class UITypeRadioListElements
        Inherits UITypeEditor



        Private service As IWindowsFormsEditorService

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then

                    Dim newList As FrmRadioListElements.WERadioButtonListElement
                    Dim culture As String = Utils.GetPageCultureContext(context)

                    If value Is Nothing Then
                        newList = New FrmRadioListElements.WERadioButtonListElement()
                    Else
                        newList = openElement.Serialization.Clone(value)
                    End If

                    Dim frmRadio As New openElement.WebElement.ElementWECommon.Form.Forms.FrmRadioListElements(newList, culture)

                    If service.ShowDialog(frmRadio) = DialogResult.OK Then

                        Return frmRadio.RadioList
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