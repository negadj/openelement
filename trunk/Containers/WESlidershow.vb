Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Common.Attributes.EditListOf
Imports openElement.WebElement.DataType.Enum
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Editors.Converter.Enum
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems
Imports openElement.WebElement.StylesManager.CssItems.Converter

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Containers

    ''' <summary>
    ''' WESlider panel specify class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WESlide

        #Region "Fields"

        Private _AccessElement As SelectIDElement

        ''' <summary>
        ''' unique id
        ''' </summary>
        ''' <remarks></remarks>
        Private _ID As String

        ''' <summary>
        ''' slide nale (title)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Name As String

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal name As String)
            Me._Name = name
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N223"), _
        LocalizableDescAtt("_D223"), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        Attributes.ConfigSelectIDElement("WEImage,WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        ShowColumn> _
        Public Property AccessElement() As SelectIDElement
            Get
                Return _AccessElement
            End Get
            Set(ByVal value As SelectIDElement)
                _AccessElement = value
            End Set
        End Property

        Public ReadOnly Property ID() As String
            Get
                If String.IsNullOrEmpty(_ID) Then _ID = Guid.NewGuid.ToString().Substring(0, 8)
                Return _ID
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N103"), _
        LocalizableDescAtt("_D103"), _
        ShowColumn> _
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        #End Region 'Properties

    End Class

    <Serializable, _
    OEObsolete(1, 32)> _
    Public Class WESlideshow
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' delay to auto start (only if autoStart is true)
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoDelay As Integer

        ''' <summary>
        ''' auto stop at the mouse hover event
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoHover As Boolean

        ''' <summary>
        ''' auto start at the loading page
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoStart As Boolean

        ''' <summary>
        ''' slide effect direction
        ''' </summary>
        ''' <remarks></remarks>
        Private _Direction As EnumDirection

        ''' <summary>
        ''' visual effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As EnumEasingEffect

        ''' <summary>
        ''' endless loop effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Infini As Boolean

        ''' <summary>
        ''' List of slide (see comments in this class)
        ''' </summary>
        ''' <remarks></remarks>
        Private _ListSlide As List(Of WESlide)

        ''' <summary>
        ''' Element's id for the next button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _NextElement As SelectIDElement

        ''' <summary>
        ''' Display mode
        ''' </summary>
        ''' <remarks></remarks>
        Private _PagePosition As CssEnum.PositionMode

        ''' <summary>
        ''' Element's id for the play button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Play As SelectIDElement

        ''' <summary>
        ''' Element's id for the prev button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _PrevElement As SelectIDElement

        ''' <summary>
        ''' margin inter slide panel
        ''' </summary>
        ''' <remarks></remarks>
        Private _SlideMargin As Integer

        ''' <summary>
        ''' slide speed
        ''' </summary>
        ''' <remarks></remarks>
        Private _Speed As Integer

        ''' <summary>
        ''' Element's id for the stop button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Stop As SelectIDElement

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WESlideshow", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both

            'default values
            Me.PositionType = CssEnum.PositionMode.absolute
            Me.ListSlide.Add(NewSlider())
            Me.ListSlide.Add(NewSlider())

            Speed = 500
            SlideMargin = 5
            Easing = EnumEasingEffect.none
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N228"), _
        LocalizableDescAtt("_D228"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoDelay() As Integer
            Get
                Return _AutoDelay
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                _AutoDelay = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N227"), _
        LocalizableDescAtt("_D227"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoHover() As Boolean
            Get
                Return _AutoHover
            End Get
            Set(ByVal value As Boolean)
                _AutoHover = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N226"), _
        LocalizableDescAtt("_D226"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoStart() As Boolean
            Get
                Return _AutoStart
            End Get
            Set(ByVal value As Boolean)
                _AutoStart = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N230"), _
        LocalizableDescAtt("_D230"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property BtnStop() As SelectIDElement
            Get
                Return _Stop
            End Get
            Set(ByVal value As SelectIDElement)
                _Stop = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N221"), _
        LocalizableDescAtt("_D221"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Direction() As EnumDirection
            Get
                Return _Direction
            End Get
            Set(ByVal value As EnumDirection)
                _Direction = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
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

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N231"), _
        LocalizableDescAtt("_D231"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Infini() As Boolean
            Get
                Return _Infini
            End Get
            Set(ByVal value As Boolean)
                _Infini = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N218"), _
        LocalizableDescAtt("_D218"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ListSlide() As List(Of WESlide)
            Get
                If _ListSlide Is Nothing Then _ListSlide = New List(Of WESlide)
                Return _ListSlide
            End Get
            Set(ByVal value As List(Of WESlide))
                Call UpdateTemplates(_ListSlide, value)
                _ListSlide = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N225"), _
        LocalizableDescAtt("_D225"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property NextElement() As SelectIDElement
            Get
                Return _NextElement
            End Get
            Set(ByVal value As SelectIDElement)
                _NextElement = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N234"), _
        LocalizableDescAtt("_D234"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PagePosition() As CssEnum.PositionMode
            Get
                Return _PagePosition
            End Get
            Set(ByVal value As CssEnum.PositionMode)
                _PagePosition = value
                For Each Slide In Me.ListSlide
                    MyBase.Templates.SetTemplate(Slide.ID, value)
                Next
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next

            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N229"), _
        LocalizableDescAtt("_D229"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Play() As SelectIDElement
            Get
                Return _Play
            End Get
            Set(ByVal value As SelectIDElement)
                _Play = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N224"), _
        LocalizableDescAtt("_D224"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        Editor(GetType(UITypeSelectIDElement), GetType(UITypeEditor)), _
        Attributes.ConfigSelectIDElement("WEImage,WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(TConvElementID)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PrevElement() As SelectIDElement
            Get
                Return _PrevElement
            End Get
            Set(ByVal value As SelectIDElement)
                _PrevElement = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N233"), _
        LocalizableDescAtt("_D233"), _
        TypeConverter(GetType(TConvCssUnit)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property SlideMargin() As Integer
            Get
                Return _SlideMargin
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                _SlideMargin = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N222"), _
        LocalizableDescAtt("_D222"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Speed() As Integer
            Get
                Return _Speed
            End Get
            Set(ByVal value As Integer)
                If value <= 0 Then value = 500
                _Speed = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ''' <summary>
        ''' Check the slide panel name (must be unique)
        ''' </summary>
        ''' <param name="list"></param>
        ''' <param name="templateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TemplateNameExiste(ByVal list As List(Of WESlide), ByVal templateName As String) As Boolean
            For Each slide As WESlide In list
                If slide.Name.Equals(templateName) Then Return True
            Next
            Return False
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(NewSlider())
            Return newObs
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0384
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WESlideshow
            info.ToolBoxDescription = LocalizableOpen._0385
            info.SortPropertyList.Add(New SortProperty("ListSlide", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\JQuery\jquery.bxSlider.min.js", "WEFiles/Client/jquery.bxSlider.min.js")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WESlideshow.js", "WEFiles/Client/WESlideshow.js")
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WESlideshow.css", "WEFiles/Css/WESlideshow.css")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen(CreateConfigStylesZones())
        End Sub

        ''' <summary>
        ''' create variable style zones on beforeRender event
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            MyBase.UpdateConfigStylesZones(CreateConfigStylesZones())
            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("PrevControl"))
            writer.WriteAttribute("style", "position:absolute; z-index: 2")

            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "Slideshow")
            writer.WriteAttribute("style", "width:100%; height:100%;position:alsolute;")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.Indent += 1
            For Each slide As WESlide In Me.ListSlide

                writer.WriteBeginTag("div")
                Dim zoneClassName As String = CreateSlideStyleName(slide.ID)
                writer.WriteAttribute("class", String.Concat(MyBase.GetTemplateClass(slide.ID), " ", MyBase.GetStyleZoneClass(zoneClassName)))
                writer.Write(HtmlTextWriter.TagRightChar)
                MyBase.RenderTemplate(writer, slide.ID)
                writer.WriteEndTag("div")

                writer.WriteLine()

            Next
            writer.Indent -= 1
            writer.WriteEndTag("div")

            writer.WriteLine()
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("NextControl"))
            writer.WriteAttribute("style", "position:absolute; z-index: 2")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' create static and dynamic style zones
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateConfigStylesZones() As List(Of ConfigStylesZone)
            Dim configStylesZones = New List(Of ConfigStylesZone)

            configStylesZones.Add(New ConfigStylesZone("PrevControl", LocalizableOpen._0131, LocalizableOpen._0387))
            configStylesZones.Add(New ConfigStylesZone("NextControl", LocalizableOpen._0133, LocalizableOpen._0388))

            'Add one style zone per panel
            For Each Slide In Me.ListSlide
                Dim configSz = New ConfigStylesZone(CreateSlideStyleName(Slide.ID), Slide.Name, Slide.Name)
                configSz.NoSaveInModel = True
                configStylesZones.Add(configSz)
            Next
            Return configStylesZones
        End Function

        ''' <summary>
        ''' create the style zone for a new slide panel
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateSlideStyleName(ByVal id As String)
            Return String.Concat("Slide_", id)
        End Function

        ''' <summary>
        ''' Add a new slide panel function
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NewSlider() As WESlide
            Dim name As String = String.Concat(LocalizableOpen._0386, " ", ListSlide.Count)
            Dim slide As New WESlide(name)
            'template create
            MyBase.Templates.SetTemplate(slide.ID, Me.PositionType)
            Return slide
        End Function

        Private Sub UpdateTemplates(ByVal oldList As List(Of WESlide), ByVal newList As List(Of WESlide))
            For Each oldSlide As WESlide In oldList
                If Not TemplateNameExiste(newList, oldSlide.Name) Then
                    MyBase.Templates.Templates.Remove(oldSlide.Name)
                End If
            Next
        End Sub

        #End Region 'Methods

    End Class

End Namespace

