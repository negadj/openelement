Imports System.ComponentModel
Imports WebElement.Elements.Standard.WELabel

Namespace Elements.Standard.Editors.Converter
    Public Class TConvEnuBaliseH
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuBaliseH))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuBaliseH)
                Case EnuBaliseH.none
                    Return My.Resources.text.LocalizableFormAndConverter._0015
                Case EnuBaliseH.H1
                    Return My.Resources.text.LocalizableFormAndConverter._0129
                Case EnuBaliseH.H2
                    Return My.Resources.text.LocalizableFormAndConverter._0130
                Case EnuBaliseH.H3
                    Return My.Resources.text.LocalizableFormAndConverter._0131
                Case EnuBaliseH.H4
                    Return My.Resources.text.LocalizableFormAndConverter._0132
                Case EnuBaliseH.H5
                    Return My.Resources.text.LocalizableFormAndConverter._0133
                Case EnuBaliseH.H6
                    Return My.Resources.text.LocalizableFormAndConverter._0134
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class
End Namespace
