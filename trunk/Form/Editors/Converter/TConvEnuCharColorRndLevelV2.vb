Imports System.ComponentModel
Imports WebElement.Elements.Form.WECaptchaV2

Namespace Elements.Form.Editors.Converter

    Public Class TConvEnuCharColorRndLevelV2
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(Enu_CharColorRndLevel))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, Enu_CharColorRndLevel)
                Case Enu_CharColorRndLevel.Dark
                    Return My.Resources.text.LocalizableFormAndConverter._0135
                Case Enu_CharColorRndLevel.Light
                    Return My.Resources.text.LocalizableFormAndConverter._0136
                Case Enu_CharColorRndLevel.None
                    Return My.Resources.text.LocalizableFormAndConverter._0137
                Case Enu_CharColorRndLevel.VeryDark
                    Return My.Resources.text.LocalizableFormAndConverter._0138
                Case Enu_CharColorRndLevel.VeryLight
                    Return My.Resources.text.LocalizableFormAndConverter._0139
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function



    End Class

End Namespace