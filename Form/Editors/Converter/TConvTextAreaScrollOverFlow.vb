Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextAreaScrollOverFlow
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(TextAreaScrollOverFlow))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Shared Function TextAreaScrollOverFlowFromCss(ByVal value As String) As TextAreaScrollOverFlow
            Select Case value.ToLower
                Case "auto"
                    Return TextAreaScrollOverFlow.auto
                Case "hidden"
                    Return TextAreaScrollOverFlow.hidden
                Case "scroll"
                    Return TextAreaScrollOverFlow.Scroll
                Case Else
                    Return TextAreaScrollOverFlow.Auto
            End Select
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

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, TextAreaScrollOverFlow)
                Case TextAreaScrollOverFlow.auto
                    Return LocalizableFormAndConverter._0002
                Case TextAreaScrollOverFlow.scroll
                    Return LocalizableFormAndConverter._0003
                Case TextAreaScrollOverFlow.hidden
                    Return LocalizableFormAndConverter._0004
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

