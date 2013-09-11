Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports System.ComponentModel



Namespace Elements.Interactivity


    <Serializable()> _
    Public Class WEIframe
        Inherits ElementBase
        Public Enum EnuScrolling As Short
            auto = 0
            yes = 1
            no = 2
        End Enum

#Region "Properties"

        Private _PageLink As LinksManager.Link
        Private _allowTransparency As Boolean
        Private _Scrolling As EnuScrolling
        Private _FrameBorder As Boolean

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        Ressource.localizable.LocalizableDescAtt("_D003"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkPage), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As LinksManager.Link
            Get
                If _PageLink Is Nothing Then
                    _PageLink = New LinksManager.Link()
                End If
                Return _PageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _PageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N145"), _
        Ressource.localizable.LocalizableDescAtt("_D145"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowTransparency() As Boolean
            Get
                Return _allowTransparency
            End Get
            Set(ByVal value As Boolean)
                _allowTransparency = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N191"), _
        Ressource.localizable.LocalizableDescAtt("_D191"), _
        TypeConverter(GetType(Elements.Interactivity.Editors.Converter.TConvEnuScrolling)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Scrolling() As EnuScrolling
            Get
                Return _Scrolling
            End Get
            Set(ByVal value As EnuScrolling)
                _Scrolling = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
       Ressource.localizable.LocalizableNameAtt("_N192"), _
       Ressource.localizable.LocalizableDescAtt("_D192"), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property FrameBorder() As Boolean
            Get
                Return _FrameBorder
            End Get
            Set(ByVal value As Boolean)
                _FrameBorder = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEIframe", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0383 '"Page externe"
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


#End Region


        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)


            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("iframe")
            End If



            MyBase.RenderEndTag(writer)

        End Sub



    End Class


End Namespace
