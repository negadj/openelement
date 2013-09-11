Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.Editors.Control.CtlEditListOf


Namespace Elements.Form


    <Serializable()> _
    Public Class WERadioButtonListV2
        Inherits WEFormFieldBase

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

        Private _Layout As EnuRadioButtonDisposition
        Private _ListBoxItem As List(Of WEListBoxItem)
        'Private _InputName As String
        Private _InputReadOnly As Boolean
        Private _InputTitle As LocalizableString

        Private _Validator As DataType.Validator

#Region "Proprietes"
        ' <Category("Apparence"), _
        'DisplayName("Affichage"), _
        'Description("Style général de l'affichage de la liste de choix, c'est a dire la position du texte et la disposition des élements"), _
        '  Editor(GetType(Editors.UITypeRadioListDisposition), GetType(Drawing.Design.UITypeEditor)), _
        'Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        'TypeConverter(GetType(Editors.Converter.TConvWERadioButtonListDisposition))> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N025"), _
        Ressource.localizable.LocalizableDescAtt("_D067"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        Editor(GetType(Editors.UITypeRadioDisposition), GetType(Drawing.Design.UITypeEditor))> _
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
       Ressource.localizable.LocalizableDescAtt("_D069"), _
       Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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


#End Region

#Region "Constructeur"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WERadioButtonList2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub


        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0095 '"Cases d'options"
            info.ToolBoxIco = My.Resources.WERadioButtonList
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0096 '"Ajouter une liste de case d'option (bouton radio)"
            info.ScriptVarName = "OEConfWERadioButtonList"
            info.AutoOpenProperty = "ListBoxItem"
            info.SortPropertyList.Add(New SortProperty("ListBoxItem", "DataTable.png", My.Resources.text.LocalizableOpen._0099)) '"Modifier la liste d'éléments"
            info.SortPropertyList.Add(New SortProperty("Layout", "position.png", My.Resources.text.LocalizableOpen._0100)) '"Configurer l'affichage de la liste"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", My.Resources.text.LocalizableOpen._0081)) '"Sélection des règles de validation"
            Return info

        End Function


        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RadioTitle", My.Resources.text.LocalizableOpen._0097, My.Resources.text.LocalizableOpen._0098)) '"Liste de choix","Zone des champs texte associés aux boutons de choix"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RadioButton", My.Resources.text.LocalizableOpen._0117, My.Resources.text.LocalizableOpen._0118)) ',"Bouton radio" "Zone du bouton radio."
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RadioButtonError", My.Resources.text.LocalizableOpen._0364, My.Resources.text.LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Validator", My.Resources.text.LocalizableOpen._0365, My.Resources.text.LocalizableOpen._0365)) 'Icône et texte d'erreur
            'configStylesZones.Add(New StylesManager.ConfigStylesZone("ValidatorToolTip", My.Resources.text.LocalizableOpen._0366, My.Resources.text.LocalizableOpen._0366)) 'Icône et texte d'erreur
            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)
            newObs.Add(New WEListBoxItem())
            Return newObs
        End Function
#End Region

#Region "Render"
        ''' <summary>
        ''' Render
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            Select Case Layout

                Case EnuRadioButtonDisposition.VerticalJustifyLeft, EnuRadioButtonDisposition.VerticalJustifyRight

                    writer.WriteBeginTag("table")
                    writer.WriteAttribute("style", "width:100%; border-collapse:collapse; border-spacing:0px")
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()
                    writer.Indent += 1

                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As DataType.LocalizableString = item.Name
                        Dim value As DataType.LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        writer.WriteFullBeginTag("tr")
                        writer.WriteLine()

                        writer.WriteBeginTag("td")
                        If Layout = EnuRadioButtonDisposition.VerticalJustifyLeft Then
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioTitle"))
                        Else
                            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioButton"))
                        End If
                        writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

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
                        writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

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
                        Me.StylesSkin.BaseDiv.BaseStyles.TextAlign = CssItems.CssEnum.TextAlign.left
                    Else
                        Me.StylesSkin.BaseDiv.BaseStyles.TextAlign = CssItems.CssEnum.TextAlign.right
                    End If

                    Dim i As Integer
                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As DataType.LocalizableString = item.Name
                        Dim value As DataType.LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        If Layout = EnuRadioButtonDisposition.VerticalRight Then Call RenderInput(writer, value, checked) Else RenderName(writer, name)
                        If Layout = EnuRadioButtonDisposition.VerticalRight Then RenderName(writer, name) Else Call RenderInput(writer, value, checked)

                        writer.WriteLine()
                        If i < ListBoxItem.Count Then writer.WriteBreak()
                        i += 1
                    Next

                Case EnuRadioButtonDisposition.HorizontalLeft, EnuRadioButtonDisposition.HorizontalRight
                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As DataType.LocalizableString = item.Name
                        Dim value As DataType.LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected
                        If Layout = EnuRadioButtonDisposition.HorizontalRight Then Call RenderInput(writer, value, checked) Else RenderName(writer, name)
                        If Layout = EnuRadioButtonDisposition.HorizontalRight Then RenderName(writer, name) Else Call RenderInput(writer, value, checked)
                    Next



                Case EnuRadioButtonDisposition.HorizontalTop, EnuRadioButtonDisposition.HorizontalBottom

                    For Each item As WEListBoxItem In Me.ListBoxItem
                        Dim name As DataType.LocalizableString = item.Name
                        Dim value As DataType.LocalizableString = item.Value
                        Dim checked As Boolean = item.Selected

                        writer.WriteBeginTag("span")
                        writer.WriteAttribute("style", "display:block;float:left;text-align:center;margin:0px 5px 0px 5px;")
                        writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

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
        Private Sub RenderInput(ByVal writer As Common.HtmlWriter, ByVal value As DataType.LocalizableString, ByVal checked As Boolean)
            writer.WriteBeginTag("input")
            writer.WriteAttribute("type", "radio")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioButton"))
            writer.WriteAttribute("name", Me.InputName)
            writer.WriteAttribute("value", value.GetValue(MyBase.Page.Culture))
            If Me.InputReadOnly Then writer.WriteAttribute("disabled", "disabled")
            If checked Then writer.WriteAttribute("checked", "checked")
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
        End Sub

        ''' <summary>
        ''' Render des titres (avec span pour la zone de style)
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Private Sub RenderName(ByVal writer As Common.HtmlWriter, ByVal name As DataType.LocalizableString)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RadioTitle"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(name.GetValue(Me.Page.Culture))
            writer.WriteEndTag("span")
        End Sub
#End Region


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
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

#End Region

    End Class












End Namespace