Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager
Imports System.Text
Imports WebElement.Elements.Form.Editors

Namespace Elements.Form

    <Serializable(), openElement.WebElement.Common.Attributes.OEObsolete(1, 31)> _
    Public Class WECheckBox
        Inherits ElementBase

#Region "Propriété"

        ''' <summary>
        ''' Sur le champs texte et la case à cocher
        ''' </summary>
        ''' <remarks></remarks>
        Private _Title As DataType.LocalizableHtml
        ''' <summary>
        ''' Position du texte de présentation par rapport à la texte box
        ''' </summary>
        ''' <remarks></remarks>
        Private _TitlePosition As TextPosition
        ''' <summary>
        ''' Lecture seul
        ''' </summary>
        ''' <remarks></remarks>
        Private _InputReadOnly As Boolean
        ''' <summary>
        ''' si le checkbox est coché ou non
        ''' </summary>
        ''' <remarks></remarks>
        Private _Checked As Boolean
        ''' <summary>
        ''' Valeur
        ''' </summary>
        ''' <remarks></remarks>
        Private _Value As DataType.LocalizableString

        'Sur le validateur (icone + texte)
        Private _Validator As DataType.Validator
        Private _ErrorImageLink As LinksManager.Link

        ''' <summary>
        ''' Champs texte associé à la case à coché
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N075"), _
        Ressource.localizable.LocalizableDescAtt("_D075"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
        Public Property Value() As DataType.LocalizableString
            Get
                If _Value Is Nothing Then _Value = New DataType.LocalizableString(My.Resources.text.LocalizablePropertyDefaultValue._0009) '"Valeur du champ")
                Return _Value
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _Value = value
            End Set
        End Property

        ''' <summary>
        ''' titre associé à l'élément
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
         Browsable(False), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
         TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
         Public Property Title() As DataType.LocalizableHtml
            Get
                If _Title Is Nothing Then _Title = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0007) 'Nom du champs
                Return _Title
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
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
        Ressource.localizable.LocalizableDescAtt("_D076"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property TitlePosition() As TextPosition
            Get
                Return _TitlePosition
            End Get
            Set(ByVal value As TextPosition)
                _TitlePosition = value
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
        Ressource.localizable.LocalizableDescAtt("_D077"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputReadOnly() As Boolean
            Get
                Return _InputReadOnly
            End Get
            Set(ByVal value As Boolean)
                _InputReadOnly = value
            End Set
        End Property

        ''' <summary>
        ''' Renseigne si la case est cochée ou non
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N078"), _
        Ressource.localizable.LocalizableDescAtt("_D078"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
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
        Ressource.localizable.LocalizableDescAtt("_D051"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeValidator), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Validator() As DataType.Validator
            Get
                If _Validator Is Nothing Then _Validator = New DataType.Validator(DataType.Validator.TypeValueToValidate.Bool)
                Return _Validator
            End Get
            Set(ByVal value As DataType.Validator)
                _Validator = value
            End Set
        End Property

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

#Region "Constructeur"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECheckBox", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            Me.TitlePosition = TextPosition.leftmiddle
        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0103 '"Case à cocher"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WECheckbox
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0104 '"Ajouter une case à cocher"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081)) ' "Sélection des règles de validation"
            info.SortPropertyList.Add(New SortProperty("ErrorImageLink", "imageError.png", My.Resources.text.LocalizableOpen._0082)) '"Sélection de l'image d'erreur"
            Return info

        End Function


        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorImage", My.Resources.text.LocalizableOpen._0077, My.Resources.text.LocalizableOpen._0105)) '"Image d'erreur","Zone de l'image d'erreur situé à droite de la case à cocher."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ErrorText", My.Resources.text.LocalizableOpen._0213, My.Resources.text.LocalizableOpen._0214)) ' "Texte d'erreur","Zone du texte de l'erreur situé à droite de la boîte de saisie de texte."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Title", My.Resources.text.LocalizableOpen._0079, My.Resources.text.LocalizableOpen._0080)) '"Titre principal", "Zone du titre associé à l'élément."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("CheckBox", My.Resources.text.LocalizableOpen._0115, My.Resources.text.LocalizableOpen._0116)) '"Case à cocher", "Zone de la case à cocher."

            MyBase.OnOpen(configStylesZones)

        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

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


        Private Sub RenderEditableText(ByRef writer As Common.HtmlWriter)
            'MyBase.RenderBeginTextEdit(writer, "Title", False, False, False, "")
            'writer.Write(Me.Title.GetHtmlValue(Me, "Title"))
            'MyBase.RenderEndTextEdit(writer)
            writer.WriteHtmlBlockEdit(Me, "Title", False)
        End Sub

        Private Sub RenderInput(ByRef writer As Common.HtmlWriter, ByVal builder As StringBuilder)

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


#End Region

    End Class

End Namespace



