Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Elements

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace WEElements.Standard

    <Serializable> _
    Public Class WEDocument
        Inherits ElementBase

        #Region "Fields"

        Private _HTML As HtmlBlock

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEDocument", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N122"), _
        LocalizableDescAtt("_D122"), _
        Editor(GetType(UITypeHTML), GetType(UITypeEditor))> _
        Public Property HTML() As HtmlBlock
            Get
                If _HTML Is Nothing Then _HTML = New HtmlBlock
                Return _HTML
            End Get
            Set(ByVal value As HtmlBlock)
                _HTML = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0137
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WEDocument
            info.ToolBoxDescription = LocalizableOpen._0138
            info.AutoOpenProperty = "HTML"
            info.SortPropertyList.Add(New SortProperty("HTML", "edit.png", LocalizableOpen._0139))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then

                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", String.Concat("width:100%;height:100%;background-image: url(file:///", Path.IOSitePath("/WEFiles/Image/mask.png"), ")"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write(Me.HTML.Html.GetValue(Me.Page.Culture))
                writer.WriteEndTag("div")
            Else
                writer.Write(Me.HTML.Html.GetValue(Me.Page.Culture))
            End If
            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

