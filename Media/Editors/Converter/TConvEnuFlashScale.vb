Imports System.ComponentModel
Imports WebElement.Elements.Media.WEFlash

Namespace Elements.Media.Editors.Converter


    Public Class TConvEnuFlashScale
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuFlashScale))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuFlashScale)
                Case EnuFlashScale.showall
                    Return My.Resources.text.LocalizableFormAndConverter._0093
                Case EnuFlashScale.noborder
                    Return My.Resources.text.LocalizableFormAndConverter._0053
                Case EnuFlashScale.exactfit
                    Return My.Resources.text.LocalizableFormAndConverter._0054
                Case Else
                    Return String.Empty
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace
