Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Interactivity.Editors.Converter

    Public Class TConvEnuScrolling
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEIframe.EnuScrolling))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEIframe.EnuScrolling)
                Case WEIframe.EnuScrolling.auto
                    Return LocalizableFormAndConverter._0148
                Case WEIframe.EnuScrolling.no
                    Return LocalizableFormAndConverter._0149
                Case WEIframe.EnuScrolling.yes
                    Return LocalizableFormAndConverter._0150
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

