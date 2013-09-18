Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Imports openElement
Imports openElement.WebElement
Imports openElement.WebElement.ElementWECommon.Form.Forms

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors

    Public Class UITypeListBoxElements
        Inherits UITypeEditor

        #Region "Fields"

        Private _Service As IWindowsFormsEditorService

        #End Region 'Fields

        #Region "Methods"

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                _Service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not _Service Is Nothing) Then

                    Dim newList As Object()
                    Dim culture As String = Utils.GetPageCultureContext(context)
                    If value Is Nothing Then
                        ReDim newList(1)
                        newList(0) = New Object() {New LocalizableString(LocalizableFormAndConverter._0032, culture), New LocalizableString(LocalizableFormAndConverter._0034, culture)}
                        newList(1) = New Object() {New LocalizableString(LocalizableFormAndConverter._0033, culture), New LocalizableString(LocalizableFormAndConverter._0035, culture)}
                    Else
                        newList = Serialization.Clone(value)
                    End If

                    Dim frmListBox As New FrmRadioListElements(newList, culture)

                    If _Service.ShowDialog(frmListBox) = DialogResult.OK Then
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

        #End Region 'Methods

    End Class

End Namespace

