Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuCarrousel_VerticalDirection
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(EnuCarrouselVerticalDirection))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, EnuCarrouselVerticalDirection)
                Case EnuCarrouselVerticalDirection.GoToTop
                    Return LocalizableFormAndConverter._0126
                Case EnuCarrouselVerticalDirection.GoToBottom
                    Return LocalizableFormAndConverter._0127

                Case Else
                    Return LocalizableFormAndConverter._0093
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

