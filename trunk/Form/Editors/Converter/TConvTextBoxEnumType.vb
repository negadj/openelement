Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextBoxEnumType
        Inherits EnumConverter

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WETextBoxV2.EnuTextBoxtype))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WETextBoxV2.EnuTextBoxtype)
                Case WETextBoxV2.EnuTextBoxtype.text
                    Return LocalizableFormAndConverter._0187
                Case WETextBoxV2.EnuTextBoxtype.password
                    Return LocalizableFormAndConverter._0188
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

