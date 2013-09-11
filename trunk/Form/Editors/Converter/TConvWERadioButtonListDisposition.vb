Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter

    Public Class TConvWERadioButtonListDisposition
        Inherits TypeConverter

        Private _BaseValue As Object

        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object

            Return _BaseValue

        End Function


        Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, _
        ByVal destinationType As System.Type) As Object

            If value Is Nothing Then Return String.Concat("(", My.Resources.text.LocalizableFormAndConverter._0015, ")")

            _BaseValue = value
            Dim element As WERadioButtonListDisposition = CType(value, WERadioButtonListDisposition)
            If element Is Nothing Then Return String.Concat("(", My.Resources.text.LocalizableFormAndConverter._0015, ")")

            Select Case element.Disposition
                Case RadioButtonDisposition.horizontal
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return My.Resources.text.LocalizableFormAndConverter._0016
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return My.Resources.text.LocalizableFormAndConverter._0017
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return My.Resources.text.LocalizableFormAndConverter._0018
                        Case TextPosition.top
                            Return My.Resources.text.LocalizableFormAndConverter._0019
                    End Select
                Case RadioButtonDisposition.Vertical
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return My.Resources.text.LocalizableFormAndConverter._0020
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return My.Resources.text.LocalizableFormAndConverter._0021
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return My.Resources.text.LocalizableFormAndConverter._0022
                        Case TextPosition.top
                            Return My.Resources.text.LocalizableFormAndConverter._0023
                    End Select
                Case RadioButtonDisposition.verticalAlign
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return My.Resources.text.LocalizableFormAndConverter._0024
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return My.Resources.text.LocalizableFormAndConverter._0025
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return My.Resources.text.LocalizableFormAndConverter._0026
                        Case TextPosition.top
                            Return My.Resources.text.LocalizableFormAndConverter._0027
                    End Select
            End Select

            Return Nothing
        End Function

    End Class


End Namespace