
Imports System.ComponentModel

Namespace Elements.Other.Editors.Converter

    Public Class TConvEnuHeaderPosition
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(WEBannerPage.EnuHeaderPosition))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, WEBannerPage.EnuHeaderPosition)
                Case WEBannerPage.EnuHeaderPosition.Bottom
                    Return My.Resources.text.LocalizableFormAndConverter._0090
                Case WEBannerPage.EnuHeaderPosition.Top
                    Return My.Resources.text.LocalizableFormAndConverter._0089
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class

End Namespace