Imports System.ComponentModel
Imports WebElement.Elements.Media.WEFlash

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashAlign
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuFlashAlign))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuFlashAlign)
                Case EnuFlashAlign.none
                    Return My.Resources.text.LocalizableFormAndConverter._0015
                Case EnuFlashAlign.l
                    Return My.Resources.text.LocalizableFormAndConverter._0041
                Case EnuFlashAlign.r
                    Return My.Resources.text.LocalizableFormAndConverter._0042
                Case EnuFlashAlign.t
                    Return My.Resources.text.LocalizableFormAndConverter._0043

                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace
