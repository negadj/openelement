Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design

Namespace Elements.Navigate.Editors

    Public Class UITypeFlagView
        Inherits ObjectSelectorEditor

        #Region "Properties"

        Public Overloads Overrides ReadOnly Property IsDropDownResizable() As Boolean
            Get
                Return True
            End Get
        End Property

        #End Region 'Properties

        #Region "Methods"

        Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.DropDown
        End Function

        Protected Overloads Overrides Sub FillTreeWithData(ByVal selector As Selector, ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider)
            selector.Nodes.Clear()

            For Each viewType In [Enum].GetValues(GetType(WEFlag.EnuViewType))
                selector.AddNode(viewType.ToString, viewType, Nothing)
            Next
        End Sub

        #End Region 'Methods

    End Class

End Namespace

