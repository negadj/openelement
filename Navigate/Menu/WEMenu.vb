Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement.WebElement.DataType


Namespace Elements.Navigate


    <Serializable()> _
    Public Class WEMenu
        Inherits ElementBase
        Implements Common.IWEMenu


        'type of trigger event
        Public Enum EnuEventType As Short
            Click = 0
            OverClick = 1
            DblClick = 2
            Over = 3
        End Enum

        'first position menu
        Public Enum EnuStartPosition As Short
            RightTop = 0
            RightBottom = 1
            LeftBottom = 2
            LeftTop = 3
        End Enum

        'visual effect
        Public Enum EnuSpeedEffect As Short
            Fast = 0
            Slow = 1
            UltraFast = 2
        End Enum

#Region "Properties"

        <Common.Attributes.ContainsLinks()> _
        Private _MenuGroup As WEMenuGroup

        Private _Hook As String
        Private _Trigger As List(Of String)
        Private _EventType As EnuEventType = EnuEventType.OverClick
        Private _StartPosition As EnuStartPosition
        Private _StartX As Integer
        Private _StartY As Integer
        Private _OpenSpeedEffect As EnuSpeedEffect
        Private _HideSpeedEffect As EnuSpeedEffect
        Private _OpenSpeed As Integer
        Private _HideSpeed As Integer
        Private _AutoHidePeriod As Integer
        Private _SubMenuStartX As Integer



        ''' <summary>
        ''' Main configuration
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D011"), _
        Editor(GetType(Editors.UITypeMenuGroup), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property MenuGroup() As WEMenuGroup Implements Common.IWEMenu.MenuGroup
            Get
                If _MenuGroup Is Nothing Then
                    _MenuGroup = New WEMenuGroup()
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, My.Resources.text.LocalizableOpen._0281, New LinksManager.Link, New LinksManager.Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, My.Resources.text.LocalizableOpen._0282, New LinksManager.Link, New LinksManager.Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, My.Resources.text.LocalizableOpen._0283, New LinksManager.Link, New LinksManager.Link, "DEFAULT"))

                End If

                Return _MenuGroup
            End Get
            Set(ByVal value As WEMenuGroup)
                _MenuGroup = value
            End Set
        End Property

        ''' <summary>
        ''' list of trigger's element on which is displayed the menu
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Trigger() As List(Of String)
            Get
                If _Trigger Is Nothing Then _Trigger = New List(Of String)
                Return _Trigger
            End Get
            Set(ByVal value As List(Of String))
                _Trigger = value
            End Set
        End Property

        ''' <summary>
        ''' Hook element's unique ID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Hook() As String
            Get
                Return _Hook
            End Get
            Set(ByVal value As String)
                _Hook = value
            End Set
        End Property

        ''' <summary>
        ''' mouse event on which is displayed the menu
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False), _
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

        ''' <summary>
        ''' start position on the trigger element 
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N013"), _
        Ressource.localizable.LocalizableDescAtt("_D013"), _
        TypeConverter(GetType(Editors.Converter.TConvMenuEnuStartPosition)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property StartPosition() As EnuStartPosition
            Get
                Return _StartPosition
            End Get
            Set(ByVal value As EnuStartPosition)
                _StartPosition = value
            End Set
        End Property

        ''' <summary>
        ''' X gap of the first menu on the trigger element  
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N014"), _
        Ressource.localizable.LocalizableDescAtt("_D014"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property StartX() As Integer
            Get
                Return _StartX
            End Get
            Set(ByVal value As Integer)
                _StartX = value
            End Set
        End Property

        ''' <summary>
        ''' Y gap of the first menu on the trigger element
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N015"), _
        Ressource.localizable.LocalizableDescAtt("_D015"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property StartY() As Integer
            Get
                Return _StartY
            End Get
            Set(ByVal value As Integer)
                _StartY = value
            End Set
        End Property


        ''' <summary>
        '''  X gap of the first sub-menu on the trigger element  
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N101"), _
        Ressource.localizable.LocalizableDescAtt("_D101"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property SubMenuStartX() As Integer
            Get
                Return _SubMenuStartX
            End Get
            Set(ByVal value As Integer)
                _SubMenuStartX = value
            End Set
        End Property


        ''' <summary>
        ''' time before opening  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N242"), _
        Ressource.localizable.LocalizableDescAtt("_D242"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property OpenSpeed() As Integer
            Get
                If _OpenSpeed < 0 Then _OpenSpeed = 0
                Return _OpenSpeed
            End Get
            Set(ByVal value As Integer)
                _OpenSpeed = value
            End Set
        End Property

        ''' <summary>
        ''' opening speed of animation
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N016"), _
        Ressource.localizable.LocalizableDescAtt("_D016"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property OpenSpeedEffect() As EnuSpeedEffect
            Get
                Return _OpenSpeedEffect
            End Get
            Set(ByVal value As EnuSpeedEffect)
                _OpenSpeedEffect = value
            End Set
        End Property

        ''' <summary>
        ''' Closing speed of the animation
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N017"), _
        Ressource.localizable.LocalizableDescAtt("_D017"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
         Public Property HideSpeedEffect() As EnuSpeedEffect
            Get
                Return _HideSpeedEffect
            End Get
            Set(ByVal value As EnuSpeedEffect)
                _HideSpeedEffect = value
            End Set
        End Property


        ''' <summary>
        ''' time before closing 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N243"), _
        Ressource.localizable.LocalizableDescAtt("_D243"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property HideSpeed() As Integer
            Get
                If _HideSpeed < 0 Then _HideSpeed = 0
                Return _HideSpeed
            End Get
            Set(ByVal value As Integer)
                _HideSpeed = value
            End Set
        End Property


        ''' <summary>
        ''' Minimal period of closing
        ''' </summary>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
          Ressource.localizable.LocalizableNameAtt("_N018"), _
          Ressource.localizable.LocalizableDescAtt("_D018"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
         Public Property AutoHidePeriod() As Integer
            Get
                Return _AutoHidePeriod
            End Get
            Set(ByVal value As Integer)
                _AutoHidePeriod = Math.Abs(value) 'the period must always to be positive
            End Set
        End Property



#End Region

#Region "Builder required function"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)

            MyBase.New(EnuElementType.HiddenEdit, "WEMenu", page, parentID, templateName)

            'default value
            AutoHidePeriod = 800
            EventType = EnuEventType.OverClick
            SubMenuStartX = 3

        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0038
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEMenu
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0039
            info.AutoOpenProperty = "MenuGroup"
            info.SortPropertyList.Add(New SortProperty("MenuGroup", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuGroup", My.Resources.text.LocalizableOpen._0040, My.Resources.text.LocalizableOpen._0041))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuItem", My.Resources.text.LocalizableOpen._0042, My.Resources.text.LocalizableOpen._0043))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuItemTable", My.Resources.text.LocalizableOpen._0189, My.Resources.text.LocalizableOpen._0190))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuTop", My.Resources.text.LocalizableOpen._0044, My.Resources.text.LocalizableOpen._0045))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuBottom", My.Resources.text.LocalizableOpen._0046, My.Resources.text.LocalizableOpen._0047))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuText", My.Resources.text.LocalizableOpen._0048, My.Resources.text.LocalizableOpen._0049))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuSeparator", My.Resources.text.LocalizableOpen._0050, My.Resources.text.LocalizableOpen._0051))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuIcon", My.Resources.text.LocalizableOpen._0052, My.Resources.text.LocalizableOpen._0053))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("WEMenuSubIcon", My.Resources.text.LocalizableOpen._0054, My.Resources.text.LocalizableOpen._0055))

            MyBase.OnOpen(ConfigStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WEMenu.css", "WEFiles/Css/WEMenu.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEMenu.js", "WEFiles/Client/WEMenu.js")
            MyBase.OnInitExternalFiles()
        End Sub

       
        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "WEMenuText"
                    configStylesZones.IsLink = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub


#End Region


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


#Region "Render"


        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            Call RenderMenuGroup(writer, Me.MenuGroup)

            MyBase.RenderEndTag(writer)

        End Sub
         
        ''' <summary>
        ''' Display menu group
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="startMenuGroup"></param>
        ''' <remarks></remarks>
        Private Sub RenderMenuGroup(ByVal writer As Common.HtmlWriter, ByVal startMenuGroup As WEMenuGroup)

            If startMenuGroup.WEMenuItems.Count = 0 Then Exit Sub

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuGroup"))
            writer.WriteAttribute("style", "display:none")
            writer.WriteAttribute("id", startMenuGroup.ID)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1


            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuTop"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            For Each Item As WEMenuItem In startMenuGroup.WEMenuItems

                If Item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuSeparator"))
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                    Continue For
                End If

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuItem"))
                writer.WriteAttribute("id", Item.ID)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteLine()

                Call RenderMenuItem(writer, Item)

                If Item.WEMenuGroup IsNot Nothing Then
                    Call RenderMenuGroup(writer, Item.WEMenuGroup)
                End If

                writer.WriteEndTag("div")
                writer.WriteLine()

            Next
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuBottom"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()

        End Sub

        Private Sub RenderMenuItem(ByVal writer As Common.HtmlWriter, ByVal menuItem As WEMenuItem)

            writer.WriteBeginTag("table")
            writer.WriteOnClickLinkAttribute(Me, menuItem.Link, True)

            writer.WriteAttribute("style", "border-spacing: 0px; border-collapse: collapse;")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuItemTable"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1
            writer.WriteBeginTag("tr")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            Call RenderIcon(writer, menuItem)

            writer.WriteBeginTag("td")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuText"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", MyBase.GetLink(menuItem.Link))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(menuItem.Text.GetValue(MyBase.Page.Culture))
            writer.WriteEndTag("a")

            writer.WriteEndTag("td")
            writer.WriteLine()

            Call RenderSubIcon(writer, menuItem)

            writer.WriteEndTag("tr")
            writer.WriteLine()
            writer.Indent -= 1
            writer.WriteEndTag("table")
            writer.WriteLine()

        End Sub

        Private Sub RenderIcon(ByVal writer As Common.HtmlWriter, ByVal menuItem As WEMenuItem)
            Dim IconPath As String = String.Empty
            If menuItem.IconMenu IsNot Nothing Then IconPath = MyBase.GetLink(menuItem.IconMenu)

            If Not String.IsNullOrEmpty(IconPath) Then

                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "width:1px")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)


                Dim MenuLink As String = MyBase.GetLink(menuItem.Link)
                If Not MenuLink = String.Empty Then
                    writer.WriteBeginTag("a")
                    writer.WriteHrefAttribute(Me, menuItem.Link, False)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                End If


                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", IconPath)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuIcon"))
                writer.WriteAttribute("alt", menuItem.Text.GetValue(MyBase.Page.Culture))
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
 
                If Not MenuLink = String.Empty Then writer.WriteEndTag("a")

                writer.WriteEndTag("td")
                writer.WriteLine()

            End If
        End Sub

        ''' <summary>
        ''' Display the item's arrow (if necessary)
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="menuItem"></param>
        ''' <remarks></remarks>
        Private Sub RenderSubIcon(ByVal writer As Common.HtmlWriter, ByVal menuItem As WEMenuItem)

            If menuItem.WEMenuGroup.WEMenuItems.Count <> 0 Then
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "width:1px")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Me.Page.CreateRelativeLink("WEFiles/Image/empty.png"))
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuSubIcon"))
                writer.WriteAttribute("alt", "")
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteLine()
            End If

        End Sub

#End Region

    End Class




End Namespace
