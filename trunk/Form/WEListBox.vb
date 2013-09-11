Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager
Imports System.Text
Imports WebElement.Elements.Form.Editors
Imports System.Web.UI.HtmlTextWriter

Namespace Elements.Form

    <Serializable(), openElement.WebElement.Common.Attributes.OEObsolete(1, 31)> _
Public Class WEListBox
        Inherits ElementBase

#Region "Propriété"

        Private _Size As Integer
        Private _Element As Object() 'le champs texte en 0 valeur en 1
        Private _Multiple As Boolean
        Private _Disabled As Boolean
        Private _Name As String
        Private _Title As DataType.LocalizableHtml
        Private _TitlePosition As TextPositionSimple

        'Sur le validateur (icone + texte)
        Private _Validator As DataType.Validator
        Private _ErrorImageLink As LinksManager.Link

        '  <Category("Apparence"), _
        'DisplayName("Lignes"), _
        'Description("Nombre de lignes de la liste déroulante affichées."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N063"), _
        Ressource.localizable.LocalizableDescAtt("_D068"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Size() As Integer
            Get
                If _Size = 0 Then _Size = 1
                Return _Size
            End Get
            Set(ByVal value As Integer)
                _Size = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Liste d'éléments"), _
        'Description("Tableau des éléments contenant les valeurs et les champs texte affichés de la liste déroulante"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N069"), _
        Ressource.localizable.LocalizableDescAtt("_D069"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Editor(GetType(Editors.UITypeListBoxElements), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(Editors.Converter.TConvWEListBoxListElements))> _
        Public Property Element() As Object()
            Get
                If _Element Is Nothing OrElse _Element.Length = 0 Then
                    ReDim _Element(1)
                    _Element(0) = New Object() {New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0008 & " 1 "), New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0009 & " 1 ")} '"Nom du champs 1""Valeur 1"
                    _Element(1) = New Object() {New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0008 & " 2 "), New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0009 & " 2 ")} '"Nom du champs 1""Valeur 1"
                End If
                Return _Element
            End Get
            Set(ByVal value As Object())
                _Element = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Choix multiple"), _
        'Description("Autoriser les choix multiples d'éléments."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N070"), _
        Ressource.localizable.LocalizableDescAtt("_D070"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Multiple() As Boolean
            Get
                Return _Multiple
            End Get
            Set(ByVal value As Boolean)
                _Multiple = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Activé"), _
        'Description("Active ou non la liste déroulante. Si non la liste est grisé."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N071"), _
        Ressource.localizable.LocalizableDescAtt("_D071"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Disabled() As Boolean
            Get
                Return _Disabled
            End Get
            Set(ByVal value As Boolean)
                _Disabled = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("Nom du groupe"), _
        'Description("Nom de la liste déroulante pris en compte pour la validation du formulaire"), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N072"), _
        Ressource.localizable.LocalizableDescAtt("_D072"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Name_group() As String
            Get
                If String.IsNullOrEmpty(_Name) Then _Name = Me.UniqueName
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        '<Category("Comportement"), _
        'DisplayName("Validateur"), _
        'Description("Edition des règles de validations de saisie de l'élément de formulaire."), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        Ressource.localizable.LocalizableDescAtt("_D051"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None), _
        Editor(GetType(openElement.WebElement.Editors.UITypeValidator), GetType(Drawing.Design.UITypeEditor))> _
        Public Property Validator() As DataType.Validator
            Get
                If _Validator Is Nothing Then _Validator = New DataType.Validator(DataType.Validator.TypeValueToValidate.Bool)
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

        '<Category("Apparence"), _
        'DisplayName("Position titre"), _
        'Description("Position du titre par rapport à liste de valeur")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        Ressource.localizable.LocalizableDescAtt("_D073"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPositionSimple
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPositionSimple)
                _TitlePosition = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Title() As DataType.LocalizableHtml
            Get
                If _Title Is Nothing Then
                    _Title = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0007) 'Nom du champs
                End If
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Title = value
            End Set
        End Property
#End Region

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEListBox", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0101 '"Liste déroulante"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WEListBox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0102 '"Liste déroulante d'élements"
            info.AutoOpenProperty = "Element"
            info.SortPropertyList.Add(New SortProperty("Element", "DataTable.png", My.Resources.text.LocalizableOpen._0030)) '  "Configurer"
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Title", My.Resources.text.LocalizableOpen._0079, My.Resources.text.LocalizableOpen._0080)) '"Titre principal","Zone du titre associé à l'élément."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("OptionValue", My.Resources.text.LocalizableOpen._0101, My.Resources.text.LocalizableOpen._0108)) '"Liste déroulante","Zone de la liste déroulante d'élements."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorImage", My.Resources.text.LocalizableOpen._0077, My.Resources.text.LocalizableOpen._0078)) '"Image d'erreur", "Zone de l'image d'erreur situé à droite du champ."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorText", My.Resources.text.LocalizableOpen._0213, My.Resources.text.LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."

            Me._Disabled = True
            MyBase.OnOpen(configStylesZones)
        End Sub



#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

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

                Case TextPositionSimple.left
                    selectBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderTitle(writer, titleBuilder)
                    Call RenderSelect(writer, selectBuilder)

                Case TextPositionSimple.right
                    selectBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderSelect(writer, selectBuilder)
                    Call RenderTitle(writer, titleBuilder)

            End Select


            MyBase.RenderEndTag(writer)

        End Sub

        Private Sub RenderSelect(ByVal writer As Common.HtmlWriter, ByVal selectBuilder As StringBuilder)

            writer.WriteBeginTag("select")
            writer.WriteAttribute("name", Me.ID)
            If Not String.IsNullOrEmpty(selectBuilder.ToString) Then writer.WriteAttribute("style", selectBuilder.ToString)
            If _Size > 1 Then writer.WriteAttribute("size", _Size.ToString)
            If _Multiple Then writer.WriteAttribute("multiple", "multiple")
            If Not _Disabled Then writer.WriteAttribute("disabled", "disabled")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("OptionValue"))
            writer.Write(TagRightChar)
            writer.WriteLine()

            For Each elements As Object() In Element

                Dim champs As DataType.LocalizableString = CType(elements(0), DataType.LocalizableString)
                Dim value As DataType.LocalizableString = CType(elements(1), DataType.LocalizableString)

                writer.WriteBeginTag("option")
                writer.WriteAttribute("value", value.GetValue(MyBase.Page.Culture))
                writer.Write(TagRightChar)
                writer.Write(champs.GetValue(MyBase.Page.Culture))
                writer.WriteEndTag("option")
                writer.WriteLine()
            Next

            writer.WriteEndTag("select")
            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If

        End Sub

        Private Sub RenderTitle(ByVal writer As Common.HtmlWriter, ByVal titleBuilder As StringBuilder)
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


#End Region



    End Class

End Namespace