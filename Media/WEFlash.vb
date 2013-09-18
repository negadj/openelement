Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.IO
Imports System.Web
Imports System.Web.UI

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Common.Attributes.EditListOf
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Media.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Media

    <Serializable> _
    Public Class WEFlash
        Inherits ElementBase

        #Region "Fields"

        Private _Align As EnuFlashAlign
        Private _Base As String
        Private _Bgcolor As Color
        Private _FlashPath As Link
        Private _Loop As Boolean
        Private _Menu As Boolean
        Private _Param As List(Of FlashParam)
        Private _Play As Boolean
        Private _Quality As EnuFlashQuality
        Private _Salign As EnuFlashSalign
        Private _Scale As EnuFlashScale
        Private _Wmode As EnuFlashWmode

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEFlash", page, parentID, templateName)
            'default config
            _Play = True
            _Loop = True
            _menu = True
            Wmode = EnuFlashWmode.transparent
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        Public Enum EnuFlashAlign As Short
            None = 0 'none by default (no render)
            L = 1 'left
            R = 2 'right
            T = 3 'top
        End Enum

        Public Enum EnuFlashQuality As Short
            Best = 0
            High = 1
            Medium = 2
            Low = 3

            Autohigh = 4
            Autolow = 5
        End Enum

        Public Enum EnuFlashSalign As Short
            None = 0
            L = 1
            R = 2
            T = 3
            Tl = 4
            Tr = 5
        End Enum

        Public Enum EnuFlashScale As Short
            Showall = 0
            Noborder = 1
            Exactfit = 2
        End Enum

        Public Enum EnuFlashWmode As Short
            Window = 0
            Opaque = 1
            Transparent = 2
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N038"), _
        LocalizableDescAtt("_D038"), _
        TypeConverter(GetType(TConvEnuFlashAlign)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Align() As EnuFlashAlign
            Get
                Return _Align
            End Get
            Set(ByVal value As EnuFlashAlign)
                _Align = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N096"), _
        LocalizableDescAtt("_D097"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Base() As String
            Get
                Return _Base
            End Get
            Set(ByVal value As String)
                _Base = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N028"), _
        LocalizableDescAtt("_D041"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Bgcolor() As Color
            Get
                Return _Bgcolor
            End Get
            Set(ByVal value As Color)
                _Bgcolor = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N026"), _
        LocalizableDescAtt("_D035"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property FlashLoop() As Boolean
            Get
                Return _Loop
            End Get
            Set(ByVal value As Boolean)
                _Loop = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N023"), _
        LocalizableDescAtt("_D033"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None), _
        ConfigBiblio(False, True, False, False, False)> _
        Public Property FlashPath() As Link
            Get
                If _FlashPath Is Nothing Then _FlashPath = New Link()
                Return _FlashPath
            End Get
            Set(ByVal value As Link)
                _FlashPath = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N036"), _
        LocalizableDescAtt("_D036"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Menu() As Boolean
            Get
                Return _menu
            End Get
            Set(ByVal value As Boolean)
                _menu = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        Ressource.localizable.LocalizableNameAtt("_N194"), _
        LocalizableDescAtt("_D194"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Param() As List(Of FlashParam)
            Get
                If _Param Is Nothing Then
                    _Param = New List(Of FlashParam)
                    _Param.Add(New FlashParam(LocalizableOpen._0308, New LocalizableString(LocalizableOpen._0309))) '"Parametre_1" "Valeur"

                End If

                Return _Param
            End Get
            Set(ByVal value As List(Of FlashParam))
                _Param = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N024"), _
        LocalizableDescAtt("_D034"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Play() As Boolean
            Get
                Return _Play
            End Get
            Set(ByVal value As Boolean)
                _Play = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N037"), _
        LocalizableDescAtt("_D037"), _
        TypeConverter(GetType(TConvEnuFlashQuality)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Quality() As EnuFlashQuality
            Get
                Return _Quality
            End Get
            Set(ByVal value As EnuFlashQuality)
                _Quality = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N039"), _
        LocalizableDescAtt("_D039"), _
        TypeConverter(GetType(TConvEnuFlashSalign)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Salign() As EnuFlashSalign
            Get
                Return _Salign
            End Get
            Set(ByVal value As EnuFlashSalign)
                _Salign = value
            End Set
        End Property

        ''' <summary>
        ''' Method of flash's fit in the windows
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N042"), _
        LocalizableDescAtt("_D042"), _
        TypeConverter(GetType(TConvEnuFlashScale)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Scale() As EnuFlashScale
            Get
                Return _scale
            End Get
            Set(ByVal value As EnuFlashScale)
                _scale = value
            End Set
        End Property

        ''' <summary>
        ''' behavior
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N040"), _
        LocalizableDescAtt("_D040"), _
        TypeConverter(GetType(TConvEnuFlashWmode)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Wmode() As EnuFlashWmode
            Get
                Return _Wmode
            End Get
            Set(ByVal value As EnuFlashWmode)
                _Wmode = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newList As New List(Of Object)
            If addButton.Name = "AddParam" Then
                newList.Add(New FlashParam)
            End If
            Return newList
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("AddParam", LocalizableFormAndConverter._0151, Nothing))
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0152, LocalizableFormAndConverter._0153, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0068
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEFlash
            info.ToolBoxDescription = LocalizableOpen._0069
            info.AutoOpenProperty = "FlashPath"
            info.SortPropertyList.Add(New SortProperty("FlashPath", "flash.png", LocalizableOpen._0070))
            Return info
        End Function

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "BaseDiv"
                    configStylesZones.UIDisabledRibbon.Add(StylesZone.EnuDisabledRibbonType.GroupText)
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Dim valFlashPath As String = MyBase.GetLink(Me.FlashPath)

            If Not String.IsNullOrEmpty(valFlashPath) And Not MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then

                Dim strParam As String = String.Empty
                For Each item As FlashParam In Param
                    If Not String.IsNullOrEmpty(strParam) Then strParam = String.Concat(strParam, "&")
                    strParam = String.Concat(strParam, item.Name, "=", HttpUtility.UrlEncode(item.Val.GetValue(Me.Page.Culture)))
                Next
                writer.WriteBeginTag("object")
                writer.WriteAttribute("classid", "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000")
                writer.WriteAttribute("codebase", "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0")
                writer.WriteAttribute("width", "100%")
                writer.WriteAttribute("height", "100%")
                If Not Me.FlashLoop Then writer.WriteAttribute("loop", "false") 'true is the default value, we don't write this
                If Not Me.Play Then writer.WriteAttribute("play", "false")
                If Not Me.Menu Then writer.WriteAttribute("menu", "false")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "movie")
                writer.WriteAttribute("value", valFlashPath)
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "quality")
                writer.WriteAttribute("value", Me.Quality.ToString)
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "bgcolor")
                writer.WriteAttribute("value", ColorTranslator.ToHtml(Me.Bgcolor))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                If Me.Align <> EnuFlashAlign.none Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "align")
                    writer.WriteAttribute("value", Me.Align.ToString)
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Me.Salign <> EnuFlashSalign.none Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "salign")
                    writer.WriteAttribute("value", Me.Salign.ToString)
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "wmode")
                writer.WriteAttribute("value", Me.Wmode.ToString)
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                If Me.Scale <> EnuFlashScale.showall Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "scale")
                    writer.WriteAttribute("value", Me.Scale.ToString)
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Not String.Equals(Me.Base, String.Empty) Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "base")
                    writer.WriteAttribute("value", Me.Base)
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Not String.IsNullOrEmpty(strParam) Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "flashvars")
                    writer.WriteAttribute("value", strParam)
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                writer.WriteBeginTag("embed")
                writer.WriteAttribute("src", valFlashPath)
                writer.WriteAttribute("quality", Me.Quality.ToString)
                writer.WriteAttribute("pluginspage", "http://www.macromedia.com/go/getflashplayer")
                writer.WriteAttribute("type", "application/x-shockwave-flash")
                writer.WriteAttribute("width", "100%")
                writer.WriteAttribute("height", "100%")

                If Not String.IsNullOrEmpty(strParam) Then writer.WriteAttribute("flashvars", strParam)
                If Not Me.FlashLoop Then writer.WriteAttribute("loop", "false") 'true is the default value, we don't write this
                If Not Me.Play Then writer.WriteAttribute("play", "false")
                If Not Me.Menu Then writer.WriteAttribute("menu", "false")
                writer.WriteAttribute("bgcolor", ColorTranslator.ToHtml(Me.Bgcolor))
                If Me.Align <> EnuFlashAlign.none Then writer.WriteAttribute("align", Me.Align.ToString)
                If Me.Salign <> EnuFlashSalign.none Then writer.WriteAttribute("salign", Me.Salign.ToString)
                writer.WriteAttribute("wmode", Me.Wmode.ToString)
                If Me.Scale <> EnuFlashScale.showall Then writer.WriteAttribute("scale", Me.Scale.ToString)
                If Not String.Equals(Me.Base, String.Empty) Then writer.WriteAttribute("base", Me.Base)

                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("embed")

                writer.WriteEndTag("object")

            Else

                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Path.Combine(Utils.EditorModCSSPath, "images/Plugin.png"))
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            End If

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

        #Region "Nested Types"

        ''' <summary>
        ''' flash config class
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable> _
        Public Class FlashParam

            #Region "Fields"

            Private _Name As String
            Private _Val As LocalizableString

            #End Region 'Fields

            #Region "Constructors"

            Public Sub New()
            End Sub

            Public Sub New(ByVal name As String, ByVal val As LocalizableString)
                _Name = name
                _Val = val
            End Sub

            #End Region 'Constructors

            #Region "Properties"

            <Common.LocalizableCatAtt("_Att12"), _
            Ressource.localizable.LocalizableNameAtt("_N195"), _
            LocalizableDescAtt("_D195"), _
            ShowColumn> _
            Public Property Name() As String
                Get
                    Return _Name
                End Get
                Set(ByVal value As String)
                    value = Replace(value, " ", "_")
                    _Name = value
                End Set
            End Property

            <Common.LocalizableCatAtt("_Att12"), _
            Ressource.localizable.LocalizableNameAtt("_N196"), _
            LocalizableDescAtt("_D196"), _
            TypeConverter(GetType(TConvLocalizableString)), _
            ShowColumn> _
            Public Property Val() As LocalizableString
                Get
                    If _Val Is Nothing Then _Val = New LocalizableString
                    Return _Val
                End Get
                Set(ByVal value As LocalizableString)
                    _Val = value
                End Set
            End Property

            #End Region 'Properties

        End Class

        #End Region 'Nested Types

    End Class

End Namespace

