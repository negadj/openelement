Imports System.ComponentModel
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.DataType.Enum
Imports openElement.WebElement.Editors.Converter.Enum
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Containers.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Containers

    <Serializable> _
    Public Class WECollapsiblePanel
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' opening delay
        ''' </summary>
        ''' <remarks></remarks>
        Private _Delay As Integer

        ''' <summary>
        ''' close slow effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _EasingClose As EnumEasingEffect

        ''' <summary>
        ''' opening slow effect  
        ''' </summary>
        ''' <remarks></remarks>
        Private _EasingOpen As EnumEasingEffect

        ''' <summary>
        ''' type of opening mouse event
        ''' </summary>
        ''' <remarks></remarks>
        Private _EventType As EnuEventType

        ''' <summary>
        ''' if it's open at the page loading 
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsOpen As Boolean

        ''' <summary>
        ''' How the panel opens 
        ''' </summary>
        ''' <remarks></remarks>
        Private _PanelPosition As EnuCollapsiblePanelPosition

        ''' <summary>
        ''' css position 
        ''' </summary>
        ''' <remarks></remarks>
        Private _PositionMode As CssEnum.PositionMode

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECollapsiblePanel", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both
            Me._PanelPosition = EnuCollapsiblePanelPosition.Top
            IsOpen = False
            Delay = 500
            PositionMode = CssEnum.PositionMode.absolute
            EasingOpen = EnumEasingEffect.none
            EasingClose = EnumEasingEffect.none
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        ''' <summary>
        ''' tab opening position
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuCollapsiblePanelPosition As Short
            Top = 0
            Bottom = 1
            Left = 2
            Right = 3
        End Enum

        ''' <summary>
        ''' opening event enum
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuEventType As Short
            Click = 0
            OverClick = 1
            Over = 3
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N135"), _
        LocalizableDescAtt("_D135"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public Property Delay() As Integer
            Get
                Return _Delay
            End Get
            Set(ByVal value As Integer)
                _Delay = value
                If _Delay <= 0 Then _Delay = 500
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N236"), _
        LocalizableDescAtt("_D236"), _
        TypeConverter(GetType(TConvEnumEasingEffect)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property EasingClose() As EnumEasingEffect
            Get
                Return _EasingClose
            End Get
            Set(ByVal value As EnumEasingEffect)
                _EasingClose = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingCloseJs() As String
            Get
                Return _EasingClose.ToString
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N235"), _
        LocalizableDescAtt("_D235"), _
        TypeConverter(GetType(TConvEnumEasingEffect)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property EasingOpen() As EnumEasingEffect
            Get
                Return _EasingOpen
            End Get
            Set(ByVal value As EnumEasingEffect)
                _EasingOpen = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingOpenJs() As String
            Get
                Return _EasingOpen.ToString
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N133"), _
        LocalizableDescAtt("_D133"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public Property EventType() As EnuEventType
            Get
                Return _EventType
            End Get
            Set(ByVal value As EnuEventType)
                _EventType = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N215"), _
        LocalizableDescAtt("_D215"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public Property IsOpen() As Boolean
            Get
                Return _IsOpen
            End Get
            Set(ByVal value As Boolean)
                _IsOpen = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N214"), _
        LocalizableDescAtt("_D214"), _
        TypeConverter(GetType(TConvEnuCollapsiblePanelPosition)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PanelPosition() As EnuCollapsiblePanelPosition
            Get
                Return _PanelPosition
            End Get
            Set(ByVal value As EnuCollapsiblePanelPosition)

                _PanelPosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N127"), _
        LocalizableDescAtt("_D127"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PositionMode() As CssEnum.PositionMode
            Get
                Return _PositionMode
            End Get
            Set(ByVal value As CssEnum.PositionMode)
                _PositionMode = value
                MyBase.Templates.SetTemplate("Content", value)
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Sub ContentRender(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "position:relative;")
            writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("OpenZone", Me.PanelPosition.ToString)), " OpenZone"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetTemplateClass("OpenZone"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            MyBase.RenderTemplate(writer, "OpenZone")

            'writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0369
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WECollapsiblePanel
            info.ToolBoxDescription = LocalizableOpen._0373
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECollapsiblePanel.js", "WEFiles/Client/WECollapsiblePanel.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.Templates.SetTemplate("OpenZone", CssEnum.PositionMode.absolute)

            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("OpenZoneTop", LocalizableOpen._0368, LocalizableOpen._0370))
            configStylesZones.Add(New ConfigStylesZone("PullZoneCloseTop", LocalizableOpen._0371, LocalizableOpen._0371))
            configStylesZones.Add(New ConfigStylesZone("PullZoneOpenTop", LocalizableOpen._0372, LocalizableOpen._0372))

            configStylesZones.Add(New ConfigStylesZone("OpenZoneBottom", LocalizableOpen._0374, LocalizableOpen._0370))
            configStylesZones.Add(New ConfigStylesZone("PullZoneCloseBottom", LocalizableOpen._0375, LocalizableOpen._0371))
            configStylesZones.Add(New ConfigStylesZone("PullZoneOpenBottom", LocalizableOpen._0376, LocalizableOpen._0372))

            configStylesZones.Add(New ConfigStylesZone("OpenZoneLeft", LocalizableOpen._0377, LocalizableOpen._0370))
            configStylesZones.Add(New ConfigStylesZone("PullZoneCloseLeft", LocalizableOpen._0378, LocalizableOpen._0371))
            configStylesZones.Add(New ConfigStylesZone("PullZoneOpenLeft", LocalizableOpen._0379, LocalizableOpen._0372))

            configStylesZones.Add(New ConfigStylesZone("OpenZoneRight", LocalizableOpen._0380, LocalizableOpen._0370))
            configStylesZones.Add(New ConfigStylesZone("PullZoneCloseRight", LocalizableOpen._0381, LocalizableOpen._0371))
            configStylesZones.Add(New ConfigStylesZone("PullZoneOpenRight", LocalizableOpen._0382, LocalizableOpen._0372))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Sub PullRender(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "position:relative")
            If IsOpen Then
                writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("PullZoneOpen", Me.PanelPosition.ToString)), " PullZone PullZoneClose"))
            Else
                writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("PullZoneClose", Me.PanelPosition.ToString)), " PullZone PullZoneClose"))
            End If

            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "overflow:hidden; height:100%;")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECollapsiblePanelContent")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1
            If PanelPosition = EnuCollapsiblePanelPosition.Top Or PanelPosition = EnuCollapsiblePanelPosition.Left Then
                Call ContentRender(writer)
                Call PullRender(writer)
            Else
                Call PullRender(writer)
                Call ContentRender(writer)
            End If
            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.Indent -= 1
            writer.WriteLine()
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

