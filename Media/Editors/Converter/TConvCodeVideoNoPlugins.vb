Imports System.ComponentModel


Namespace Elements.Media.Editors.Converter


    Public Class TConvCodeVideoNoPlugin
        Inherits TypeConverter

        Private _BaseValue As Object

        Public Overloads Overrides Function ConvertFrom( _
        ByVal context As ITypeDescriptorContext, _
        ByVal culture As System.Globalization.CultureInfo, _
        ByVal value As Object _
        ) As Object
            Return _BaseValue
        End Function

        Public Overloads Overrides Function ConvertTo( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext, _
        ByVal culture As System.Globalization.CultureInfo, _
        ByVal value As Object, _
        ByVal destinationType As System.Type _
        ) As Object
            Return "(HTML)"
        End Function

    End Class
End Namespace
