Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter

    Public Class TConvRadioListElement
        Inherits TypeConverter

        Public Overloads Overrides Function ConvertTo( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext, _
        ByVal culture As System.Globalization.CultureInfo, _
        ByVal value As Object, _
        ByVal destinationType As System.Type _
        ) As Object

            Return My.Resources.text.LocalizableFormAndConverter._0001

        End Function


    End Class

End Namespace
