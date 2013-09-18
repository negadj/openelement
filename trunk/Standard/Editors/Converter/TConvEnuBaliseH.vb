Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Standard.Editors.Converter

    Public Class TConvEnuBaliseH
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WELabel.EnuBaliseH))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WELabel.EnuBaliseH)
                Case WELabel.EnuBaliseH.none
                    Return LocalizableFormAndConverter._0015
                Case WELabel.EnuBaliseH.H1
                    Return LocalizableFormAndConverter._0129
                Case WELabel.EnuBaliseH.H2
                    Return LocalizableFormAndConverter._0130
                Case WELabel.EnuBaliseH.H3
                    Return LocalizableFormAndConverter._0131
                Case WELabel.EnuBaliseH.H4
                    Return LocalizableFormAndConverter._0132
                Case WELabel.EnuBaliseH.H5
                    Return LocalizableFormAndConverter._0133
                Case WELabel.EnuBaliseH.H6
                    Return LocalizableFormAndConverter._0134
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

