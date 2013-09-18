Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WERadioButtonListV2
        Inherits WEFormFieldBase

        #Region "Fields"

        'Private _InputName As String
        Private _InputReadOnly As Boolean
        Private _InputTitle As LocalizableString
        Private _Layout As EnuRadioButtonDisposition
        Private _ListBoxItem As List(Of WEListBoxItem)
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WERadioButtonList2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        ''' <summary>
        ''' Disposition des textes par rapport au bouton radio
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuRadioButtonDisposition As Integer
            VerticalJustifyRight = 0
            VerticalJustifyLeft = 1
            VerticalRight = 2
            VerticalLeft = 3
            HorizontalRight = 4
            HorizontalLeft = 5
            HorizontalTop = 6
            HorizontalBottom = 7
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

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

        ' <Category("Apparence"), _
        'DisplayName("Affichage"), _
        'Description("Style général de l'affichage de la liste de choix, c'est a dire la position du texte et la disposition des élements"), _
        '  Editor(GetType(Editors.UITypeRadioListDisposition), GetType(Drawing.Design.UITypeEditor)), _
        'Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        'TypeConverter(GetType(Editors.Converter.TConvWERadioButtonListDisposition))> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N025"), _
        LocalizableDescAtt("_D067"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        Editor(GetType(UITypeRadioDisposition), GetType(UITypeEditor))> _
        Public Property Layout() As EnuRadioButtonDisposition
            Get
                Return _Layout
            End Get
            Set(ByVal value As EnuRadioButtonDisposition)
                _Layout = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N069"), _
        LocalizableDescAtt("_D069"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ListBoxItem() As List(Of WEListBoxItem)
            Get
                If _ListBoxItem Is Nothing Then
                    _ListBoxItem = New List(Of WEListBoxItem)
                    _ListBoxItem.Add(New WEListBoxItem(True))
                    _ListBoxItem.Add(New WEListBoxItem)
                End If

                Return _ListBoxItem
            End Get
            Set(ByVal value As List(Of WEListBoxItem))
                _ListBoxItem = value
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

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
            ByVal accListInfo As Dictionary(Of String, String), _
            Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            Dim r As Boolean = False
            r = r Or AddFrmFieldLSForTranslationSystem(_InputTitle, "InputTitle", "RadioButtonList", accListLS, accListInfo, onlyNonEmpty)

            If _ListBoxItem Is Nothing OrElse _ListBoxItem.Count < 1 Then Return r

            Dim cntr As Integer = 0
            For Each item In _ListBoxItem
                cntr += 1
                r = r Or AddFrmFieldLSForTranslationSystem(item.Name, "List.Row" & cntr.ToString & ".Title", "RadioButtonList", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddFrmFieldLSForTranslationSystem(item.Value, "List.Row" & cntr.ToString & ".Value", "RadioButtonList", accListLS, accListInfo, onlyNonEmpty)
            Next
            Return r
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(New WEListBoxItem())
            Return newObs
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0095 '"Cases d'options"
            info.ToolBoxIco = My.Resources.WERadioButtonList
            info.ToolBoxDescription = LocalizableOpen._0096 '"Ajouter une liste de case d'option (bouton radio)"
            info.ScriptVarName = "OEConfWERadioButtonList"
            info.AutoOpenProperty = "ListBoxItem"
            info.SortPropertyList.Add(New SortProperty("ListBoxItem", "DataTable.png", LocalizableOpen._0099)) '"Modifier la liste d'éléments"
            info.SortPropertyList.Add(New SortProperty("Layout", "position.png", LocalizableOpen._0100)) '"Configurer l'affichage de la liste"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081)) '"Sélection des règles de validation"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("RadioTitle", LocalizableOpen._0097, LocalizableOpen._0098)) '"Liste de choix","Zone des champs texte associés aux boutons de choix"
            configStylesZones.Add(New ConfigStylesZone("RadioButton", LocalizableOpen._0117, LocalizableOpen._0118)) ',"Bouton radio" "Zone du bouton radio."
            configStylesZones.Add(New ConfigStylesZone("RadioButtonError", LocalizableOpen._0364, LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365)) 'Icône et texte d'erreur
            'configStylesZones.Add(New StylesManager.ConfigStylesZone("ValidatorToolTip", My.Resources.text.LocalizableOpen._0366, My.Resources.text.LocalizableOpen._0366)) 'Icône et texte d'erreur
            MyBase.OnOpen(configStylesZones)
        End Sub

        ''' <summary>
        ''' Render
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Select Case Layout

                Case EnuRadioButtonDisposition.VerticalJustifyLeft, EnuRadioButtonDisposition.VerticalJustifyRight

                    writer.WriteBeginTag("table")
                    writer.WriteAttribute("style", "width:100%; border-collapse:collapse; border-spacing:0px")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                    writer.Indent += 1

                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As LocalizableString = item.Name
                        Dim value As LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        writer.WriteFullBeginTag("tr")
                        writer.WriteLine()

                        writer.WriteBeginTag("td")
                        If Layout = EnuRadioButtonDisposition.VerticalJustifyLeft Then
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioTitle"))
                        Else
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioButton"))
                        End If
                        writer.Write(HtmlTextWriter.TagRightChar)

                        If Layout = EnuRadioButtonDisposition.VerticalJustifyLeft Then writer.Write(name.GetValue(Me.Page.Culture)) Else Call RenderInput(writer, value, checked)
                        writer.WriteEndTag("td")
                        writer.WriteLine()

                        writer.WriteBeginTag("td")
                        If Layout = EnuRadioButtonDisposition.VerticalJustifyLeft Then
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioButton"))
                        Else
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioTitle"))
                        End If
                        If Layout = EnuRadioButtonDisposition.VerticalJustifyRight Then writer.WriteAttribute("style", "text-align:right")
                        writer.Write(HtmlTextWriter.TagRightChar)

                        If Layout = EnuRadioButtonDisposition.VerticalJustifyLeft Then Call RenderInput(writer, value, checked) Else writer.Write(name.GetValue(Me.Page.Culture))

                        writer.WriteEndTag("td")
                        writer.WriteLine()

                        writer.WriteEndTag("tr")
                        writer.WriteLine()
                    Next
                    writer.Indent -= 1
                    writer.WriteEndTag("table")
                    writer.WriteLine()

                Case EnuRadioButtonDisposition.VerticalLeft, EnuRadioButtonDisposition.VerticalRight
                    If Layout = EnuRadioButtonDisposition.VerticalRight Then
                        Me.StylesSkin.BaseDiv.BaseStyles.TextAlign = CssEnum.TextAlign.left
                    Else
                        Me.StylesSkin.BaseDiv.BaseStyles.TextAlign = CssEnum.TextAlign.right
                    End If

                    Dim i As Integer
                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As LocalizableString = item.Name
                        Dim value As LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        If Layout = EnuRadioButtonDisposition.VerticalRight Then Call RenderInput(writer, value, checked) Else RenderName(writer, name)
                        If Layout = EnuRadioButtonDisposition.VerticalRight Then RenderName(writer, name) Else Call RenderInput(writer, value, checked)

                        writer.WriteLine()
                        If i < ListBoxItem.Count Then writer.WriteBreak()
                        i += 1
                    Next

                Case EnuRadioButtonDisposition.HorizontalLeft, EnuRadioButtonDisposition.HorizontalRight
                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As LocalizableString = item.Name
                        Dim value As LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected
                        If Layout = EnuRadioButtonDisposition.HorizontalRight Then Call RenderInput(writer, value, checked) Else RenderName(writer, name)
                        If Layout = EnuRadioButtonDisposition.HorizontalRight Then RenderName(writer, name) Else Call RenderInput(writer, value, checked)
                    Next

                Case EnuRadioButtonDisposition.HorizontalTop, EnuRadioButtonDisposition.HorizontalBottom

                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As LocalizableString = item.Name
                        Dim value As LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        writer.WriteBeginTag("span")
                        writer.WriteAttribute("style", "display:block;float:left;text-align:center;margin:0px 5px 0px 5px;")
                        writer.Write(HtmlTextWriter.TagRightChar)

                        If Layout = EnuRadioButtonDisposition.HorizontalTop Then Call RenderInput(writer, value, checked) Else RenderName(writer, name)
                        writer.WriteBreak()
                        If Layout = EnuRadioButtonDisposition.HorizontalTop Then RenderName(writer, name) Else Call RenderInput(writer, value, checked)
                        writer.WriteEndTag("span")
                    Next

            End Select

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Render de l'imput
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="value"></param>
        ''' <param name="checked"></param>
        ''' <remarks></remarks>
        Private Sub RenderInput(ByVal writer As HtmlWriter, ByVal value As LocalizableString, ByVal checked As Boolean)
            writer.WriteBeginTag("input")
            writer.WriteAttribute("type", "radio")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioButton"))
            writer.WriteAttribute("name", Me.InputName)
            writer.WriteAttribute("value", value.GetValue(MyBase.Page.Culture))
            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")
            If checked Then writer.WriteAttribute("checked", "checked")
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)
        End Sub

        ''' <summary>
        ''' Render des titres (avec span pour la zone de style)
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Private Sub RenderName(ByVal writer As HtmlWriter, ByVal name As LocalizableString)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioTitle"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write(name.GetValue(Me.Page.Culture))
            writer.WriteEndTag("span")
        End Sub

        #End Region 'Methods

        #Region "Other"

        ' ''' <summary>
        ' ''' Nom de l'input dans le HTML
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        ' <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        'Ressource.localizable.LocalizableNameAtt("_N208"), _
        'Ressource.localizable.LocalizableDescAtt("_D207"), _
        'Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        'Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        'MergableProperty(False)> _
        'Public Property InputName() As String
        '     Get
        '         If String.IsNullOrEmpty(_InputName) Then _InputName = Me.ID
        '         Return _InputName
        '     End Get
        '     Set(ByVal value As String)
        '         _InputName = value
        '     End Set
        ' End Property

        #End Region 'Other

    End Class

End Namespace

