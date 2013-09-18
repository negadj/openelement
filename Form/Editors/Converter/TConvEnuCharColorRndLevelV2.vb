Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvEnuCharColorRndLevelV2
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WECaptchaV2.EnuCharColorRndLevel))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WECaptchaV2.EnuCharColorRndLevel)
                Case WECaptchaV2.EnuCharColorRndLevel.Dark
                    Return LocalizableFormAndConverter._0135
                Case WECaptchaV2.EnuCharColorRndLevel.Light
                    Return LocalizableFormAndConverter._0136
                Case WECaptchaV2.EnuCharColorRndLevel.None
                    Return LocalizableFormAndConverter._0137
                Case WECaptchaV2.EnuCharColorRndLevel.VeryDark
                    Return LocalizableFormAndConverter._0138
                Case WECaptchaV2.EnuCharColorRndLevel.VeryLight
                    Return LocalizableFormAndConverter._0139
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

