
Imports System.ComponentModel
Imports WebElement.Elements.Interactivity.WEIframe

Namespace Elements.Containers.Editors.Converter
    Public Class TConvEnuCollapsiblePanelPosition
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(WECollapsiblePanel.EnuCollapsiblePanelPosition))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, WECollapsiblePanel.EnuCollapsiblePanelPosition)
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Top
                    Return My.Resources.text.LocalizableFormAndConverter._0194 ' top
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Bottom
                    Return My.Resources.text.LocalizableFormAndConverter._0195 ' Bottom
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Left
                    Return My.Resources.text.LocalizableFormAndConverter._0196 ' left
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Right
                    Return My.Resources.text.LocalizableFormAndConverter._0197 ' right
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace

