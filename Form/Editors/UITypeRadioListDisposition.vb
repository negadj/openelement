Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Imports openElement
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.ElementWECommon.Form.Forms

Namespace Elements.Form.Editors

    <OEObsolete(1, 31)> _
    Public Class UITypeRadioListDisposition
        Inherits UITypeEditor

        #Region "Fields"

        Private _Service As IWindowsFormsEditorService

        #End Region 'Fields

        #Region "Methods"

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                _Service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not _Service Is Nothing) Then

                    Dim newPosition As WERadioButtonListDisposition

                    If value Is Nothing Then
                        newPosition = New WERadioButtonListDisposition()
                    Else
                        newPosition = Serialization.Clone(value)
                    End If

                    Dim frmRadio As New FrmRadioListDisposition(newPosition.Alignement, newPosition.Disposition, newPosition.LabelsPosition)

                    Call frmRadio.SelectPreSelectionDisposition()

                    If _Service.ShowDialog(frmRadio) = DialogResult.OK Then

                        newPosition.Disposition = frmRadio.Disposition
                        newPosition.LabelsPosition = frmRadio.LabelsPosition
                        newPosition.Alignement = frmRadio.Alignement

                        Return newPosition

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

