Imports System.ComponentModel


Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuCarrouselTypeEffect
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuCarrousel_TypeEffect))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuCarrousel_TypeEffect)
                Case EnuCarrousel_TypeEffect.linear_linear
                    Return My.Resources.text.LocalizableFormAndConverter._0123
                Case EnuCarrousel_TypeEffect.sequential
                    Return My.Resources.text.LocalizableFormAndConverter._0125
                Case Else
                    Return My.Resources.text.LocalizableFormAndConverter._0093
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class



End Namespace