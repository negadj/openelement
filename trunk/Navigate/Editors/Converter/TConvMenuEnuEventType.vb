Imports System.ComponentModel
Imports WebElement.Elements.Navigate.WEMenu

Namespace Elements.Navigate.Editors.Converter

    Public Class TConvMenuEnuEventType
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuEventType))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuEventType)
                Case EnuEventType.Click
                    Return My.Resources.text.LocalizableFormAndConverter._0063
                Case EnuEventType.DblClick
                    Return My.Resources.text.LocalizableFormAndConverter._0064
                Case EnuEventType.Over
                    Return My.Resources.text.LocalizableFormAndConverter._0065
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace