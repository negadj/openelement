Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.DataType

Namespace Elements.Navigate


    <Serializable()> _
    Public Class WEBreadCrumbs
        Inherits ElementBase



        Private _Config As DataType.SelectIDElement
        Private _FirstLink As LinksManager.Link


        <NonSerialized()> _
        Private _MenuName As String
        <NonSerialized()> _
        Private _MenuConfig As WEMenuGroup

#Region "Properties"

        ''' <summary>
        ''' Choise of menu
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
       Ressource.localizable.LocalizableNameAtt("_N148"), _
       Ressource.localizable.LocalizableDescAtt("_D148"), _
       Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
       Common.Attributes.ConfigSelectIDElement("WEMenu; WEMenuAccordion", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
       TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property Config() As DataType.SelectIDElement
            Get
                Return _Config
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _Config = value
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
        Ressource.localizable.LocalizableDescAtt("_D149"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkPage), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property FirstLink() As LinksManager.Link
            Get
                If _FirstLink Is Nothing Then
                    _FirstLink = New LinksManager.Link
                End If
                Return _FirstLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _FirstLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N150"), _
        Ressource.localizable.LocalizableDescAtt("_D150"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFileSkin), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.OnlyCss)> _
        Public Property FirstImage() As LinksManager.Link
            Get
                Return MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Background.ImageLink
            End Get

            Set(ByVal value As LinksManager.Link)
                MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.FindStylesZone("FirstImage").BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
       Ressource.localizable.LocalizableNameAtt("_N151"), _
       Ressource.localizable.LocalizableDescAtt("_D151"), _
       Editor(GetType(openElement.WebElement.Editors.UITypeLinkFileSkin), GetType(Drawing.Design.UITypeEditor)), _
       TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.OnlyCss)> _
       Public Property Separator() As LinksManager.Link
            Get
                Return MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Background.ImageLink
            End Get

            Set(ByVal value As LinksManager.Link)
                MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Background.ImageLink = value
                If Not value.ImageSize.IsEmpty Then
                    MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Width.Value = value.ImageSize.Width
                    MyBase.StylesSkin.FindStylesZone("Separator").BaseStyles.Height.Value = value.ImageSize.Height
                End If
            End Set
        End Property


        <Browsable(False)> _
        Private ReadOnly Property MenuName() As String
            Get
                Return _MenuName
            End Get
        End Property

        <Browsable(False)> _
        Private ReadOnly Property MenuConfig() As WEMenuGroup
            Get

                Return _MenuConfig
            End Get
        End Property



#End Region

#Region "Builder required function"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEBreadCrumbs", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            'data recovery of the selected menu
            Call GetMenuConfig()
            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0269
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEBreadCrumbs
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0270
            info.AutoOpenProperty = "Config"
            info.SortPropertyList.Add(New SortProperty("Config", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("FirstImage", My.Resources.text.LocalizableOpen._0271, My.Resources.text.LocalizableOpen._0272)) ' Première image, Image affiché avant le premier lien
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Separator", My.Resources.text.LocalizableOpen._0273, My.Resources.text.LocalizableOpen._0274)) ' Séparateurs, Image affichée entre chaque liens
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Link", My.Resources.text.LocalizableOpen._0275, My.Resources.text.LocalizableOpen._0276)) 'Lien, Zone d'affichage du lien
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("LastImage", My.Resources.text.LocalizableOpen._0277, My.Resources.text.LocalizableOpen._0278)) 'Dernière image, Image affichée après le dernier lien


            MyBase.OnOpen(ConfigStylesZones)

        End Sub

      
        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Link"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub


#End Region

#Region "Render"
     
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'First image
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("FirstImage"))
            If Not FirstLink.IsEmpty Then writer.WriteOnClickLinkAttribute(Me, FirstLink, False, Me.Page.Culture)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            'no display on template page
            If Me.Page.IsTemplate = True Then
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Link"))

                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.Write(String.Format(My.Resources.text.LocalizableOpen._0279, Me.MenuName))
                writer.WriteEndTag("span")

                'Last image
                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LastImage"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("span")
                MyBase.RenderEndTag(writer)
                Exit Sub
            End If

            'the menu isn't configured
            If MenuConfig Is Nothing Then MyBase.RenderEndTag(writer) : Exit Sub

            'search of the current page's path in the menu
            Dim ListLink As List(Of WEMenuGroup.SimpleWEMenuItem) = Me.MenuConfig.SearchPath(Me.Page.DataPagePath)
            'the page isn't in the menu
            If ListLink Is Nothing Then MyBase.RenderEndTag(writer) : Exit Sub

            'results display
            Dim i As Integer = 0
            For Each item As WEMenuGroup.SimpleWEMenuItem In ListLink
                If Not i = 0 Then
                    'Separator
                    writer.WriteBeginTag("span")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Separator"))
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("span")

                End If

                Call RenderItem(writer, item)
                i += 1
            Next

            'Last image
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LastImage"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' link's Render
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Protected Sub RenderItem(ByVal writer As Common.HtmlWriter, ByVal item As WEMenuGroup.SimpleWEMenuItem)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Link"))
            If Not item.Link.IsEmpty Then writer.WriteOnClickLinkAttribute(Me, item.Link, False, Me.Page.Culture)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            If Not item.Link.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, item.Link, True)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            End If

            writer.Write(item.Text.GetValue(MyBase.Page.Culture))

            If Not item.Link.IsEmpty Then writer.WriteEndTag("a")

            writer.WriteEndTag("span")
        End Sub


#End Region

      
        Private Sub GetMenuConfig()

            'BreadCrumbs no configured
            If Me.Config Is Nothing Then Me._MenuName = My.Resources.text.LocalizableOpen._0280 : Exit Sub

            Dim IDMenu As String = Me.Config.getUniqueID
            Dim ElmMenu As ElementBase = Nothing

            For Each elm As ElementBase In openElement.Tools.WebElem.GetAllElementPage(Me.Page, True)
                If String.Equals(elm.ID, IDMenu) Then ElmMenu = elm
            Next
 
            If ElmMenu Is Nothing Then Exit Sub

            Me._MenuName = ElmMenu.Name
            'search all element with IWEMenu implement
            If TypeOf ElmMenu Is openElement.WebElement.Common.IWEMenu Then
                Me._MenuConfig = CType(ElmMenu, openElement.WebElement.Common.IWEMenu).MenuGroup
            End If

        End Sub


    End Class


End Namespace