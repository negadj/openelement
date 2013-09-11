﻿Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports openElement.WebElement.DataType

Namespace Elements.Navigate.Editors
    Public Class UITypeMenuGroup
        Inherits UITypeEditor



        Private service As IWindowsFormsEditorService


        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then

                service = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (Not service Is Nothing) Then
                    Dim MenuGroup As WEMenuGroup = openElement.Serialization.Clone(value)

                    Dim WEMenu As WEMenu = CType(context.Instance, WEMenu)

                    Dim FrmListOfObj As New openElement.WebElement.ElementWECommon.Navigate.Forms.FrmConfigPopupMenu(MenuGroup, WEMenu.Hook, WEMenu.Trigger, WEMenu.EventType, context.Instance)
                    If service.ShowDialog(FrmListOfObj) = DialogResult.OK Then
                        WEMenu.Hook = FrmListOfObj.Hook
                        WEMenu.Trigger = FrmListOfObj.Trigger
                        WEMenu.EventType = FrmListOfObj.EventType

                        Return MenuGroup
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

