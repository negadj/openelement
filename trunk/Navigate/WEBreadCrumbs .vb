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
    Public Class WEBreadCrumbs
        Inherits ElementBase

        #Region "Fields"

        Private _Config As SelectIDElement
        Private _FirstLink As Link
        <NonSerialized> _
        Private _MenuConfig As WEMenuGroup
        <NonSerialized> _
        Private _MenuName As String

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEBreadCrumbs", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Choise of menu
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N148"), _
        LocalizableDescAtt("_D148"), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        ConfigSelectIDElement("WEMenu; WEMenuAccordion", ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Config() As SelectIDElement
            Get
                Return _Config
            End Get
            Set(ByVal value As SelectIDElement)
                _Config = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N150"), _
        LocalizableDescAtt("_D150"), _
        Editor(GetType(UITypeLinkFileSkin), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property FirstImage() As Link
            Get
                Return MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Background.ImageLink
            End Get

            Set(ByVal value As Link)
                MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property

        ''' <summary>
        ''' link of the first image
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N149"), _
        LocalizableDescAtt("_D149"), _
        Editor(GetType(UITypeLinkPage), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property FirstLink() As Link
            Get
                If _FirstLink Is Nothing Then
                    _FirstLink = New Link
                End If
                Return _FirstLink
            End Get
            Set(ByVal value As Link)
                _FirstLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N151"), _
        LocalizableDescAtt("_D151"), _
        Editor(GetType(UITypeLinkFileSkin), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property Separator() As Link
            Get
                Return MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Background.ImageLink
            End Get

            Set(ByVal value As Link)
                MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property

        <Browsable(False)> _
        Private ReadOnly Property MenuConfig() As WEMenuGroup
            Get

                Return _MenuConfig
            End Get
        End Property

        <Browsable(False)> _
        Private ReadOnly Property MenuName() As String
            Get
                Return _MenuName
            End Get
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0269
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEBreadCrumbs
            info.ToolBoxDescription = LocalizableOpen._0270
            info.AutoOpenProperty = "Config"
            info.SortPropertyList.Add(New SortProperty("Config", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Link"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)

            configStylesZones.Add(New ConfigStylesZone("FirstImage", LocalizableOpen._0271, LocalizableOpen._0272)) ' Première image, Image affiché avant le premier lien
            configStylesZones.Add(New ConfigStylesZone("Separator", LocalizableOpen._0273, LocalizableOpen._0274)) ' Séparateurs, Image affichée entre chaque liens
            configStylesZones.Add(New ConfigStylesZone("Link", LocalizableOpen._0275, LocalizableOpen._0276)) 'Lien, Zone d'affichage du lien
            configStylesZones.Add(New ConfigStylesZone("LastImage", LocalizableOpen._0277, LocalizableOpen._0278)) 'Dernière image, Image affichée après le dernier lien

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            'data recovery of the selected menu
            Call GetMenuConfig()
            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'First image
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("FirstImage"))
            If Not FirstLink.IsEmpty Then writer.WriteOnClickLinkAttribute(Me, FirstLink, False, Me.Page.Culture)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            'no display on template page
            If Me.Page.IsTemplate = True Then
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Link"))

                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write(String.Format(LocalizableOpen._0279, Me.MenuName))
                writer.WriteEndTag("span")

                'Last image
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LastImage"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")
                MyBase.RenderEndTag(writer)
                Exit Sub
            End If

            'the menu isn't configured
            If MenuConfig Is Nothing Then MyBase.RenderEndTag(writer) : Exit Sub

            'search of the current page's path in the menu
            Dim listLink As List(Of WEMenuGroup.SimpleWEMenuItem) = Me.MenuConfig.SearchPath(Me.Page.DataPagePath)
            'the page isn't in the menu
            If listLink Is Nothing Then MyBase.RenderEndTag(writer) : Exit Sub

            'results display
            Dim i As Integer = 0
            For Each item As WEMenuGroup.SimpleWEMenuItem In listLink
                If Not i = 0 Then
                    'Separator
                    writer.WriteBeginTag("span")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Separator"))
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("span")

                End If

                Call RenderItem(writer, item)
                i += 1
            Next

            'Last image
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LastImage"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' link's Render
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Protected Sub RenderItem(ByVal writer As HtmlWriter, ByVal item As WEMenuGroup.SimpleWEMenuItem)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Link"))
            If Not item.Link.IsEmpty Then writer.WriteOnClickLinkAttribute(Me, item.Link, False, Me.Page.Culture)
            writer.Write(HtmlTextWriter.TagRightChar)

            If Not item.Link.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, item.Link, True)
                writer.Write(HtmlTextWriter.TagRightChar)
            End If

            writer.Write(item.Text.GetValue(MyBase.Page.Culture))

            If Not item.Link.IsEmpty Then writer.WriteEndTag("a")

            writer.WriteEndTag("span")
        End Sub

        Private Sub GetMenuConfig()
            'BreadCrumbs no configured
            If Me.Config Is Nothing Then Me._MenuName = LocalizableOpen._0280 : Exit Sub

            Dim idMenu As String = Me.Config.getUniqueID
            Dim elmMenu As ElementBase = Nothing

            For Each elm As ElementBase In WebElem.GetAllElementPage(Me.Page, True)
                If String.Equals(elm.ID, idMenu) Then elmMenu = elm
            Next

            If elmMenu Is Nothing Then Exit Sub

            Me._MenuName = elmMenu.Name
            'search all element with IWEMenu implement
            Dim elementBase = TryCast(elmMenu, IWEMenu)
            If (elementBase IsNot Nothing) Then
                Me._MenuConfig = elementBase.MenuGroup
            End If
        End Sub

        #End Region 'Methods

    End Class

End Namespace

