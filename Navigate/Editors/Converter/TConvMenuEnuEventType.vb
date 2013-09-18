Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Navigate.Editors.Converter

    Public Class TConvMenuEnuEventType
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WEMenu.EnuEventType))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WEMenu.EnuEventType)
                Case WEMenu.EnuEventType.Click
                    Return LocalizableFormAndConverter._0063
                Case WEMenu.EnuEventType.DblClick
                    Return LocalizableFormAndConverter._0064
                Case WEMenu.EnuEventType.Over
                    Return LocalizableFormAndConverter._0065
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

