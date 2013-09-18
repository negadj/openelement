Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Common.Attributes.EditListOf
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Navigate

    <Serializable> _
    Public Class WETreeView
        Inherits ElementBase

        #Region "Fields"

        Private _Collapsed As Boolean
        <ContainsLinks> _
        Private _TreeViewItem As WETreeViewItem
        Private _Unique As Boolean

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETreeView", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' true if the treeview is over at the loading
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N140"), _
        LocalizableDescAtt("_D140"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Collapsed() As Boolean
            Get
                Return _Collapsed
            End Get
            Set(ByVal value As Boolean)
                _Collapsed = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N139"), _
        LocalizableDescAtt("_D139"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property TreeViewItem() As WETreeViewItem
            Get
                If _TreeViewItem Is Nothing Then
                    _TreeViewItem = New WETreeViewItem
                    _TreeViewItem.List.Add(New WETreeViewItem(New LocalizableString("Ligne n°1")))
                    _TreeViewItem.List.Add(New WETreeViewItem(New LocalizableString("Ligne n°2")))
                    _TreeViewItem.List.Add(New WETreeViewItem(New LocalizableString("Ligne n°3")))

                End If

                Return _TreeViewItem
            End Get
            Set(ByVal value As WETreeViewItem)
                _TreeViewItem = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N141"), _
        LocalizableDescAtt("_D141"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Unique() As Boolean
            Get
                Return _Unique
            End Get
            Set(ByVal value As Boolean)
                _Unique = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)

            'Add a separator
            If addButton.Name = "AddSiteMap" Then
                Dim listPage As Dictionary(Of LocalizableString, Link) = WebElem.AddSiteMap()
                If listPage IsNot Nothing Then
                    For Each item As KeyValuePair(Of LocalizableString, Link) In listPage
                        newObs.Add(New WETreeViewItem(item.Key, item.Value))
                    Next
                End If
                Return newObs
            End If
            Dim newItem As New WETreeViewItem()
            newObs.Add(newItem)
            Return newObs
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("Default", LocalizableFormAndConverter._0178, Nothing))
            addButtonList.Add(New CtlEditListOf.AddButton("AddSiteMap", LocalizableFormAndConverter._0179, Nothing))
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0180, LocalizableFormAndConverter._0180, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0262
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WETreeView
            info.ToolBoxDescription = LocalizableOpen._0263
            info.AutoOpenProperty = "TreeViewItem"
            info.SortPropertyList.Add(New SortProperty("TreeViewItem", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WETreeView.css", "WEFiles/Css/WETreeView.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WETreeView.js", "WEFiles/Client/WETreeView.js")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.treeview.js", "WEFiles/Client/jquery.treeview.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "File", "Folder"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)

            configStylesZones.Add(New ConfigStylesZone("File", LocalizableOpen._0242, LocalizableOpen._0244))
            configStylesZones.Add(New ConfigStylesZone("Folder", LocalizableOpen._0243, LocalizableOpen._0245))
            configStylesZones.Add(New ConfigStylesZone("Icon", LocalizableOpen._0246, LocalizableOpen._0247))

            configStylesZones.Add(New ConfigStylesZone("expandable-hitarea", LocalizableOpen._0248, LocalizableOpen._0249))
            configStylesZones.Add(New ConfigStylesZone("lastExpandable-hitarea", LocalizableOpen._0250, LocalizableOpen._0251))
            configStylesZones.Add(New ConfigStylesZone("collapsable-hitarea", LocalizableOpen._0252, LocalizableOpen._0253))
            configStylesZones.Add(New ConfigStylesZone("lastCollapsable-hitarea", LocalizableOpen._0254, LocalizableOpen._0255))

            configStylesZones.Add(New ConfigStylesZone("last", LocalizableOpen._0256, LocalizableOpen._0257))
            configStylesZones.Add(New ConfigStylesZone("li", LocalizableOpen._0258, LocalizableOpen._0259))
            configStylesZones.Add(New ConfigStylesZone("ul", LocalizableOpen._0260, LocalizableOpen._0261))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Const level As Integer = 0

            writer.WriteBeginTag("ul")
            writer.WriteAttribute("id", String.Concat("Tree", Me.ID))
            writer.WriteAttribute("class", "OESZ_FileTree")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            Dim curLastUl As Boolean
            If TreeViewItem.List.Count > 0 Then
                If TreeViewItem.List.Count = 1 Then curLastUl = True
                RenderFolder(writer, TreeViewItem, level, curLastUl)
            Else
                RenderFile(writer, TreeViewItem, level)
            End If

            writer.Indent -= 1
            writer.WriteEndTag("ul")

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Affichage d'un fichier
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Private Sub RenderFile(ByVal writer As HtmlWriter, ByVal item As WETreeViewItem, ByVal level As Integer)
            level += 1
            writer.WriteBeginTag("li")
            If level = 2 Then writer.WriteAttribute("class", "TreeViewFirst")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("File"))
            writer.Write(HtmlTextWriter.TagRightChar)

            Call RenderItem(writer, item)

            writer.WriteEndTag("span")

            writer.WriteEndTag("li")
            writer.WriteLine()
        End Sub

        ''' <summary>
        ''' display a folder
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <param name="level"></param>
        ''' <remarks></remarks>
        Private Sub RenderFolder(ByVal writer As HtmlWriter, ByVal item As WETreeViewItem, ByVal level As Integer, ByVal lastUL As Boolean)
            level += 1
            If level > 1 Then

                writer.WriteBeginTag("li")
                'La class TreeViewFirst facilitates the display (jquery.treeview.js)
                Dim classLi As String = String.Empty

                If level = 2 Then classLi &= "TreeViewFirst"
                If item.Close Then classLi &= " TreeViewFirstclose"
                If item.Open Then classLi &= " TreeViewFirstopen"

                writer.WriteAttribute("class", classLi)
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Folder"))
                writer.Write(HtmlTextWriter.TagRightChar)
                Call RenderItem(writer, item)
                writer.WriteEndTag("span")

                writer.WriteLine()

                writer.WriteBeginTag("ul")
                If Not lastUL Then writer.WriteAttribute("class", MyBase.GetStyleZoneClass("ul"))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()
                writer.Indent += 1
            End If

            'children render
            Dim i As Integer = 1
            Dim curLastUl As Boolean = 0
            For Each pageInter As WETreeViewItem In item.List

                If pageInter.List.Count > 0 Then
                    If i = item.List.Count Then curLastUl = True
                    Call RenderFolder(writer, pageInter, level, curLastUl)
                Else
                    Call RenderFile(writer, pageInter, level)
                End If
                i += 1
            Next

            If level > 1 Then
                writer.Indent -= 1
                writer.WriteEndTag("ul")
                writer.WriteLine()

                writer.WriteEndTag("li")
                writer.WriteLine()
            End If
        End Sub

        ''' <summary>
        ''' Affichage de la partie icon+texte 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Private Sub RenderItem(ByVal writer As HtmlWriter, ByVal item As WETreeViewItem)
            'Icon
            If Not item.Icon.IsEmpty Then
                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Me.GetLink(item.Icon))
                writer.WriteAttribute("alt", String.Empty)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Icon"))
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)
            End If

            'Lien
            If Not item.Link.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, item.Link, True)
                writer.Write(HtmlTextWriter.TagRightChar)

                'Texte
                writer.Write(item.Title.GetValue(MyBase.Page.Culture))

                writer.WriteEndTag("a")
            Else
                'Texte
                writer.Write(item.Title.GetValue(MyBase.Page.Culture))
            End If
        End Sub

        #End Region 'Methods

    End Class

    ''' <summary>
    ''' WETreeView configuration class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WETreeViewItem

        #Region "Fields"

        Private _Close As Boolean
        Private _Icon As Link
        Private _Link As Link
        <ContainsLinks> _
        Private _List As List(Of WETreeViewItem)
        Private _Open As Boolean
        Private _Title As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New()
        End Sub

        Public Sub New(ByVal title As LocalizableString, ByVal link As Link, ByVal icon As Link)
            _Title = title
            _Link = link
            _Icon = icon
        End Sub

        Public Sub New(ByVal title As LocalizableString, ByVal link As Link)
            _Title = title
            _Link = link
        End Sub

        Public Sub New(ByVal title As LocalizableString)
            _Title = title
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N147"), _
        LocalizableDescAtt("_D147")> _
        Public Property Close() As Boolean
            Get
                Return _Close
            End Get
            Set(ByVal value As Boolean)
                _Close = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N144"), _
        LocalizableDescAtt("_D144"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        ConfigBiblio(True, False, False, False, False), _
        ShowColumn(ShowColumn.EnuRepositoryType.RepositoryItemPictureEdit, 30, 30)> _
        Public Property Icon() As Link
            Get
                If _Icon Is Nothing Then _Icon = New Link
                Return _Icon
            End Get
            Set(ByVal value As Link)
                _Icon = value
            End Set
        End Property

        ''' <summary>
        ''' Lien
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N143"), _
        LocalizableDescAtt("_D143"), _
        Editor(GetType(UITypeLinkPage), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        ShowColumn> _
        Public Property Link() As Link
            Get
                If _Link Is Nothing Then _Link = New Link
                Return _Link
            End Get
            Set(ByVal value As Link)
                _Link = value
            End Set
        End Property

        ''' <summary>
        ''' list of the content item
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ContainsListOfObject> _
        Public Property List() As List(Of WETreeViewItem)
            Get
                If _List Is Nothing Then _List = New List(Of WETreeViewItem)
                Return _List
            End Get
            Set(ByVal value As List(Of WETreeViewItem))
                _List = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N146"), _
        LocalizableDescAtt("_D146")> _
        Public Property Open() As Boolean
            Get
                Return _Open
            End Get
            Set(ByVal value As Boolean)
                _Open = value
            End Set
        End Property

        ''' <summary>
        ''' Titre
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N142"), _
        LocalizableDescAtt("_D142"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ShowColumn> _
        Public Property Title() As LocalizableString
            Get
                If _Title Is Nothing Then _Title = New LocalizableString
                Return _Title
            End Get
            Set(ByVal value As LocalizableString)
                _Title = value
            End Set
        End Property

        #End Region 'Properties

    End Class

End Namespace

