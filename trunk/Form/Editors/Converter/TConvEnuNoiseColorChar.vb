Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvEnuNoiseColorChar
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WECaptcha.EnuNoiseColorChar))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WECaptcha.EnuNoiseColorChar)
                Case WECaptcha.EnuNoiseColorChar.Same
                    Return LocalizableFormAndConverter._0140
                Case WECaptcha.EnuNoiseColorChar.Ramdom
                    Return LocalizableFormAndConverter._0141
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

