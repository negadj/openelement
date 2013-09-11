Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement

Namespace Elements.Navigate


    <Serializable()> _
    Public Class WELinkImage
        Inherits ElementBase

#Region "Properties"

        Private _PageLink As LinksManager.Link
     
        Private _AlternateText As DataType.LocalizableString

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


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N123"), _
        Ressource.localizable.LocalizableDescAtt("_D123"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFileSkin), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property Image() As LinksManager.Link
            Get
                Return MyBase.StylesSkin.BaseDiv.BaseStyles.Background.ImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                MyBase.StylesSkin.BaseDiv.BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N124"), _
        Ressource.localizable.LocalizableDescAtt("_D124"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFileSkin), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property ImageOver() As LinksManager.Link
            Get
                Return MyBase.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Over).Background.ImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                MyBase.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Over).Background.ImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N125"), _
        Ressource.localizable.LocalizableDescAtt("_D125"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFileSkin), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property ImageDown() As LinksManager.Link
            Get
                Return MyBase.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Down).Background.ImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                MyBase.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Down).Background.ImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N004"), _
        Ressource.localizable.LocalizableDescAtt("_D004"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AlternateText() As DataType.LocalizableString
            Get
                If _AlternateText Is Nothing Then
                    _AlternateText = New DataType.LocalizableString("")
                End If
                Return _AlternateText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _AlternateText = Tools.WebElem.PropertiesLocalizableStringFormat(value, MyBase.Page.Culture, Tools.Enu.ProgLanguage.Html)
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WELinkImage", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0200
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WELinkImage
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0201
            info.AutoOpenProperty = "PageLink"
            info.SortPropertyList.Add(New SortProperty("Image", "image.png", My.Resources.text.LocalizableOpen._0009))
            info.SortPropertyList.Add(New SortProperty("ImageOver", "image.png", My.Resources.text.LocalizableOpen._0241))
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", My.Resources.text.LocalizableOpen._0010))
            Return info

        End Function

        Protected Overrides Sub OnOpen()
 
            MyBase.OnOpen()
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer, PageLink)
            If Not Me.PageLink.IsEmpty AndAlso Me.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                writer.WriteBeginTag("a")
                writer.WriteAttribute("href", MyBase.GetLink(Me.PageLink))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            End If
            writer.WriteBeginTag("img")
            writer.WriteAttribute("style", "width:100%;height:100%;border:none")
            writer.WriteAttribute("src", MyBase.ConvertToRelativeLink("WEFiles/Image/empty.png"))
            writer.WriteAttribute("alt", Me.AlternateText.GetValue(MyBase.Page.Culture))
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            If Not Me.PageLink.IsEmpty Then
                writer.WriteEndTag("a")
            End If
            MyBase.RenderEndTag(writer)

        End Sub

#End Region

    End Class

End Namespace



