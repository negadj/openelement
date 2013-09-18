Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvWERadioButtonListDisposition
        Inherits TypeConverter

        #Region "Fields"

        Private _BaseValue As Object

        #End Region 'Fields

        #Region "Methods"

        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
            Return _BaseValue
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, _
            ByVal destinationType As Type) As Object
            If value Is Nothing Then Return String.Concat("(", LocalizableFormAndConverter._0015, ")")

            _BaseValue = value
            Dim element As WERadioButtonListDisposition = CType(value, WERadioButtonListDisposition)
            If element Is Nothing Then Return String.Concat("(", LocalizableFormAndConverter._0015, ")")

            Select Case element.Disposition
                Case RadioButtonDisposition.horizontal
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return LocalizableFormAndConverter._0016
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return LocalizableFormAndConverter._0017
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return LocalizableFormAndConverter._0018
                        Case TextPosition.top
                            Return LocalizableFormAndConverter._0019
                    End Select
                Case RadioButtonDisposition.Vertical
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return LocalizableFormAndConverter._0020
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return LocalizableFormAndConverter._0021
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return LocalizableFormAndConverter._0022
                        Case TextPosition.top
                            Return LocalizableFormAndConverter._0023
                    End Select
                Case RadioButtonDisposition.verticalAlign
                    Select Case element.LabelsPosition
                        Case TextPosition.bottom
                            Return LocalizableFormAndConverter._0024
                        Case TextPosition.leftbottom, TextPosition.leftmiddle, TextPosition.lefttop
                            Return LocalizableFormAndConverter._0025
                        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
                            Return LocalizableFormAndConverter._0026
                        Case TextPosition.top
                            Return LocalizableFormAndConverter._0027
                    End Select
            End Select

            Return Nothing
        End Function

        #End Region 'Methods

    End Class

End Namespace

