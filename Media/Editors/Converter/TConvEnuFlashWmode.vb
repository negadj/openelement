Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashWmode
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEFlash.EnuFlashWmode))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEFlash.EnuFlashWmode)
                Case WEFlash.EnuFlashWmode.window
                    Return LocalizableFormAndConverter._0055
                Case WEFlash.EnuFlashWmode.opaque
                    Return LocalizableFormAndConverter._0056
                Case WEFlash.EnuFlashWmode.transparent
                    Return LocalizableFormAndConverter._0057

                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

