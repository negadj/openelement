Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Text

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Form.Editors
Imports WebElement.Elements.Form.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable, _
    OEObsolete(1, 31)> _
    Public Class WETextArea
        Inherits ElementBase

        #Region "Fields"

        Private _ErrorImageLink As Link
        Private _LeftImageLink As Link
        Private _LeftImagePosition As CssEnum.VerticalAlign
        Private _TextAreaCols As Integer
        Private _TextAreaReadOnly As Boolean
        Private _TextAreaRows As Integer
        Private _TextAreaScrollOverFlow As TextAreaScrollOverFlow
        Private _TextAreaValue As LocalizableString
        Private _TextAreaWidth As CssUnit
        Private _Title As LocalizableHtml
        Private _TitlePosition As TextPosition
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETextArea", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N052"), _
        LocalizableDescAtt("_D052"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None), _
        ConfigBiblio(True, False, False, False, False)> _
        Public Property ErrorImageLink() As Link
            Get
                If _ErrorImageLink Is Nothing OrElse _ErrorImageLink.IsEmpty("DEFAULT") Then
                    _ErrorImageLink = New Link()
                    MyBase.CreateAutoRessourceByBitmap(_ErrorImageLink, Link.EnuLinkType.ElementImage, My.Resources.errorDefault, "WEFiles/Image/ErrorImageDefault.png")
                End If
                Return _ErrorImageLink
            End Get
            Set(ByVal value As Link)
                _ErrorImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N049"), _
        LocalizableDescAtt("_D058"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        ConfigBiblio(True, False, False, False, False)> _
        Public Property LeftImageLink() As Link
            Get
                If _LeftImageLink Is Nothing Then _LeftImageLink = New Link()
                Return _LeftImageLink
            End Get
            Set(ByVal value As Link)
                _LeftImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N050"), _
        LocalizableDescAtt("_D059"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property LeftImagePosition() As CssEnum.VerticalAlign
            Get
                Return _LeftImagePosition
            End Get
            Set(ByVal value As CssEnum.VerticalAlign)
                _LeftImagePosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N062"), _
        LocalizableDescAtt("_D062"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaCols() As Integer
            Get
                Return _TextAreaCols
            End Get
            Set(ByVal value As Integer)
                _TextAreaCols = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N057"), _
        LocalizableDescAtt("_D057"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaReadOnly() As Boolean
            Get
                Return _TextAreaReadOnly
            End Get
            Set(ByVal value As Boolean)
                _TextAreaReadOnly = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N063"), _
        LocalizableDescAtt("_D063"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaRows() As Integer
            Get
                Return _TextAreaRows
            End Get
            Set(ByVal value As Integer)
                _TextAreaRows = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N061"), _
        LocalizableDescAtt("_D061"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaScrollOverFlow() As TextAreaScrollOverFlow
            Get
                Return _TextAreaScrollOverFlow
            End Get
            Set(ByVal value As TextAreaScrollOverFlow)
                _TextAreaScrollOverFlow = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaValue() As LocalizableString
            Get
                If _TextAreaValue Is Nothing Then _TextAreaValue = New LocalizableString("")
                Return _TextAreaValue
            End Get
            Set(ByVal value As LocalizableString)
                _TextAreaValue = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N048"), _
        LocalizableDescAtt("_D060"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaWidth() As CssUnit
            Get
                If _TextAreaWidth Is Nothing Then _TextAreaWidth = New CssUnit()
                Return _TextAreaWidth
            End Get
            Set(ByVal value As CssUnit)
                _TextAreaWidth = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Title() As LocalizableHtml
            Get
                If _Title Is Nothing Then _Title = New LocalizableHtml(LocalizablePropertyDefaultValue._0007) 'Nom du champs :
                Return _Title
            End Get
            Set(ByVal value As LocalizableHtml)
                _Title = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        LocalizableDescAtt("_D064"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPosition
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPosition)
                _TitlePosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        LocalizableDescAtt("_D051"), _
        Editor(GetType(UITypeValidator), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As Validator
            Get
                If _Validator Is Nothing Then _Validator = New Validator(Validator.TypeValueToValidate.Text)
                Return _Validator
            End Get
            Set(ByVal value As Validator)
                _Validator = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0087
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WETextArea
            info.ToolBoxDescription = LocalizableOpen._0088
            info.SortPropertyList.Add(New SortProperty("LeftImageLink", "image.png", LocalizableOpen._0025))
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081))
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", LocalizableOpen._0082))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("LeftImage", LocalizableOpen._0075, LocalizableOpen._0085))
            configStylesZones.Add(New ConfigStylesZone("ErrorImage", LocalizableOpen._0077, LocalizableOpen._0086))
            configStylesZones.Add(New ConfigStylesZone("ErrorText", LocalizableOpen._0213, LocalizableOpen._0214))
            configStylesZones.Add(New ConfigStylesZone("Label", LocalizableOpen._0079, LocalizableOpen._0080))
            configStylesZones.Add(New ConfigStylesZone("TextArea", LocalizableOpen._0083, LocalizableOpen._0089))
            configStylesZones.Add(New ConfigStylesZone("LeftInput", LocalizableOpen._0215, LocalizableOpen._0216))
            configStylesZones.Add(New ConfigStylesZone("RightInput", LocalizableOpen._0217, LocalizableOpen._0218))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'leftImage
            Dim leftImage As String = MyBase.GetLink(Me.LeftImageLink)
            If Not String.IsNullOrEmpty(leftImage) Then
                writer.Indent = 2
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftImage"))
                writer.WriteAttribute("src", leftImage)

                Dim builder As New StringBuilder()
                builder.Append(StylesUtils.ConcatCSSValue("vertical-align:", CssEnumConverter.VerticalAlignToCss(Me.LeftImagePosition), ";"))
                If Not String.IsNullOrEmpty(builder.ToString) Then writer.WriteAttribute("style", builder.ToString)

                writer.Write("/>")
                writer.WriteLine()
            End If

            Dim textAreaBuilder As New StringBuilder()
            textAreaBuilder.Append(StylesUtils.ConcatCSSValue("width:", Me.TextAreaWidth.ToCss, ";"))
            textAreaBuilder.Append(StylesUtils.ConcatCSSValue("overflow-y:", TConvTextAreaScrollOverFlow.TextAreaScrollOverFlowToCss(Me.TextAreaScrollOverFlow), ";"))
            textAreaBuilder.Append(StylesUtils.ConcatCSSValue("overflow-x:", "hidden", ";"))

            Dim labelBuilder As New StringBuilder()

            writer.Indent = 2
            Select Case TitlePosition
                Case TextPosition.leftmiddle

                    Call Me.RenderEditableText(writer, labelBuilder)
                    'input
                    Call CSSInputBuilder(textAreaBuilder)
                    textAreaBuilder.Append(StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))
                    Call RenderTextArea(writer, textAreaBuilder)

                Case TextPosition.lefttop, TextPosition.leftbottom
                    Call CSSInputBuilder(labelBuilder)
                    Call Me.RenderEditableText(writer, labelBuilder)
                    'input

                    textAreaBuilder.Append(StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))
                    Call RenderTextArea(writer, textAreaBuilder)

                Case TextPosition.top
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("display : ", "block", ";"))
                    Call Me.RenderEditableText(writer, labelBuilder)
                    Call RenderTextArea(writer, textAreaBuilder)

                Case TextPosition.bottom
                    Call RenderTextArea(writer, textAreaBuilder)
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("display : ", "block", ";"))
                    Call Me.RenderEditableText(writer, labelBuilder)

                Case TextPosition.righttop, TextPosition.rightmiddle, TextPosition.rightbottom
                    'input
                    Call RenderTextArea(writer, textAreaBuilder)
                    'label
                    Call CSSInputBuilder(labelBuilder) 'Mise à jour du Css
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("text-align : ", "right", ";"))
                    Call Me.RenderEditableText(writer, labelBuilder)

            End Select

            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If
            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub CSSInputBuilder(ByRef builder As StringBuilder)
            Select Case TitlePosition
                Case TextPosition.lefttop, TextPosition.righttop
                    builder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "top", ";"))
                Case TextPosition.leftmiddle, TextPosition.rightmiddle
                    builder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                Case TextPosition.leftbottom, TextPosition.rightbottom
                    builder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "bottom", ";"))
            End Select
        End Sub

        Private Sub RenderEditableText(ByVal writer As HtmlWriter, ByVal labelBuilder As StringBuilder)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Label"))
            writer.WriteAttribute("style", labelBuilder.ToString)
            writer.Write(">")

            writer.WriteHtmlBlockEdit(Me, "Title", False)
            writer.WriteEndTag("span")
        End Sub

        Private Sub RenderTextArea(ByVal writer As HtmlWriter, ByVal builder As StringBuilder)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftInput"))
            writer.WriteAttribute("style", "display:inline-block;")
            writer.Write(">")
            writer.WriteEndTag("span")

            writer.WriteLine()
            writer.Indent = 2
            writer.WriteBeginTag("textarea")

            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("TextArea"))
            writer.WriteAttribute("name", Me.ID)
            If Me.TextAreaReadOnly Then writer.Write("disabled")
            If Not Me.TextAreaCols = 0 Then writer.WriteAttribute("cols", Me.TextAreaCols) Else writer.WriteAttribute("cols", "50")
            If Not Me.TextAreaRows = 0 Then writer.WriteAttribute("rows", Me.TextAreaRows) Else writer.WriteAttribute("rows", "4")
            If Not String.IsNullOrEmpty(builder.ToString) Then writer.WriteAttribute("style", builder.ToString)

            writer.Write(">")

            writer.Write(Me.TextAreaValue.GetValue(MyBase.Page.Culture))

            writer.WriteEndTag("textarea")
            writer.WriteLine()
            writer.Indent = 1

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RightInput"))
            writer.WriteAttribute("style", "display:inline-block;")
            writer.Write(">")
            writer.WriteEndTag("span")
        End Sub

        #End Region 'Methods

    End Class

End Namespace

