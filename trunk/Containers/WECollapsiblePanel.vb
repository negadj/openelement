Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager.CssItems

Namespace Elements.Containers

    <Serializable()> _
    Public Class WECollapsiblePanel
        Inherits ElementBase

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

#Region "private variable"

        ''' <summary>
        ''' How the panel opens 
        ''' </summary>
        ''' <remarks></remarks>
        Private _PanelPosition As EnuCollapsiblePanelPosition
        ''' <summary>
        ''' if it's open at the page loading 
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsOpen As Boolean
        ''' <summary>
        ''' opening delay
        ''' </summary>
        ''' <remarks></remarks>
        Private _Delay As Integer
        ''' <summary>
        ''' type of opening mouse event
        ''' </summary>
        ''' <remarks></remarks>
        Private _EventType As EnuEventType
        ''' <summary>
        ''' css position 
        ''' </summary>
        ''' <remarks></remarks>
        Private _PositionMode As StylesManager.CssItems.CssEnum.PositionMode
        ''' <summary>
        ''' opening slow effect  
        ''' </summary>
        ''' <remarks></remarks>
        Private _EasingOpen As DataType.Enum.EnumEasingEffect
        ''' <summary>
        ''' close slow effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _EasingClose As DataType.Enum.EnumEasingEffect
        <NonSerialized()> _
        Private _EasingCloseJS As String
        <NonSerialized()> _
        Private _EasingOpenJS As String

#End Region

#Region "Properties"
     
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N214"), _
        Ressource.localizable.LocalizableDescAtt("_D214"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuCollapsiblePanelPosition)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PanelPosition() As EnuCollapsiblePanelPosition
            Get
                Return _PanelPosition
            End Get
            Set(ByVal value As EnuCollapsiblePanelPosition)

                _PanelPosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N215"), _
        Ressource.localizable.LocalizableDescAtt("_D215"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public Property IsOpen() As Boolean
            Get
                Return _IsOpen
            End Get
            Set(ByVal value As Boolean)
                _IsOpen = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N135"), _
        Ressource.localizable.LocalizableDescAtt("_D135"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
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
        Ressource.localizable.LocalizableNameAtt("_N133"), _
        Ressource.localizable.LocalizableDescAtt("_D133"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public Property EventType() As EnuEventType
            Get
                Return _EventType
            End Get
            Set(ByVal value As EnuEventType)
                _EventType = value
            End Set
        End Property

       
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N127"), _
        Ressource.localizable.LocalizableDescAtt("_D127"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PositionMode() As StylesManager.CssItems.CssEnum.PositionMode
            Get
                Return _PositionMode
            End Get
            Set(ByVal value As StylesManager.CssItems.CssEnum.PositionMode)
                _PositionMode = value
                MyBase.Templates.SetTemplate("Content", value)
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N235"), _
        Ressource.localizable.LocalizableDescAtt("_D235"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.Enum.TConvEnumEasingEffect)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property EasingOpen() As DataType.Enum.EnumEasingEffect
            Get
                Return _EasingOpen
            End Get
            Set(ByVal value As DataType.Enum.EnumEasingEffect)
                _EasingOpen = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingOpenJs() As String
            Get
                Return _EasingOpen.ToString
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N236"), _
        Ressource.localizable.LocalizableDescAtt("_D236"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.Enum.TConvEnumEasingEffect)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property EasingClose() As DataType.Enum.EnumEasingEffect
            Get
                Return _EasingClose
            End Get
            Set(ByVal value As DataType.Enum.EnumEasingEffect)
                _EasingClose = value
            End Set
        End Property
 
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingCloseJs() As String
            Get
                Return _EasingClose.ToString
            End Get
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECollapsiblePanel", Page, ParentID, TemplateName)
            MyBase.TypeResize = EnuTypeResize.Both
            Me._PanelPosition = EnuCollapsiblePanelPosition.Top
            IsOpen = False
            Delay = 500
            PositionMode = CssEnum.PositionMode.absolute
            EasingOpen = DataType.Enum.EnumEasingEffect.none
            EasingClose = DataType.Enum.EnumEasingEffect.none
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0369
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WECollapsiblePanel
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0373
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.Templates.SetTemplate("OpenZone", StylesManager.CssItems.CssEnum.PositionMode.absolute)

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("OpenZoneTop", My.Resources.text.LocalizableOpen._0368, My.Resources.text.LocalizableOpen._0370))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneCloseTop", My.Resources.text.LocalizableOpen._0371, My.Resources.text.LocalizableOpen._0371))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneOpenTop", My.Resources.text.LocalizableOpen._0372, My.Resources.text.LocalizableOpen._0372))

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("OpenZoneBottom", My.Resources.text.LocalizableOpen._0374, My.Resources.text.LocalizableOpen._0370))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneCloseBottom", My.Resources.text.LocalizableOpen._0375, My.Resources.text.LocalizableOpen._0371))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneOpenBottom", My.Resources.text.LocalizableOpen._0376, My.Resources.text.LocalizableOpen._0372))

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("OpenZoneLeft", My.Resources.text.LocalizableOpen._0377, My.Resources.text.LocalizableOpen._0370))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneCloseLeft", My.Resources.text.LocalizableOpen._0378, My.Resources.text.LocalizableOpen._0371))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneOpenLeft", My.Resources.text.LocalizableOpen._0379, My.Resources.text.LocalizableOpen._0372))

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("OpenZoneRight", My.Resources.text.LocalizableOpen._0380, My.Resources.text.LocalizableOpen._0370))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneCloseRight", My.Resources.text.LocalizableOpen._0381, My.Resources.text.LocalizableOpen._0371))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PullZoneOpenRight", My.Resources.text.LocalizableOpen._0382, My.Resources.text.LocalizableOpen._0372))

            MyBase.OnOpen(ConfigStylesZones)
        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECollapsiblePanel.js", "WEFiles/Client/WECollapsiblePanel.js")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "overflow:hidden; height:100%;")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECollapsiblePanelContent")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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


        Protected Sub PullRender(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "position:relative")
            If IsOpen Then
                writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("PullZoneOpen", Me.PanelPosition.ToString)), " PullZone PullZoneClose"))
            Else
                writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("PullZoneClose", Me.PanelPosition.ToString)), " PullZone PullZoneClose"))
            End If

            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")

        End Sub

        Protected Sub ContentRender(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "position:relative;")
            writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(String.Concat("OpenZone", Me.PanelPosition.ToString)), " OpenZone"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetTemplateClass("OpenZone"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            MyBase.RenderTemplate(writer, "OpenZone")

            'writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")

        End Sub
#End Region

    End Class

End Namespace