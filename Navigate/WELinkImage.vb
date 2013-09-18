Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Navigate

    <Serializable> _
    Public Class WELinkImage
        Inherits ElementBase

        #Region "Fields"

        Private _AlternateText As LocalizableString
        Private _PageLink As Link

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WELinkImage", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N004"), _
        LocalizableDescAtt("_D004"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AlternateText() As LocalizableString
            Get
                If _AlternateText Is Nothing Then
                    _AlternateText = New LocalizableString("")
                End If
                Return _AlternateText
            End Get
            Set(ByVal value As LocalizableString)
                _AlternateText = WebElem.PropertiesLocalizableStringFormat(value, MyBase.Page.Culture, Enu.ProgLanguage.Html)
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N123"), _
        LocalizableDescAtt("_D123"), _
        Editor(GetType(UITypeLinkFileSkin), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property Image() As Link
            Get
                Return MyBase.StylesSkin.BaseDiv.BaseStyles.Background.ImageLink
            End Get
            Set(ByVal value As Link)
                MyBase.StylesSkin.BaseDiv.BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N125"), _
        LocalizableDescAtt("_D125"), _
        Editor(GetType(UITypeLinkFileSkin), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property ImageDown() As Link
            Get
                Return MyBase.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Down).Background.ImageLink
            End Get
            Set(ByVal value As Link)
                MyBase.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Down).Background.ImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N124"), _
        LocalizableDescAtt("_D124"), _
        Editor(GetType(UITypeLinkFileSkin), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property ImageOver() As Link
            Get
                Return MyBase.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Over).Background.ImageLink
            End Get
            Set(ByVal value As Link)
                MyBase.StylesSkin.BaseDiv.FindStyles(StylesZone.EnuStyleState.Over).Background.ImageLink = value
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

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0200
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WELinkImage
            info.ToolBoxDescription = LocalizableOpen._0201
            info.AutoOpenProperty = "PageLink"
            info.SortPropertyList.Add(New SortProperty("Image", "image.png", LocalizableOpen._0009))
            info.SortPropertyList.Add(New SortProperty("ImageOver", "image.png", LocalizableOpen._0241))
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", LocalizableOpen._0010))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer, PageLink)
            If Not Me.PageLink.IsEmpty AndAlso Me.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", MyBase.GetLink(Me.PageLink))
                writer.Write(HtmlTextWriter.TagRightChar)
            End If
            writer.WriteBeginTag("img")
            writer.WriteAttribute("style", "width:100%;height:100%;border:none")
            writer.WriteAttribute("src", MyBase.ConvertToRelativeLink("WEFiles/Image/empty.png"))
            writer.WriteAttribute("alt", Me.AlternateText.GetValue(MyBase.Page.Culture))
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            If Not Me.PageLink.IsEmpty Then
                writer.WriteEndTag("a")
            End If
            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

