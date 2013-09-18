Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextBoxEnumTextPosition
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(TextPosition))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, TextPosition)
                Case TextPosition.lefttop
                    Return LocalizableFormAndConverter._0005
                Case TextPosition.leftmiddle
                    Return LocalizableFormAndConverter._0006
                Case TextPosition.leftbottom
                    Return LocalizableFormAndConverter._0007
                Case TextPosition.top
                    Return LocalizableFormAndConverter._0008
                Case TextPosition.righttop
                    Return LocalizableFormAndConverter._0009
                Case TextPosition.rightmiddle
                    Return LocalizableFormAndConverter._0010
                Case TextPosition.rightbottom
                    Return LocalizableFormAndConverter._0011
                Case TextPosition.bottom
                    Return LocalizableFormAndConverter._0012
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

    Public Class TConvTextBoxEnumTextPositionSimple
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(TextPositionSimple))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, TextPositionSimple)
                Case TextPositionSimple.bottom
                    Return LocalizableFormAndConverter._0012
                Case TextPositionSimple.Left
                    Return LocalizableFormAndConverter._0013
                Case TextPositionSimple.Right
                    Return LocalizableFormAndConverter._0014
                Case TextPositionSimple.top
                    Return LocalizableFormAndConverter._0008
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

