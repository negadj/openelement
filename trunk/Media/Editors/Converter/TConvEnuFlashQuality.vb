Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashQuality
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEFlash.EnuFlashQuality))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEFlash.EnuFlashQuality)
                Case WEFlash.EnuFlashQuality.autohigh
                    Return LocalizableFormAndConverter._0044
                Case WEFlash.EnuFlashQuality.autolow
                    Return LocalizableFormAndConverter._0045
                Case WEFlash.EnuFlashQuality.best
                    Return LocalizableFormAndConverter._0046
                Case WEFlash.EnuFlashQuality.high
                    Return LocalizableFormAndConverter._0047
                Case WEFlash.EnuFlashQuality.low
                    Return LocalizableFormAndConverter._0048
                Case WEFlash.EnuFlashQuality.medium
                    Return LocalizableFormAndConverter._0049
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

