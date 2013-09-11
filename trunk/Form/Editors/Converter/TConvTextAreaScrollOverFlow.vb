Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextAreaScrollOverFlow
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(TextAreaScrollOverFlow))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, TextAreaScrollOverFlow)
                Case TextAreaScrollOverFlow.auto
                    Return My.Resources.text.LocalizableFormAndConverter._0002
                Case TextAreaScrollOverFlow.scroll
                    Return My.Resources.text.LocalizableFormAndConverter._0003
                Case TextAreaScrollOverFlow.hidden
                    Return My.Resources.text.LocalizableFormAndConverter._0004

                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

        Public Shared Function TextAreaScrollOverFlowToCss(ByVal value As TextAreaScrollOverFlow) As String
            Select Case value
                Case TextAreaScrollOverFlow.auto
                    Return "auto"
                Case TextAreaScrollOverFlow.hidden
                    Return "hidden"
                Case TextAreaScrollOverFlow.scroll
                    Return "scroll"

                Case Else
                    Return ""
            End Select
        End Function

        Public Shared Function TextAreaScrollOverFlowFromCss(ByVal value As String) As TextAreaScrollOverFlow
            Select Case value.ToLower
                Case "auto"
                    Return TextAreaScrollOverFlow.auto
                Case "hidden"
                    Return TextAreaScrollOverFlow.hidden
                Case "scroll"
                    Return TextAreaScrollOverFlow.scroll

            End Select
        End Function

    End Class



End Namespace
