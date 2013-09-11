Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports openElement.DB.DBElem

Namespace Elements.Standard


    <Serializable()> _
    Public Class WEPanel
        Inherits WEDynamic

        Private _PositionMode As StylesManager.CssItems.CssEnum.PositionMode

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N127"), _
        Ressource.localizable.LocalizableDescAtt("_D127"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property PositionMode() As StylesManager.CssItems.CssEnum.PositionMode
            Get
                Return _PositionMode
            End Get
            Set(ByVal value As StylesManager.CssItems.CssEnum.PositionMode)
                _PositionMode = value
                MyBase.Templates.SetTemplate("Content", value)
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next
            End Set
        End Property

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEPanel", page, parentID, templateName)
            Me.PositionMode = StylesManager.CssItems.CssEnum.PositionMode.absolute
        End Sub

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String, ByVal uniqueName As String)
            MyBase.New(EnuElementType.PageEdit, uniqueName, page, parentID, templateName)
            Me.PositionMode = StylesManager.CssItems.CssEnum.PositionMode.absolute
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0003
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WEPanel
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0004
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.Templates.SetTemplate("Content", Me.PositionMode)
            MyBase.OnOpen()
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetTemplateClass("Content"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            RenderPanelContent(writer) ' DD in this class just renders children; in descendant classes this function can iterate child elements

            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)

        End Sub

        Protected Overridable Sub RenderPanelContent(ByVal writer As Common.HtmlWriter)
            ' DD in this class just renders children; in descendant classes this function can iterate child elements
            MyBase.RenderTemplate(writer, "Content") ' old static code
        End Sub


#End Region

    End Class

End Namespace
