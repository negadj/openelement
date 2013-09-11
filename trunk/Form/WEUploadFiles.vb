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
    Public Class WEUploadFiles
        Inherits ElementBase

#Region "Propriété"

        'Sur le champs texte et la zone de saisie
        Private _Title As DataType.LocalizableHtml
        Private _TitlePosition As TextPosition 'Position du texte de présentation par rapport à la texte box
        Private _InputWidth As CssItems.CssUnit 'largeur de la zone de saisie
        Private _AllowedTypesExt As String
        Private _AllowedSize As String

        'Configuration
        'Private _

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
                If _Title Is Nothing Then _Title = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0014) '"Nom du champ :"
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Title = value
            End Set
        End Property

        '        <Category("Apparence"), _
        '        DisplayName("Position titre"), _
        'Description("Position du titre par rapport à l'élément de téléchargement"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
                Ressource.localizable.LocalizableNameAtt("_N045"), _
                Ressource.localizable.LocalizableDescAtt("_D045"), _
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
        'DisplayName("Extensions autorisées"), _
        'Description("Liste des extensions autorisées (Ex : .jpg,.png) des fichiers à importer"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N046"), _
        Ressource.localizable.LocalizableDescAtt("_D046"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AllowedTypesExt() As String
            Get
                If _AllowedTypesExt Is Nothing Then _AllowedTypesExt = ".png,.gif,.jpg,.jpeg,.doc,.docx,.xls,.xlsx,.rtf,.txt,.pdf,.odg,.odt,.ods,.odf,.odp,.odb"
                Return _AllowedTypesExt
            End Get
            Set(ByVal value As String)
                _AllowedTypesExt = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Taille autorisées"), _
        'Description("Taille maximum autorisée des fichiers à importer"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N047"), _
        Ressource.localizable.LocalizableDescAtt("_D047"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(Elements.Form.Editors.Converter.TConvUploadFileSize)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
                Public Property AllowedSize() As String
            Get
                If String.IsNullOrEmpty(_AllowedSize) Then _AllowedSize = 1
                If _AllowedSize = "0" Then _AllowedSize = 1
                Return _AllowedSize
            End Get
            Set(ByVal value As String)
                If Long.TryParse(value, New Long) Then
                    _AllowedSize = value
                Else
                    _AllowedSize = 1
                End If

            End Set
        End Property

        '<Category("Apparence"), _
        'DisplayName("Largeur"), _
        'Description("Largeur du champs texte associé au champs de téléchargement")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N048"), _
        Ressource.localizable.LocalizableDescAtt("_D048"), _
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


        '<Category("Edition"), _
        'DisplayName("Image à gauche"), _
        'Description("Selection de l'image principal de l'élément situé à gauche du champs de téléchargement"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N049"), _
        Ressource.localizable.LocalizableDescAtt("_D049"), _
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
        'Description("Position de l'image à gauche du champs de téléchargement.")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
         Ressource.localizable.LocalizableNameAtt("_N050"), _
         Ressource.localizable.LocalizableDescAtt("_D050"), _
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
        'Description("Edition des règles de validations de saisie de l'élément de formulaire."), _
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
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
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
            MyBase.New(EnuElementType.PageEdit, "WEUploadFiles", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0073 '"Document(s) à importer"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WEUploadFiles
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0074 '"Permettre le téléchargement d'un fichier sur son hébergement"
            info.SortPropertyList.Add(New SortProperty("LeftImageLink", "image.png", My.Resources.text.LocalizableOpen._0025)) '"Sélection de l'image de gauche"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081)) '"Sélection des règles de validation"
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", My.Resources.text.LocalizableOpen._0082)) ' "Sélection de l'image d'erreur"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LeftImage", My.Resources.text.LocalizableOpen._0075, My.Resources.text.LocalizableOpen._0076)) '"Image de gauche", "Zone de l'image situé à gauche du champ."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorImage", My.Resources.text.LocalizableOpen._0077, My.Resources.text.LocalizableOpen._0078)) '"Image d'erreur", "Zone de l'image d'erreur situé à droite du champ."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorText", My.Resources.text.LocalizableOpen._0213, My.Resources.text.LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Label", My.Resources.text.LocalizableOpen._0079, My.Resources.text.LocalizableOpen._0080)) '"Titre principal", "Zone du titre associé à l'élément."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("InputFile", My.Resources.text.LocalizableOpen._0119, My.Resources.text.LocalizableOpen._0120)) '"Champ de selection du fichier", "Zone de selection du fichier."


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

            Dim inputBuilder As New StringBuilder()

            inputBuilder.Append(StylesUtils.ConcatCSSValue("width:", InputWidth.ToCss, ";"))

            Dim labelBuilder As New StringBuilder()

            'Début de l'étiquette
            writer.WriteBeginTag("label")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Label"))

            Select Case TitlePosition
                Case TextPosition.lefttop
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)
                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "top", ";"))

                    Call RenderInput(writer, inputBuilder)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.leftmiddle
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)

                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderInput(writer, inputBuilder)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.leftbottom
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)

                    Call RenderInput(writer, inputBuilder)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.top
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    writer.WriteAttribute("style", labelBuilder.ToString)
                    writer.Write(">")

                    Call Me.RenderEditableText(writer)

                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                    Call RenderInput(writer, inputBuilder)

                Case TextPosition.bottom
                    writer.Write(">")

                    inputBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.righttop
                    writer.Write(">")

                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "top", ";"))
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.rightmiddle
                    writer.Write(">")
                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderInput(writer, inputBuilder)
                    Call Me.RenderEditableText(writer)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

                Case TextPosition.rightbottom
                    writer.Write(">")
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)
                    'Fin de l'étiquette
                    writer.WriteEndTag("label")

            End Select

            'Image et texte d'erreur
            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If

            MyBase.RenderEndTag(writer)

        End Sub

#Region "Private render"

        Private Sub RenderEditableText(ByVal writer As Common.HtmlWriter)
            'MyBase.RenderBeginTextEdit(writer, "Title", False, False, False, "")
            'writer.Write(Me.Title.GetHtmlValue(Me, "Title"))
            'MyBase.RenderEndTextEdit(writer)
            writer.WriteHtmlBlockEdit(Me, "Title", False)
        End Sub


        Private Sub RenderInput(ByRef writer As Common.HtmlWriter, ByVal builder As StringBuilder)

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", ID)
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("InputFile"))
            writer.WriteAttribute("type", "file")

            If Not String.IsNullOrEmpty(builder.ToString) Then writer.WriteAttribute("style", builder.ToString)

            writer.Write(">")

        End Sub





#End Region

#End Region

    End Class


End Namespace