Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form.Class

    <Serializable> _
    Public Class WEListBoxV2
        Inherits WEFormFieldBase

        #Region "Fields"

        Private _ActivateDynamicList As Boolean
        Private _InputReadOnly As Boolean

        'Private _InputName As String
        Private _ListBoxItem As List(Of WEListBoxItem)
        Private _Multiple As Boolean
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WEListBox2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Activates rendering of dynamic list (ex. from database)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        Ressource.localizable.LocalizableNameAtt("_N244"), _
        LocalizableDescAtt("_D244"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ActivateDynamicList() As Boolean
            Get
                Return _ActivateDynamicList
            End Get
            Set(ByVal value As Boolean)
                _ActivateDynamicList = value
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

        '''' <summary>
        '''' Nom de l'input dans le HTML
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        '<Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        'Ressource.localizable.LocalizableNameAtt("_N208"), _
        'Ressource.localizable.LocalizableDescAtt("_D207"), _
        'Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        'Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        'MergableProperty(False)> _
        'Public Property InputName() As String
        '    Get
        '        If String.IsNullOrEmpty(_InputName) Then _InputName = Me.ID
        '        Return _InputName
        '    End Get
        '    Set(ByVal value As String)
        '        _InputName = value
        '    End Set
        'End Property
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
            If _ListBoxItem Is Nothing OrElse _ListBoxItem.Count < 1 Then Return False

            Dim r As Boolean = False
            Dim cntr As Integer = 0
            For Each item In _ListBoxItem
                cntr += 1
                r = r Or AddFrmFieldLSForTranslationSystem(item.Name, "List.Row" & cntr.ToString & ".Title", "ListBox", accListLS, accListInfo, onlyNonEmpty)
                r = r Or AddFrmFieldLSForTranslationSystem(item.Value, "List.Row" & cntr.ToString & ".Value", "ListBox", accListLS, accListInfo, onlyNonEmpty)
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
            info.ToolBoxCaption = LocalizableOpen._0101 '"Liste déroulante"
            info.ToolBoxIco = My.Resources.WEListBox
            info.ToolBoxDescription = LocalizableOpen._0102 '"Liste déroulante d'élements"
            info.ScriptVarName = "OEConfWEListBox"
            info.SortPropertyList.Add(New SortProperty("ListBoxItem", "DataTable.png", LocalizableOpen._0030)) '  "Configurer"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081)) '"Sélection des règles de validation"
            info.AutoOpenProperty = "ListBoxItem"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("ListBox", LocalizableOpen._0101, LocalizableOpen._0108)) '"Liste déroulante","Zone de la liste déroulante d'élements."
            configStylesZones.Add(New ConfigStylesZone("Options", LocalizableOpen._0359, LocalizableOpen._0360)) 'Lignes de la liste
            configStylesZones.Add(New ConfigStylesZone("ListBoxError", LocalizableOpen._0364, LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365)) 'Icône et texte d'erreur
            'configStylesZones.Add(New StylesManager.ConfigStylesZone("ValidatorToolTip", My.Resources.text.LocalizableOpen._0366, My.Resources.text.LocalizableOpen._0366)) 'Icône et texte d'erreur
            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            DTWriteBeginTagWithIterators("select", writer)

            DTWriteAttribute("name", Me.InputName)

            If _Multiple Then DTWriteAttribute("multiple", "multiple")
            DTWriteAttribute("class", MyBase.GetStyleZoneClass("ListBox"))
            If Me.InputReadOnly Then DTWriteAttribute("disabled", "disabled")

            DTTagEndDeclaration()
            writer.WriteLine()

            If Not ActivateDynamicList Then
                ' Static list dfined in editor
                For Each item As WEListBoxItem In ListBoxItem
                    Dim champs As LocalizableString = item.Name
                    Dim value As LocalizableString = item.Value

                    writer.WriteBeginTag("option")
                    writer.WriteAttribute("value", value.GetValue(MyBase.Page.Culture))
                    writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Options"))
                    If item.Selected Then writer.WriteAttribute("selected", "selected")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Write(champs.GetValue(MyBase.Page.Culture))
                    writer.WriteEndTag("option")
                    writer.WriteLine()
                Next

            Else
                'Dynamic list formed by data

                ' alternative "expert" dynamic modifier, to generate all code at once with php - much more performant for big lists
                Dim fullInnerHTML = DTWriteInnerHtmlDynamic(, , )
                ' if its format is specified, don't render iterator below

                If PreRenderModeOn OrElse ( _
                   fullInnerHTML Is Nothing OrElse fullInnerHTML.FormattedItem Is Nothing OrElse _
                   fullInnerHTML.FormattedItem.IsEmpty(Page.Culture)) Then

                    ' generate options by automatic iterator:
                    DTIteratorBegin()

                    DTWriteBeginTag("option", writer, "Option")
                    DTWriteAttrDynamic("value")
                    DTWriteAttribute("class", MyBase.GetStyleZoneClass("Options"))
                    DTWriteAttrDynamic("selected")
                    DTTagEndDeclaration()
                    DTWriteInnerHtmlDynamic()
                    DTWriteEndTag("option")
                    writer.WriteLine()

                    DTIteratorEnd()

                End If

            End If

            DTWriteEndTag("select")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

