Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashScale
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEFlash.EnuFlashScale))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEFlash.EnuFlashScale)
                Case WEFlash.EnuFlashScale.showall
                    Return LocalizableFormAndConverter._0093
                Case WEFlash.EnuFlashScale.noborder
                    Return LocalizableFormAndConverter._0053
                Case WEFlash.EnuFlashScale.exactfit
                    Return LocalizableFormAndConverter._0054
                Case Else
                    Return String.Empty
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

