Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement.WebElement.DataType


Namespace Elements.Navigate
    <Serializable()> _
    Public Class WEMenuAccordion
        Inherits ElementBase
        Implements Common.IWEMenu




        <Common.Attributes.ContainsLinks()> _
        Private _MenuGroup As WEMenuGroup 'Premier group du menu
        Private _EventType As EnuEventType  'Type d'évènement sur le déclencheur
        Private _AutoHeight As Boolean
        Private _Speed As Integer
        ''' <summary>
        ''' Effet de ralenti
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As DataType.Enum.EnumEasingEffect
        <NonSerialized()> _
        Private _EasingJS As String



        'Enum de l'evenemnt declencheur
        Public Enum EnuEventType As Short
            Click = 0
            'OverClick = 1
            Over = 3
        End Enum



#Region "Proprietes"
        '<Category("Edition"), _
        'DisplayName("Configuration"), _
        'Description("Configuration du menu" & vbCrLf & ""), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D011"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property MenuGroup() As WEMenuGroup Implements Common.IWEMenu.MenuGroup

            Get
                If _MenuGroup Is Nothing Then
                    _MenuGroup = New WEMenuGroup()
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(My.Resources.text.LocalizablePropertyDefaultValue._0018, "1"), New LinksManager.Link, New LinksManager.Link, "DEFAULT")) '"Lien n°1 du menu"
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(My.Resources.text.LocalizablePropertyDefaultValue._0018, "2"), New LinksManager.Link, New LinksManager.Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, String.Format(My.Resources.text.LocalizablePropertyDefaultValue._0018, "3"), New LinksManager.Link, New LinksManager.Link, "DEFAULT"))

                End If

                Return _MenuGroup
            End Get
            Set(ByVal value As WEMenuGroup)
                _MenuGroup = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N133"), _
        Ressource.localizable.LocalizableDescAtt("_D133"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
         Public Property EventType() As EnuEventType
            Get
                Return _EventType
            End Get
            Set(ByVal value As EnuEventType)
                _EventType = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N134"), _
        Ressource.localizable.LocalizableDescAtt("_D134"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
         Public Property AutoHeight() As Boolean
            Get
                Return _AutoHeight
            End Get
            Set(ByVal value As Boolean)
                _AutoHeight = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N135"), _
        Ressource.localizable.LocalizableDescAtt("_D134"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Speed() As Integer
            Get

                Return _Speed
            End Get
            Set(ByVal value As Integer)
                _Speed = value
            End Set
        End Property


        ''' <summary>
        ''' Effet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
        Ressource.localizable.LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.Enum.TConvEnumEasingEffect)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As DataType.Enum.EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As DataType.Enum.EnumEasingEffect)
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
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

#End Region

#Region "Constructeur"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)

            MyBase.New(EnuElementType.PageEdit, "WEMenuAccordion", page, parentID, templateName)


            'initialisation des proprietes
            Me.AutoHeight = False
            Me.EventType = EnuEventType.Over
            Me.Speed = 500
        End Sub
#End Region

#Region "Overrides (Events)"


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            'Menu en accordéon
            'Menu vertical en accordéon
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0220 'Menu accordéon
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEMenuAccordion
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0221 'Menu vertical en accordéon
            info.AutoOpenProperty = "MenuGroup"
            info.SortPropertyList.Add(New SortProperty("MenuGroup", "tools.png", My.Resources.text.LocalizableOpen._0030)) '"Configuration"
            Return info

        End Function


        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("FirstTitle", My.Resources.text.LocalizableOpen._0222, My.Resources.text.LocalizableOpen._0223)) 'Menus principaux/Zone des menus principaux
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("FirstTitleSelect", My.Resources.text.LocalizableOpen._0224, My.Resources.text.LocalizableOpen._0225)) 'Menus principaux sélectionnés/Style des menus principaux lorsqu'ils sont sélectionnés
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Box", My.Resources.text.LocalizableOpen._0226, My.Resources.text.LocalizableOpen._0227)) 'Conteneur des menus secondaires /Conteneur des menus secondaires et de niveaux supérieurs
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Line", My.Resources.text.LocalizableOpen._0228, My.Resources.text.LocalizableOpen._0229)) 'Menu secondaires / Ligne des menu secondaires et de niveaux supérieurs
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Separator", My.Resources.text.LocalizableOpen._0236, My.Resources.text.LocalizableOpen._0237)) ' "Séparateur des menus principaux","Zone des séparateur des menus principaux"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("SeparatorSubMenu", My.Resources.text.LocalizableOpen._0234, My.Resources.text.LocalizableOpen._0235)) ' "Séparateur des sous menus","Zones des séparateur des sous menus"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Icon", My.Resources.text.LocalizableOpen._0052, My.Resources.text.LocalizableOpen._0053)) '"Icônes","Zones des icônes du menu"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Top", My.Resources.text.LocalizableOpen._0044, My.Resources.text.LocalizableOpen._0045)) '"Première ligne des menus","Zone de la première ligne du menu"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Bottom", My.Resources.text.LocalizableOpen._0046, My.Resources.text.LocalizableOpen._0047)) '"Dernière ligne des menus","Zone de la dernière ligne du menu"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Box2", My.Resources.text.LocalizableOpen._0230, My.Resources.text.LocalizableOpen._0231)) 'Conteneur des menus de niveaux >2 / Conteneur des menus de niveaux supprérieur à deux      

            MyBase.OnOpen(ConfigStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryUICore)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryUIAccordion)
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryEasing)
            'MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.ui.accordion.js", "WEFiles/Client/jQuery/jquery.ui.accordion.js")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEMenuAccordion.js", "WEFiles/Client/WEMenuAccordion.js")
            MyBase.OnInitExternalFiles()
        End Sub

        ''' <summary>
        ''' Configuration des zones
        ''' </summary>
        ''' <param name="configStylesZones"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "FirstTitle", "FirstTitleSelect", "Line"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub


        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim NewObs As New List(Of Object)


            Dim NewWEMenuItem As WEMenuItem
            If selectedNodeTag Is Nothing Then
                NewWEMenuItem = New WEMenuItem(Me.MenuGroup)
            Else

                If TypeOf (selectedNodeTag.ParentObj) Is WEMenuItem Then
                    NewWEMenuItem = New WEMenuItem(CType(selectedNodeTag.ParentObj, WEMenuItem).WEMenuGroup)
                Else
                    NewWEMenuItem = New WEMenuItem(selectedNodeTag.ParentObj)
                End If
            End If

            'ajout d'un separateur
            If addButton.Name = "Separator" Then
                NewWEMenuItem.Separator = True
            End If

            NewObs.Add(NewWEMenuItem)
            Return NewObs







        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim AddButtonList As New List(Of AddButton)
            AddButtonList.Add(New AddButton("Default", My.Resources.text.LocalizableFormAndConverter._0174, Nothing)) '"Ajouter un lien"
            AddButtonList.Add(New AddButton("Separator", My.Resources.text.LocalizableFormAndConverter._0175, Nothing)) '"Ajouter un separateur"
            Dim EditConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0113, My.Resources.text.LocalizableFormAndConverter._0170, AddButtonList) '"Gestion des listes", "Edition de l'item"
            Return EditConfig
        End Function



#End Region

#Region "Render"

        'Affichage principal
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Call RenderMenuGroup(writer, Me.MenuGroup)

            MyBase.RenderEndTag(writer)

        End Sub



        Private Sub RenderMenuGroup(ByVal writer As Common.HtmlWriter, ByVal startMenuGroup As WEMenuGroup)


            If startMenuGroup.WEMenuItems.Count = 0 Then Exit Sub

            Dim Index As Integer = 1

            'Ligne du haut du menu
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Top"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            For Each Item As WEMenuItem In startMenuGroup.WEMenuItems




                If Item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Separator"))
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                Else
                    'Menu principal

                    writer.WriteBeginTag("h3")


                    If Item.WEMenuGroup IsNot Nothing AndAlso Item.WEMenuGroup.WEMenuItems.Count > 0 Then
                        writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass("FirstTitle"), " full"))
                    Else
                        writer.WriteAttribute("class", MyBase.GetStyleZoneClass("FirstTitle"))
                    End If

                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                    'Icon
                    Call RenderIcon(writer, Item)
                    'Lien
                    writer.WriteBeginTag("a")
                    Select Case Item.Link.GetLinkType
                        Case LinksManager.Link.EnuLinkType.FreeUrl, LinksManager.Link.EnuLinkType.JavascriptPreformat
                            'Evite un bug IE8
                            'DD also fix JavaScript code (to NOT add #-1-1-1)
                            writer.WriteHrefAttribute(Me, Item.Link, True)
                        Case Else
                            writer.WriteHrefAttribute(Me, Item.Link, True, , String.Concat("#section", Index))
                    End Select
                    'If Item.Link.GetLinkType = LinksManager.Link.EnuLinkType.FreeUrl Then
                    '    'Evite un bug IE8
                    '    writer.WriteHrefAttribute(Me, Item.Link, True)
                    'Else
                    '    writer.WriteHrefAttribute(Me, Item.Link, True, , String.Concat("#section", Index))
                    'End If

                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write(Item.Text.GetValue(MyBase.Page.Culture))
                    writer.WriteEndTag("a")

                    'Fin menu principal

                    writer.WriteEndTag("h3")

                    writer.WriteLine()
                End If




                'Sous menu
                writer.WriteBeginTag("ul")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Box"))
                If Item.WEMenuGroup Is Nothing OrElse Item.WEMenuGroup.WEMenuItems.Count = 0 Then
                    writer.WriteAttribute("style", "list-style-type:none; height:0px; padding: 0px; margin:0px;")
                Else
                    writer.WriteAttribute("style", "list-style-type:none")
                End If

                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                'Ligne du premier sous menu
                If Item.WEMenuGroup IsNot Nothing AndAlso Item.WEMenuGroup.WEMenuItems.Count > 0 Then
                    Call RenderMenuGroup2Level(writer, Item.WEMenuGroup, Index.ToString)
                Else
                    writer.WriteBeginTag("li")
                    writer.WriteAttribute("style", "display:none")
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("li")
                End If


                writer.WriteLine()
                'Fin sous menu
                writer.WriteEndTag("ul")
                writer.WriteLine()
                Index += 1

            Next

            'Ligne du bas de menu
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Bottom"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


        End Sub

        Private Sub RenderMenuGroup2Level(ByVal writer As Common.HtmlWriter, ByVal startMenuGroup As WEMenuGroup, ByVal rootindex As String)
            Dim Index2 As Integer = 1

            For Each Item As WEMenuItem In startMenuGroup.WEMenuItems
                writer.WriteLine()
                'debut de Ligne
                writer.WriteBeginTag("li")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Line"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                If Item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("SeparatorSubMenu"))
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                Else
                    'Icone
                    Call RenderIcon(writer, Item)
                    'Lien
                    writer.WriteBeginTag("a")

                    Select Case Item.Link.GetLinkType
                        Case LinksManager.Link.EnuLinkType.FreeUrl, LinksManager.Link.EnuLinkType.JavascriptPreformat
                            'Evite un bug IE8
                            'DD also fix JavaScript code (to NOT add #-1-1-1)
                            writer.WriteAttribute("href", MyBase.GetLink(Item.Link))
                        Case Else
                            writer.WriteHrefAttribute(Me, Item.Link, True, , String.Concat("#", rootindex, "-", Index2))
                    End Select

                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write(Item.Text.GetValue(MyBase.Page.Culture))
                    writer.WriteEndTag("a")
                End If

                'Les autre sous menu
                If Item.WEMenuGroup IsNot Nothing AndAlso Item.WEMenuGroup.WEMenuItems.Count > 0 Then
                    writer.WriteLine()
                    writer.WriteBeginTag("ul")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Box2"))
                    writer.WriteAttribute("style", "list-style-type:none")

                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    Dim NewRootindex = String.Concat(rootindex, "-", Index2)
                    Call RenderMenuGroup2Level(writer, Item.WEMenuGroup, NewRootindex)

                    writer.WriteLine()
                    writer.WriteEndTag("ul")

                End If
                writer.WriteLine()
                'Fin de ligne
                writer.WriteEndTag("li")

                Index2 += 1
            Next
        End Sub

        'Affichage des icone des items
        Private Sub RenderIcon(ByVal writer As Common.HtmlWriter, ByVal menuItem As WEMenuItem)
            Dim IconPath As String = String.Empty
            If menuItem.IconMenu IsNot Nothing Then IconPath = MyBase.GetLink(menuItem.IconMenu)

            If Not String.IsNullOrEmpty(IconPath) Then

                'Lien
                Dim MenuLink As String = MyBase.GetLink(menuItem.Link)
                If Not MenuLink = String.Empty Then
                    writer.WriteBeginTag("a")
                    writer.WriteHrefAttribute(Me, menuItem.Link, False)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                End If

                'Icone
                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", IconPath)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Icon"))
                writer.WriteAttribute("alt", menuItem.Text.GetValue(MyBase.Page.Culture))
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                'Fin du lien
                If Not MenuLink = String.Empty Then writer.WriteEndTag("a")



            End If
        End Sub

#End Region
    End Class
End Namespace
