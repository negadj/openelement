Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Other.Editors.Converter

    Public Class TConvEnuHeaderPosition
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEBannerPage.EnuHeaderPosition))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEBannerPage.EnuHeaderPosition)
                Case WEBannerPage.EnuHeaderPosition.Bottom
                    Return LocalizableFormAndConverter._0090
                Case WEBannerPage.EnuHeaderPosition.Top
                    Return LocalizableFormAndConverter._0089
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

