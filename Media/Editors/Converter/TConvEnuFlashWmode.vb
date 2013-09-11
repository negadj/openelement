Imports System.ComponentModel
Imports WebElement.Elements.Media.WEFlash

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashWmode
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuFlashWmode))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuFlashWmode)
                Case EnuFlashWmode.window
                    Return My.Resources.text.LocalizableFormAndConverter._0055
                Case EnuFlashWmode.opaque
                    Return My.Resources.text.LocalizableFormAndConverter._0056
                Case EnuFlashWmode.transparent
                    Return My.Resources.text.LocalizableFormAndConverter._0057

                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace
