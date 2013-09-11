Imports WebElement.Elements.Form.WETextBoxV2
Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter

    Public Class TConvTextBoxEnumType
        Inherits EnumConverter

        Public Sub New()
            MyBase.New(GetType(EnuTextBoxtype))
        End Sub

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            Select Case CType(value, EnuTextBoxtype)
                Case EnuTextBoxtype.text
                    Return My.Resources.text.LocalizableFormAndConverter._0187
                Case EnuTextBoxtype.password
                    Return My.Resources.text.LocalizableFormAndConverter._0188
                Case Else
                    Return ""
            End Select
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class




End Namespace


