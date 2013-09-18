Imports System.ComponentModel
Imports System.Globalization

Imports WebElement.My.Resources.text

Namespace Elements.Containers.Editors.Converter

    Public Class TConvEnuCollapsiblePanelPosition
        Inherits EnumConverter

        #Region "Fields"

        Public TCSonvEnuPPP As String

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New()
            MyBase.New(GetType(WECollapsiblePanel.EnuCollapsiblePanelPosition))
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Select Case CType(value, WECollapsiblePanel.EnuCollapsiblePanelPosition)
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Top
                    Return LocalizableFormAndConverter._0194 ' top
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Bottom
                    Return LocalizableFormAndConverter._0195 ' Bottom
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Left
                    Return LocalizableFormAndConverter._0196 ' left
                Case WECollapsiblePanel.EnuCollapsiblePanelPosition.Right
                    Return LocalizableFormAndConverter._0197 ' right
                Case Else
                    Return ""
            End Select
        End Function

        #End Region 'Methods

    End Class

End Namespace

