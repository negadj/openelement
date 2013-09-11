Imports System.ComponentModel
Imports WebElement.Elements.Navigate.WEMenu

Namespace Elements.Navigate.Editors.Converter

    Public Class TConvMenuEnuStartPosition
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuStartPosition))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuStartPosition)
                Case EnuStartPosition.LeftBottom
                    Return My.Resources.text.LocalizableFormAndConverter._0066
                Case EnuStartPosition.LeftTop
                    Return My.Resources.text.LocalizableFormAndConverter._0067
                Case EnuStartPosition.RightBottom
                    Return My.Resources.text.LocalizableFormAndConverter._0069
                Case EnuStartPosition.RightTop
                    Return My.Resources.text.LocalizableFormAndConverter._0070
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

End Namespace
