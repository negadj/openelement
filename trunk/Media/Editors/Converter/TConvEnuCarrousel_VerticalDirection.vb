Imports System.ComponentModel


Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuCarrousel_VerticalDirection
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuCarrousel_VerticalDirection))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuCarrousel_VerticalDirection)
                Case EnuCarrousel_VerticalDirection.GoToTop
                    Return My.Resources.text.LocalizableFormAndConverter._0126
                Case EnuCarrousel_VerticalDirection.GoToBottom
                    Return My.Resources.text.LocalizableFormAndConverter._0127

                Case Else
                    Return My.Resources.text.LocalizableFormAndConverter._0093
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class



End Namespace