Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Text
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable, _
    OEObsolete(1, 31)> _
    Public Class WETextBox
        Inherits ElementBase

        #Region "Fields"

        Private _ErrorImageLink As Link
        Private _ImputMaxLenght As Integer 'Nombre de caractère maximum autorisé dans la zone de saisie
        Private _InputReadOnly As Boolean
        Private _InputValue As LocalizableString 'Valeur dans la zone de saisie
        Private _InputWidth As CssUnit 'largeur de la zone de saisie

        'Sur l'image à gauche
        Private _LeftImageLink As Link
        Private _LeftImageLinkPosition As CssEnum.VerticalAlign
        Private _Title As LocalizableHtml
        Private _TitlePosition As TextPosition

        'Sur le validateur (icone + texte)
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETextBox", page, parentID, templateName)
            Me.TitlePosition = TextPosition.leftmiddle
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        '<Category("Edition"), _
        'DisplayName("Image d'erreur"), _
        'Description("Selection de l'image a afficher en cas d'erreur"), _
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

        '<Category("Comportement"), _
        'DisplayName("Longueur texte"), _
        'Description("Nombre de caractère maximum (espace compris) autorisé lors de la saisie dans la zone de texte. Renseigné 0 pour un nombre illimité de caractères")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N056"), _
        LocalizableDescAtt("_D056"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ImputMaxLenght() As Integer
            Get
                Return _ImputMaxLenght
            End Get
            Set(ByVal value As Integer)
                _ImputMaxLenght = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Lecture seule"), _
        'Description("Définit la boite de saisie comme étant en lecture seule")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N057"), _
        LocalizableDescAtt("_D057"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Valeur de saisie"), _
        'Description("texte pré-remplis dans la boite de saisie."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputValue() As LocalizableString
            Get
                If _InputValue Is Nothing Then _InputValue = New LocalizableString("")
                Return _InputValue
            End Get
            Set(ByVal value As LocalizableString)
                _InputValue = value
            End Set
        End Property

        '<Category("Apparence"), _
        'DisplayName("Largeur"), _
        'Description("Largeur du champs texte associé à la boite de saisie")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N048"), _
        LocalizableDescAtt("_D055"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputWidth() As CssUnit
            Get
                If _InputWidth Is Nothing Then _InputWidth = New CssUnit()
                Return _InputWidth
            End Get
            Set(ByVal value As CssUnit)
                _InputWidth = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Image à gauche"), _
        'Description("Selection de l'image principal de l'élément situé à gauche du titre"), _
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

        ' <Category("Apparence"), _
        'DisplayName("Image alignement"), _
        'Description("Position de l'image à gauche du titre")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N050"), _
        LocalizableDescAtt("_D059"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property LeftImagePosition() As CssEnum.VerticalAlign
            Get
                Return _LeftImageLinkPosition
            End Get
            Set(ByVal value As CssEnum.VerticalAlign)
                _LeftImageLinkPosition = value
            End Set
        End Property

        <ExportVar(ExportVar.EnuVarType.Php), _
        Browsable(False), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Title() As LocalizableHtml
            Get
                If _Title Is Nothing Then _Title = New LocalizableHtml(LocalizablePropertyDefaultValue._0007) '"Nom du champ :")
                Return _Title
            End Get
            Set(ByVal value As LocalizableHtml)
                _Title = value
            End Set
        End Property

        '<Category("Apparence"), _
        'DisplayName("Position titre"), _
        'Description("Position du champs de texte par rapport à la boite de saisie")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        LocalizableDescAtt("_D053"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPosition
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPosition)
                _TitlePosition = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Validateur"), _
        'Description("Edition des règle de validations de saisie de l'élément de formulaire."), _
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
            info.ToolBoxCaption = LocalizableOpen._0083 '"Boite de saisie de texte"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WETextBox
            info.ToolBoxDescription = LocalizableOpen._0084 '"Ajouter un champ de saisie de texte simple ligne"
            info.SortPropertyList.Add(New SortProperty("LeftImageLink", "image.png", LocalizableOpen._0025)) '"Sélection de l'image de gauche"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081)) '"Sélection des règles de validation"
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", LocalizableOpen._0082)) '"Sélection de l'image d'erreur"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("LeftImage", LocalizableOpen._0075, LocalizableOpen._0085)) '"Image de gauche","Zone de l'image situé à gauche de la boîte de saisie de texte."
            configStylesZones.Add(New ConfigStylesZone("ErrorImage", LocalizableOpen._0077, LocalizableOpen._0086)) ' "Image d'erreur","Zone de l'image d'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New ConfigStylesZone("ErrorText", LocalizableOpen._0213, LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New ConfigStylesZone("Label", LocalizableOpen._0079, LocalizableOpen._0080)) '"Titre principal","Zone du titre associé à l'élément."
            configStylesZones.Add(New ConfigStylesZone("TextArea", LocalizableOpen._0083, LocalizableOpen._0089)) '"Boite de saisie","Zone de saisie du texte."
            configStylesZones.Add(New ConfigStylesZone("LeftInput", LocalizableOpen._0215, LocalizableOpen._0216)) ' "Gauche de la saisie"  Décoration positionnée à gauche de la boite de saisie
            configStylesZones.Add(New ConfigStylesZone("RightInput", LocalizableOpen._0217, LocalizableOpen._0218)) '"Droite de la saisie","Décoration positionnée à gauche de la boite de saisie."

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'LeftImage
            Dim leftImage As String = MyBase.GetLink(Me.LeftImageLink)
            If Not String.IsNullOrEmpty(leftImage) Then
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftImage"))
                writer.WriteAttribute("src", leftImage)

                Dim builder As New StringBuilder()
                builder.Append(StylesUtils.ConcatCSSValue("vertical-align:", CssEnumConverter.VerticalAlignToCss(Me._LeftImageLinkPosition), ";"))
                If Not String.IsNullOrEmpty(builder.ToString) Then writer.WriteAttribute("style", builder.ToString)

                writer.Write("/>")
            End If

            'Champs texte et zone de saisie
            Dim inputBuilder As String
            inputBuilder = StylesUtils.ConcatCSSValue("width:", Me.InputWidth.ToCss, ";")
            Dim labelStyle As String

            Select Case TitlePosition
                Case TextPosition.leftmiddle
                    'label
                    Call Me.RenderEditableText(writer, StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))
                    'input
                    inputBuilder = String.Concat(inputBuilder, StylesUtils.ConcatCSSValue("display : ", "inline-block", ";")) 'Mise à jour du Css

                    Call RenderInput(writer, inputBuilder)

                Case TextPosition.lefttop, TextPosition.leftbottom
                    'label
                    labelStyle = CSSInputBuilder() 'Mise à jour du Css
                    labelStyle = String.Concat(labelStyle, StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))
                    Call Me.RenderEditableText(writer, labelStyle)
                    'input
                    Call RenderInput(writer, StylesUtils.ConcatCSSValue("display : ", "inline-block", ";"))

                Case TextPosition.top
                    Call Me.RenderEditableText(writer, StylesUtils.ConcatCSSValue("display : ", "block", ";"))
                    Call RenderInput(writer, inputBuilder)

                Case TextPosition.bottom

                    Call RenderInput(writer, inputBuilder)
                    Call Me.RenderEditableText(writer, StylesUtils.ConcatCSSValue("display : ", "block", ";"))

                Case TextPosition.righttop, TextPosition.rightmiddle, TextPosition.rightbottom
                    'input
                    inputBuilder = String.Concat(inputBuilder, CSSInputBuilder()) 'Mise à jour du Css
                    Call RenderInput(writer, inputBuilder)
                    'label

                    labelStyle = StylesUtils.ConcatCSSValue("display : ", "inline-block", ";")
                    labelStyle = String.Concat(labelStyle, StylesUtils.ConcatCSSValue("text-align : ", "right", ";"))
                    Call Me.RenderEditableText(writer, labelStyle)

            End Select

            'Image et texte d'erreur
            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If

            MyBase.RenderEndTag(writer)
        End Sub

        Private Function CSSInputBuilder() As String
            Select Case TitlePosition
                Case TextPosition.lefttop, TextPosition.righttop
                    Return StylesUtils.ConcatCSSValue("vertical-align:", "top", ";")
                Case TextPosition.leftmiddle, TextPosition.rightmiddle
                    Return StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";")
                Case TextPosition.leftbottom, TextPosition.rightbottom
                    Return StylesUtils.ConcatCSSValue("vertical-align:", "baseline", ";")
            End Select
            Return "" ' DD just to remove the compilation warning
        End Function

        'Private Sub CSSLabelBuilder(ByRef Builder As StringBuilder)
        '    Select Case TitlePosition
        '        Case TextPosition.lefttop, TextPosition.leftmiddle, TextPosition.leftmiddle
        '            Builder.Append(StylesUtils.ConcatCSSValue("float : ", "left", ";"))
        '        Case TextPosition.rightbottom, TextPosition.rightmiddle, TextPosition.righttop
        '            Builder.Append(StylesUtils.ConcatCSSValue("float : ", "right", ";"))
        '    End Select
        'End Sub
        Private Sub RenderEditableText(ByVal writer As HtmlWriter, ByVal style As String)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Label"))
            writer.WriteAttribute("style", style)
            writer.Write(">")

            'MyBase.RenderBeginTextEdit(writer, "Title", False, False, False, "")
            'writer.Write(Me.Title.GetHtmlValue(Me, "Title"))
            'MyBase.RenderEndTextEdit(writer)
            writer.WriteHtmlBlockEdit(Me, "Title", False)
            writer.WriteEndTag("span")
        End Sub

        Private Sub RenderInput(ByRef writer As HtmlWriter, ByVal style As String)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftInput"))
            writer.WriteAttribute("style", "display:inline-block;")
            writer.Write(">")
            writer.WriteEndTag("span")

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", ID)
            writer.WriteAttribute("type", "text")

            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("TextArea"))

            Dim imputValue As String = Me.InputValue.GetValue(MyBase.Page.Culture)
            If Not String.IsNullOrEmpty(imputValue) Then writer.WriteAttribute("value", imputValue)
            If Me.ImputMaxLenght <> 0 Then writer.WriteAttribute("maxlength", Me.ImputMaxLenght)
            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")

            If Not String.IsNullOrEmpty(style) Then writer.WriteAttribute("style", style)

            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RightInput"))
            writer.WriteAttribute("style", "display:inline-block;")
            writer.Write(">")
            writer.WriteEndTag("span")
        End Sub

        #End Region 'Methods

    End Class

End Namespace

