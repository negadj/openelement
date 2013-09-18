Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager

Imports WebElement.Elements.Interactivity.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Interactivity

    <Serializable> _
    Public Class WEIframe
        Inherits ElementBase

        #Region "Fields"

        Private _AllowTransparency As Boolean
        Private _FrameBorder As Boolean
        Private _PageLink As Link
        Private _Scrolling As EnuScrolling

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEIframe", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        Public Enum EnuScrolling As Short
            Auto = 0
            Yes = 1
            No = 2
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N145"), _
        LocalizableDescAtt("_D145"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowTransparency() As Boolean
            Get
                Return _allowTransparency
            End Get
            Set(ByVal value As Boolean)
                _allowTransparency = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N192"), _
        LocalizableDescAtt("_D192"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property FrameBorder() As Boolean
            Get
                Return _FrameBorder
            End Get
            Set(ByVal value As Boolean)
                _FrameBorder = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        LocalizableDescAtt("_D003"), _
        Editor(GetType(UITypeLinkPage), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As Link
            Get
                If _PageLink Is Nothing Then
                    _PageLink = New Link()
                End If
                Return _PageLink
            End Get
            Set(ByVal value As Link)
                _PageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N191"), _
        LocalizableDescAtt("_D191"), _
        TypeConverter(GetType(TConvEnuScrolling)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Scrolling() As EnuScrolling
            Get
                Return _Scrolling
            End Get
            Set(ByVal value As EnuScrolling)
                _Scrolling = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0383 '"Page externe"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WECodeBlock
            info.ToolBoxDescription = ""
            info.AutoOpenProperty = "PageLink"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("div")
            Else
                writer.WriteBeginTag("iframe")
                writer.WriteAttribute("src", MyBase.GetLink(Me.PageLink))
                If Me.AllowTransparency Then writer.WriteAttribute("allowTransparency", "true")
                writer.WriteAttribute("width", "100%")
                writer.WriteAttribute("height", "100%")
                writer.WriteAttribute("scrolling", Me.Scrolling.ToString)
                writer.WriteAttribute("marginwidth", "0px")
                writer.WriteAttribute("marginheight", "0px")
                writer.WriteAttribute("frameborder", CInt(FrameBorder))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("iframe")
            End If

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

