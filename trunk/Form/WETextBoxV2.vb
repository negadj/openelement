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
    Public Class WETextBoxV2
        Inherits WEFormFieldBase

        #Region "Fields"

        Private _AutoComplete As Boolean
        Private _ImputMaxLenght As Integer
        Private _InputReadOnly As Boolean
        Private _InputTitle As LocalizableString
        Private _InputValue As LocalizableString
        Private _Typ As EnuTextBoxtype
        Private _Validator As Validator

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New("WETextBox2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width

            _AutoComplete = True
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        Public Enum EnuTextBoxtype As Integer
            Text = 0
            Password = 1
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N211"), _
        LocalizableDescAtt("_D211"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AutoComplete() As Boolean
            Get
                Return _AutoComplete
            End Get
            Set(ByVal value As Boolean)
                _AutoComplete = value
            End Set
        End Property

        ''' <summary>
        ''' Max characters number (with space). Set 0 for an infinite characters
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N056"), _
        LocalizableDescAtt("_D056"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ImputMaxLenght() As Integer
            Get
                Return _ImputMaxLenght
            End Get
            Set(ByVal value As Integer)
                _ImputMaxLenght = value
            End Set
        End Property

        ''' <summary>
        ''' true if read only
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
        ''' text field value
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N054"), _
        LocalizableDescAtt("_D054"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property InputValue() As LocalizableString
            Get
                If _InputValue Is Nothing Then _InputValue = New LocalizableString()
                Return _InputValue
            End Get
            Set(ByVal value As LocalizableString)
                _InputValue = value
            End Set
        End Property

        ''' <summary>
        ''' input's type
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N210"), _
        LocalizableDescAtt("_D210"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Typ() As EnuTextBoxtype
            Get
                Return _Typ
            End Get
            Set(ByVal value As EnuTextBoxtype)
                _Typ = value
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
            r = r Or AddFrmFieldLSForTranslationSystem(_InputTitle, "InputTitle", "TextBox", accListLS, accListInfo, onlyNonEmpty)
            r = r Or AddFrmFieldLSForTranslationSystem(_InputValue, "InputValue", "TextBox", accListLS, accListInfo, onlyNonEmpty)
            Return r
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0083
            info.ToolBoxIco = My.Resources.WETextBox
            info.ToolBoxDescription = LocalizableOpen._0084
            info.ScriptVarName = "OEConfWETextBox"
            info.SortPropertyList.Add(New SortProperty("Validator", "Valid.png", LocalizableOpen._0081))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("TextBox", LocalizableOpen._0083, LocalizableOpen._0089))
            configStylesZones.Add(New ConfigStylesZone("TextBoxError", LocalizableOpen._0364, LocalizableOpen._0364))
            configStylesZones.Add(New ConfigStylesZone("Validator", LocalizableOpen._0365, LocalizableOpen._0365))
            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            ' dynamic render, or static if dyn mode not active for this element:

            DTWriteBeginTag("input", writer) '                                   writer.WriteBeginTag("input")

            DTWriteAttrStatic("name", Me.InputName) ' check if need dynamic    ' writer.WriteAttribute("name", Me.InputName)
            DTWriteAttrStatic("type", Me.Typ.ToString) '                         writer.WriteAttribute("type", Me.Typ.ToString)
            If Me.InputReadOnly Then DTWriteAttrStatic("disabled", "disabled") ' writer.WriteAttribute("disabled", "disabled")

            Dim strAutoComplete As String
            If AutoComplete Then strAutoComplete = "on" Else strAutoComplete = "off" 'on affiche pas autocomplete, si non necessaire (conformite w3c)
            If Not AutoComplete Then DTWriteAttrStatic("autocomplete", strAutoComplete)

            DTWriteAttrStatic("class", MyBase.GetStyleZoneClass("TextBox"))
            DTWriteAttrDynamic("style") ' ex to be able to hide it

            Dim inputValue As String = Me.InputValue.GetValue(MyBase.Page.Culture)
            If Not String.IsNullOrEmpty(inputValue) OrElse IsDynamic Then
                DTWriteAttrDynamic("value", , , inputValue) ' dynamic value
            End If
            If Me.ImputMaxLenght <> 0 Then DTWriteAttrStatic("maxlength", Me.ImputMaxLenght)

            DTSelfClosingTagEnd() ' writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

