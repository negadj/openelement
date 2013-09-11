Imports System.ComponentModel
Imports WebElement.Elements.Media.WEFlash

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashSalign
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuFlashSalign))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuFlashSalign)
                Case EnuFlashSalign.none
                    Return My.Resources.text.LocalizableFormAndConverter._0015
                Case EnuFlashSalign.l
                    Return My.Resources.text.LocalizableFormAndConverter._0041
                Case EnuFlashSalign.r
                    Return My.Resources.text.LocalizableFormAndConverter._0042
                Case EnuFlashSalign.t
                    Return My.Resources.text.LocalizableFormAndConverter._0043
                Case EnuFlashSalign.tl
                    Return My.Resources.text.LocalizableFormAndConverter._0050
                Case EnuFlashSalign.tr
                    Return My.Resources.text.LocalizableFormAndConverter._0051
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

End Namespace