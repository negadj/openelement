Imports System.Web.UI

Imports openElement.DB.DBElem
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Standard

    <Serializable> _
    Public Class WEPanel
        Inherits WEDynamic

        #Region "Fields"

        Private _PositionMode As CssEnum.PositionMode

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEPanel", page, parentID, templateName)
            Me.PositionMode = CssEnum.PositionMode.absolute
        End Sub

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String, ByVal uniqueName As String)
            MyBase.New(EnuElementType.PageEdit, uniqueName, page, parentID, templateName)
            Me.PositionMode = CssEnum.PositionMode.absolute
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N127"), _
        LocalizableDescAtt("_D127"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property PositionMode() As CssEnum.PositionMode
            Get
                Return _PositionMode
            End Get
            Set(ByVal value As CssEnum.PositionMode)
                _PositionMode = value
                MyBase.Templates.SetTemplate("Content", value)
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0003
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WEPanel
            info.ToolBoxDescription = LocalizableOpen._0004
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.Templates.SetTemplate("Content", Me.PositionMode)
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetTemplateClass("Content"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            RenderPanelContent(writer) ' DD in this class just renders children; in descendant classes this function can iterate child elements

            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        Protected Overridable Sub RenderPanelContent(ByVal writer As HtmlWriter)
            ' DD in this class just renders children; in descendant classes this function can iterate child elements
            MyBase.RenderTemplate(writer, "Content") ' old static code
        End Sub

        #End Region 'Methods

    End Class

End Namespace

