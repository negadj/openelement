
Imports System.ComponentModel
Imports WebElement.Elements.Interactivity.WEIframe

Namespace Elements.Interactivity.Editors.Converter

    Public Class TConvEnuScrolling
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuScrolling))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuScrolling)
                Case EnuScrolling.auto
                    Return My.Resources.text.LocalizableFormAndConverter._0148
                Case EnuScrolling.no
                    Return My.Resources.text.LocalizableFormAndConverter._0149
                Case EnuScrolling.yes
                    Return My.Resources.text.LocalizableFormAndConverter._0150
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace

