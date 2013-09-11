Imports System.ComponentModel
Imports WebElement.Elements.Form.WECaptcha

Namespace Elements.Form.Editors.Converter

    Public Class TConvEnuNoiseColorChar
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(Enu_NoiseColorChar))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, Enu_NoiseColorChar)
                Case Enu_NoiseColorChar.Same
                    Return My.Resources.text.LocalizableFormAndConverter._0140
                Case Enu_NoiseColorChar.Ramdom
                    Return My.Resources.text.LocalizableFormAndConverter._0141
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

End Namespace