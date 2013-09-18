Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Navigate.Editors.Converter

    Public Class TConvMenuEnuStartPosition
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEMenu.EnuStartPosition))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEMenu.EnuStartPosition)
                Case WEMenu.EnuStartPosition.LeftBottom
                    Return LocalizableFormAndConverter._0066
                Case WEMenu.EnuStartPosition.LeftTop
                    Return LocalizableFormAndConverter._0067
                Case WEMenu.EnuStartPosition.RightBottom
                    Return LocalizableFormAndConverter._0069
                Case WEMenu.EnuStartPosition.RightTop
                    Return LocalizableFormAndConverter._0070
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

