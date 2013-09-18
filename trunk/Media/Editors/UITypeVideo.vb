Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Imports openElement
Imports openElement.WebElement
Imports openElement.WebElement.ElementWECommon.Media.Forms
Imports openElement.WebElement.LinksManager

Namespace Elements.Media.Editors

    Public Class UITypeVideo
        Inherits UITypeEditor

        #Region "Fields"

        Private _Service As IWindowsFormsEditorService

        #End Region 'Fields

        #Region "Methods"

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                _Service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not _Service Is Nothing) Then

                    Dim videoLinks As Dictionary(Of String, Link) = Serialization.Clone(value)

                    Dim frmVideo As New FrmVideo(videoLinks, Utils.GetPageCultureContext(context))
                    If _Service.ShowDialog(frmVideo) = DialogResult.OK Then
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

        #End Region 'Methods

    End Class

End Namespace

