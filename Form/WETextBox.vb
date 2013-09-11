Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager.CssItems.CssEnum
Imports openElement.WebElement.StylesManager.CssItems
Imports openElement.WebElement.StylesManager
Imports System.Text
Imports WebElement.Elements.Form.Editors

Namespace Elements.Form

    <Serializable(), openElement.WebElement.Common.Attributes.OEObsolete(1, 31)> _
    Public Class WETextBox
        Inherits ElementBase

#Region "Private"


        Private _Title As DataType.LocalizableHtml
        Private _TitlePosition As TextPosition
        Private _InputValue As DataType.LocalizableString 'Valeur dans la zone de saisie
        Private _InputWidth As CssItems.CssUnit 'largeur de la zone de saisie
        Private _ImputMaxLenght As Integer 'Nombre de caractère maximum autorisé dans la zone de saisie
        Private _InputReadOnly As Boolean

        'Sur l'image à gauche
        Private _LeftImageLink As LinksManager.Link
        Private _LeftImageLinkPosition As VerticalAlign

        'Sur le validateur (icone + texte)
        Private _Validator As DataType.Validator
        Private _ErrorImageLink As LinksManager.Link

        <Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Browsable(False), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Title() As DataType.LocalizableHtml
            Get
                If _Title Is Nothing Then _Title = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0007) '"Nom du champ :")
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Title = value
            End Set
        End Property
        '<Category("Apparence"), _
        'DisplayName("Position titre"), _
        'Description("Position du champs de texte par rapport à la boite de saisie")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        Ressource.localizable.LocalizableDescAtt("_D053"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPosition
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPosition)
                _TitlePosition = value
            End Set
        End Property
        '<Category("Edition"), _
        'DisplayName("Valeur de saisie"), _
        'Description("texte pré-remplis dans la boite de saisie."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        Ressource.localizable.LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputValue() As DataType.LocalizableString
            Get
                If _InputValue Is Nothing Then _InputValue = New DataType.LocalizableString("")
                Return _InputValue
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _InputValue = value
            End Set
        End Property
        '<Category("Apparence"), _
        'DisplayName("Largeur"), _
        'Description("Largeur du champs texte associé à la boite de saisie")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N048"), _
        Ressource.localizable.LocalizableDescAtt("_D055"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputWidth() As CssItems.CssUnit
            Get
                If _InputWidth Is Nothing Then _InputWidth = New CssItems.CssUnit()
                Return _InputWidth
            End Get
            Set(ByVal value As CssItems.CssUnit)
                _InputWidth = value
            End Set
        End Property
        '<Category("Comportement"), _
        'DisplayName("Longueur texte"), _
        'Description("Nombre de caractère maximum (espace compris) autorisé lors de la saisie dans la zone de texte. Renseigné 0 pour un nombre illimité de caractères")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N056"), _
        Ressource.localizable.LocalizableDescAtt("_D056"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        Ressource.localizable.LocalizableDescAtt("_D057"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Image à gauche"), _
        'Description("Selection de l'image principal de l'élément situé à gauche du titre"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N049"), _
        Ressource.localizable.LocalizableDescAtt("_D058"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False)> _
        Public Property LeftImageLink() As LinksManager.Link
            Get
                If _LeftImageLink Is Nothing Then _LeftImageLink = New LinksManager.Link()
                Return _LeftImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _LeftImageLink = value
            End Set
        End Property
        ' <Category("Apparence"), _
        'DisplayName("Image alignement"), _
        'Description("Position de l'image à gauche du titre")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
         Ressource.localizable.LocalizableNameAtt("_N050"), _
         Ressource.localizable.LocalizableDescAtt("_D059"), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property LeftImagePosition() As VerticalAlign
            Get
                Return _LeftImageLinkPosition
            End Get
            Set(ByVal value As VerticalAlign)
                _LeftImageLinkPosition = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Validateur"), _
        'Description("Edition des règle de validations de saisie de l'élément de formulaire."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        Ressource.localizable.LocalizableDescAtt("_D051"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeValidator), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As DataType.Validator
            Get
                If _Validator Is Nothing Then _Validator = New DataType.Validator(DataType.Validator.TypeValueToValidate.Text)
                Return _Validator
            End Get
            Set(ByVal value As DataType.Validator)
                _Validator = value
            End Set
        End Property
        '<Category("Edition"), _
        'DisplayName("Image d'erreur"), _
        'Description("Selection de l'image a afficher en cas d'erreur"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N052"), _
        Ressource.localizable.LocalizableDescAtt("_D052"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False)> _
        Public Property ErrorImageLink() As LinksManager.Link
            Get
                If _ErrorImageLink Is Nothing OrElse _ErrorImageLink.IsEmpty("DEFAULT") Then
                    _ErrorImageLink = New LinksManager.Link()
                    MyBase.CreateAutoRessourceByBitmap(_ErrorImageLink, LinksManager.Link.EnuLinkType.ElementImage, My.Resources.errorDefault, "WEFiles/Image/ErrorImageDefault.png")
                End If

                Return _ErrorImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _ErrorImageLink = value
            End Set
        End Property

#End Region

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETextBox", page, parentID, templateName)
            Me.TitlePosition = TextPosition.leftmiddle
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0083 '"Boite de saisie de texte"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WETextBox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0084 '"Ajouter un champ de saisie de texte simple ligne"
            info.SortPropertyList.Add(New SortProperty("LeftImageLink", "image.png", My.Resources.text.LocalizableOpen._0025)) '"Sélection de l'image de gauche"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081)) '"Sélection des règles de validation"
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", My.Resources.text.LocalizableOpen._0082)) '"Sélection de l'image d'erreur"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LeftImage", My.Resources.text.LocalizableOpen._0075, My.Resources.text.LocalizableOpen._0085)) '"Image de gauche","Zone de l'image situé à gauche de la boîte de saisie de texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorImage", My.Resources.text.LocalizableOpen._0077, My.Resources.text.LocalizableOpen._0086)) ' "Image d'erreur","Zone de l'image d'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorText", My.Resources.text.LocalizableOpen._0213, My.Resources.text.LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Label", My.Resources.text.LocalizableOpen._0079, My.Resources.text.LocalizableOpen._0080)) '"Titre principal","Zone du titre associé à l'élément."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("TextArea", My.Resources.text.LocalizableOpen._0083, My.Resources.text.LocalizableOpen._0089)) '"Boite de saisie","Zone de saisie du texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LeftInput", My.Resources.text.LocalizableOpen._0215, My.Resources.text.LocalizableOpen._0216)) ' "Gauche de la saisie"  Décoration positionnée à gauche de la boite de saisie
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RightInput", My.Resources.text.LocalizableOpen._0217, My.Resources.text.LocalizableOpen._0218)) '"Droite de la saisie","Décoration positionnée à gauche de la boite de saisie."

            MyBase.OnOpen(configStylesZones)

        End Sub



#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

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
            Dim labelStyle As String = String.Empty

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

#Region "Private render"



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


        Private Sub RenderEditableText(ByVal writer As Common.HtmlWriter, ByVal style As String)
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

        Private Sub RenderInput(ByRef writer As Common.HtmlWriter, ByVal style As String)

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

            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RightInput"))
            writer.WriteAttribute("style", "display:inline-block;")
            writer.Write(">")
            writer.WriteEndTag("span")


        End Sub

#End Region


#End Region




    End Class

End Namespace



