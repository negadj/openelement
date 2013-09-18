Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuCarrouselDirection
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(EnuCarrouselHorizontalDirection))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, EnuCarrouselHorizontalDirection)
                Case EnuCarrouselHorizontalDirection.GoToLeft
                    Return LocalizableFormAndConverter._0091
                Case EnuCarrouselHorizontalDirection.GoToRight
                    Return LocalizableFormAndConverter._0092

                Case Else
                    Return LocalizableFormAndConverter._0093
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

