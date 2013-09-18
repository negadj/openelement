#Region "Header"

'NameSpace of element (create yours ex: Elements.MyCompagny)
'NameSpace is equivalent to group of elements which the current element belongs

#End Region 'Header

Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Navigate.Editors
Imports WebElement.Elements.Navigate.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports LocalizableCatAtt = WebElement.Ressource.localizable.LocalizableCatAtt

Imports LocalizableNameAtt = WebElement.Ressource.localizable.LocalizableNameAtt

Namespace Elements.Navigate

    ''' <summary>
    '''  This class is the correct source code of openElement's element : WEMenu (popup menu)
    ''' Create a public class with inherit ElementBase (complete namespace : openElement.WebElement.Elements.ElementBase)
    ''' See comments in elementBase for all explanations of methods of mybase used in this class.
    '''  the class's name must to be unique in the namespace. he can't will be changing after
    ''' This class must to be  "Serializable"
    ''' </summary>
    ''' <remarks>it'd be better of us to subject the class name</remarks>
    <Serializable> _
    Public Class WEMenu
        Inherits ElementBase
        Implements IWEMenu

        #Region "Fields"

        ''' <summary>
        '''  Minimal period of closing
        ''' </summary>
        Private _AutoHidePeriod As Integer

        ''' <summary>
        ''' mouse event on which is displayed the menu
        ''' </summary>
        Private _EventType As EnuEventType = EnuEventType.OverClick

        ''' <summary>
        ''' time before closing 
        ''' </summary>
        Private _HideSpeed As Integer

        ''' <summary>
        '''  Closing speed of the animation
        ''' </summary>
        Private _HideSpeedEffect As EnuSpeedEffect

        ''' <summary>
        ''' Hook element's unique ID
        ''' </summary>
        Private _Hook As String

        'this tag allows to know if the object contains himself 'links' property. It's recursif. All class who contains 'links" must to have this tag
        <ContainsLinks> _
        Private _MenuGroup As WEMenuGroup

        ''' <summary>
        ''' time before opening  
        ''' </summary>
        Private _OpenSpeed As Integer

        ''' <summary>
        '''  opening speed of animation
        ''' </summary>
        Private _OpenSpeedEffect As EnuSpeedEffect

        ''' <summary>
        ''' start position on the trigger element 
        ''' </summary>
        Private _StartPosition As EnuStartPosition

        ''' <summary>
        ''' X gap of the first menu on the trigger element  
        ''' </summary>
        Private _StartX As Integer

        ''' <summary>
        ''' Y gap of the first menu on the trigger element
        ''' </summary>
        Private _StartY As Integer

        ''' <summary>
        ''' X gap of the first sub-menu on the trigger element 
        ''' </summary>
        Private _SubMenuStartX As Integer

        ''' <summary>
        ''' list of trigger's element on which is displayed the menu
        ''' </summary>
        Private _Trigger As List(Of String)

        #End Region 'Fields

        #Region "Constructors"

        ''' <summary>
        ''' Obligatory configuration of constructor. The base constructor call is necessary 
        ''' for parameter, see comments in ElementBase class
        ''' </summary>
        ''' <param name="page"> Page reference which element belongs </param>
        ''' <param name="parentID"> Unique ID of parent container</param>
        ''' <param name="templateName"> template's name which element belongs</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.HiddenEdit, "WEMenu", page, parentID, templateName)

            'default value
            AutoHidePeriod = 800
            EventType = EnuEventType.OverClick
            SubMenuStartX = 3
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        'adding of 'IWEMenu' interface  because the 'WEMEnuGroup' property  must to be compatible with other elements
        ''' <summary>
        ''' type of trigger event (on mouse event)
        ''' </summary>
        Public Enum EnuEventType As Short
            Click = 0
            OverClick = 1
            DblClick = 2
            Over = 3
        End Enum

        ''' <summary>
        ''' list of visual effect as possible
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuSpeedEffect As Short
            Fast = 0
            Slow = 1
            UltraFast = 2
        End Enum

        ''' <summary>
        ''' first position menu according to hook element
        ''' </summary>
        Public Enum EnuStartPosition As Short
            RightTop = 0
            RightBottom = 1
            LeftBottom = 2
            LeftTop = 3
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        ''' <summary>
        ''' Minimal period of closing
        ''' </summary>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N018"), _
        LocalizableDescAtt("_D018"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoHidePeriod() As Integer
            Get
                Return _AutoHidePeriod
            End Get
            Set(ByVal value As Integer)
                _AutoHidePeriod = Math.Abs(value) 'the period must always to be positive
            End Set
        End Property

        ''' <summary>
        ''' mouse event on which is displayed the menu
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False), _
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

        ''' <summary>
        ''' time before closing 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N243"), _
        LocalizableDescAtt("_D243"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
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
        ''' Closing speed of the animation
        ''' </summary>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N017"), _
        LocalizableDescAtt("_D017"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property HideSpeedEffect() As EnuSpeedEffect
            Get
                Return _HideSpeedEffect
            End Get
            Set(ByVal value As EnuSpeedEffect)
                _HideSpeedEffect = value
            End Set
        End Property

        ''' <summary>
        ''' Hook element's unique ID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Hook() As String
            Get
                Return _Hook
            End Get
            Set(ByVal value As String)
                _Hook = value
            End Set
        End Property

        ''' <summary>
        ''' Main configuration
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Edition), _
        LocalizableNameAtt("_N001"), _
        LocalizableDescAtt("_D011"), _
        Editor(GetType(UITypeMenuGroup), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property MenuGroup() As WEMenuGroup Implements IWEMenu.MenuGroup
            Get
                If _MenuGroup Is Nothing Then
                    _MenuGroup = New WEMenuGroup()
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, LocalizableOpen._0281, New Link, New Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, LocalizableOpen._0282, New Link, New Link, "DEFAULT"))
                    _MenuGroup.WEMenuItems.Add(New WEMenuItem(_MenuGroup, LocalizableOpen._0283, New Link, New Link, "DEFAULT"))

                End If

                Return _MenuGroup
            End Get
            Set(ByVal value As WEMenuGroup)
                _MenuGroup = value
            End Set
        End Property

        ''' <summary>
        ''' time before opening  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N242"), _
        LocalizableDescAtt("_D242"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
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
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Behavior), _
        LocalizableNameAtt("_N016"), _
        LocalizableDescAtt("_D016"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property OpenSpeedEffect() As EnuSpeedEffect
            Get
                Return _OpenSpeedEffect
            End Get
            Set(ByVal value As EnuSpeedEffect)
                _OpenSpeedEffect = value
            End Set
        End Property

        ''' <summary>
        ''' start position on the trigger element 
        ''' </summary>
        ''' <remarks></remarks>
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Appearance), _
        LocalizableNameAtt("_N013"), _
        LocalizableDescAtt("_D013"), _
        TypeConverter(GetType(TConvMenuEnuStartPosition)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
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
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Appearance), _
        LocalizableNameAtt("_N014"), _
        LocalizableDescAtt("_D014"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
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
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Appearance), _
        LocalizableNameAtt("_N015"), _
        LocalizableDescAtt("_D015"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
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
        <LocalizableCatAtt(LocalizableCatAtt.EnumWECategory.Appearance), _
        LocalizableNameAtt("_N101"), _
        LocalizableDescAtt("_D101"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property SubMenuStartX() As Integer
            Get
                Return _SubMenuStartX
            End Get
            Set(ByVal value As Integer)
                _SubMenuStartX = value
            End Set
        End Property

        ''' <summary>
        ''' list of trigger's element on which is displayed the menu
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Trigger() As List(Of String)
            Get
                If _Trigger Is Nothing Then _Trigger = New List(Of String)
                Return _Trigger
            End Get
            Set(ByVal value As List(Of String))
                _Trigger = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        'These Overrides functions are to use for configure the user controle : CtlEditListOf. It's a generic user control to configure the lists
        ''' <summary>
        '''  Called for adding of list element after a mouse clic event
        ''' </summary>
        ''' <param name="addButton">Button's name to click</param>
        ''' <param name="selectedNodeTag">Contains data for config object</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)

            'Create config object
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

            If addButton.Name = "Separator" Then
                newWEMenuItem.Separator = True
            End If

            newObs.Add(newWEMenuItem)
            Return newObs
        End Function

        ''' <summary>
        ''' configuration of the form "FrmListOfObj". Adding of menu button.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("Default", LocalizableFormAndConverter._0174, Nothing))
            addButtonList.Add(New CtlEditListOf.AddButton("Separator", LocalizableFormAndConverter._0175, Nothing))
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0113, LocalizableFormAndConverter._0170, addButtonList)
            Return editConfig
        End Function

        ''' <summary>         
        ''' Required function who allow to complete elementInfo object        
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0038
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEMenu
            info.ToolBoxDescription = LocalizableOpen._0039
            info.AutoOpenProperty = "MenuGroup"
            info.SortPropertyList.Add(New SortProperty("MenuGroup", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        ''' <summary>
        ''' Adding of external script to web project. These scripts must to be shared or specific at element
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WEMenu.css", "WEFiles/Css/WEMenu.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEMenu.js", "WEFiles/Client/WEMenu.js")

            'always call to mybase function
            MyBase.OnInitExternalFiles()
        End Sub

        ''' <summary>
        ''' Event called before the loading of the zone for configuration 
        ''' </summary>
        ''' <param name="configStylesZones"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "WEMenuText"
                    configStylesZones.IsLink = True 'here, the style zone: "WEMEnuText" is style "link"
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        ''' <summary>
        ''' Event called at openning of element. 
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()
            'we configures the specific style Zones of WEMenu
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("WEMenuGroup", LocalizableOpen._0040, LocalizableOpen._0041))
            configStylesZones.Add(New ConfigStylesZone("WEMenuItem", LocalizableOpen._0042, LocalizableOpen._0043))
            configStylesZones.Add(New ConfigStylesZone("WEMenuItemTable", LocalizableOpen._0189, LocalizableOpen._0190))
            configStylesZones.Add(New ConfigStylesZone("WEMenuTop", LocalizableOpen._0044, LocalizableOpen._0045))
            configStylesZones.Add(New ConfigStylesZone("WEMenuBottom", LocalizableOpen._0046, LocalizableOpen._0047))
            configStylesZones.Add(New ConfigStylesZone("WEMenuText", LocalizableOpen._0048, LocalizableOpen._0049))
            configStylesZones.Add(New ConfigStylesZone("WEMenuSeparator", LocalizableOpen._0050, LocalizableOpen._0051))
            configStylesZones.Add(New ConfigStylesZone("WEMenuIcon", LocalizableOpen._0052, LocalizableOpen._0053))
            configStylesZones.Add(New ConfigStylesZone("WEMenuSubIcon", LocalizableOpen._0054, LocalizableOpen._0055))

            'Obligatory at end
            MyBase.OnOpen(configStylesZones)
        End Sub

        'html render functions. Html is building according to dynamic data of WEMenuItem
        ''' <summary>
        ''' Main method for render in html file
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Call RenderMenuGroup(writer, Me.MenuGroup)

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Specific method for display icons of menu item
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="menuItem"></param>
        ''' <remarks></remarks>
        Private Sub RenderIcon(ByVal writer As HtmlWriter, ByVal menuItem As WEMenuItem)
            Dim iconPath As String = String.Empty
            If menuItem.IconMenu IsNot Nothing Then iconPath = MyBase.GetLink(menuItem.IconMenu)

            If Not String.IsNullOrEmpty(iconPath) Then

                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "width:1px")
                writer.Write(HtmlTextWriter.TagRightChar)

                Dim menuLink As String = MyBase.GetLink(menuItem.Link)
                If Not menuLink = String.Empty Then
                    writer.WriteBeginTag("a")
                    writer.WriteHrefAttribute(Me, menuItem.Link, False)
                    writer.Write(HtmlTextWriter.TagRightChar)
                End If

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", iconPath)
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuIcon"))
                writer.WriteAttribute("alt", menuItem.Text.GetValue(MyBase.Page.Culture))
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                If Not menuLink = String.Empty Then writer.WriteEndTag("a")

                writer.WriteEndTag("td")
                writer.WriteLine()

            End If
        End Sub

        ''' <summary>
        ''' Specific method for 
        ''' Display menu group
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="startMenuGroup"></param>
        ''' <remarks></remarks>
        Private Sub RenderMenuGroup(ByVal writer As HtmlWriter, ByVal startMenuGroup As WEMenuGroup)
            If startMenuGroup.WEMenuItems.Count = 0 Then Exit Sub

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuGroup"))
            writer.WriteAttribute("style", "display:none")
            writer.WriteAttribute("id", startMenuGroup.ID)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuTop"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            For Each item As WEMenuItem In startMenuGroup.WEMenuItems

                If item.Separator Then
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuSeparator"))
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write("&nbsp;")
                    writer.WriteEndTag("div")
                    writer.WriteLine()
                    Continue For
                End If

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuItem"))
                writer.WriteAttribute("id", item.ID)
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteLine()

                Call RenderMenuItem(writer, item)

                If item.WEMenuGroup IsNot Nothing Then
                    Call RenderMenuGroup(writer, item.WEMenuGroup)
                End If

                writer.WriteEndTag("div")
                writer.WriteLine()

            Next
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuBottom"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        ''' <summary>
        ''' Specific method for display menu items
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="menuItem"></param>
        ''' <remarks></remarks>
        Private Sub RenderMenuItem(ByVal writer As HtmlWriter, ByVal menuItem As WEMenuItem)
            writer.WriteBeginTag("table")
            writer.WriteOnClickLinkAttribute(Me, menuItem.Link, True)

            writer.WriteAttribute("style", "border-spacing: 0px; border-collapse: collapse;")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuItemTable"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1
            writer.WriteBeginTag("tr")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            Call RenderIcon(writer, menuItem)

            writer.WriteBeginTag("td")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuText"))
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", MyBase.GetLink(menuItem.Link))
            writer.Write(HtmlTextWriter.TagRightChar)
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

        ''' <summary>
        ''' Display the item's arrow (if necessary)
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="menuItem"></param>
        ''' <remarks></remarks>
        Private Sub RenderSubIcon(ByVal writer As HtmlWriter, ByVal menuItem As WEMenuItem)
            If menuItem.WEMenuGroup.WEMenuItems.Count <> 0 Then
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "width:1px")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Me.Page.CreateRelativeLink("WEFiles/Image/empty.png"))
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("WEMenuSubIcon"))
                writer.WriteAttribute("alt", "")
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteLine()
            End If
        End Sub

        #End Region 'Methods

    End Class

End Namespace

