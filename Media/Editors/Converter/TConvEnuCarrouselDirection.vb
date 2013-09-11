Imports System.ComponentModel


Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuCarrouselDirection
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuCarrousel_HorizontalDirection))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuCarrousel_HorizontalDirection)
                Case EnuCarrousel_HorizontalDirection.GoToLeft
                    Return My.Resources.text.LocalizableFormAndConverter._0091
                Case EnuCarrousel_HorizontalDirection.GoToRight
                    Return My.Resources.text.LocalizableFormAndConverter._0092

                Case Else
                    Return My.Resources.text.LocalizableFormAndConverter._0093
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class



End Namespace