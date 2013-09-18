Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Form.Editors.Converter

    Public Class TConvRadioListElement
        Inherits TypeConverter

        #Region "Methods"

        Public Overloads Overrides Function ConvertTo( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As CultureInfo, _
            ByVal value As Object, _
            ByVal destinationType As Type _
            ) As Object
            Return LocalizableFormAndConverter._0001
        End Function

        #End Region 'Methods

    End Class

End Namespace

