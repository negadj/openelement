Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.DataType.Enum
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter.Enum
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports LocalizableCatAtt = WebElement.Ressource.localizable.LocalizableCatAtt

Imports LocalizableNameAtt = WebElement.Ressource.localizable.LocalizableNameAtt

Namespace Elements.Navigate

    <Serializable> _
    Public Class WEMenuAccordion
        Inherits ElementBase
        Implements IWEMenu

        #Region "Fields"

        Private _AutoHeight As Boolean

        ''' <summary>
        ''' Effet de ralenti
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As EnumEasingEffect
        Private _EventType As EnuEventType 'Type d'évènement sur le déclencheur
        <ContainsLinks> _
        Private _MenuGroup As WEMenuGroup 'Premier group du menu
        Private _Speed As Integer

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEMenuAccordion", page, parentID, templateName)

            'initialisation des proprietes
            Me.AutoHeight = False
            Me.EventType = EnuEventType.Over
            Me.Speed = 500
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        'Enum de l'evenemnt declencheur
        Public Enum EnuEventType As Short
            Click = 0
            'OverClick = 1
            Over = 3
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N134"), _
        LocalizableDescAtt("_D134"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AutoHeight() As Boolean
            Get
                Return _AutoHeight
            End Get
            Set(ByVal value As Boolean)
                _AutoHeight = value
            End Set
        End Property

        ''' <summary>
        ''' Effet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N232"), _
        LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(TConvEnumEasingEffect)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As EnumEasingEffect)
                _Easing = value
            End Set
        End Property

        ''' <summary>
        ''' Export de l'effet en js
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N133"), _
        LocalizableDescAtt("_D133"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property EventType() As EnuEventType
            Get
                Return _EventType
            End Get
            Set(ByVal value As EnuEventType)
                _EventType = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Configuration"), _
        'Description("Configuration du menu" & vbCrLf & ""), _
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N001"), _
        LocalizableDescAtt("_D011"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property MenuGroup() As WEMenuGroup Implements IWEMenu.MenuGroup
            Get
                If _MenuGroup Is Nothing Then
                    _MenuGroup = New WEMenuGroup()
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(LocalizablePropertyDefaultValue._0018, "1"), New Link, New Link, "DEFAULT")) '"Lien n°1 du menu"
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(LocalizablePropertyDefaultValue._0018, "2"), New Link, New Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(LocalizablePropertyDefaultValue._0018, "3"), New Link, New Link, "DEFAULT"))

                End If

                Return _MenuGroup
            End Get
            Set(ByVal value As WEMenuGroup)
                _MenuGroup = value
            End Set
        End Property

        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N135"), _
        LocalizableDescAtt("_D134"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Speed() As Integer
            Get

                Return _Speed
            End Get
            Set(ByVal value As Integer)
                _Speed = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)

            Dim newWEMenuItem As WEMenuItem
            If selectedNodeTag Is Nothing Then
                newWEMenuItem = New WEMenuItem(Me.MenuGroup)
            Else

                If TypeOf (selectedNodeTag.ParentObj) Is WEMenuItem Then
                    newWEMenuItem = New WEMenuItem(CType(selectedNodeTag.ParentObj, WEMenuItem).WEMenuGroup)
                Else
                    newWEMenuItem = New WEMenuItem(selectedNodeTag.ParentObj)
                End If
            End If

            'ajout d'un separateur
            If addButton.Name = "Separator" Then
                newWEMenuItem.Separator = True
            End If

            newObs.Add(newWEMenuItem)
            Return newObs
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("Default", LocalizableFormAndConverter._0174, Nothing)) '"Ajouter un lien"
            addButtonList.Add(New CtlEditListOf.AddButton("Separator", LocalizableFormAndConverter._0175, Nothing)) '"Ajouter un separateur"
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0113, LocalizableFormAndConverter._0170, addButtonList) '"Gestion des listes", "Edition de l'item"
            Return editConfig
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            'Menu en accordéon
            'Menu vertical en accordéon
            info.ToolBoxCaption = LocalizableOpen._0220 'Menu accordéon
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEMenuAccordion
            info.ToolBoxDescription = LocalizableOpen._0221 'Menu vertical en accordéon
            info.AutoOpenProperty = "MenuGroup"
            info.SortPropertyList.Add(New SortProperty("MenuGroup", "tools.png", LocalizableOpen._0030)) '"Configuration"
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(EnuSharedScript.jQueryUICore)
            MyBase.AddSharedScripts(EnuSharedScript.jQueryUIAccordion)
            MyBase.AddSharedScripts(EnuSharedScript.jQueryEasing)
            'MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.ui.accordion.js", "WEFiles/Client/jQuery/jquery.ui.accordion.js")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEMenuAccordion.js", "WEFiles/Client/WEMenuAccordion.js")
            MyBase.OnInitExternalFiles()
        End Sub

        ''' <summary>
        ''' Configuration des zones
        ''' </summary>
        ''' <param name="configStylesZones"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "FirstTitle", "FirstTitleSelect", "Line"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("FirstTitle", LocalizableOpen._0222, LocalizableOpen._0223)) 'Menus principaux/Zone des menus principaux
            configStylesZones.Add(New ConfigStylesZone("FirstTitleSelect", LocalizableOpen._0224, LocalizableOpen._0225)) 'Menus principaux sélectionnés/Style des menus principaux lorsqu'ils sont sélectionnés
            configStylesZones.Add(New ConfigStylesZone("Box", LocalizableOpen._0226, LocalizableOpen._0227)) 'Conteneur des menus secondaires /Conteneur des menus secondaires et de niveaux supérieurs
            configStylesZones.Add(New ConfigStylesZone("Line", LocalizableOpen._0228, LocalizableOpen._0229)) 'Menu secondaires / Ligne des menu secondaires et de niveaux supérieurs
            configStylesZones.Add(New ConfigStylesZone("Separator", LocalizableOpen._0236, LocalizableOpen._0237)) ' "Séparateur des menus principaux","Zone des séparateur des menus principaux"
            configStylesZones.Add(New ConfigStylesZone("SeparatorSubMenu", LocalizableOpen._0234, LocalizableOpen._0235)) ' "Séparateur des sous menus","Zones des séparateur des sous menus"
            configStylesZones.Add(New ConfigStylesZone("Icon", LocalizableOpen._0052, LocalizableOpen._0053)) '"Icônes","Zones des icônes du menu"
            configStylesZones.Add(New ConfigStylesZone("Top", LocalizableOpen._0044, LocalizableOpen._0045)) '"Première ligne des menus","Zone de la première ligne du menu"
            configStylesZones.Add(New ConfigStylesZone("Bottom", LocalizableOpen._0046, LocalizableOpen._0047)) '"Dernière ligne des menus","Zone de la dernière ligne du menu"
            configStylesZones.Add(New ConfigStylesZone("Box2", LocalizableOpen._0230, LocalizableOpen._0231)) 'Conteneur des menus de niveaux >2 / Conteneur des menus de niveaux supprérieur à deux

            MyBase.OnOpen(configStylesZones)
        End Sub

        'Affichage principal
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Call RenderMenuGroup(writer, Me.MenuGroup)

            MyBase.RenderEndTag(writer)
        End Sub

        'Affichage des icone des items
        Private Sub RenderIcon(ByVal writer As HtmlWriter, ByVal menuItem As WEMenuItem)
            Dim iconPath As String = String.Empty
            If menuItem.IconMenu IsNot Nothing Then iconPath = MyBase.GetLink(menuItem.IconMenu)

            If Not String.IsNullOrEmpty(iconPath) Then

                'Lien
                Dim menuLink As String = MyBase.GetLink(menuItem.Link)
                If Not menuLink = String.Empty Then
                    writer.WriteBeginTag("a")
                    writer.WriteHrefAttribute(Me, menuItem.Link, False)
                    writer.Write(HtmlTextWriter.TagRightChar)
                End If

                'Icone
                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", iconPath)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Icon"))
                writer.WriteAttribute("alt", menuItem.Text.GetValue(MyBase.Page.Culture))
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                'Fin du lien
                If Not menuLink = String.Empty Then writer.WriteEndTag("a")

            End If
        End Sub

        Private Sub RenderMenuGroup(ByVal writer As HtmlWriter, ByVal startMenuGroup As WEMenuGroup)
            If startMenuGroup.WEMenuItems.Count = 0 Then Exit Sub

            Dim index As Integer = 1

            'Ligne du haut du menu
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Top"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            For Each item As WEMenuItem In startMenuGroup.WEMenuItems

                If item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Separator"))
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                Else
                    'Menu principal

                    writer.WriteBeginTag("h3")

                    If item.WEMenuGroup IsNot Nothing AndAlso item.WEMenuGroup.WEMenuItems.Count > 0 Then
                        writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass("FirstTitle"), " full"))
                    Else
                        writer.WriteAttribute("class", MyBase.GetStyleZoneClass("FirstTitle"))
                    End If

                    writer.Write(HtmlTextWriter.TagRightChar)

                    'Icon
                    Call RenderIcon(writer, item)
                    'Lien
                    writer.WriteBeginTag("a")
                    Select Case item.Link.GetLinkType
                        Case Link.EnuLinkType.FreeUrl, Link.EnuLinkType.JavascriptPreformat
                            'Evite un bug IE8
                            'DD also fix JavaScript code (to NOT add #-1-1-1)
                            writer.WriteHrefAttribute(Me, item.Link, True)
                        Case Else
                            writer.WriteHrefAttribute(Me, item.Link, True, , String.Concat("#section", index))
                    End Select
                    'If Item.Link.GetLinkType = LinksManager.Link.EnuLinkType.FreeUrl Then
                    '    'Evite un bug IE8
                    '    writer.WriteHrefAttribute(Me, Item.Link, True)
                    'Else
                    '    writer.WriteHrefAttribute(Me, Item.Link, True, , String.Concat("#section", Index))
                    'End If

                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write(item.Text.GetValue(MyBase.Page.Culture))
                    writer.WriteEndTag("a")

                    'Fin menu principal

                    writer.WriteEndTag("h3")

                    writer.WriteLine()
                End If

                'Sous menu
                writer.WriteBeginTag("ul")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Box"))
                If item.WEMenuGroup Is Nothing OrElse item.WEMenuGroup.WEMenuItems.Count = 0 Then
                    writer.WriteAttribute("style", "list-style-type:none; height:0px; padding: 0px; margin:0px;")
                Else
                    writer.WriteAttribute("style", "list-style-type:none")
                End If

                writer.Write(HtmlTextWriter.TagRightChar)

                'Ligne du premier sous menu
                If item.WEMenuGroup IsNot Nothing AndAlso item.WEMenuGroup.WEMenuItems.Count > 0 Then
                    Call RenderMenuGroup2Level(writer, item.WEMenuGroup, index.ToString)
                Else
                    writer.WriteBeginTag("li")
                    writer.WriteAttribute("style", "display:none")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("li")
                End If

                writer.WriteLine()
                'Fin sous menu
                writer.WriteEndTag("ul")
                writer.WriteLine()
                index += 1

            Next

            'Ligne du bas de menu
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Bottom"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        Private Sub RenderMenuGroup2Level(ByVal writer As HtmlWriter, ByVal startMenuGroup As WEMenuGroup, ByVal rootindex As String)
            Dim index2 As Integer = 1

            For Each item As WEMenuItem In startMenuGroup.WEMenuItems
                writer.WriteLine()
                'debut de Ligne
                writer.WriteBeginTag("li")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Line"))
                writer.Write(HtmlTextWriter.TagRightChar)

                If item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("SeparatorSubMenu"))
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                Else
                    'Icone
                    Call RenderIcon(writer, item)
                    'Lien
                    writer.WriteBeginTag("a")

                    Select Case item.Link.GetLinkType
                        Case Link.EnuLinkType.FreeUrl, Link.EnuLinkType.JavascriptPreformat
                            'Evite un bug IE8
                            'DD also fix JavaScript code (to NOT add #-1-1-1)
                            writer.WriteAttribute("href", MyBase.GetLink(item.Link))
                        Case Else
                            writer.WriteHrefAttribute(Me, item.Link, True, , String.Concat("#", rootindex, "-", index2))
                    End Select

                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write(item.Text.GetValue(MyBase.Page.Culture))
                    writer.WriteEndTag("a")
                End If

                'Les autre sous menu
                If item.WEMenuGroup IsNot Nothing AndAlso item.WEMenuGroup.WEMenuItems.Count > 0 Then
                    writer.WriteLine()
                    writer.WriteBeginTag("ul")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Box2"))
                    writer.WriteAttribute("style", "list-style-type:none")

                    writer.Write(HtmlTextWriter.TagRightChar)
                    Dim newRootindex = String.Concat(rootindex, "-", index2)
                    Call RenderMenuGroup2Level(writer, item.WEMenuGroup, newRootindex)

                    writer.WriteLine()
                    writer.WriteEndTag("ul")

                End If
                writer.WriteLine()
                'Fin de ligne
                writer.WriteEndTag("li")

                index2 += 1
            Next
        End Sub

        #End Region 'Methods

    End Class

End Namespace

