Imports System.ComponentModel
Imports System.Globalization

Namespace Elements.Form.Editors.Converter

    Public Class TConvUploadFileSize
        Inherits TypeConverter

        #Region "Methods"

        Public Overloads Overrides Function ConvertTo( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As CultureInfo, _
            ByVal value As Object, _
            ByVal destinationType As Type _
            ) As Object
            If String.IsNullOrEmpty(value) Then Return String.Empty
            Return String.Concat(value, " Mo")
        End Function

        #End Region 'Methods

    End Class

End Namespace

