Imports System.ComponentModel
Imports WebElement.Elements.Media.WEFlash

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashQuality
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuFlashQuality))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuFlashQuality)
                Case EnuFlashQuality.autohigh
                    Return My.Resources.text.LocalizableFormAndConverter._0044
                Case EnuFlashQuality.autolow
                    Return My.Resources.text.LocalizableFormAndConverter._0045
                Case EnuFlashQuality.best
                    Return My.Resources.text.LocalizableFormAndConverter._0046
                Case EnuFlashQuality.high
                    Return My.Resources.text.LocalizableFormAndConverter._0047
                Case EnuFlashQuality.low
                    Return My.Resources.text.LocalizableFormAndConverter._0048
                Case EnuFlashQuality.medium
                    Return My.Resources.text.LocalizableFormAndConverter._0049
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace