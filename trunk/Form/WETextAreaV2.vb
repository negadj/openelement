Imports System.ComponentModel
Imports System.Drawing.Design

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Form

    <Serializable> _
    Public Class WETextAreaV2
        Inherits WEFormFieldBase

        #Region "Fields"

        Private _InputReadOnly As Boolean
        Private _NoResize As Boolean
        Private _TextAreaValue As LocalizableString
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WETextArea2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Both
        End Sub

        #End Region 'Constructors

        #Region "Properties"

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

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N213"), _
        LocalizableDescAtt("_D213"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoResize() As Boolean
            Get
                Return _NoResize
            End Get
            Set(ByVal value As Boolean)
                _NoResize = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        MemoEditor, _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property TextAreaValue() As LocalizableString
            Get
                If _TextAreaValue Is Nothing Then _TextAreaValue = New LocalizableString("")
                Return _TextAreaValue
            End Get
            Set(ByVal value As LocalizableString)
                _TextAreaValue = value
            End Set
        End Property

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

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
            ByVal accListInfo As Dictionary(Of String, String), _
            Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            Dim r As Boolean = False
            r = r Or AddFrmFieldLSForTranslationSystem(_TextAreaValue, "TextAreaValue", "TextArea Multiline", accListLS, accListInfo, onlyNonEmpty)
            Return r
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0087
            info.ToolBoxIco = My.Resources.WETextArea
            info.ToolBoxDescription = LocalizableOpen._0088
            info.ScriptVarName = "OEConfWETextArea"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("TextArea", LocalizableOpen._0083, LocalizableOpen._0089)) '"Boite de saisie","Zone de saisie du texte."
            configStylesZones.Add(New ConfigStylesZone("TextAreaError", LocalizableOpen._0364, LocalizableOpen._0364)) 'Champ en erreur
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365)) 'Icône et texte d'erreur

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            DTWriteBeginTag("textarea", writer)
            DTWriteAttrStatic("class", MyBase.GetStyleZoneClass("TextArea"))
            DTWriteAttrStatic("name", InputName)

            If NoResize Then
                DTWriteAttrDynamic("style", , , "resize:none")
            Else
                DTWriteAttrDynamic("style")
            End If

            If Me.InputReadOnly Then DTWriteAttrStatic("disabled", "disabled")
            DTWriteAttrStatic("rows", "3")
            DTWriteAttrStatic("cols", "50")
            DTTagEndDeclaration()

            DTWriteInnerHtmlDynamic(, , Me.TextAreaValue.GetValue(MyBase.Page.Culture))

            DTWriteEndTag("textarea")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

