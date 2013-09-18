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

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable, _
    OEObsolete(1, 31)> _
    Public Class WECheckBox
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' si le checkbox est coché ou non
        ''' </summary>
        ''' <remarks></remarks>
        Private _Checked As Boolean
        Private _ErrorImageLink As Link

        ''' <summary>
        ''' Lecture seul
        ''' </summary>
        ''' <remarks></remarks>
        Private _InputReadOnly As Boolean

        ''' <summary>
        ''' Sur le champs texte et la case à cocher
        ''' </summary>
        ''' <remarks></remarks>
        Private _Title As LocalizableHtml

        ''' <summary>
        ''' Position du texte de présentation par rapport à la texte box
        ''' </summary>
        ''' <remarks></remarks>
        Private _TitlePosition As TextPosition

        'Sur le validateur (icone + texte)
        Private _Validator As Validator

        ''' <summary>
        ''' Valeur
        ''' </summary>
        ''' <remarks></remarks>
        Private _Value As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECheckBox", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Renseigne si la case est cochée ou non
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N078"), _
        LocalizableDescAtt("_D078"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
            End Set
        End Property

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

        ''' <summary>
        ''' Renseigne si la case à coché est en 'lecture seule'
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N057"), _
        LocalizableDescAtt("_D077"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        ''' <summary>
        ''' titre associé à l'élément
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportVar(ExportVar.EnuVarType.Php), _
        Browsable(False), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(TConvLocalizableString))> _
        Public Property Title() As LocalizableHtml
            Get
                If _Title Is Nothing Then _Title = New LocalizableHtml(LocalizablePropertyDefaultValue._0007) 'Nom du champs
                Return _Title
            End Get
            Set(ByVal value As LocalizableHtml)
                _Title = value
            End Set
        End Property

        ''' <summary>
        ''' Position du titre par rapport à la case à coché
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N045"), _
        LocalizableDescAtt("_D076"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPosition
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPosition)
                _TitlePosition = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N051"), _
        LocalizableDescAtt("_D051"), _
        Editor(GetType(UITypeValidator), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As Validator
            Get
                If _Validator Is Nothing Then _Validator = New Validator(Validator.TypeValueToValidate.Bool)
                Return _Validator
            End Get
            Set(ByVal value As Validator)
                _Validator = value
            End Set
        End Property

        ''' <summary>
        ''' Champs texte associé à la case à coché
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N075"), _
        LocalizableDescAtt("_D075"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(TConvLocalizableString))> _
        Public Property Value() As LocalizableString
            Get
                If _Value Is Nothing Then _Value = New LocalizableString(LocalizablePropertyDefaultValue._0009) '"Valeur du champ")
                Return _Value
            End Get
            Set(ByVal value As LocalizableString)
                _Value = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0103 '"Case à cocher"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WECheckbox
            info.ToolBoxDescription = LocalizableOpen._0104 '"Ajouter une case à cocher"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081)) ' "Sélection des règles de validation"
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", LocalizableOpen._0082)) '"Sélection de l'image d'erreur"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("ErrorImage", LocalizableOpen._0077, LocalizableOpen._0105)) '"Image d'erreur","Zone de l'image d'erreur situé à droite de la case à cocher."
            configStylesZones.Add(New ConfigStylesZone("ErrorText", LocalizableOpen._0213, LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New ConfigStylesZone("Title", LocalizableOpen._0079, LocalizableOpen._0080)) '"Titre principal", "Zone du titre associé à l'élément."
            configStylesZones.Add(New ConfigStylesZone("CheckBox", LocalizableOpen._0115, LocalizableOpen._0116)) '"Case à cocher", "Zone de la case à cocher."

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'Champs texte et zone de saisie
            Dim inputBuilder As New StringBuilder()
            Dim labelBuilder As New StringBuilder()

            'Début d'étiquette
            writer.WriteBeginTag("label")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Title"))

            Select Case TitlePosition
                Case TextPosition.lefttop
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)

                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "top", ";"))
                    Call RenderInput(writer, inputBuilder)

                    writer.WriteEndTag("label")

                Case TextPosition.leftmiddle
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)

                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderInput(writer, inputBuilder)

                    writer.WriteEndTag("label")

                Case TextPosition.leftbottom
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)

                    Call RenderInput(writer, inputBuilder)

                    writer.WriteEndTag("label")

                Case TextPosition.top
                    labelBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    writer.WriteAttribute("style", labelBuilder.ToString)
                    writer.Write(">")
                    Call Me.RenderEditableText(writer)
                    writer.WriteEndTag("label")

                    Call RenderInput(writer, inputBuilder)

                Case TextPosition.bottom
                    writer.Write(">")
                    inputBuilder.Append(StylesUtils.ConcatCSSValue("display:", "block", ";"))
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)

                    writer.WriteEndTag("label")

                Case TextPosition.righttop
                    writer.Write(">")
                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "top", ";"))
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)

                    writer.WriteEndTag("label")

                Case TextPosition.rightmiddle
                    writer.Write(">")
                    inputBuilder.Append(StylesUtils.ConcatCSSValue("vertical-align:", "middle", ";"))
                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)

                    writer.WriteEndTag("label")

                Case TextPosition.rightbottom
                    writer.Write(">")

                    Call RenderInput(writer, inputBuilder)

                    Call Me.RenderEditableText(writer)

                    writer.WriteEndTag("label")
            End Select

            'Image et texte d'erreur
            If Validator.Rules.Count <> 0 Then
                Validator.Render(writer, MyBase.GetLink(Me.ErrorImageLink), MyBase.GetStyleZoneClass("ErrorImage"), MyBase.GetStyleZoneClass("ErrorText"), "")
            End If

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub RenderEditableText(ByRef writer As HtmlWriter)
            'MyBase.RenderBeginTextEdit(writer, "Title", False, False, False, "")
            'writer.Write(Me.Title.GetHtmlValue(Me, "Title"))
            'MyBase.RenderEndTextEdit(writer)
            writer.WriteHtmlBlockEdit(Me, "Title", False)
        End Sub

        Private Sub RenderInput(ByRef writer As HtmlWriter, ByVal builder As StringBuilder)
            writer.WriteBeginTag("input")
            writer.WriteAttribute("type", "checkbox")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("CheckBox"))
            writer.WriteAttribute("name", ID)
            writer.WriteAttribute("value", Me.Value.GetValue(MyBase.Page.Culture))

            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")
            If Me.Checked Then writer.WriteAttribute("checked", "checked") 'Else writer.WriteAttribute("checked", "unchecked")

            If Not String.IsNullOrEmpty(builder.ToString) Then writer.WriteAttribute("style", builder.ToString)

            writer.Write("/>")
        End Sub

        #End Region 'Methods

    End Class

End Namespace

