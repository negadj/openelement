Imports System.ComponentModel

Namespace Elements.Form.Editors.Converter
    Public Class TConvUploadFileSize
        Inherits TypeConverter

        Private _BaseValue As Object


        Public Overloads Overrides Function ConvertTo( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext, _
        ByVal culture As System.Globalization.CultureInfo, _
        ByVal value As Object, _
        ByVal destinationType As System.Type _
        ) As Object
            If String.IsNullOrEmpty(value) Then Return String.Empty
            Return String.Concat(value, " Mo")

        End Function




    End Class

End Namespace

