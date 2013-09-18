Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Media.Editors.Converter

    Public Class TConvEnuFlashAlign
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEFlash.EnuFlashAlign))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEFlash.EnuFlashAlign)
                Case WEFlash.EnuFlashAlign.none
                    Return LocalizableFormAndConverter._0015
                Case WEFlash.EnuFlashAlign.l
                    Return LocalizableFormAndConverter._0041
                Case WEFlash.EnuFlashAlign.r
                    Return LocalizableFormAndConverter._0042
                Case WEFlash.EnuFlashAlign.t
                    Return LocalizableFormAndConverter._0043
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

