Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextBoxEnumTextPosition
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(TextPosition))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, TextPosition)
                Case TextPosition.lefttop
                    Return My.Resources.text.LocalizableFormAndConverter._0005
                Case TextPosition.leftmiddle
                    Return My.Resources.text.LocalizableFormAndConverter._0006
                Case TextPosition.leftbottom
                    Return My.Resources.text.LocalizableFormAndConverter._0007
                Case TextPosition.top
                    Return My.Resources.text.LocalizableFormAndConverter._0008
                Case TextPosition.righttop
                    Return My.Resources.text.LocalizableFormAndConverter._0009
                Case TextPosition.rightmiddle
                    Return My.Resources.text.LocalizableFormAndConverter._0010
                Case TextPosition.rightbottom
                    Return My.Resources.text.LocalizableFormAndConverter._0011
                Case TextPosition.bottom
                    Return My.Resources.text.LocalizableFormAndConverter._0012
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class


    Public Class TConvTextBoxEnumTextPositionSimple
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(TextPositionSimple))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, TextPositionSimple)
                Case TextPositionSimple.bottom
                    Return My.Resources.text.LocalizableFormAndConverter._0012
                Case TextPositionSimple.left
                    Return My.Resources.text.LocalizableFormAndConverter._0013
                Case TextPositionSimple.right
                    Return My.Resources.text.LocalizableFormAndConverter._0014
                Case TextPositionSimple.top
                    Return My.Resources.text.LocalizableFormAndConverter._0008
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

    End Class


End Namespace
