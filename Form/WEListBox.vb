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

Imports WebElement.Elements.Form.Editors
Imports WebElement.Elements.Form.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable, _
    OEObsolete(1, 31)> _
    Public Class WEListBox
        Inherits ElementBase

        #Region "Fields"

        Private _Disabled As Boolean
        Private _Element As Object() 'le champs texte en 0 valeur en 1
        Private _ErrorImageLink As Link
        Private _Multiple As Boolean
        Private _Name As String
        Private _Size As Integer
        Private _Title As LocalizableHtml
        Private _TitlePosition As TextPositionSimple

        'Sur le validateur (icone + texte)
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEListBox", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        '<Category("Edition"), _
        'DisplayName("Activé"), _
        'Description("Active ou non la liste déroulante. Si non la liste est grisé."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N071"), _
        LocalizableDescAtt("_D071"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Disabled() As Boolean
            Get
                Return _Disabled
            End Get
            Set(ByVal value As Boolean)
                _Disabled = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Liste d'éléments"), _
        'Description("Tableau des éléments contenant les valeurs et les champs texte affichés de la liste déroulante"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N069"), _
        LocalizableDescAtt("_D069"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        Editor(GetType(UITypeListBoxElements), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvWEListBoxListElements))> _
        Public Property Element() As Object()
            Get
                If _Element Is Nothing OrElse _Element.Length = 0 Then
                    ReDim _Element(1)
                    _Element(0) = New Object() {New LocalizableString(LocalizablePropertyDefaultValue._0008 & " 1 "), New LocalizableString(LocalizablePropertyDefaultValue._0009 & " 1 ")} '"Nom du champs 1""Valeur 1"
                    _Element(1) = New Object() {New LocalizableString(LocalizablePropertyDefaultValue._0008 & " 2 "), New LocalizableString(LocalizablePropertyDefaultValue._0009 & " 2 ")} '"Nom du champs 1""Valeur 1"
                End If
                Return _Element
            End Get
            Set(ByVal value As Object())
                _Element = value
            End Set
        End Property

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
        'DisplayName("Choix multiple"), _
        'Description("Autoriser les choix multiples d'éléments."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N070"), _
        LocalizableDescAtt("_D070"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Multiple() As Boolean
            Get
                Return _Multiple
            End Get
            Set(ByVal value As Boolean)
                _Multiple = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Nom du groupe"), _
        'Description("Nom de la liste déroulante pris en compte pour la validation du formulaire"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N072"), _
        LocalizableDescAtt("_D072"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NameGroup() As String
            Get
                If String.IsNullOrEmpty(_Name) Then _Name = Me.UniqueName
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        '  <Category("Apparence"), _
        'DisplayName("Lignes"), _
        'Description("Nombre de lignes de la liste déroulante affichées."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N063"), _
        LocalizableDescAtt("_D068"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Size() As Integer
            Get
                If _Size = 0 Then _Size = 1
                Return _Size
            End Get
            Set(ByVal value As Integer)
                _Size = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Title() As LocalizableHtml
            Get
                If _Title Is Nothing Then
                    _Title = New LocalizableHtml(LocalizablePropertyDefaultValue._0007) 'Nom du champs
                End If
                Return _Title
            End Get
            Set(ByVal value As LocalizableHtml)
                _Title = value
            End Set
        End Property

        '<Category("Apparence"), _
        'DisplayName("Position titre"), _
        'Description("Position du titre par rapport à liste de valeur")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        LocalizableDescAtt("_D073"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPositionSimple
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPositionSimple)
                _TitlePosition = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Validateur"), _
        'Description("Edition des règles de validations de saisie de l'élément de formulaire."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        LocalizableDescAtt("_D051"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None), _
        Editor(GetType(UITypeValidator), GetType(UITypeEditor))> _
        Public Property Validator() As Validator
            Get
                If _Validator Is Nothing Then _Validator = New Validator(Validator.TypeValueToValidate.Bool)
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
            info.ToolBoxCaption = LocalizableOpen._0101 '"Liste déroulante"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WEListBox
            info.ToolBoxDescription = LocalizableOpen._0102 '"Liste déroulante d'élements"
            info.AutoOpenProperty = "Element"
            info.SortPropertyList.Add(New SortProperty("Element", "DataTable.png", LocalizableOpen._0030)) '  "Configurer"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Title", LocalizableOpen._0079, LocalizableOpen._0080)) '"Titre principal","Zone du titre associé à l'élément."
            configStylesZones.Add(New ConfigStylesZone("OptionValue", LocalizableOpen._0101, LocalizableOpen._0108)) '"Liste déroulante","Zone de la liste déroulante d'élements."
            configStylesZones.Add(New ConfigStylesZone("ErrorImage", LocalizableOpen._0077, LocalizableOpen._0078)) '"Image d'erreur", "Zone de l'image d'erreur situé à droite du champ."
            configStylesZones.Add(New ConfigStylesZone("ErrorText", LocalizableOpen._0213, LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."

            Me._Disabled = True
            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'Ajout du titre par rapport à sa position
            Dim titleBuilder As New StringBuilder()
            Dim selectBuilder As New StringBuilder()
            Select Case Me.TitlePosition
                Case TextPositionSimple.top
                    titleBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    Call RenderTitle(writer, titleBuilder)
                    Call RenderSelect(writer, selectBuilder)

                Case TextPositionSimple.bottom
                    titleBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    Call RenderSelect(writer, selectBuilder)
                    Call RenderTitle(writer, titleBuilder)

                Case TextPositionSimple.Left
                    selectBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderTitle(writer, titleBuilder)
                    Call RenderSelect(writer, selectBuilder)

                Case TextPositionSimple.Right
                    selectBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderSelect(writer, selectBuilder)
                    Call RenderTitle(writer, titleBuilder)

            End Select

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub RenderSelect(ByVal writer As HtmlWriter, ByVal selectBuilder As StringBuilder)
            writer.WriteBeginTag("select")
            writer.WriteAttribute("name", Me.ID)
            If Not String.IsNullOrEmpty(selectBuilder.ToString) Then writer.WriteAttribute("style", selectBuilder.ToString)
            If _Size > 1 Then writer.WriteAttribute("size", _Size.ToString)
            If _Multiple Then writer.WriteAttribute("multiple", "multiple")
            If Not _Disabled Then writer.WriteAttribute("disabled", "disabled")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("OptionValue"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            For Each elements As Object() In Element

                Dim champs As LocalizableString = CType(elements(0), LocalizableString)
                Dim value As LocalizableString = CType(elements(1), LocalizableString)

                writer.WriteBeginTag("option")
                writer.WriteAttribute("value", value.GetValue(MyBase.Page.Culture))
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write(champs.GetValue(MyBase.Page.Culture))
                writer.WriteEndTag("option")
                writer.WriteLine()
            Next

            writer.WriteEndTag("select")
            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If
        End Sub

        Private Sub RenderTitle(ByVal writer As HtmlWriter, ByVal titleBuilder As StringBuilder)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Title"))
            If Not String.IsNullOrEmpty(titleBuilder.ToString) Then writer.WriteAttribute("style", titleBuilder.ToString)
            writer.Write(">")

            'MyBase.RenderBeginTextEdit(writer, "Title", False, False, False, "")
            'writer.Write(Me.Title.GetHtmlValue(Me, "Title"))
            'MyBase.RenderEndTextEdit(writer)
            writer.WriteHtmlBlockEdit(Me, "Title", False)

            writer.WriteEndTag("span")
            writer.WriteLine()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

