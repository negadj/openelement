Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel

Imports System.Drawing
Imports openElement.WebElement.DataType
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement.WebElement.StylesManager


Namespace Elements.Media

    <Serializable()> _
    Public Class WEFlash
        Inherits ElementBase

        Public Enum EnuFlashQuality As Short

            best = 0
            high = 1
            medium = 2
            low = 3

            autohigh = 4
            autolow = 5
        End Enum

        Public Enum EnuFlashAlign As Short
            none = 0 'none by default (no render)
            l = 1 'left
            r = 2 'right
            t = 3 'top
        End Enum

        Public Enum EnuFlashWmode As Short
            window = 0
            opaque = 1
            transparent = 2
        End Enum

        Public Enum EnuFlashSalign As Short
            none = 0
            l = 1
            r = 2
            t = 3
            tl = 4
            tr = 5
        End Enum

        Public Enum EnuFlashScale As Short
            showall = 0
            noborder = 1
            exactfit = 2
        End Enum

#Region "Private variable"

        Private _FlashPath As LinksManager.Link
        Private _Play As Boolean '
        Private _Loop As Boolean '
        Private _menu As Boolean '
        Private _Quality As EnuFlashQuality
        Private _Align As EnuFlashAlign
        Private _Salign As EnuFlashSalign
        Private _Wmode As EnuFlashWmode
        Private _scale As EnuFlashScale
        Private _Bgcolor As Drawing.Color
        Private _Base As String
        Private _Param As List(Of FlashParam)


#End Region

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N023"), _
        Ressource.localizable.LocalizableDescAtt("_D033"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None), _
        Common.Attributes.ConfigBiblio(False, True, False, False, False)> _
               Public Property FlashPath() As LinksManager.Link
            Get
                If _FlashPath Is Nothing Then _FlashPath = New LinksManager.Link()
                Return _FlashPath
            End Get
            Set(ByVal value As LinksManager.Link)
                _FlashPath = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N024"), _
        Ressource.localizable.LocalizableDescAtt("_D034"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Play() As Boolean
            Get
                Return _Play
            End Get
            Set(ByVal value As Boolean)
                _Play = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N026"), _
        Ressource.localizable.LocalizableDescAtt("_D035"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property FlashLoop() As Boolean
            Get
                Return _Loop
            End Get
            Set(ByVal value As Boolean)
                _Loop = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N036"), _
        Ressource.localizable.LocalizableDescAtt("_D036"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Menu() As Boolean
            Get
                Return _menu
            End Get
            Set(ByVal value As Boolean)
                _menu = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N037"), _
        Ressource.localizable.LocalizableDescAtt("_D037"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuFlashQuality)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Quality() As EnuFlashQuality
            Get
                Return _Quality
            End Get
            Set(ByVal value As EnuFlashQuality)
                _Quality = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N038"), _
        Ressource.localizable.LocalizableDescAtt("_D038"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuFlashAlign)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Align() As EnuFlashAlign
            Get
                Return _Align
            End Get
            Set(ByVal value As EnuFlashAlign)
                _Align = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N039"), _
        Ressource.localizable.LocalizableDescAtt("_D039"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuFlashSalign)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Salign() As EnuFlashSalign
            Get
                Return _Salign
            End Get
            Set(ByVal value As EnuFlashSalign)
                _Salign = value
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
        Ressource.localizable.LocalizableDescAtt("_D040"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuFlashWmode)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Wmode() As EnuFlashWmode
            Get
                Return _Wmode
            End Get
            Set(ByVal value As EnuFlashWmode)
                _Wmode = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N028"), _
        Ressource.localizable.LocalizableDescAtt("_D041"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Bgcolor() As Drawing.Color
            Get
                Return _Bgcolor
            End Get
            Set(ByVal value As Drawing.Color)
                _Bgcolor = value
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
        Ressource.localizable.LocalizableDescAtt("_D042"), _
        TypeConverter(GetType(Editors.Converter.TConvEnuFlashScale)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Scale() As EnuFlashScale
            Get
                Return _scale
            End Get
            Set(ByVal value As EnuFlashScale)
                _scale = value
            End Set
        End Property
      
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N096"), _
        Ressource.localizable.LocalizableDescAtt("_D097"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Base() As String
            Get
                Return _Base
            End Get
            Set(ByVal value As String)
                _Base = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
       Ressource.localizable.LocalizableNameAtt("_N194"), _
       Ressource.localizable.LocalizableDescAtt("_D194"), _
       Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property Param() As List(Of FlashParam)
            Get
                If _Param Is Nothing Then
                    _Param = New List(Of FlashParam)
                    _Param.Add(New FlashParam(My.Resources.text.LocalizableOpen._0308, New LocalizableString(My.Resources.text.LocalizableOpen._0309))) '"Parametre_1" "Valeur"

                End If

                Return _Param
            End Get
            Set(ByVal value As List(Of FlashParam))
                _Param = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEFlash", page, parentID, templateName)
            'default config
            _Play = True
            _Loop = True
            _menu = True
            Wmode = EnuFlashWmode.transparent
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0068
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEFlash
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0069
            info.AutoOpenProperty = "FlashPath"
            info.SortPropertyList.Add(New SortProperty("FlashPath", "flash.png", My.Resources.text.LocalizableOpen._0070))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen()

        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "BaseDiv"
                    configStylesZones.UIDisabledRibbon.Add(StylesZone.EnuDisabledRibbonType.GroupText)
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of AddButton)
            addButtonList.Add(New AddButton("AddParam", My.Resources.text.LocalizableFormAndConverter._0151, Nothing))
            Dim editConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0152, My.Resources.text.LocalizableFormAndConverter._0153, addButtonList)
            Return editConfig
        End Function


        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim newList As New List(Of Object)
            If addButton.Name = "AddParam" Then
                newList.Add(New FlashParam)
            End If
            Return newList

        End Function

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            Dim valFlashPath As String = MyBase.GetLink(Me.FlashPath)

            If Not String.IsNullOrEmpty(valFlashPath) And Not MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then

                Dim strParam As String = String.Empty
                For Each item As FlashParam In Param
                    If Not String.IsNullOrEmpty(strParam) Then strParam = String.Concat(strParam, "&")
                    strParam = String.Concat(strParam, item.Name, "=", Web.HttpUtility.UrlEncode(item.Val.GetValue(Me.Page.Culture)))
                Next
                writer.WriteBeginTag("object")
                writer.WriteAttribute("classid", "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000")
                writer.WriteAttribute("codebase", "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0")
                writer.WriteAttribute("width", "100%")
                writer.WriteAttribute("height", "100%")
                If Not Me.FlashLoop Then writer.WriteAttribute("loop", "false") 'true is the default value, we don't write this  
                If Not Me.Play Then writer.WriteAttribute("play", "false")
                If Not Me.Menu Then writer.WriteAttribute("menu", "false")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "movie")
                writer.WriteAttribute("value", valFlashPath)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "quality")
                writer.WriteAttribute("value", Me.Quality.ToString)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "bgcolor")
                writer.WriteAttribute("value", ColorTranslator.ToHtml(Me.Bgcolor))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                If Me.Align <> EnuFlashAlign.none Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "align")
                    writer.WriteAttribute("value", Me.Align.ToString)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Me.Salign <> EnuFlashSalign.none Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "salign")
                    writer.WriteAttribute("value", Me.Salign.ToString)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "wmode")
                writer.WriteAttribute("value", Me.Wmode.ToString)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                If Me.Scale <> EnuFlashScale.showall Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "scale")
                    writer.WriteAttribute("value", Me.Scale.ToString)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Not String.Equals(Me.Base, String.Empty) Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "base")
                    writer.WriteAttribute("value", Me.Base)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                End If

                If Not String.IsNullOrEmpty(strParam) Then
                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "flashvars")
                    writer.WriteAttribute("value", strParam)
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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

                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteEndTag("embed")

                writer.WriteEndTag("object")

            Else

                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", IO.Path.Combine(Utils.EditorModCSSPath, "images/Plugin.png"))
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            End If

            MyBase.RenderEndTag(writer)

        End Sub

#End Region

        ''' <summary>
        ''' flash config class
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable()> _
        Public Class FlashParam
            Private _Name As String
            Private _Val As LocalizableString

            <Common.LocalizableCatAtt("_Att12"), _
            Ressource.localizable.LocalizableNameAtt("_N195"), _
            Ressource.localizable.LocalizableDescAtt("_D195"), _
            Common.Attributes.EditListOf.ShowColumn()> _
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
            Ressource.localizable.LocalizableDescAtt("_D196"), _
            TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
            Common.Attributes.EditListOf.ShowColumn()> _
            Public Property Val() As LocalizableString
                Get
                    If _Val Is Nothing Then _Val = New LocalizableString
                    Return _Val
                End Get
                Set(ByVal value As LocalizableString)
                    _Val = value
                End Set
            End Property

            Public Sub New()

            End Sub

            Public Sub New(ByVal name As String, ByVal val As LocalizableString)
                _Name = name
                _Val = val
            End Sub

        End Class

    End Class

End Namespace
