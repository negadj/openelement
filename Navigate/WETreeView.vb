Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.Editors.Control.CtlEditListOf

Namespace Elements.Navigate


    <Serializable()> _
    Public Class WETreeView
        Inherits ElementBase

        <Common.Attributes.ContainsLinks()> _
        Private _TreeViewItem As WETreeViewItem
        Private _Collapsed As Boolean
        Private _Unique As Boolean

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N139"), _
        Ressource.localizable.LocalizableDescAtt("_D139"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property TreeViewItem() As WETreeViewItem
            Get
                If _TreeViewItem Is Nothing Then
                    _TreeViewItem = New WETreeViewItem
                    _TreeViewItem.List.Add(New WETreeViewItem(New DataType.LocalizableString("Ligne n°1")))
                    _TreeViewItem.List.Add(New WETreeViewItem(New DataType.LocalizableString("Ligne n°2")))
                    _TreeViewItem.List.Add(New WETreeViewItem(New DataType.LocalizableString("Ligne n°3")))

                End If

                Return _TreeViewItem
            End Get
            Set(ByVal value As WETreeViewItem)
                _TreeViewItem = value
            End Set
        End Property

        ''' <summary>
        ''' true if the treeview is over at the loading
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
       Ressource.localizable.LocalizableNameAtt("_N140"), _
       Ressource.localizable.LocalizableDescAtt("_D140"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
       Public Property Collapsed() As Boolean
            Get
                Return _Collapsed
            End Get
            Set(ByVal value As Boolean)
                _Collapsed = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
      Ressource.localizable.LocalizableNameAtt("_N141"), _
      Ressource.localizable.LocalizableDescAtt("_D141"), _
      Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
      Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
       Public Property Unique() As Boolean
            Get
                Return _Unique
            End Get
            Set(ByVal value As Boolean)
                _Unique = value
            End Set
        End Property


#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETreeView", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0262
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WETreeView
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0263
            info.AutoOpenProperty = "TreeViewItem"
            info.SortPropertyList.Add(New SortProperty("TreeViewItem", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("File", My.Resources.text.LocalizableOpen._0242, My.Resources.text.LocalizableOpen._0244))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Folder", My.Resources.text.LocalizableOpen._0243, My.Resources.text.LocalizableOpen._0245))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Icon", My.Resources.text.LocalizableOpen._0246, My.Resources.text.LocalizableOpen._0247))

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("expandable-hitarea", My.Resources.text.LocalizableOpen._0248, My.Resources.text.LocalizableOpen._0249))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("lastExpandable-hitarea", My.Resources.text.LocalizableOpen._0250, My.Resources.text.LocalizableOpen._0251))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("collapsable-hitarea", My.Resources.text.LocalizableOpen._0252, My.Resources.text.LocalizableOpen._0253))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("lastCollapsable-hitarea", My.Resources.text.LocalizableOpen._0254, My.Resources.text.LocalizableOpen._0255))

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("last", My.Resources.text.LocalizableOpen._0256, My.Resources.text.LocalizableOpen._0257))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("li", My.Resources.text.LocalizableOpen._0258, My.Resources.text.LocalizableOpen._0259))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("ul", My.Resources.text.LocalizableOpen._0260, My.Resources.text.LocalizableOpen._0261))

            MyBase.OnOpen(ConfigStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WETreeView.css", "WEFiles/Css/WETreeView.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WETreeView.js", "WEFiles/Client/WETreeView.js")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.treeview.js", "WEFiles/Client/jquery.treeview.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "File", "Folder"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region


        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim NewObs As New List(Of Object)

            'Add a separator
            If addButton.Name = "AddSiteMap" Then
                Dim listPage As Dictionary(Of DataType.LocalizableString, LinksManager.Link) = Tools.WebElem.AddSiteMap()
                If listPage IsNot Nothing Then
                    For Each item As KeyValuePair(Of DataType.LocalizableString, LinksManager.Link) In listPage
                        NewObs.Add(New WETreeViewItem(item.Key, item.Value))
                    Next
                End If
                Return NewObs
            End If
            Dim NewItem As New WETreeViewItem()
            NewObs.Add(NewItem)
            Return NewObs


        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim AddButtonList As New List(Of AddButton)
            AddButtonList.Add(New AddButton("Default", My.Resources.text.LocalizableFormAndConverter._0178, Nothing))
            AddButtonList.Add(New AddButton("AddSiteMap", My.Resources.text.LocalizableFormAndConverter._0179, Nothing))
            Dim EditConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0180, My.Resources.text.LocalizableFormAndConverter._0180, AddButtonList)
            Return EditConfig
        End Function
 

#Region "Render"
         
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Dim Level As Integer = 0

            writer.WriteBeginTag("ul")
            writer.WriteAttribute("id", String.Concat("Tree", Me.ID))
            writer.WriteAttribute("class", "OESZ_FileTree")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            Dim CurLastUl As Boolean
            If TreeViewItem.List.Count > 0 Then
                If TreeViewItem.List.Count = 1 Then CurLastUl = True
                RenderFolder(writer, TreeViewItem, Level, CurLastUl)
            Else
                RenderFile(writer, TreeViewItem, Level)
            End If

            writer.Indent -= 1
            writer.WriteEndTag("ul")


            MyBase.RenderEndTag(writer)
        End Sub


        ''' <summary>
        ''' display a folder
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <param name="level"></param>
        ''' <remarks></remarks>
        Private Sub RenderFolder(ByVal writer As Common.HtmlWriter, ByVal item As WETreeViewItem, ByVal level As Integer, ByVal lastUL As Boolean)
            level += 1
            If level > 1 Then

                writer.WriteBeginTag("li")
                'La class TreeViewFirst facilitates the display (jquery.treeview.js)
                Dim ClassLi As String = String.Empty

                If level = 2 Then ClassLi &= "TreeViewFirst"
                If item.Close Then ClassLi &= " TreeViewFirstclose"
                If item.Open Then ClassLi &= " TreeViewFirstopen"

                writer.WriteAttribute("class", ClassLi)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)


                writer.WriteBeginTag("span")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Folder"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                Call RenderItem(writer, item)
                writer.WriteEndTag("span")

                writer.WriteLine()

                writer.WriteBeginTag("ul")
                If Not lastUL Then writer.WriteAttribute("class", MyBase.GetStyleZoneClass("ul"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()
                writer.Indent += 1
            End If

            'children render
            Dim i As Integer = 1
            Dim CurLastUl As Boolean = 0
            For Each PageInter As WETreeViewItem In item.List

                If PageInter.List.Count > 0 Then
                    If i = item.List.Count Then CurLastUl = True
                    Call RenderFolder(writer, PageInter, level, CurLastUl)
                Else
                    Call RenderFile(writer, PageInter, level)
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
        ''' Affichage d'un fichier
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Private Sub RenderFile(ByVal writer As Common.HtmlWriter, ByVal item As WETreeViewItem, ByVal level As Integer)
            level += 1
            writer.WriteBeginTag("li")
            If level = 2 Then writer.WriteAttribute("class", "TreeViewFirst")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("File"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            Call RenderItem(writer, item)

            writer.WriteEndTag("span")

            writer.WriteEndTag("li")
            writer.WriteLine()
        End Sub

        ''' <summary>
        ''' Affichage de la partie icon+texte 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Private Sub RenderItem(ByVal writer As Common.HtmlWriter, ByVal item As WETreeViewItem)
            'Icon 
            If Not item.Icon.IsEmpty Then
                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Me.GetLink(item.Icon))
                writer.WriteAttribute("alt", String.Empty)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Icon"))
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
            End If

            'Lien
            If Not item.Link.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, item.Link, True)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                'Texte
                writer.Write(item.Title.GetValue(MyBase.Page.Culture))

                writer.WriteEndTag("a")
            Else
                'Texte
                writer.Write(item.Title.GetValue(MyBase.Page.Culture))
            End If
        End Sub



#End Region


    End Class

    ''' <summary>
    ''' WETreeView configuration class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETreeViewItem

        <Common.Attributes.ContainsLinks()> _
        Private _List As List(Of WETreeViewItem)
        Private _Title As DataType.LocalizableString
        Private _Link As Link
        Private _Icon As Link
        Private _Close As Boolean
        Private _Open As Boolean

#Region "Properties"
       
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N144"), _
        Ressource.localizable.LocalizableDescAtt("_D144"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False), _
        Common.Attributes.EditListOf.ShowColumn(Common.Attributes.EditListOf.ShowColumn.ENURepositoryType.RepositoryItemPictureEdit, 30, 30)> _
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
        ''' list of the content item
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), Common.Attributes.EditListOf.ContainsListOfObject()> _
        Public Property List() As List(Of WETreeViewItem)
            Get
                If _List Is Nothing Then _List = New List(Of WETreeViewItem)
                Return _List
            End Get
            Set(ByVal value As List(Of WETreeViewItem))
                _List = value
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
        Ressource.localizable.LocalizableDescAtt("_D142"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.EditListOf.ShowColumn()> _
        Public Property Title() As DataType.LocalizableString
            Get
                If _Title Is Nothing Then _Title = New DataType.LocalizableString
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Title = value
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
        Ressource.localizable.LocalizableDescAtt("_D143"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkPage), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.EditListOf.ShowColumn()> _
        Public Property Link() As Link
            Get
                If _Link Is Nothing Then _Link = New Link
                Return _Link
            End Get
            Set(ByVal value As Link)
                _Link = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N147"), _
        Ressource.localizable.LocalizableDescAtt("_D147")> _
        Public Property Close() As Boolean
            Get
                Return _Close
            End Get
            Set(ByVal value As Boolean)
                _Close = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N146"), _
        Ressource.localizable.LocalizableDescAtt("_D146")> _
        Public Property Open() As Boolean
            Get
                Return _Open
            End Get
            Set(ByVal value As Boolean)
                _Open = value
            End Set
        End Property

#End Region

#Region "Constructeur"
        Public Sub New()
        End Sub

        Public Sub New(ByVal title As DataType.LocalizableString, ByVal link As Link, ByVal icon As Link)
            _Title = title
            _Link = link
            _Icon = icon
        End Sub
        Public Sub New(ByVal title As DataType.LocalizableString, ByVal link As Link)
            _Title = title
            _Link = link
        End Sub
        Public Sub New(ByVal title As DataType.LocalizableString)
            _Title = title
        End Sub
#End Region

    End Class

End Namespace