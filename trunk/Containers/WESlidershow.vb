Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.Editors.Control.CtlEditListOf

Namespace Elements.Containers

    <Serializable(), openElement.WebElement.Common.Attributes.OEObsolete(1, 32)> _
    Public Class WESlideshow
        Inherits ElementBase

#Region "Private variable"

        ''' <summary>
        ''' List of slide (see comments in this class)
        ''' </summary>
        ''' <remarks></remarks>
        Private _ListSlide As List(Of WESlide)
        ''' <summary>
        ''' Element's id for the prev button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _PrevElement As DataType.SelectIDElement
        ''' <summary>
        ''' Element's id for the next button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _NextElement As DataType.SelectIDElement
        ''' <summary>
        ''' Element's id for the play button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Play As DataType.SelectIDElement
        ''' <summary>
        ''' Element's id for the stop button (one or several elements)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Stop As DataType.SelectIDElement
        ''' <summary>
        ''' slide effect direction
        ''' </summary>
        ''' <remarks></remarks>
        Private _Direction As DataType.Enum.EnumDirection
        ''' <summary>
        ''' slide speed
        ''' </summary>
        ''' <remarks></remarks>
        Private _Speed As Integer
        ''' <summary>
        ''' endless loop effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Infini As Boolean
        ''' <summary>
        ''' auto start at the loading page
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoStart As Boolean
        ''' <summary>
        ''' auto stop at the mouse hover event
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoHover As Boolean
        ''' <summary>
        ''' delay to auto start (only if autoStart is true)
        ''' </summary>
        ''' <remarks></remarks>
        Private _AutoDelay As Integer
        ''' <summary>
        ''' visual effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As DataType.Enum.EnumEasingEffect
        <NonSerialized()> _
        Private _EasingJS As String
        ''' <summary>
        ''' margin inter slide panel
        ''' </summary>
        ''' <remarks></remarks>
        Private _SlideMargin As Integer
        ''' <summary>
        ''' Display mode
        ''' </summary>
        ''' <remarks></remarks>
        Private _PagePosition As StylesManager.CssItems.CssEnum.PositionMode

#End Region

#Region "Properties"
      
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
       Ressource.localizable.LocalizableNameAtt("_N218"), _
       Ressource.localizable.LocalizableDescAtt("_D218"), _
       Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        Ressource.localizable.LocalizableNameAtt("_N224"), _
        Ressource.localizable.LocalizableDescAtt("_D224"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ConfigSelectIDElement("WEImage,WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PrevElement() As DataType.SelectIDElement
            Get
                Return _PrevElement
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _PrevElement = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N225"), _
        Ressource.localizable.LocalizableDescAtt("_D225"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property NextElement() As DataType.SelectIDElement
            Get
                Return _NextElement
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _NextElement = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N229"), _
        Ressource.localizable.LocalizableDescAtt("_D229"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Play() As DataType.SelectIDElement
            Get
                Return _Play
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _Play = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N230"), _
        Ressource.localizable.LocalizableDescAtt("_D230"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ConfigSelectIDElement("WEImage, WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property BtnStop() As DataType.SelectIDElement
            Get
                Return _Stop
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _Stop = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N221"), _
        Ressource.localizable.LocalizableDescAtt("_D221"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Direction() As DataType.Enum.EnumDirection
            Get
                Return _Direction
            End Get
            Set(ByVal value As DataType.Enum.EnumDirection)
                _Direction = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N222"), _
        Ressource.localizable.LocalizableDescAtt("_D222"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Speed() As Integer
            Get
                Return _Speed
            End Get
            Set(ByVal value As Integer)
                If value <= 0 Then value = 500
                _Speed = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N231"), _
        Ressource.localizable.LocalizableDescAtt("_D231"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Infini() As Boolean
            Get
                Return _Infini
            End Get
            Set(ByVal value As Boolean)
                _Infini = value
            End Set
        End Property

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
    
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
       Ressource.localizable.LocalizableNameAtt("_N233"), _
       Ressource.localizable.LocalizableDescAtt("_D233"), _
       TypeConverter(GetType(openElement.WebElement.StylesManager.CssItems.Converter.TConvCssUnit)), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
       Public Property SlideMargin() As Integer
            Get
                Return _SlideMargin
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                _SlideMargin = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N226"), _
        Ressource.localizable.LocalizableDescAtt("_D226"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoStart() As Boolean
            Get
                Return _AutoStart
            End Get
            Set(ByVal value As Boolean)
                _AutoStart = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N227"), _
        Ressource.localizable.LocalizableDescAtt("_D227"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoHover() As Boolean
            Get
                Return _AutoHover
            End Get
            Set(ByVal value As Boolean)
                _AutoHover = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Automatique), _
        Ressource.localizable.LocalizableNameAtt("_N228"), _
        Ressource.localizable.LocalizableDescAtt("_D228"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property AutoDelay() As Integer
            Get
                Return _AutoDelay
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                _AutoDelay = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N234"), _
        Ressource.localizable.LocalizableDescAtt("_D234"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property PagePosition() As StylesManager.CssItems.CssEnum.PositionMode
            Get
                Return _PagePosition
            End Get
            Set(ByVal value As StylesManager.CssItems.CssEnum.PositionMode)
                _PagePosition = value
                For Each Slide In Me.ListSlide
                    MyBase.Templates.SetTemplate(Slide.ID, value)
                Next
                For Each element As ElementBase In MyBase.Templates.Elements
                    element.PositionType = value
                Next

            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
            MyBase.New(EnuElementType.PageEdit, "WESlideshow", Page, ParentID, TemplateName)
            MyBase.TypeResize = EnuTypeResize.Both

            'default values
            Me.PositionType = StylesManager.CssItems.CssEnum.PositionMode.absolute
            Me.ListSlide.Add(NewSlider())
            Me.ListSlide.Add(NewSlider())

            Speed = 500
            SlideMargin = 5
            Easing = DataType.Enum.EnumEasingEffect.none

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0384
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupContainers"
            info.ToolBoxIco = My.Resources.WESlideshow
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0385
            info.SortPropertyList.Add(New SortProperty("ListSlide", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen(CreateConfigStylesZones())
        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryEasing)
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\JQuery\jquery.bxSlider.min.js", "WEFiles/Client/jquery.bxSlider.min.js")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WESlideshow.js", "WEFiles/Client/WESlideshow.js")
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WESlideshow.css", "WEFiles/Css/WESlideshow.css")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("PrevControl"))
            writer.WriteAttribute("style", "position:absolute; z-index: 2")

            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")


            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "Slideshow")
            writer.WriteAttribute("style", "width:100%; height:100%;position:alsolute;")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.Indent += 1
            For Each Slide As WESlide In Me.ListSlide

                writer.WriteBeginTag("div")
                Dim ZoneClassName As String = CreateSlideStyleName(Slide.ID)
                writer.WriteAttribute("class", String.Concat(MyBase.GetTemplateClass(Slide.ID), " ", MyBase.GetStyleZoneClass(ZoneClassName)))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                MyBase.RenderTemplate(writer, Slide.ID)
                writer.WriteEndTag("div")

                writer.WriteLine()

            Next
            writer.Indent -= 1
            writer.WriteEndTag("div")

            writer.WriteLine()
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("NextControl"))
            writer.WriteAttribute("style", "position:absolute; z-index: 2")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub
#End Region

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(NewSlider())
            Return newObs
        End Function

        ''' <summary>
        ''' create variable style zones on beforeRender event
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            MyBase.UpdateConfigStylesZones(CreateConfigStylesZones())
            MyBase.OnPageBeforeRender(mode)
        End Sub


        ''' <summary>
        ''' create static and dynamic style zones
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateConfigStylesZones() As List(Of StylesManager.ConfigStylesZone)

            Dim ConfigStylesZones = New List(Of StylesManager.ConfigStylesZone)

            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("PrevControl", My.Resources.text.LocalizableOpen._0131, My.Resources.text.LocalizableOpen._0387))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("NextControl", My.Resources.text.LocalizableOpen._0133, My.Resources.text.LocalizableOpen._0388))

            'Add one style zone per panel
            For Each Slide In Me.ListSlide
                Dim ConfigSZ = New StylesManager.ConfigStylesZone(CreateSlideStyleName(Slide.ID), Slide.Name, Slide.Name)
                ConfigSZ.NoSaveInModel = True
                ConfigStylesZones.Add(ConfigSZ)
            Next
            Return ConfigStylesZones
        End Function

        ''' <summary>
        ''' Add a new slide panel function
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function NewSlider() As WESlide
            Dim Name As String = String.Concat(My.Resources.text.LocalizableOpen._0386, " ", ListSlide.Count)
            Dim Slide As New WESlide(Name)
            'template create
            MyBase.Templates.SetTemplate(Slide.ID, Me.PositionType)
            Return Slide
        End Function

        ''' <summary>
        ''' Check the slide panel name (must be unique)
        ''' </summary>
        ''' <param name="List"></param>
        ''' <param name="templateName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TemplateNameExiste(ByVal List As List(Of WESlide), ByVal templateName As String) As Boolean
            For Each Slide As WESlide In List
                If Slide.Name.Equals(templateName) Then Return True
            Next
        End Function

        Private Sub UpdateTemplates(ByVal oldList As List(Of WESlide), ByVal newList As List(Of WESlide))
            For Each OldSlide As WESlide In oldList
                If Not TemplateNameExiste(newList, OldSlide.Name) Then
                    MyBase.Templates.Templates.Remove(OldSlide.Name)
                End If
            Next
        End Sub

        ''' <summary>
        ''' create the style zone for a new slide panel
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateSlideStyleName(ByVal ID As String)
            Return String.Concat("Slide_", ID)
        End Function

    End Class


    ''' <summary>
    ''' WESlider panel specify class
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WESlide

        ''' <summary>
        ''' slide nale (title)
        ''' </summary>
        ''' <remarks></remarks>
        Private _Name As String
        ''' <summary>
        ''' unique id
        ''' </summary>
        ''' <remarks></remarks>
        Private _ID As String
   
        Private _AccessElement As DataType.SelectIDElement

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
       Ressource.localizable.LocalizableNameAtt("_N103"), _
       Ressource.localizable.LocalizableDescAtt("_D103"), _
       Common.Attributes.EditListOf.ShowColumn()> _
       Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N223"), _
        Ressource.localizable.LocalizableDescAtt("_D223"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeSelectIDElement), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ConfigSelectIDElement("WEImage,WELinkButton,WELink,WELinkButton,WELinkImage,WEText,WELabel", Common.Attributes.ConfigSelectIDElement.TypeFilterAuthorized.allowed, True), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvElementID)), _
        Common.Attributes.EditListOf.ShowColumn()> _
        Public Property AccessElement() As DataType.SelectIDElement
            Get
                Return _AccessElement
            End Get
            Set(ByVal value As DataType.SelectIDElement)
                _AccessElement = value
            End Set
        End Property

        Public ReadOnly Property ID() As String
            Get
                If String.IsNullOrEmpty(_ID) Then _ID = System.Guid.NewGuid.ToString().Substring(0, 8)
                Return _ID
            End Get

        End Property

        Public Sub New(ByVal name As String)
            Me._Name = name
        End Sub


    End Class

End Namespace