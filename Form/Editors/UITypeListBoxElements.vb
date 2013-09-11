Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports openElement.WebElement
Imports System.Windows.Forms



Namespace Elements.Form.Editors

    Public Class UITypeListBoxElements
        Inherits UITypeEditor


        Private service As IWindowsFormsEditorService

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then

                    Dim newList As Object()
                    Dim culture As String = Utils.GetPageCultureContext(context)
                    If value Is Nothing Then
                        ReDim newList(1)
                        newList(0) = New Object() {New DataType.LocalizableString(My.Resources.text.LocalizableFormAndConverter._0032, culture), New DataType.LocalizableString(My.Resources.text.LocalizableFormAndConverter._0034, culture)}
                        newList(1) = New Object() {New DataType.LocalizableString(My.Resources.text.LocalizableFormAndConverter._0033, culture), New DataType.LocalizableString(My.Resources.text.LocalizableFormAndConverter._0035, culture)}
                    Else
                        newList = openElement.Serialization.Clone(value)
                    End If

                    Dim frmListBox As New openElement.WebElement.ElementWECommon.Form.Forms.FrmRadioListElements(newList, culture)

                    If service.ShowDialog(frmListBox) = DialogResult.OK Then
                        Return frmListBox.ListBoxElements
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
