Imports System.ComponentModel
Imports System.Globalization

Namespace Elements.Media.Editors.Converter

    Public Class TConvCodeVideoNoPlugin
        Inherits TypeConverter

        #Region "Fields"

        Private _BaseValue As Object = Nothing

        #End Region 'Fields

        #Region "Methods"

        Public Overloads Overrides Function ConvertFrom( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As CultureInfo, _
            ByVal value As Object _
            ) As Object
            Return _BaseValue
        End Function

        Public Overloads Overrides Function ConvertTo( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As CultureInfo, _
            ByVal value As Object, _
            ByVal destinationType As Type _
            ) As Object
            Return "(HTML)"
        End Function

        #End Region 'Methods

    End Class

End Namespace

