Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    ' <Obsolete()> _ 'DD commented to remove VS warning
    Public Class TConvEnuCharColorRndLevel
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WECaptcha.EnuCharColorRndLevel))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WECaptcha.EnuCharColorRndLevel)
                Case WECaptcha.EnuCharColorRndLevel.Dark
                    Return LocalizableFormAndConverter._0135
                Case WECaptcha.EnuCharColorRndLevel.Light
                    Return LocalizableFormAndConverter._0136
                Case WECaptcha.EnuCharColorRndLevel.None
                    Return LocalizableFormAndConverter._0137
                Case WECaptcha.EnuCharColorRndLevel.VeryDark
                    Return LocalizableFormAndConverter._0138
                Case WECaptcha.EnuCharColorRndLevel.VeryLight
                    Return LocalizableFormAndConverter._0139
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

