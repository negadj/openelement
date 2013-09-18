Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashSalign
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEFlash.EnuFlashSalign))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEFlash.EnuFlashSalign)
                Case WEFlash.EnuFlashSalign.none
                    Return LocalizableFormAndConverter._0015
                Case WEFlash.EnuFlashSalign.l
                    Return LocalizableFormAndConverter._0041
                Case WEFlash.EnuFlashSalign.r
                    Return LocalizableFormAndConverter._0042
                Case WEFlash.EnuFlashSalign.t
                    Return LocalizableFormAndConverter._0043
                Case WEFlash.EnuFlashSalign.tl
                    Return LocalizableFormAndConverter._0050
                Case WEFlash.EnuFlashSalign.tr
                    Return LocalizableFormAndConverter._0051
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

