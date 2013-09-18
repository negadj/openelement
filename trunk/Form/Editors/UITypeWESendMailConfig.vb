﻿Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Form.Forms

Namespace Elements.Form.Editors

    Public Class UITypeWESendMailConfig
        Inherits UITypeEditor

        #Region "Fields"

        Private _Service As IWindowsFormsEditorService

        #End Region 'Fields

        #Region "Methods"

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                _Service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not _Service Is Nothing) Then

                    If (Not _Service Is Nothing) Then

                        Dim culture As String = Utils.GetPageCultureContext(context)

                        Dim frmSendMailConfig As New FrmWESendMailConfig(value, culture, CType(context.Instance, ElementBase))

                        If _Service.ShowDialog(frmSendMailConfig) = DialogResult.OK Then
                            'Return FrmSendMailConfig.SendMailConfig <-  marche pas
                            Return New FrmWESendMailConfig.WeSendMailConfig(frmSendMailConfig.SendMailConfig.FormLinks, frmSendMailConfig.SendMailConfig.SendMailInfo, frmSendMailConfig.SendMailConfig.SendMailResponse)

                        Else
                            Return value
                        End If

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

